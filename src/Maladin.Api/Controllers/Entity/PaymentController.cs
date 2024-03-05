﻿using AutoMapper;

using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;
using Maladin.EFCore;
using Maladin.EFCore.Models;

using Microsoft.Extensions.Options;

namespace Maladin.Api.Controllers.Entity
{
    public class PaymentController(MaladinDbContext dbContext, IMapper mapper, ILogger<PaymentController> logger, IConfiguration configuration, IOptions<Options.EntityAuthorizeOptions<Payment, PaymentRead, PaymentCreate, PaymentUpdate>> entityAuthorizeOptions)
        : EntityControllerBase<Payment, PaymentRead, PaymentCreate, PaymentUpdate>(dbContext, mapper, logger, configuration, entityAuthorizeOptions)
    {
    }
}