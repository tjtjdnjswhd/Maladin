using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Maladin.Service.Models
{
    public class ServiceResult
    {
        public static readonly ServiceResult NoError = new(EErrorCode.NoError);
        public static readonly ServiceResult Canceled = new(EErrorCode.OperationCanceled);
        public static readonly ServiceResult UpdateError = new(EErrorCode.UpdateError);

        [SetsRequiredMembers]
        public ServiceResult(EErrorCode errorCode, string? errorArgumentName = null)
        {
            ErrorCode = errorCode;
            ErrorArgumentName = errorArgumentName;
        }

        public required string? ErrorArgumentName { get; set; }
        public required EErrorCode ErrorCode { get; init; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public static new readonly ServiceResult<T> Canceled = new(default, EErrorCode.OperationCanceled);
        public static new readonly ServiceResult<T> UpdateError = new(default, EErrorCode.UpdateError);
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
        NotExistKey,
        NotExistEmail,
        NotExistNameIdentifier,
        NotMatchPasswordHash,
        NotExistOAuthProvider,
        OAuthOnly,
        IdPasswordOnly,
        NeedEmailAuth,
        DuplicateName,
        DuplicateEmail,
        DuplicateNameIdentifier,
        DuplicateRole,
        InvalidPayment,
        DeliveryStarted,
        NotEnoughPoint,
        UpdateError,
        OperationCanceled
    }
}