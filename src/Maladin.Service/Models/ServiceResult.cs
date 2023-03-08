using System.Diagnostics.CodeAnalysis;

namespace Maladin.Service.Models
{
    public class ServiceResult
    {
        public static readonly ServiceResult NoError = new(EErrorCode.NoError);

        [SetsRequiredMembers]
        public ServiceResult(EErrorCode errorCode, string? errorArgumentName = null)
        {
            ErrorCode = errorCode;
            ErrorArgumentName = errorArgumentName;
        }

        public bool IsSuccess => ErrorCode == EErrorCode.NoError;
        public required string? ErrorArgumentName { get; set; }
        public required EErrorCode ErrorCode { get; init; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public static new ServiceResult<T> NoError(T data) => new(data, EErrorCode.NoError);

        [SetsRequiredMembers]
        public ServiceResult(T? data, EErrorCode errorCode, string? errorArgumentName = null) : base(errorCode, errorArgumentName)
        {
            Data = data;
        }

        public required T? Data { get; init; }
    }

    public enum EErrorCode
    {
        NoError,
        NotExist,
        DuplicateUnique,
        HashNotMatch,
        OAuthOnly,
        IdPasswordOnly,
        NeedEmailAuth,
        NotEnoughPoint,
        PointOverAmount,
        InvalidPayment,
        DeliveryStarted,
        FailGetPortoneAccessToken
    }
}