using Maladin.Api.Models.Dtos;
using Maladin.Api.Models.Dtos.Create.Abstractions;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Models.Dtos.Update.Abstractions;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.Diagnostics;

namespace Maladin.Api.ModelBinders
{
    public class GoodsModelBinderProvider(Dictionary<EGoodsKind, DtoTypes> dtoTypesByKind) : IModelBinderProvider
    {
        private readonly Dictionary<EGoodsKind, DtoTypes> _goodsTypesByKind = dtoTypesByKind;

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            Func<KeyValuePair<EGoodsKind, DtoTypes>, Type> elementSelector;
            if (context.Metadata.ModelType == typeof(GoodsRead))
            {
                elementSelector = pair => pair.Value.Read;
            }
            else if (context.Metadata.ModelType == typeof(GoodsCreate))
            {
                elementSelector = pair => pair.Value.Create;
            }
            else if (context.Metadata.ModelType == typeof(GoodsUpdate))
            {
                elementSelector = pair => pair.Value.Update;
            }
            else
            {
                return null;
            }

            Dictionary<EGoodsKind, (ModelMetadata modelMetadata, IModelBinder)> binders = _goodsTypesByKind.ToDictionary(t => t.Key, k =>
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(elementSelector.Invoke(k));
                return (modelMetadata, context.CreateBinder(modelMetadata));
            });

            return new GoodsModelBinder(binders);
        }
    }

    public class GoodsModelBinder(Dictionary<EGoodsKind, (ModelMetadata, IModelBinder)> binders) : IModelBinder
    {
        private readonly Dictionary<EGoodsKind, (ModelMetadata, IModelBinder)> _binders = binders;

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string kindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(IGoodsKind.Kind));
            string? kind = bindingContext.ValueProvider.GetValue(kindName).FirstValue;

            if (kind is null || !Enum.TryParse(kind, true, out EGoodsKind goodsKind))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            if (!_binders.TryGetValue(goodsKind, out (ModelMetadata modelMetadata, IModelBinder modelBinder) binder))
            {
                Debug.Assert(false);
                throw new ArgumentException($"kind '{goodsKind}' not registed");
            }

            var newBindingContext = DefaultModelBindingContext.CreateBindingContext(bindingContext.ActionContext, bindingContext.ValueProvider, binder.modelMetadata, null, bindingContext.ModelName);

            await binder.modelBinder.BindModelAsync(newBindingContext);
            bindingContext.Result = newBindingContext.Result;

            if (newBindingContext.Result.IsModelSet)
            {
                var model = newBindingContext.Result.Model;
                if (model is not null)
                {
                    bindingContext.ValidationState[model] = new ValidationStateEntry()
                    {
                        Metadata = binder.modelMetadata
                    };
                }
            }
        }
    }

    public record struct DtoTypes(Type Read, Type Create, Type Update)
    {
        public static implicit operator (Type read, Type create, Type update)(DtoTypes value)
        {
            return (value.Read, value.Create, value.Update);
        }

        public static implicit operator DtoTypes((Type read, Type create, Type update) value)
        {
            return new DtoTypes(value.read, value.create, value.update);
        }
    }
}