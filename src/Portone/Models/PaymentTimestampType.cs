namespace Portone.Models
{
    /// <summary>
    /// 조회 시점 기준
    /// <br/>&lt;p&gt;어떤 시점을 기준으로 조회를 할 것인지 선택합니다.
    /// <br/>CREATED_AT: 결제 건 생성 시점을 기준으로 조회합니다.
    /// <br/>STATUS_CHANGED_AT: 상태 승인 시점을 기준으로 조회합니다. 결제 건의 최종 상태에 따라 검색 기준이 다르게 적용됩니다.
    /// <br/>ready -&amp;gt; 결제 요청 시점 기준
    /// <br/>paid -&amp;gt; 결제 완료 시점 기준
    /// <br/>cancelled -&amp;gt; 결제 취소 시점 기준
    /// <br/>failed -&amp;gt; 결제 실패 시점 기준
    /// <br/>값을 입력하지 않으면 STATUS_CHANGED_AT 으로 자동 적용됩니다.&lt;/p&gt;
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentTimestampType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"CREATED_AT")]
        CREATED_AT = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"STATUS_CHANGED_AT")]
        STATUS_CHANGED_AT = 1,
    }
}