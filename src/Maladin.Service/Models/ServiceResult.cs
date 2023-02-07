namespace Maladin.Service.Models
{
    public class ServiceResult
    {
        public required EErrorCode ErrorCode { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public required T? Data { get; set; }
    }

    public enum EErrorCode
    {
        Success,
        NotExistId,
        NotExistEmail,
        NotExistNameIdentifier,
        NotMatchPassword,
        DuplicateName,
        DuplicateEmail,
        DuplicateNameIdentifier,
        DuplicateRole
    }
}