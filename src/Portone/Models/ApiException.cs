namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result, Exception? innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }
}