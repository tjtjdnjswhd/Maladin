using Maladin.Api.Helpers;
using Maladin.Api.Models.Dtos;
using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Create.Abstractions;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Models.Dtos.Update;
using Maladin.Api.Models.Dtos.Update.Abstractions;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Maladin.Api.ModelBinders
{
    public class GoodsModelBinderProvider : IModelBinderProvider
    {
        private static readonly Type[] ReadDtoTypes = [typeof(BookDisplayRead)];

        private static readonly Type[] CreateDtoTypes = [typeof(BookDisplayCreate)];

        private static readonly Type[] UpdateDtoTypes = [typeof(BookDisplayUpdate)];

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(GoodsRead))
            {
                return new GoodsModelBinder(EDtoAction.Read, GetBinders(context, ReadDtoTypes));
            }

            if (context.Metadata.ModelType == typeof(GoodsCreate))
            {
                return new GoodsModelBinder(EDtoAction.Create, GetBinders(context, CreateDtoTypes));
            }

            if (context.Metadata.ModelType == typeof(GoodsUpdate))
            {
                return new GoodsModelBinder(EDtoAction.Update, GetBinders(context, UpdateDtoTypes));
            }

            return null;
        }

        private static Dictionary<Type, (ModelMetadata, IModelBinder)> GetBinders(ModelBinderProviderContext context, Type[] modelTypes)
        {
            Dictionary<Type, (ModelMetadata, IModelBinder)> binders = modelTypes.ToDictionary(t => t, t =>
            {
                var modelMetaData = context.MetadataProvider.GetMetadataForType(t);
                return (modelMetaData, context.CreateBinder(modelMetaData));
            });
            return binders;
        }
    }

    public class GoodsModelBinder(EDtoAction dtoType, Dictionary<Type, (ModelMetadata, IModelBinder)> binders) : IModelBinder
    {
        private readonly EDtoAction _dtoType = dtoType;
        private readonly Dictionary<Type, (ModelMetadata, IModelBinder)> _binders = binders;

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string kindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(IDtoKind.Kind));
            string? kind = bindingContext.ValueProvider.GetValue(kindName).FirstValue;

            if (kind is null || DtoHelper.GetDtoTypeOrNull(_dtoType, kind) is not Type dtoType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            (ModelMetadata modelMetadata, IModelBinder modelBinder) = _binders[dtoType];

            var newBindingContext = DefaultModelBindingContext.CreateBindingContext(bindingContext.ActionContext, bindingContext.ValueProvider, modelMetadata, null, bindingContext.ModelName);

            await modelBinder.BindModelAsync(newBindingContext);
            bindingContext.Result = newBindingContext.Result;

            if (newBindingContext.Result.IsModelSet)
            {
                var model = newBindingContext.Result.Model;
                if (model is not null)
                {
                    bindingContext.ValidationState[model] = new ValidationStateEntry()
                    {
                        Metadata = modelMetadata
                    };
                }
            }
        }
    }
}