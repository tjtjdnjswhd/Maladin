using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

namespace Maladin.Api.Controllers.Entity
{
    public class GoodsCartController(MaladinDbContext dbContext, IMapper mapper, ILogger<GoodsCartController> logger, IConfiguration configuration, Microsoft.Extensions.Options.IOptions<Options.EntityAuthorizeOptions<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<GoodsCart, GoodsCartRead, GoodsCartCreate, GoodsCartUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}