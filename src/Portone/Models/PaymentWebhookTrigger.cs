namespace Portone.Models
{
    /// <summary>
    /// 웹훅 실행 트리거
    /// <br/>수동 웹훅 재발송, 가상계좌 입금, 비동기 취소 승인 시 발생한 웹훅일 때 필드의 값이 존재합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentWebhookTrigger
    {
        [System.Runtime.Serialization.EnumMember(Value = @"ASYNC_CANCEL_APPROVED")]
        ASYNC_CANCEL_APPROVED = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"MANUAL")]
        MANUAL = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"VIRTUAL_ACCOUNT_DEPOSIT")]
        VIRTUAL_ACCOUNT_DEPOSIT = 2,
    }
}