using Maladin.Api.Models.Dtos;
using Maladin.Api.Models.Dtos.Create;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Update;

using System.ComponentModel;

namespace Maladin.Api.Helpers
{
    public static class DtoHelper
    {
        public static Type? GetDtoTypeOrNull(EDtoAction dtoAction, string kind)
        {
            return kind.ToLower() switch
            {
                "bookdisplay" => dtoAction switch
                {
                    EDtoAction.Read => typeof(BookDisplayRead),
                    EDtoAction.Create => typeof(BookDisplayCreate),
                    EDtoAction.Update => typeof(BookDisplayUpdate),
                    _ => throw new InvalidEnumArgumentException(nameof(dtoAction), (int)dtoAction, typeof(EDtoAction))
                },
                _ => null
            };
        }
    }
}