using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Options
{
    public class EntityActionFilterOptions<TEntity, TRead, TCreate, TUpdate>
    {
        [Required]
        public required Func<HttpContext, Task<IActionResult?>> BeforeRead { get; set; }

        [Required]
        public required Func<HttpContext, TRead, Task<IActionResult?>> AfterRead { get; set; }

        [Required]
        public required Func<HttpContext, TCreate, Task<IActionResult?>> BeforeCreate { get; set; }

        [Required]
        public required Func<HttpContext, int, TUpdate, Task<IActionResult?>> BeforeUpdate { get; set; }

        [Required]
        public required Func<HttpContext, int, Task<IActionResult?>> BeforeDelete { get; set; }
    }
}