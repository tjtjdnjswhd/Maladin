using Newtonsoft.Json;

using System.Text;

namespace Portone.Client
{
    public partial class PortoneV2Client
    {
        public static Action<JsonSerializerSettings>? SerializerSettingsAction { get; set; }

        public Action<HttpClient, HttpRequestMessage, string>? PrepareRequestAction { get; set; }

        public Action<HttpClient, HttpResponseMessage>? ProcessResponseAction { get; set; }

        private partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            PrepareRequestAction?.Invoke(client, request, url);
        }

        private partial void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
        }

        private partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {
            ProcessResponseAction?.Invoke(client, response);
        }

        private static partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
            SerializerSettingsAction?.Invoke(settings);
        }
    }
}