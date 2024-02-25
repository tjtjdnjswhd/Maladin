using Microsoft.AspNetCore.Mvc;

namespace Maladin.Api.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static StatusCodeResult InternalServerError(this ControllerBase controller)
        {
            return controller.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}