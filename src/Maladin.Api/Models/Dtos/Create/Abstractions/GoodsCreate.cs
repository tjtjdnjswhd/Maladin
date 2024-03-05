﻿using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create.Abstractions
{
    public abstract class GoodsCreate : IDtoKind
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public string? Overview { get; set; }

        [Range(0, int.MaxValue)]
        public required int Price { get; set; }

        [EntityId]
        public required int CategoryId { get; set; }

        public required string Kind { get; set; }
    }
}