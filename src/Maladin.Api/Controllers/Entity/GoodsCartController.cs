using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.Api.Options;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models;

using Microsoft.Extensions.Options;

namespace Maladin.Api.Controllers.Entity
{
    public class GoodsCartController(MaladinDbContext dbContext, IMapper mapper, ILogger<GoodsCartController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>> crudOptions, IOptions<EntityAuthorizeOptions<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>(dbContext, mapper, logger, configuration, crudOptions, entityAuthorizeOptions)
    {
    }
}