using Portone.Models;

namespace Portone.Client
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PortoneV2Client
    {
        private string _baseUrl;
        private System.Net.Http.HttpClient _httpClient;
        private static System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings = new(CreateSerializerSettings, true);

        public PortoneV2Client(System.Net.Http.HttpClient httpClient)
        {
            _baseUrl = "https://api.portone.io";
            _httpClient = httpClient;
        }

        private static Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set
            {
                _baseUrl = value;
                if (!string.IsNullOrEmpty(_baseUrl) && !_baseUrl.EndsWith('/'))
                    _baseUrl += '/';
            }
        }

        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

        private static partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);

        private partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);

        private partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);

        private partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        /// <remarks>
        /// API secret 를 사용한 토큰 발급
        /// <br/>API secret 를 통해 API 인증에 사용할 토큰을 가져옵니다.
        /// </remarks>
        /// <returns>성공 응답으로 토큰을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<LoginViaApiSecretResponse> LoginViaApiSecretAsync(LoginViaApiSecretBody body)
        {
            return LoginViaApiSecretAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// API secret 를 사용한 토큰 발급
        /// <br/>API secret 를 통해 API 인증에 사용할 토큰을 가져옵니다.
        /// </remarks>
        /// <returns>성공 응답으로 토큰을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<LoginViaApiSecretResponse> LoginViaApiSecretAsync(LoginViaApiSecretBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "login/api-secret"
                urlBuilder_.Append("login/api-secret");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<LoginViaApiSecretResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 토큰 갱신
        /// <br/>리프레시 토큰을 사용해 유효기간이 연장된 새로운 토큰을 재발급합니다.
        /// </remarks>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenBody body)
        {
            return RefreshTokenAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 토큰 갱신
        /// <br/>리프레시 토큰을 사용해 유효기간이 연장된 새로운 토큰을 재발급합니다.
        /// </remarks>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "token/refresh"
                urlBuilder_.Append("token/refresh");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<RefreshTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// &lt;p&gt;가맹점의 플랫폼 정보를 조회합니다.
        /// <br/>요청된 Authorization header 를 통해 자동으로 요청자의 가맹점을 특정합니다.&lt;/p&gt;
        /// </remarks>
        /// <returns>성공 응답으로 플랫폼 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<Platform> GetPlatformAsync()
        {
            return GetPlatformAsync(System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// &lt;p&gt;가맹점의 플랫폼 정보를 조회합니다.
        /// <br/>요청된 Authorization header 를 통해 자동으로 요청자의 가맹점을 특정합니다.&lt;/p&gt;
        /// </remarks>
        /// <returns>성공 응답으로 플랫폼 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<Platform> GetPlatformAsync(System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform"
                urlBuilder_.Append("platform");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<Platform>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// &lt;p&gt;가맹점의 플랫폼 관련 정보를 업데이트합니다.
        /// <br/>요청된 Authorization header 를 통해 자동으로 요청자의 가맹점을 특정합니다.&lt;/p&gt;
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<UpdatePlatformResponse> UpdatePlatformAsync(UpdatePlatformBody body)
        {
            return UpdatePlatformAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// &lt;p&gt;가맹점의 플랫폼 관련 정보를 업데이트합니다.
        /// <br/>요청된 Authorization header 를 통해 자동으로 요청자의 가맹점을 특정합니다.&lt;/p&gt;
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<UpdatePlatformResponse> UpdatePlatformAsync(UpdatePlatformBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform"
                urlBuilder_.Append("platform");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<UpdatePlatformResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformInvalidSettlementFormulaError</code></li>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 할인 분담 정책 다건 조회 시 필요한 필터 옵션을 조회합니다.
        /// </remarks>
        /// <param name="includeHidden">숨김 조회 여부
        /// <br/>true 이면 숨김 처리된 할인 분담의 필터 옵션까지 조회하고, false 이면 숨김 처리되지 않은 할인 분담의 필터 옵션만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <param name="isArchived">보관 조회 여부
        /// <br/>true 이면 보관된 할인 분담의 필터 옵션을 조회하고, false 이면 보관되지 않은 할인 분담의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <returns>성공 응답으로 조회된 할인 분담 정책 필터 옵션을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformDiscountSharePolicyFilterOptions> GetPlatformDiscountSharePolicyFilterOptionsAsync(bool? includeHidden, bool? isArchived)
        {
            return GetPlatformDiscountSharePolicyFilterOptionsAsync(includeHidden, isArchived, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 할인 분담 정책 다건 조회 시 필요한 필터 옵션을 조회합니다.
        /// </remarks>
        /// <param name="includeHidden">숨김 조회 여부
        /// <br/>true 이면 숨김 처리된 할인 분담의 필터 옵션까지 조회하고, false 이면 숨김 처리되지 않은 할인 분담의 필터 옵션만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <param name="isArchived">보관 조회 여부
        /// <br/>true 이면 보관된 할인 분담의 필터 옵션을 조회하고, false 이면 보관되지 않은 할인 분담의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <returns>성공 응답으로 조회된 할인 분담 정책 필터 옵션을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformDiscountSharePolicyFilterOptions> GetPlatformDiscountSharePolicyFilterOptionsAsync(bool? includeHidden, bool? isArchived, System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policy-filter-options"
                urlBuilder_.Append("platform/discount-share-policy-filter-options");
                urlBuilder_.Append('?');
                if (includeHidden != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeHidden")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(includeHidden, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (isArchived != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("isArchived")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(isArchived, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformDiscountSharePolicyFilterOptions>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 여러 할인 분담을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 파트너 리스트와 페이지 정보가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetPlatformDiscountSharePoliciesResponse> GetPlatformDiscountSharePoliciesAsync(GetPlatformDiscountSharePoliciesBody body)
        {
            return GetPlatformDiscountSharePoliciesAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 여러 할인 분담을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 파트너 리스트와 페이지 정보가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetPlatformDiscountSharePoliciesResponse> GetPlatformDiscountSharePoliciesAsync(GetPlatformDiscountSharePoliciesBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policies"
                urlBuilder_.Append("platform/discount-share-policies");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetPlatformDiscountSharePoliciesResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 새로운 할인 분담을 생성합니다.
        /// </remarks>
        /// <returns>성공 응답으로 생성된 할인 분담 정책이 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreatePlatformDiscountSharePolicyResponse> CreatePlatformDiscountSharePolicyAsync(CreatePlatformDiscountSharePolicyBody body)
        {
            return CreatePlatformDiscountSharePolicyAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 새로운 할인 분담을 생성합니다.
        /// </remarks>
        /// <returns>성공 응답으로 생성된 할인 분담 정책이 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreatePlatformDiscountSharePolicyResponse> CreatePlatformDiscountSharePolicyAsync(CreatePlatformDiscountSharePolicyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policies"
                urlBuilder_.Append("platform/discount-share-policies");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreatePlatformDiscountSharePolicyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformDiscountSharePolicyAlreadyExistsError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담을 조회합니다.
        /// </remarks>
        /// <param name="id">조회할 할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 할인 분담 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformDiscountSharePolicy> GetPlatformDiscountSharePolicyAsync(string id)
        {
            return GetPlatformDiscountSharePolicyAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담을 조회합니다.
        /// </remarks>
        /// <param name="id">조회할 할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 할인 분담 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformDiscountSharePolicy> GetPlatformDiscountSharePolicyAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policies/{id}"
                urlBuilder_.Append("platform/discount-share-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformDiscountSharePolicy>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformDiscountSharePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담을 업데이트합니다.
        /// </remarks>
        /// <param name="id">업데이트할 할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 업데이트된 할인 분담 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<UpdatePlatformDiscountSharePolicyResponse> UpdatePlatformDiscountSharePolicyAsync(string id, UpdatePlatformDiscountSharePolicyBody body)
        {
            return UpdatePlatformDiscountSharePolicyAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담을 업데이트합니다.
        /// </remarks>
        /// <param name="id">업데이트할 할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 업데이트된 할인 분담 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<UpdatePlatformDiscountSharePolicyResponse> UpdatePlatformDiscountSharePolicyAsync(string id, UpdatePlatformDiscountSharePolicyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policies/{id}"
                urlBuilder_.Append("platform/discount-share-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<UpdatePlatformDiscountSharePolicyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformDiscountSharePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformArchivedDiscountSharePolicyError</code>: \ubcf4\uad00\ub41c \ud560\uc778 \ubd84\ub2f4 \uc815\ucc45\uc744 \uc5c5\ub370\uc774\ud2b8\ud558\ub824\uace0 \ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담의 예약 업데이트를 조회합니다.
        /// </remarks>
        /// <param name="id">할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 할인 분담 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformDiscountSharePolicy> GetPlatformDiscountSharePolicyScheduleAsync(string id)
        {
            return GetPlatformDiscountSharePolicyScheduleAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담의 예약 업데이트를 조회합니다.
        /// </remarks>
        /// <param name="id">할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 할인 분담 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformDiscountSharePolicy> GetPlatformDiscountSharePolicyScheduleAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policies/{id}/schedule"
                urlBuilder_.Append("platform/discount-share-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformDiscountSharePolicy>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformDiscountSharePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담에 예약 업데이트를 재설정합니다.
        /// </remarks>
        /// <param name="id">할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 할인 분담 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ReschedulePlatformDiscountSharePolicyResponse> RescheduleDiscountSharePolicyAsync(string id, ReschedulePlatformDiscountSharePolicyBody body)
        {
            return RescheduleDiscountSharePolicyAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담에 예약 업데이트를 재설정합니다.
        /// </remarks>
        /// <param name="id">할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 할인 분담 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ReschedulePlatformDiscountSharePolicyResponse> RescheduleDiscountSharePolicyAsync(string id, ReschedulePlatformDiscountSharePolicyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PUT");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policies/{id}/schedule"
                urlBuilder_.Append("platform/discount-share-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ReschedulePlatformDiscountSharePolicyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformDiscountSharePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담에 업데이트를 예약합니다.
        /// </remarks>
        /// <param name="id">할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 할인 분담 정책이 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<SchedulePlatformDiscountSharePolicyResponse> ScheduleDiscountSharePolicyAsync(string id, SchedulePlatformDiscountSharePolicyBody body)
        {
            return ScheduleDiscountSharePolicyAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담에 업데이트를 예약합니다.
        /// </remarks>
        /// <param name="id">할인 분담 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 할인 분담 정책이 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<SchedulePlatformDiscountSharePolicyResponse> ScheduleDiscountSharePolicyAsync(string id, SchedulePlatformDiscountSharePolicyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policies/{id}/schedule"
                urlBuilder_.Append("platform/discount-share-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SchedulePlatformDiscountSharePolicyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformDiscountSharePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformDiscountSharePolicyScheduleAlreadyExistsError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담의 예약 업데이트를 취소합니다.
        /// </remarks>
        /// <param name="id">할인 분담 정책 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CancelPlatformDiscountSharePolicyScheduleResponse> CancelPlatformDiscountSharePolicyScheduleAsync(string id)
        {
            return CancelPlatformDiscountSharePolicyScheduleAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 할인 분담의 예약 업데이트를 취소합니다.
        /// </remarks>
        /// <param name="id">할인 분담 정책 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CancelPlatformDiscountSharePolicyScheduleResponse> CancelPlatformDiscountSharePolicyScheduleAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("DELETE");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/discount-share-policies/{id}/schedule"
                urlBuilder_.Append("platform/discount-share-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelPlatformDiscountSharePolicyScheduleResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformDiscountSharePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 추가 수수료 정책 다건 조회 시 필요한 필터 옵션을 조회합니다.
        /// </remarks>
        /// <param name="includeHidden">숨김 조회 여부
        /// <br/>true 이면 숨김 처리된 추가 수수료 정책의 필터 옵션까지 조회하고, false 이면 숨김 처리되지 않은 추가 수수료 정책의 필터 옵션만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <param name="isArchived">보관 조회 여부
        /// <br/>true 이면 보관된 추가 수수료 정책의 필터 옵션을 조회하고, false 이면 보관되지 않은 추가 수수료 정책의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <returns>성공 응답으로 조회된 추가 수수료 정책 필터 옵션을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformAdditionalFeePolicyFilterOptions> GetPlatformAdditionalFeePolicyFilterOptionsAsync(bool? includeHidden, bool? isArchived)
        {
            return GetPlatformAdditionalFeePolicyFilterOptionsAsync(includeHidden, isArchived, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 추가 수수료 정책 다건 조회 시 필요한 필터 옵션을 조회합니다.
        /// </remarks>
        /// <param name="includeHidden">숨김 조회 여부
        /// <br/>true 이면 숨김 처리된 추가 수수료 정책의 필터 옵션까지 조회하고, false 이면 숨김 처리되지 않은 추가 수수료 정책의 필터 옵션만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <param name="isArchived">보관 조회 여부
        /// <br/>true 이면 보관된 추가 수수료 정책의 필터 옵션을 조회하고, false 이면 보관되지 않은 추가 수수료 정책의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <returns>성공 응답으로 조회된 추가 수수료 정책 필터 옵션을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformAdditionalFeePolicyFilterOptions> GetPlatformAdditionalFeePolicyFilterOptionsAsync(bool? includeHidden, bool? isArchived, System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policy-filter-options"
                urlBuilder_.Append("platform/additional-fee-policy-filter-options");
                urlBuilder_.Append('?');
                if (includeHidden != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeHidden")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(includeHidden, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (isArchived != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("isArchived")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(isArchived, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformAdditionalFeePolicyFilterOptions>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 여러 추가 수수료 정책을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 추가 수수료 정책 리스트와 페이지 정보를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetPlatformAdditionalFeePoliciesResponse> GetPlatformAdditionalFeePoliciesAsync(GetPlatformAdditionalFeePoliciesBody body)
        {
            return GetPlatformAdditionalFeePoliciesAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 여러 추가 수수료 정책을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 추가 수수료 정책 리스트와 페이지 정보를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetPlatformAdditionalFeePoliciesResponse> GetPlatformAdditionalFeePoliciesAsync(GetPlatformAdditionalFeePoliciesBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policies"
                urlBuilder_.Append("platform/additional-fee-policies");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetPlatformAdditionalFeePoliciesResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 새로운 추가 수수료 정책을 생성합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreatePlatformAdditionalFeePolicyResponse> CreatePlatformAdditionalFeePolicyAsync(CreatePlatformAdditionalFeePolicyBody body)
        {
            return CreatePlatformAdditionalFeePolicyAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 새로운 추가 수수료 정책을 생성합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreatePlatformAdditionalFeePolicyResponse> CreatePlatformAdditionalFeePolicyAsync(CreatePlatformAdditionalFeePolicyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policies"
                urlBuilder_.Append("platform/additional-fee-policies");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreatePlatformAdditionalFeePolicyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformAdditionalFeePolicyAlreadyExistsError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책을 조회합니다.
        /// </remarks>
        /// <param name="id">조회할 추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 추가 수수료 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformAdditionalFeePolicy> GetPlatformAdditionalFeePolicyAsync(string id)
        {
            return GetPlatformAdditionalFeePolicyAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책을 조회합니다.
        /// </remarks>
        /// <param name="id">조회할 추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 추가 수수료 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformAdditionalFeePolicy> GetPlatformAdditionalFeePolicyAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policies/{id}"
                urlBuilder_.Append("platform/additional-fee-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformAdditionalFeePolicy>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformAdditionalFeePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책을 업데이트합니다.
        /// </remarks>
        /// <param name="id">업데이트할 추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 업데이트된 추가 수수료 정책이 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<UpdatePlatformAdditionalFeePolicyResponse> UpdatePlatformAdditionalFeePolicyAsync(string id, UpdatePlatformAdditionalFeePolicyBody body)
        {
            return UpdatePlatformAdditionalFeePolicyAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책을 업데이트합니다.
        /// </remarks>
        /// <param name="id">업데이트할 추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 업데이트된 추가 수수료 정책이 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<UpdatePlatformAdditionalFeePolicyResponse> UpdatePlatformAdditionalFeePolicyAsync(string id, UpdatePlatformAdditionalFeePolicyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policies/{id}"
                urlBuilder_.Append("platform/additional-fee-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<UpdatePlatformAdditionalFeePolicyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformAdditionalFeePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformArchivedAdditionalFeePolicyError</code>: \ubcf4\uad00\ub41c \ucd94\uac00 \uc218\uc218\ub8cc \uc815\ucc45\uc744 \uc5c5\ub370\uc774\ud2b8\ud558\ub824\uace0 \ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책의 예약 업데이트를 조회합니다.
        /// </remarks>
        /// <param name="id">추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 추가 수수료 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformAdditionalFeePolicy> GetPlatformAdditionalFeePolicyScheduleAsync(string id)
        {
            return GetPlatformAdditionalFeePolicyScheduleAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책의 예약 업데이트를 조회합니다.
        /// </remarks>
        /// <param name="id">추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 추가 수수료 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformAdditionalFeePolicy> GetPlatformAdditionalFeePolicyScheduleAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policies/{id}/schedule"
                urlBuilder_.Append("platform/additional-fee-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformAdditionalFeePolicy>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformAdditionalFeePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <param name="id">추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 추가 수수료 정책이 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ReschedulePlatformAdditionalFeePolicyResponse> RescheduleAdditionalFeePolicyAsync(string id, ReschedulePlatformAdditionalFeePolicyBody body)
        {
            return RescheduleAdditionalFeePolicyAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="id">추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 추가 수수료 정책이 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ReschedulePlatformAdditionalFeePolicyResponse> RescheduleAdditionalFeePolicyAsync(string id, ReschedulePlatformAdditionalFeePolicyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PUT");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policies/{id}/schedule"
                urlBuilder_.Append("platform/additional-fee-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ReschedulePlatformAdditionalFeePolicyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformAdditionalFeePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책에 업데이트를 예약합니다.
        /// </remarks>
        /// <param name="id">추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 추가 수수료 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<SchedulePlatformAdditionalFeePolicyResponse> ScheduleAdditionalFeePolicyAsync(string id, SchedulePlatformAdditionalFeePolicyBody body)
        {
            return ScheduleAdditionalFeePolicyAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책에 업데이트를 예약합니다.
        /// </remarks>
        /// <param name="id">추가 수수료 정책 아이디</param>
        /// <returns>성공 응답으로 예약된 추가 수수료 정책을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<SchedulePlatformAdditionalFeePolicyResponse> ScheduleAdditionalFeePolicyAsync(string id, SchedulePlatformAdditionalFeePolicyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policies/{id}/schedule"
                urlBuilder_.Append("platform/additional-fee-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SchedulePlatformAdditionalFeePolicyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformAdditionalFeePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformAdditionalFeePolicyScheduleAlreadyExistsError</code></li>\n<li><code>PlatformArchivedAdditionalFeePolicyError</code>: \ubcf4\uad00\ub41c \ucd94\uac00 \uc218\uc218\ub8cc \uc815\ucc45\uc744 \uc5c5\ub370\uc774\ud2b8\ud558\ub824\uace0 \ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책의 예약 업데이트를 취소합니다.
        /// </remarks>
        /// <param name="id">추가 수수료 정책 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CancelPlatformAdditionalFeePolicyScheduleResponse> CancelPlatformAdditionalFeePolicyScheduleAsync(string id)
        {
            return CancelPlatformAdditionalFeePolicyScheduleAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 추가 수수료 정책의 예약 업데이트를 취소합니다.
        /// </remarks>
        /// <param name="id">추가 수수료 정책 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CancelPlatformAdditionalFeePolicyScheduleResponse> CancelPlatformAdditionalFeePolicyScheduleAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("DELETE");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/additional-fee-policies/{id}/schedule"
                urlBuilder_.Append("platform/additional-fee-policies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelPlatformAdditionalFeePolicyScheduleResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformAdditionalFeePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 파트너 다건 조회 시 필요한 필터 옵션을 조회합니다.
        /// </remarks>
        /// <param name="includeHidden">숨김 조회 여부
        /// <br/>true 이면 숨김 처리된 파트너의 필터 옵션까지 조회하고, false 이면 숨김 처리되지 않은 파트너의 필터 옵션만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <param name="isArchived">보관 조회 여부
        /// <br/>true 이면 보관된 파트너의 필터 옵션을 조회하고, false 이면 보관되지 않은 파트너의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <returns>성공 응답으로 조회된 파트너 필터 옵션을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformPartnerFilterOptions> GetPlatformPartnerFilterOptionsAsync(bool? includeHidden, bool? isArchived)
        {
            return GetPlatformPartnerFilterOptionsAsync(includeHidden, isArchived, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 파트너 다건 조회 시 필요한 필터 옵션을 조회합니다.
        /// </remarks>
        /// <param name="includeHidden">숨김 조회 여부
        /// <br/>true 이면 숨김 처리된 파트너의 필터 옵션까지 조회하고, false 이면 숨김 처리되지 않은 파트너의 필터 옵션만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <param name="isArchived">보관 조회 여부
        /// <br/>true 이면 보관된 파트너의 필터 옵션을 조회하고, false 이면 보관되지 않은 파트너의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <returns>성공 응답으로 조회된 파트너 필터 옵션을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformPartnerFilterOptions> GetPlatformPartnerFilterOptionsAsync(bool? includeHidden, bool? isArchived, System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partner-filter-options"
                urlBuilder_.Append("platform/partner-filter-options");
                urlBuilder_.Append('?');
                if (includeHidden != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeHidden")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(includeHidden, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (isArchived != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("isArchived")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(isArchived, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformPartnerFilterOptions>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 여러 파트너를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 파트너 리스트와 페이지 정보가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetPlatformPartnersResponse> GetPlatformPartnersAsync(GetPlatformPartnersBody body)
        {
            return GetPlatformPartnersAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 여러 파트너를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 파트너 리스트와 페이지 정보가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetPlatformPartnersResponse> GetPlatformPartnersAsync(GetPlatformPartnersBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners"
                urlBuilder_.Append("platform/partners");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetPlatformPartnersResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 새로운 파트너를 생성합니다.
        /// </remarks>
        /// <returns>성공 응답으로 생성된 파트너 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreatePlatformPartnerResponse> CreatePlatformPartnerAsync(CreatePlatformPartnerBody body)
        {
            return CreatePlatformPartnerAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 새로운 파트너를 생성합니다.
        /// </remarks>
        /// <returns>성공 응답으로 생성된 파트너 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreatePlatformPartnerResponse> CreatePlatformPartnerAsync(CreatePlatformPartnerBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners"
                urlBuilder_.Append("platform/partners");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreatePlatformPartnerResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerIdAlreadyExistsError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 파트너 객체를 조회합니다.
        /// </remarks>
        /// <param name="id">조회하고 싶은 파트너 아이디</param>
        /// <returns>성공 응답으로 파트너 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformPartner> GetPlatformPartnerAsync(string id)
        {
            return GetPlatformPartnerAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 파트너 객체를 조회합니다.
        /// </remarks>
        /// <param name="id">조회하고 싶은 파트너 아이디</param>
        /// <returns>성공 응답으로 파트너 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformPartner> GetPlatformPartnerAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners/{id}"
                urlBuilder_.Append("platform/partners/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformPartner>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너 정보를 업데이트합니다.
        /// </remarks>
        /// <param name="id">업데이트할 파트너 아이디</param>
        /// <returns>성공 응답으로 업데이트된 파트너 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<UpdatePlatformPartnerResponse> UpdatePlatformPartnerAsync(string id, UpdatePlatformPartnerBody body)
        {
            return UpdatePlatformPartnerAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너 정보를 업데이트합니다.
        /// </remarks>
        /// <param name="id">업데이트할 파트너 아이디</param>
        /// <returns>성공 응답으로 업데이트된 파트너 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<UpdatePlatformPartnerResponse> UpdatePlatformPartnerAsync(string id, UpdatePlatformPartnerBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners/{id}"
                urlBuilder_.Append("platform/partners/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<UpdatePlatformPartnerResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerNotFoundError</code></li>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformArchivedPartnerError</code>: \ubcf4\uad00\ub41c \ud30c\ud2b8\ub108\ub97c \uc5c5\ub370\uc774\ud2b8\ud558\ub824\uace0 \ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 새로운 파트너를 다건 생성합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreatePlatformPartnersResponse> CreatePlatformPartnersAsync(CreatePlatformPartnersBody body)
        {
            return CreatePlatformPartnersAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 새로운 파트너를 다건 생성합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreatePlatformPartnersResponse> CreatePlatformPartnersAsync(CreatePlatformPartnersBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners/batch"
                urlBuilder_.Append("platform/partners/batch");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreatePlatformPartnersResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>PlatformPartnerIdsDuplicatedError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractsNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerIdsAlreadyExistError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너의 예약 업데이트를 조회합니다.
        /// </remarks>
        /// <param name="id">파트너 아이디</param>
        /// <returns>성공 응답으로 예약된 파트너 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformPartner> GetPlatformPartnerScheduleAsync(string id)
        {
            return GetPlatformPartnerScheduleAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너의 예약 업데이트를 조회합니다.
        /// </remarks>
        /// <param name="id">파트너 아이디</param>
        /// <returns>성공 응답으로 예약된 파트너 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformPartner> GetPlatformPartnerScheduleAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners/{id}/schedule"
                urlBuilder_.Append("platform/partners/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformPartner>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너에 예약 업데이트를 재설정합니다.
        /// </remarks>
        /// <param name="id">파트너 아이디</param>
        /// <returns>성공 응답으로 예약된 파트너 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ReschedulePlatformPartnerResponse> ReschedulePartnerAsync(string id, ReschedulePlatformPartnerBody body)
        {
            return ReschedulePartnerAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너에 예약 업데이트를 재설정합니다.
        /// </remarks>
        /// <param name="id">파트너 아이디</param>
        /// <returns>성공 응답으로 예약된 파트너 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ReschedulePlatformPartnerResponse> ReschedulePartnerAsync(string id, ReschedulePlatformPartnerBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PUT");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners/{id}/schedule"
                urlBuilder_.Append("platform/partners/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ReschedulePlatformPartnerResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerNotFoundError</code></li>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너에 업데이트를 예약합니다.
        /// </remarks>
        /// <param name="id">파트너 아이디</param>
        /// <returns>성공 응답으로 예약된 파트너 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<SchedulePlatformPartnerResponse> SchedulePartnerAsync(string id, SchedulePlatformPartnerBody body)
        {
            return SchedulePartnerAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너에 업데이트를 예약합니다.
        /// </remarks>
        /// <param name="id">파트너 아이디</param>
        /// <returns>성공 응답으로 예약된 파트너 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<SchedulePlatformPartnerResponse> SchedulePartnerAsync(string id, SchedulePlatformPartnerBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners/{id}/schedule"
                urlBuilder_.Append("platform/partners/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SchedulePlatformPartnerResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerNotFoundError</code></li>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerScheduleAlreadyExistsError</code></li>\n<li><code>PlatformArchivedPartnerError</code>: \ubcf4\uad00\ub41c \ud30c\ud2b8\ub108\ub97c \uc5c5\ub370\uc774\ud2b8\ud558\ub824\uace0 \ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너의 예약 업데이트를 취소합니다.
        /// </remarks>
        /// <param name="id">파트너 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CancelPlatformPartnerScheduleResponse> CancelPlatformPartnerScheduleAsync(string id)
        {
            return CancelPlatformPartnerScheduleAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 파트너의 예약 업데이트를 취소합니다.
        /// </remarks>
        /// <param name="id">파트너 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CancelPlatformPartnerScheduleResponse> CancelPlatformPartnerScheduleAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("DELETE");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners/{id}/schedule"
                urlBuilder_.Append("platform/partners/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelPlatformPartnerScheduleResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<SchedulePlatformPartnersResponse> SchedulePlatformPartnersAsync(SchedulePlatformPartnersBody body)
        {
            return SchedulePlatformPartnersAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<SchedulePlatformPartnersResponse> SchedulePlatformPartnersAsync(SchedulePlatformPartnersBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/partners/schedule"
                urlBuilder_.Append("platform/partners/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SchedulePlatformPartnersResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerSchedulesAlreadyExistError</code></li>\n<li><code>PlatformArchivedPartnersCannotBeScheduledError</code>: \ubcf4\uad00\ub41c \ud30c\ud2b8\ub108\ub4e4\uc744 \uc608\uc57d \uc5c5\ub370\uc774\ud2b8\ud558\ub824\uace0 \ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 계약 다건 조회 시 필요한 필터 옵션을 조회합니다.
        /// </remarks>
        /// <param name="includeHidden">숨김 조회 여부
        /// <br/>true 이면 숨김 처리된 계약의 필터 옵션까지 조회하고, false 이면 숨김 처리되지 않은 계약의 필터 옵션만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <param name="isArchived">보관 조회 여부
        /// <br/>true 이면 보관된 계약의 필터 옵션을 조회하고, false 이면 보관되지 않은 계약의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <returns>성공 응답으로 조회된 계약 필터 옵션을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformContractFilterOptions> GetPlatformContractFilterOptionsAsync(bool? includeHidden, bool? isArchived)
        {
            return GetPlatformContractFilterOptionsAsync(includeHidden, isArchived, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 계약 다건 조회 시 필요한 필터 옵션을 조회합니다.
        /// </remarks>
        /// <param name="includeHidden">숨김 조회 여부
        /// <br/>true 이면 숨김 처리된 계약의 필터 옵션까지 조회하고, false 이면 숨김 처리되지 않은 계약의 필터 옵션만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <param name="isArchived">보관 조회 여부
        /// <br/>true 이면 보관된 계약의 필터 옵션을 조회하고, false 이면 보관되지 않은 계약의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.</param>
        /// <returns>성공 응답으로 조회된 계약 필터 옵션을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformContractFilterOptions> GetPlatformContractFilterOptionsAsync(bool? includeHidden, bool? isArchived, System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contract-filter-options"
                urlBuilder_.Append("platform/contract-filter-options");
                urlBuilder_.Append('?');
                if (includeHidden != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeHidden")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(includeHidden, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (isArchived != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("isArchived")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(isArchived, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformContractFilterOptions>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 여러 계약을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 계약 리스트와 페이지 정보를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetPlatformContractsResponse> GetPlatformContractsAsync(GetPlatformContractsBody body)
        {
            return GetPlatformContractsAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 여러 계약을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 계약 리스트와 페이지 정보를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetPlatformContractsResponse> GetPlatformContractsAsync(GetPlatformContractsBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contracts"
                urlBuilder_.Append("platform/contracts");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetPlatformContractsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 새로운 계약을 생성합니다.
        /// </remarks>
        /// <returns>성공 응답으로 생성된 계약 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreatePlatformContractResponse> CreatePlatformContractAsync(CreatePlatformContractBody body)
        {
            return CreatePlatformContractAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 새로운 계약을 생성합니다.
        /// </remarks>
        /// <returns>성공 응답으로 생성된 계약 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreatePlatformContractResponse> CreatePlatformContractAsync(CreatePlatformContractBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contracts"
                urlBuilder_.Append("platform/contracts");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreatePlatformContractResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractAlreadyExistsError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <param name="id">조회할 계약 아이디</param>
        /// <returns>성공 응답으로 계약 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformContract> GetPlatformContractAsync(string id)
        {
            return GetPlatformContractAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="id">조회할 계약 아이디</param>
        /// <returns>성공 응답으로 계약 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformContract> GetPlatformContractAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contracts/{id}"
                urlBuilder_.Append("platform/contracts/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformContract>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 계약을 업데이트합니다.
        /// </remarks>
        /// <param name="id">업데이트할 계약 아이디</param>
        /// <returns>성공 응답으로 업데이트된 계약 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<UpdatePlatformContractResponse> UpdatePlatformContractAsync(string id, UpdatePlatformContractBody body)
        {
            return UpdatePlatformContractAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 계약을 업데이트합니다.
        /// </remarks>
        /// <param name="id">업데이트할 계약 아이디</param>
        /// <returns>성공 응답으로 업데이트된 계약 객체가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<UpdatePlatformContractResponse> UpdatePlatformContractAsync(string id, UpdatePlatformContractBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contracts/{id}"
                urlBuilder_.Append("platform/contracts/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<UpdatePlatformContractResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformArchivedContractError</code>: \ubcf4\uad00\ub41c \uacc4\uc57d\uc744 \uc5c5\ub370\uc774\ud2b8\ud558\ub824\uace0 \ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 계약의 예약 업데이트를 조회합니다.
        /// </remarks>
        /// <param name="id">계약 아이디</param>
        /// <returns>성공 응답으로 예약된 계약 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformContract> GetPlatformContractScheduleAsync(string id)
        {
            return GetPlatformContractScheduleAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 계약의 예약 업데이트를 조회합니다.
        /// </remarks>
        /// <param name="id">계약 아이디</param>
        /// <returns>성공 응답으로 예약된 계약 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformContract> GetPlatformContractScheduleAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contracts/{id}/schedule"
                urlBuilder_.Append("platform/contracts/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformContract>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 계약에 예약 업데이트를 재설정합니다.
        /// </remarks>
        /// <param name="id">계약 아이디</param>
        /// <returns>성공 응답으로 예약된 계약 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ReschedulePlatformContractResponse> RescheduleContractAsync(string id, ReschedulePlatformContractBody body)
        {
            return RescheduleContractAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 계약에 예약 업데이트를 재설정합니다.
        /// </remarks>
        /// <param name="id">계약 아이디</param>
        /// <returns>성공 응답으로 예약된 계약 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ReschedulePlatformContractResponse> RescheduleContractAsync(string id, ReschedulePlatformContractBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PUT");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contracts/{id}/schedule"
                urlBuilder_.Append("platform/contracts/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ReschedulePlatformContractResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 계약에 업데이트를 예약합니다.
        /// </remarks>
        /// <param name="id">계약 아이디</param>
        /// <returns>성공 응답으로 예약된 계약 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<SchedulePlatformContractResponse> ScheduleContractAsync(string id, SchedulePlatformContractBody body)
        {
            return ScheduleContractAsync(id, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 계약에 업데이트를 예약합니다.
        /// </remarks>
        /// <param name="id">계약 아이디</param>
        /// <returns>성공 응답으로 예약된 계약 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<SchedulePlatformContractResponse> ScheduleContractAsync(string id, SchedulePlatformContractBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contracts/{id}/schedule"
                urlBuilder_.Append("platform/contracts/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SchedulePlatformContractResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractScheduleAlreadyExistsError</code></li>\n<li><code>PlatformArchivedContractError</code>: \ubcf4\uad00\ub41c \uacc4\uc57d\uc744 \uc5c5\ub370\uc774\ud2b8\ud558\ub824\uace0 \ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 주어진 아이디에 대응되는 계약의 예약 업데이트를 취소합니다.
        /// </remarks>
        /// <param name="id">계약 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CancelPlatformContractScheduleResponse> CancelPlatformContractScheduleAsync(string id)
        {
            return CancelPlatformContractScheduleAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 주어진 아이디에 대응되는 계약의 예약 업데이트를 취소합니다.
        /// </remarks>
        /// <param name="id">계약 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CancelPlatformContractScheduleResponse> CancelPlatformContractScheduleAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("DELETE");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/contracts/{id}/schedule"
                urlBuilder_.Append("platform/contracts/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelPlatformContractScheduleResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformContractNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PlatformManualTransfer> GetPlatformTransferAsync(string id)
        {
            return GetPlatformTransferAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PlatformManualTransfer> GetPlatformTransferAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/transfers/{id}"
                urlBuilder_.Append("platform/transfers/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlatformManualTransfer>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformTransferNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <param name="id">정산건 아이디</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<DeletePlatformTransferResponse> DeletePlatformTransferAsync(string id)
        {
            return DeletePlatformTransferAsync(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="id">정산건 아이디</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<DeletePlatformTransferResponse> DeletePlatformTransferAsync(string id, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(id);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("DELETE");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/transfers/{id}"
                urlBuilder_.Append("platform/transfers/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<DeletePlatformTransferResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformCancelOrderTransfersExistsError</code></li>\n<li><code>PlatformTransferNonDeletableStatusError</code></li>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformTransferNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreateOrderTransferResponse> CreatePlatformOrderTransferAsync(CreatePlatformOrderTransferBody body)
        {
            return CreatePlatformOrderTransferAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreateOrderTransferResponse> CreatePlatformOrderTransferAsync(CreatePlatformOrderTransferBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/transfers/order"
                urlBuilder_.Append("platform/transfers/order");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreateOrderTransferResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>PlatformDiscountExceededOrderAmountError</code></li>\n<li><code>PlatformProductIdDuplicatedError</code></li>\n<li><code>PlatformSettlementPaymentAmountExceededPortOnePaymentError</code></li>\n<li><code>PlatformContractPlatformFixedAmountFeeCurrencyAndSettlementCurrencyMismatchedError</code></li>\n<li><code>PlatformAdditionalFixedAmountFeeCurrencyAndSettlementCurrencyMismatchedError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerNotFoundError</code></li>\n<li><code>PlatformContractNotFoundError</code></li>\n<li><code>PlatformAdditionalFeePoliciesNotFoundError</code></li>\n<li><code>PlatformDiscountSharePoliciesNotFoundError</code></li>\n<li><code>PlatformPaymentNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformTransferAlreadyExistsError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreateOrderCancelTransferResponse> CreatePlatformOrderCancelTransferAsync(CreatePlatformOrderCancelTransferBody body)
        {
            return CreatePlatformOrderCancelTransferAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreateOrderCancelTransferResponse> CreatePlatformOrderCancelTransferAsync(CreatePlatformOrderCancelTransferBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/transfers/order-cancel"
                urlBuilder_.Append("platform/transfers/order-cancel");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreateOrderCancelTransferResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>PlatformOrderDetailMismatchedError</code></li>\n<li><code>PlatformDiscountSharePolicyIdDuplicatedError</code></li>\n<li><code>PlatformCancellableAmountExceededError</code></li>\n<li><code>PlatformCancellableDiscountAmountExceededError</code></li>\n<li><code>PlatformProductIdDuplicatedError</code></li>\n<li><code>PlatformCancellableProductQuantityExceededError</code></li>\n<li><code>PlatformOrderTransferAlreadyCancelledError</code></li>\n<li><code>PlatformDiscountCancelExceededOrderCancelAmountError</code></li>\n<li><code>PlatformCancellationAndPaymentTypeMismatchedError</code></li>\n<li><code>PlatformSettlementCancelAmountExceededPortOneCancelError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformTransferNotFoundError</code></li>\n<li><code>PlatformCancellationNotFoundError</code></li>\n<li><code>PlatformPaymentNotFoundError</code></li>\n<li><code>PlatformProductIdNotFoundError</code></li>\n<li><code>PlatformTransferDiscountSharePolicyNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformTransferAlreadyExistsError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreateManualTransferResponse> CreatePlatformManualTransferAsync(CreatePlatformManualTransferBody body)
        {
            return CreatePlatformManualTransferAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreateManualTransferResponse> CreatePlatformManualTransferAsync(CreatePlatformManualTransferBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "platform/transfers/manual"
                urlBuilder_.Append("platform/transfers/manual");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreateManualTransferResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>PlatformUnavailableSettlementDateError</code>: \uc0ac\uc6a9\ud560 \uc218 \uc5c6\ub294 \uc815\uc0b0\uc77c\uc774 \uc694\uccad\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformNotEnabledError</code>: \ud50c\ub7ab\ud3fc \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc544 \uc694\uccad\uc744 \ucc98\ub9ac\ud560 \uc218 \uc5c6\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApprovePlatformPartnerError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApprovePlatformPartnerError>("<ul>\n<li><code>PlatformPartnerNotFoundError</code></li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 본인인증 단건 조회
        /// <br/>주어진 아이디에 대응되는 본인인증 내역을 조회합니다.
        /// </remarks>
        /// <param name="identityVerificationId">조회할 본인인증 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답으로 본인 인증 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<FailedIdentityVerification> GetIdentityVerificationAsync(string identityVerificationId, string storeId)
        {
            return GetIdentityVerificationAsync(identityVerificationId, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 본인인증 단건 조회
        /// <br/>주어진 아이디에 대응되는 본인인증 내역을 조회합니다.
        /// </remarks>
        /// <param name="identityVerificationId">조회할 본인인증 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답으로 본인 인증 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<FailedIdentityVerification> GetIdentityVerificationAsync(string identityVerificationId, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(identityVerificationId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "identity-verifications/{identityVerificationId}"
                urlBuilder_.Append("identity-verifications/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(identityVerificationId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<FailedIdentityVerification>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>IdentityVerificationNotFoundError</code>: \uc694\uccad\ub41c \ubcf8\uc778\uc778\uc99d \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 본인인증 요청 전송
        /// <br/>SMS 또는 APP 방식을 이용하여 본인인증 요청을 전송합니다.
        /// </remarks>
        /// <param name="identityVerificationId">본인인증 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<SendIdentityVerificationResponse> SendIdentityVerificationAsync(string identityVerificationId, SendIdentityVerificationBody body)
        {
            return SendIdentityVerificationAsync(identityVerificationId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 본인인증 요청 전송
        /// <br/>SMS 또는 APP 방식을 이용하여 본인인증 요청을 전송합니다.
        /// </remarks>
        /// <param name="identityVerificationId">본인인증 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<SendIdentityVerificationResponse> SendIdentityVerificationAsync(string identityVerificationId, SendIdentityVerificationBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(identityVerificationId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "identity-verifications/{identityVerificationId}/send"
                urlBuilder_.Append("identity-verifications/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(identityVerificationId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/send");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SendIdentityVerificationResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>IdentityVerificationNotFoundError</code>: \uc694\uccad\ub41c \ubcf8\uc778\uc778\uc99d \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n<li><code>ChannelNotFoundError</code>: \uc694\uccad\ub41c \ucc44\ub110\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>IdentityVerificationAlreadyVerifiedError</code>: \ubcf8\uc778\uc778\uc99d \uac74\uc774 \uc774\ubbf8 \uc778\uc99d \uc644\ub8cc\ub41c \uc0c1\ud0dc\uc778 \uacbd\uc6b0</li>\n<li><code>IdentityVerificationAlreadySentError</code>: \ubcf8\uc778\uc778\uc99d \uac74\uc774 \uc774\ubbf8 API\ub85c \uc694\uccad\ub41c \uc0c1\ud0dc\uc778 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 본인인증 확인
        /// <br/>요청된 본인인증에 대한 확인을 진행합니다.
        /// </remarks>
        /// <param name="identityVerificationId">본인인증 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ConfirmIdentityVerificationResponse> ConfirmIdentityVerificationAsync(string identityVerificationId, ConfirmIdentityVerificationBody body)
        {
            return ConfirmIdentityVerificationAsync(identityVerificationId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 본인인증 확인
        /// <br/>요청된 본인인증에 대한 확인을 진행합니다.
        /// </remarks>
        /// <param name="identityVerificationId">본인인증 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ConfirmIdentityVerificationResponse> ConfirmIdentityVerificationAsync(string identityVerificationId, ConfirmIdentityVerificationBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(identityVerificationId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "identity-verifications/{identityVerificationId}/confirm"
                urlBuilder_.Append("identity-verifications/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(identityVerificationId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/confirm");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ConfirmIdentityVerificationResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>IdentityVerificationNotFoundError</code>: \uc694\uccad\ub41c \ubcf8\uc778\uc778\uc99d \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n<li><code>IdentityVerificationNotSentError</code>: \ubcf8\uc778\uc778\uc99d \uac74\uc774 API\ub85c \uc694\uccad\ub41c \uc0c1\ud0dc\uac00 \uc544\ub2cc \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>IdentityVerificationAlreadyVerifiedError</code>: \ubcf8\uc778\uc778\uc99d \uac74\uc774 \uc774\ubbf8 \uc778\uc99d \uc644\ub8cc\ub41c \uc0c1\ud0dc\uc778 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// SMS 본인인증 요청 재전송
        /// <br/>SMS 본인인증 요청을 재전송합니다.
        /// </remarks>
        /// <param name="identityVerificationId">본인인증 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ResendIdentityVerificationResponse> ResendIdentityVerificationAsync(string identityVerificationId, string storeId)
        {
            return ResendIdentityVerificationAsync(identityVerificationId, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// SMS 본인인증 요청 재전송
        /// <br/>SMS 본인인증 요청을 재전송합니다.
        /// </remarks>
        /// <param name="identityVerificationId">본인인증 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ResendIdentityVerificationResponse> ResendIdentityVerificationAsync(string identityVerificationId, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(identityVerificationId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "identity-verifications/{identityVerificationId}/resend"
                urlBuilder_.Append("identity-verifications/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(identityVerificationId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/resend");
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ResendIdentityVerificationResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>IdentityVerificationNotFoundError</code>: \uc694\uccad\ub41c \ubcf8\uc778\uc778\uc99d \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n<li><code>IdentityVerificationNotSentError</code>: \ubcf8\uc778\uc778\uc99d \uac74\uc774 API\ub85c \uc694\uccad\ub41c \uc0c1\ud0dc\uac00 \uc544\ub2cc \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>IdentityVerificationAlreadyVerifiedError</code>: \ubcf8\uc778\uc778\uc99d \uac74\uc774 \uc774\ubbf8 \uc778\uc99d \uc644\ub8cc\ub41c \uc0c1\ud0dc\uc778 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 정보 사전 등록
        /// <br/>결제 정보를 사전 등록합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PreRegisterPaymentResponse> PreRegisterPaymentAsync(string paymentId, PreRegisterPaymentBody body)
        {
            return PreRegisterPaymentAsync(paymentId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 정보 사전 등록
        /// <br/>결제 정보를 사전 등록합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PreRegisterPaymentResponse> PreRegisterPaymentAsync(string paymentId, PreRegisterPaymentBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/pre-register"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/pre-register");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PreRegisterPaymentResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>AlreadyPaidError</code>: \uacb0\uc81c\uac00 \uc774\ubbf8 \uc644\ub8cc\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 빌링키 단건 조회
        /// <br/>주어진 빌링키에 대응되는 빌링키 정보를 조회합니다.
        /// </remarks>
        /// <param name="billingKey">조회할 빌링키</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답으로 빌링키 정보를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<BillingKeyInfo> GetBillingKeyInfoAsync(string billingKey, string storeId)
        {
            return GetBillingKeyInfoAsync(billingKey, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 빌링키 단건 조회
        /// <br/>주어진 빌링키에 대응되는 빌링키 정보를 조회합니다.
        /// </remarks>
        /// <param name="billingKey">조회할 빌링키</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답으로 빌링키 정보를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<BillingKeyInfo> GetBillingKeyInfoAsync(string billingKey, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(billingKey);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "billing-keys/{billingKey}"
                urlBuilder_.Append("billing-keys/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(billingKey, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyInfo>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyNotFoundError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyNotFoundError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyNotFoundError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyNotFoundError>("<ul>\n<li><code>BillingKeyNotFoundError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 빌링키 삭제
        /// <br/>빌링키를 삭제합니다.
        /// </remarks>
        /// <param name="billingKey">삭제할 빌링키</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<DeleteBillingKeyResponse> DeleteBillingKeyAsync(string billingKey, string storeId)
        {
            return DeleteBillingKeyAsync(billingKey, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 빌링키 삭제
        /// <br/>빌링키를 삭제합니다.
        /// </remarks>
        /// <param name="billingKey">삭제할 빌링키</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<DeleteBillingKeyResponse> DeleteBillingKeyAsync(string billingKey, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(billingKey);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("DELETE");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "billing-keys/{billingKey}"
                urlBuilder_.Append("billing-keys/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(billingKey, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<DeleteBillingKeyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>BillingKeyNotIssuedError</code></li>\n<li><code>BillingKeyNotFoundError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>BillingKeyAlreadyDeletedError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc774\ubbf8 \uc0ad\uc81c\ub41c \uacbd\uc6b0</li>\n<li><code>PaymentScheduleAlreadyExistsError</code>: \uacb0\uc81c \uc608\uc57d\uac74\uc774 \uc774\ubbf8 \uc874\uc7ac\ud558\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 현금 영수증 단건 조회
        /// <br/>주어진 결제 아이디에 대응되는 현금 영수증 내역을 조회합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답으로 현금 영수증 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CancelledCashReceipt> GetCashReceiptByPaymentIdAsync(string paymentId, string storeId)
        {
            return GetCashReceiptByPaymentIdAsync(paymentId, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 현금 영수증 단건 조회
        /// <br/>주어진 결제 아이디에 대응되는 현금 영수증 내역을 조회합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답으로 현금 영수증 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CancelledCashReceipt> GetCashReceiptByPaymentIdAsync(string paymentId, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/cash-receipt"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/cash-receipt");
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelledCashReceipt>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>CashReceiptNotFoundError</code>: \ud604\uae08\uc601\uc218\uc99d\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 단건 조회
        /// <br/>주어진 아이디에 대응되는 결제 건을 조회합니다.
        /// </remarks>
        /// <param name="paymentId">조회할 결제 아이디</param>
        /// <param name="storeId">상점 아이디</param>
        /// <returns>성공 응답으로 결제 건 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CancelledPayment> GetPaymentAsync(string paymentId, string storeId)
        {
            return GetPaymentAsync(paymentId, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 단건 조회
        /// <br/>주어진 아이디에 대응되는 결제 건을 조회합니다.
        /// </remarks>
        /// <param name="paymentId">조회할 결제 아이디</param>
        /// <param name="storeId">상점 아이디</param>
        /// <returns>성공 응답으로 결제 건 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CancelledPayment> GetPaymentAsync(string paymentId, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelledPayment>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentNotFoundError</code>: \uacb0\uc81c \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 다건 조회(페이지 기반)
        /// <br/>주어진 조건에 맞는 결제 건들을 페이지 기반으로 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 결제 건 리스트와 페이지 정보가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetPaymentsResponse> GetPaymentsAsync(GetPaymentsBody body)
        {
            return GetPaymentsAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 다건 조회(페이지 기반)
        /// <br/>주어진 조건에 맞는 결제 건들을 페이지 기반으로 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 결제 건 리스트와 페이지 정보가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetPaymentsResponse> GetPaymentsAsync(GetPaymentsBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments"
                urlBuilder_.Append("payments");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetPaymentsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 대용량 다건 조회(커서 기반)
        /// <br/>기간 내 모든 결제 건을 커서 기반으로 조회합니다. 결제 건의 생성일시를 기준으로 주어진 기간 내 존재하는 모든 결제 건이 조회됩니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 결제 건 리스트와 커서 정보가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetAllPaymentsByCursorResponse> GetAllPaymentsByCursorAsync(GetAllPaymentsByCursorBody body)
        {
            return GetAllPaymentsByCursorAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 대용량 다건 조회(커서 기반)
        /// <br/>기간 내 모든 결제 건을 커서 기반으로 조회합니다. 결제 건의 생성일시를 기준으로 주어진 기간 내 존재하는 모든 결제 건이 조회됩니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 결제 건 리스트와 커서 정보가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetAllPaymentsByCursorResponse> GetAllPaymentsByCursorAsync(GetAllPaymentsByCursorBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments-by-cursor"
                urlBuilder_.Append("payments-by-cursor");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetAllPaymentsByCursorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 예약 단건 조회
        /// <br/>주어진 아이디에 대응되는 결제 예약 건을 조회합니다.
        /// </remarks>
        /// <param name="paymentScheduleId">조회할 결제 예약 건 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답으로 결제 예약 건 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<FailedPaymentSchedule> GetPaymentScheduleAsync(string paymentScheduleId, string storeId)
        {
            return GetPaymentScheduleAsync(paymentScheduleId, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 예약 단건 조회
        /// <br/>주어진 아이디에 대응되는 결제 예약 건을 조회합니다.
        /// </remarks>
        /// <param name="paymentScheduleId">조회할 결제 예약 건 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답으로 결제 예약 건 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<FailedPaymentSchedule> GetPaymentScheduleAsync(string paymentScheduleId, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentScheduleId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payment-schedules/{paymentScheduleId}"
                urlBuilder_.Append("payment-schedules/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentScheduleId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<FailedPaymentSchedule>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentScheduleNotFoundError</code>: \uacb0\uc81c \uc608\uc57d\uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 예약 다건 조회
        /// <br/>주어진 조건에 맞는 결제 예약 건들을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 예약 결제 건 리스트가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetPaymentSchedulesResponse> GetPaymentSchedulesAsync(GetPaymentSchedulesBody body)
        {
            return GetPaymentSchedulesAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 예약 다건 조회
        /// <br/>주어진 조건에 맞는 결제 예약 건들을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 조회된 예약 결제 건 리스트가 반환됩니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetPaymentSchedulesResponse> GetPaymentSchedulesAsync(GetPaymentSchedulesBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payment-schedules"
                urlBuilder_.Append("payment-schedules");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetPaymentSchedulesResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 예약 취소
        /// <br/>결제 예약 건을 취소합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<RevokePaymentScheduleResponse> RevokePaymentScheduleAsync(RevokePaymentScheduleBody body)
        {
            return RevokePaymentScheduleAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 예약 취소
        /// <br/>결제 예약 건을 취소합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<RevokePaymentScheduleResponse> RevokePaymentScheduleAsync(RevokePaymentScheduleBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("DELETE");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payment-schedules"
                urlBuilder_.Append("payment-schedules");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<RevokePaymentScheduleResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>PaymentScheduleNotFoundError</code>: \uacb0\uc81c \uc608\uc57d\uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n<li><code>BillingKeyNotFoundError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BillingKeyAlreadyDeletedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BillingKeyAlreadyDeletedError>("<ul>\n<li><code>PaymentScheduleAlreadyProcessedError</code>: \uacb0\uc81c \uc608\uc57d\uac74\uc774 \uc774\ubbf8 \ucc98\ub9ac\ub41c \uacbd\uc6b0</li>\n<li><code>PaymentScheduleAlreadyRevokedError</code>: \uacb0\uc81c \uc608\uc57d\uac74\uc774 \uc774\ubbf8 \ucde8\uc18c\ub41c \uacbd\uc6b0</li>\n<li><code>BillingKeyAlreadyDeletedError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc774\ubbf8 \uc0ad\uc81c\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 예약
        /// <br/>결제를 예약합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CreatePaymentScheduleResponse> CreatePaymentScheduleAsync(string paymentId, CreatePaymentScheduleBody body)
        {
            return CreatePaymentScheduleAsync(paymentId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 예약
        /// <br/>결제를 예약합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CreatePaymentScheduleResponse> CreatePaymentScheduleAsync(string paymentId, CreatePaymentScheduleBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/schedule"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/schedule");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CreatePaymentScheduleResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidOrWaitingError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidOrWaitingError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidOrWaitingError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidOrWaitingError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidOrWaitingError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidOrWaitingError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidOrWaitingError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidOrWaitingError>("<ul>\n<li><code>BillingKeyNotFoundError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidOrWaitingError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidOrWaitingError>("<ul>\n<li><code>AlreadyPaidOrWaitingError</code>: \uacb0\uc81c\uac00 \uc774\ubbf8 \uc644\ub8cc\ub418\uc5c8\uac70\ub098 \ub300\uae30\uc911\uc778 \uacbd\uc6b0</li>\n<li><code>SumOfPartsExceedsTotalAmountError</code>: \uba74\uc138 \uae08\uc561 \ub4f1 \ud558\uc704 \ud56d\ubaa9\ub4e4\uc758 \ud569\uc774 \uc804\uccb4 \uacb0\uc81c \uae08\uc561\uc744 \ucd08\uacfc\ud55c \uacbd\uc6b0</li>\n<li><code>BillingKeyAlreadyDeletedError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc774\ubbf8 \uc0ad\uc81c\ub41c \uacbd\uc6b0</li>\n<li><code>PaymentScheduleAlreadyExistsError</code>: \uacb0\uc81c \uc608\uc57d\uac74\uc774 \uc774\ubbf8 \uc874\uc7ac\ud558\ub294 \uacbd\uc6b0</li>\n<li><code>PastPaymentScheduleError</code>: \uacb0\uc81c \uc608\uc57d \uc2dc\uc810\uc774 \uacfc\uac70\ub85c \uc9c0\uc815\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 결제 취소
        /// <br/>결제 취소를 요청합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CancelPaymentResponse> CancelPaymentAsync(string paymentId, CancelPaymentBody body)
        {
            return CancelPaymentAsync(paymentId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 결제 취소
        /// <br/>결제 취소를 요청합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CancelPaymentResponse> CancelPaymentAsync(string paymentId, CancelPaymentBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/cancel"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/cancel");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelPaymentResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelAmountExceedsCancellableAmountError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelAmountExceedsCancellableAmountError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelAmountExceedsCancellableAmountError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelAmountExceedsCancellableAmountError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelAmountExceedsCancellableAmountError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelAmountExceedsCancellableAmountError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelAmountExceedsCancellableAmountError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelAmountExceedsCancellableAmountError>("<ul>\n<li><code>PaymentNotFoundError</code>: \uacb0\uc81c \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelAmountExceedsCancellableAmountError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelAmountExceedsCancellableAmountError>("<ul>\n<li><code>PaymentNotPaidError</code>: \uacb0\uc81c\uac00 \uc644\ub8cc\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>PaymentAlreadyCancelledError</code>: \uacb0\uc81c\uac00 \uc774\ubbf8 \ucde8\uc18c\ub41c \uacbd\uc6b0</li>\n<li><code>CancellableAmountConsistencyBrokenError</code>: \ucde8\uc18c \uac00\ub2a5 \uc794\uc561 \uac80\uc99d\uc5d0 \uc2e4\ud328\ud55c \uacbd\uc6b0</li>\n<li><code>CancelAmountExceedsCancellableAmountError</code>: \uacb0\uc81c \ucde8\uc18c \uae08\uc561\uc774 \ucde8\uc18c \uac00\ub2a5 \uae08\uc561\uc744 \ucd08\uacfc\ud55c \uacbd\uc6b0</li>\n<li><code>SumOfPartsExceedsCancelAmountError</code>: \uba74\uc138 \uae08\uc561 \ub4f1 \ud558\uc704 \ud56d\ubaa9\ub4e4\uc758 \ud569\uc774 \uc804\uccb4 \ucde8\uc18c \uae08\uc561\uc744 \ucd08\uacfc\ud55c \uacbd\uc6b0</li>\n<li><code>CancelTaxFreeAmountExceedsCancellableTaxFreeAmountError</code>: \ucde8\uc18c \uba74\uc138 \uae08\uc561\uc774 \ucde8\uc18c \uac00\ub2a5\ud55c \uba74\uc138 \uae08\uc561\uc744 \ucd08\uacfc\ud55c \uacbd\uc6b0</li>\n<li><code>CancelTaxAmountExceedsCancellableTaxAmountError</code>: \ucde8\uc18c \uacfc\uc138 \uae08\uc561\uc774 \ucde8\uc18c \uac00\ub2a5\ud55c \uacfc\uc138 \uae08\uc561\uc744 \ucd08\uacfc\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelAmountExceedsCancellableAmountError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelAmountExceedsCancellableAmountError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 빌링키 결제
        /// <br/>빌링키로 결제를 진행합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PayWithBillingKeyResponse> PayWithBillingKeyAsync(string paymentId, BillingKeyPaymentInput body)
        {
            return PayWithBillingKeyAsync(paymentId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 빌링키 결제
        /// <br/>빌링키로 결제를 진행합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PayWithBillingKeyResponse> PayWithBillingKeyAsync(string paymentId, BillingKeyPaymentInput body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/billing-key"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/billing-key");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PayWithBillingKeyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>BillingKeyNotFoundError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>AlreadyPaidError</code>: \uacb0\uc81c\uac00 \uc774\ubbf8 \uc644\ub8cc\ub41c \uacbd\uc6b0</li>\n<li><code>SumOfPartsExceedsTotalAmountError</code>: \uba74\uc138 \uae08\uc561 \ub4f1 \ud558\uc704 \ud56d\ubaa9\ub4e4\uc758 \ud569\uc774 \uc804\uccb4 \uacb0\uc81c \uae08\uc561\uc744 \ucd08\uacfc\ud55c \uacbd\uc6b0</li>\n<li><code>BillingKeyAlreadyDeletedError</code>: \ube4c\ub9c1\ud0a4\uac00 \uc774\ubbf8 \uc0ad\uc81c\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 수기 결제
        /// <br/>수기 결제를 진행합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<PayInstantlyResponse> PayInstantlyAsync(string paymentId, InstantPaymentInput body)
        {
            return PayInstantlyAsync(paymentId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 수기 결제
        /// <br/>수기 결제를 진행합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<PayInstantlyResponse> PayInstantlyAsync(string paymentId, InstantPaymentInput body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/instant"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/instant");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PayInstantlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>ChannelNotFoundError</code>: \uc694\uccad\ub41c \ucc44\ub110\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>AlreadyPaidError</code>: \uacb0\uc81c\uac00 \uc774\ubbf8 \uc644\ub8cc\ub41c \uacbd\uc6b0</li>\n<li><code>SumOfPartsExceedsTotalAmountError</code>: \uba74\uc138 \uae08\uc561 \ub4f1 \ud558\uc704 \ud56d\ubaa9\ub4e4\uc758 \ud569\uc774 \uc804\uccb4 \uacb0\uc81c \uae08\uc561\uc744 \ucd08\uacfc\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AlreadyPaidError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<AlreadyPaidError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 빌링키 발급
        /// <br/>빌링키 발급을 요청합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<IssueBillingKeyResponse> IssueBillingKeyAsync(IssueBillingKeyBody body)
        {
            return IssueBillingKeyAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 빌링키 발급
        /// <br/>빌링키 발급을 요청합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<IssueBillingKeyResponse> IssueBillingKeyAsync(IssueBillingKeyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "billing-keys"
                urlBuilder_.Append("billing-keys");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<IssueBillingKeyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>ChannelNotFoundError</code>: \uc694\uccad\ub41c \ucc44\ub110\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ChannelNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ChannelNotFoundError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 현금 영수증 수동 발급
        /// <br/>현금 영수증 발급을 요청합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<IssueCashReceiptResponse> IssueCashReceiptAsync(IssueCashReceiptBody body)
        {
            return IssueCashReceiptAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 현금 영수증 수동 발급
        /// <br/>현금 영수증 발급을 요청합니다.
        /// </remarks>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<IssueCashReceiptResponse> IssueCashReceiptAsync(IssueCashReceiptBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "cash-receipts"
                urlBuilder_.Append("cash-receipts");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<IssueCashReceiptResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CashReceiptAlreadyIssuedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CashReceiptAlreadyIssuedError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CashReceiptAlreadyIssuedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CashReceiptAlreadyIssuedError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CashReceiptAlreadyIssuedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CashReceiptAlreadyIssuedError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CashReceiptAlreadyIssuedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CashReceiptAlreadyIssuedError>("<ul>\n<li><code>ChannelNotFoundError</code>: \uc694\uccad\ub41c \ucc44\ub110\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CashReceiptAlreadyIssuedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CashReceiptAlreadyIssuedError>("<ul>\n<li><code>CashReceiptAlreadyIssuedError</code>: \ud604\uae08\uc601\uc218\uc99d\uc774 \uc774\ubbf8 \ubc1c\uae09\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CashReceiptAlreadyIssuedError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CashReceiptAlreadyIssuedError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 현금 영수증 취소
        /// <br/>현금 영수증 취소를 요청합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CancelCashReceiptResponse> CancelCashReceiptByPaymentIdAsync(string paymentId, string storeId)
        {
            return CancelCashReceiptByPaymentIdAsync(paymentId, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 현금 영수증 취소
        /// <br/>현금 영수증 취소를 요청합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CancelCashReceiptResponse> CancelCashReceiptByPaymentIdAsync(string paymentId, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/cash-receipt/cancel"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/cash-receipt/cancel");
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>CashReceiptNotIssuedError</code>: \ud604\uae08\uc601\uc218\uc99d\uc774 \ubc1c\uae09\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>CashReceiptNotFoundError</code>: \ud604\uae08\uc601\uc218\uc99d\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CancelCashReceiptError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<CancelCashReceiptError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가상계좌 말소
        /// <br/>발급된 가상계좌를 말소합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<CloseVirtualAccountResponse> CloseVirtualAccountAsync(string paymentId, string storeId)
        {
            return CloseVirtualAccountAsync(paymentId, storeId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가상계좌 말소
        /// <br/>발급된 가상계좌를 말소합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <param name="storeId">상점 아이디
        /// <br/>접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<CloseVirtualAccountResponse> CloseVirtualAccountAsync(string paymentId, string storeId, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/virtual-account/close"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/virtual-account/close");
                urlBuilder_.Append('?');
                if (storeId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("storeId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(storeId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CloseVirtualAccountResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentNotFoundError</code>: \uacb0\uc81c \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentNotWaitingForDepositError</code>: \uacb0\uc81c \uac74\uc774 \uc785\uae08 \ub300\uae30 \uc0c1\ud0dc\uac00 \uc544\ub2cc \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 에스크로 배송 정보 등록
        /// <br/>에스크로 배송 정보를 등록합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ApplyEscrowLogisticsResponse> ApplyEscrowLogisticsAsync(string paymentId, EscrowLogisticsRegisterBody body)
        {
            return ApplyEscrowLogisticsAsync(paymentId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 에스크로 배송 정보 등록
        /// <br/>에스크로 배송 정보를 등록합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ApplyEscrowLogisticsResponse> ApplyEscrowLogisticsAsync(string paymentId, EscrowLogisticsRegisterBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/escrow/logistics"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/escrow/logistics");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentNotFoundError</code>: \uacb0\uc81c \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentNotPaidError</code>: \uacb0\uc81c\uac00 \uc644\ub8cc\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 에스크로 구매 확정
        /// <br/>에스크로 결제를 구매 확정 처리합니다
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ConfirmEscrowResponse> ConfirmEscrowAsync(string paymentId, ConfirmEscrowBody body)
        {
            return ConfirmEscrowAsync(paymentId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 에스크로 구매 확정
        /// <br/>에스크로 결제를 구매 확정 처리합니다
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ConfirmEscrowResponse> ConfirmEscrowAsync(string paymentId, ConfirmEscrowBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/escrow/complete"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/escrow/complete");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ConfirmEscrowResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentNotFoundError</code>: \uacb0\uc81c \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentNotPaidError</code>: \uacb0\uc81c\uac00 \uc644\ub8cc\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PgProviderError</code>: PG\uc0ac\uc5d0\uc11c \uc624\ub958\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 웹훅 재발송
        /// <br/>웹훅을 재발송합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ResendWebhookResponse> ResendWebhookAsync(string paymentId, ResendWebhookBody body)
        {
            return ResendWebhookAsync(paymentId, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 웹훅 재발송
        /// <br/>웹훅을 재발송합니다.
        /// </remarks>
        /// <param name="paymentId">결제 건 아이디</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ResendWebhookResponse> ResendWebhookAsync(string paymentId, ResendWebhookBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(paymentId);

            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "payments/{paymentId}/resend-webhook"
                urlBuilder_.Append("payments/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(paymentId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/resend-webhook");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ResendWebhookResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>PaymentNotFoundError</code>: \uacb0\uc81c \uac74\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n<li><code>WebhookNotFoundError</code>: \uc6f9\ud6c5 \ub0b4\uc5ed\uc774 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPaymentChart> GetAnalyticsPaymentChartAsync(GetAnalyticsPaymentChartBody body)
        {
            return GetAnalyticsPaymentChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPaymentChart> GetAnalyticsPaymentChartAsync(GetAnalyticsPaymentChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/payment"
                urlBuilder_.Append("analytics/charts/payment");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPaymentChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제 현황 인사이트를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제 현황 인사이트를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPaymentChartInsight> GetAnalyticsPaymentChartInsightAsync(GetAnalyticsPaymentChartInsightBody body)
        {
            return GetAnalyticsPaymentChartInsightAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제 현황 인사이트를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제 현황 인사이트를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPaymentChartInsight> GetAnalyticsPaymentChartInsightAsync(GetAnalyticsPaymentChartInsightBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/payment-insight"
                urlBuilder_.Append("analytics/charts/payment-insight");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPaymentChartInsight>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 평균 거래액 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 평균 거래액 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsAverageAmountChart> GetAverageAmountChartAsync(GetAnalyticsAverageAmountChartBody body)
        {
            return GetAverageAmountChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 평균 거래액 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 평균 거래액 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsAverageAmountChart> GetAverageAmountChartAsync(GetAnalyticsAverageAmountChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/average-amount"
                urlBuilder_.Append("analytics/charts/average-amount");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsAverageAmountChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제수단 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제수단 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPaymentMethodChart> GetPaymentMethodChartAsync(GetAnalyticsPaymentMethodChartBody body)
        {
            return GetPaymentMethodChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제수단 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제수단 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPaymentMethodChart> GetPaymentMethodChartAsync(GetAnalyticsPaymentMethodChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/payment-method"
                urlBuilder_.Append("analytics/charts/payment-method");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPaymentMethodChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제수단 트렌드를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제수단 트렌드를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPaymentMethodTrendChart> GetPaymentMethodTrendChartAsync(GetAnalyticsPaymentMethodTrendChartBody body)
        {
            return GetPaymentMethodTrendChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제수단 트렌드를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제수단 트렌드를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPaymentMethodTrendChart> GetPaymentMethodTrendChartAsync(GetAnalyticsPaymentMethodTrendChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/payment-method-trend"
                urlBuilder_.Append("analytics/charts/payment-method-trend");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPaymentMethodTrendChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 카드결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 카드결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsCardChart> GetAnalyticsCardChartAsync(GetAnalyticsCardChartBody body)
        {
            return GetAnalyticsCardChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 카드결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 카드결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsCardChart> GetAnalyticsCardChartAsync(GetAnalyticsCardChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/card"
                urlBuilder_.Append("analytics/charts/card");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsCardChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 카드사별 결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 카드사별 결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsCardCompanyChart> GetAnalyticsCardCompanyChartAsync(GetAnalyticsCardCompanyChartBody body)
        {
            return GetAnalyticsCardCompanyChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 카드사별 결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 카드사별 결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsCardCompanyChart> GetAnalyticsCardCompanyChartAsync(GetAnalyticsCardCompanyChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/card-company"
                urlBuilder_.Append("analytics/charts/card-company");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsCardCompanyChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 간편결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 간편결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsEasyPayChart> GetAnalyticsEasyPayChartAsync(GetAnalyticsEasyPayChartBody body)
        {
            return GetAnalyticsEasyPayChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 간편결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 간편결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsEasyPayChart> GetAnalyticsEasyPayChartAsync(GetAnalyticsEasyPayChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/easy-pay"
                urlBuilder_.Append("analytics/charts/easy-pay");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsEasyPayChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 간편결제사별 결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 간편결제사별 결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsEasyPayProviderChart> GetAnalyticsEasyPayProviderChartAsync(GetAnalyticsEasyPayProviderChartBody body)
        {
            return GetAnalyticsEasyPayProviderChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 간편결제사별 결제 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 간편결제사별 결제 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsEasyPayProviderChart> GetAnalyticsEasyPayProviderChartAsync(GetAnalyticsEasyPayProviderChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/easy-pay-provider"
                urlBuilder_.Append("analytics/charts/easy-pay-provider");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsEasyPayProviderChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제대행사 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제대행사 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPgCompanyChart> GetPgCompanyChartAsync(GetAnalyticsPgCompanyChartBody body)
        {
            return GetPgCompanyChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제대행사 현황을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제대행사 현황을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPgCompanyChart> GetPgCompanyChartAsync(GetAnalyticsPgCompanyChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/pg-company"
                urlBuilder_.Append("analytics/charts/pg-company");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPgCompanyChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제대행사별 거래 추이를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제대행사별 거래 추이를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPgCompanyTrendChart> GetPgCompanyTrendChartAsync(GetAnalyticsPgCompanyTrendChartBody body)
        {
            return GetPgCompanyTrendChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제대행사별 거래 추이를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제대행사별 거래 추이를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPgCompanyTrendChart> GetPgCompanyTrendChartAsync(GetAnalyticsPgCompanyTrendChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/pg-company-trend"
                urlBuilder_.Append("analytics/charts/pg-company-trend");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPgCompanyTrendChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 해외 결제 사용 여부를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 해외 결제 사용 여부을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsOverseasPaymentUsage> GetAnalyticsOverseasPaymentUsageAsync()
        {
            return GetAnalyticsOverseasPaymentUsageAsync(System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 해외 결제 사용 여부를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 해외 결제 사용 여부을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsOverseasPaymentUsage> GetAnalyticsOverseasPaymentUsageAsync(System.Threading.CancellationToken cancellationToken)
        {
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/overseas-payment-usage"
                urlBuilder_.Append("analytics/overseas-payment-usage");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsOverseasPaymentUsage>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 환불율을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 환불율을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsCancellationRate> GetAnalyticsCancellationRateAsync(GetAnalyticsCancellationRateBody body)
        {
            return GetAnalyticsCancellationRateAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 환불율을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 환불율을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsCancellationRate> GetAnalyticsCancellationRateAsync(GetAnalyticsCancellationRateBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/cancellation-rate"
                urlBuilder_.Append("analytics/cancellation-rate");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsCancellationRate>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제상태 이력 집계를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제상태 이력 집계 결과를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPaymentStatusChart> GetPaymentStatusChartAsync(GetAnalyticsPaymentStatusChartBody body)
        {
            return GetPaymentStatusChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제상태 이력 집계를 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제상태 이력 집계 결과를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPaymentStatusChart> GetPaymentStatusChartAsync(GetAnalyticsPaymentStatusChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/payment-status"
                urlBuilder_.Append("analytics/charts/payment-status");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPaymentStatusChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제수단별 결제전환율을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제수단별 결제전환율 조회 결과를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPaymentStatusByPaymentMethodChart> GetPaymentStatusByPaymentMethodChartAsync(GetAnalyticsPaymentStatusByPaymentMethodChartBody body)
        {
            return GetPaymentStatusByPaymentMethodChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제수단별 결제전환율을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제수단별 결제전환율 조회 결과를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPaymentStatusByPaymentMethodChart> GetPaymentStatusByPaymentMethodChartAsync(GetAnalyticsPaymentStatusByPaymentMethodChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/payment-status/by-method"
                urlBuilder_.Append("analytics/charts/payment-status/by-method");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPaymentStatusByPaymentMethodChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 PG사별 결제전환율을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 PG사별 결제전환율 조회 결과를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPaymentStatusByPgCompanyChart> GetPaymentStatusByPgCompanyChartAsync(GetAnalyticsPaymentStatusByPgCompanyChartBody body)
        {
            return GetPaymentStatusByPgCompanyChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 PG사별 결제전환율을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 PG사별 결제전환율 조회 결과를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPaymentStatusByPgCompanyChart> GetPaymentStatusByPgCompanyChartAsync(GetAnalyticsPaymentStatusByPgCompanyChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/payment-status/by-pg-company"
                urlBuilder_.Append("analytics/charts/payment-status/by-pg-company");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPaymentStatusByPgCompanyChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 가맹점의 결제환경별 결제전환율을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제환경별 결제전환율 조회 결과를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<AnalyticsPaymentStatusByPaymentClientChart> GetPaymentStatusByPaymentClientChartAsync(GetAnalyticsPaymentStatusByPaymentClientChartBody body)
        {
            return GetPaymentStatusByPaymentClientChartAsync(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 가맹점의 결제환경별 결제전환율을 조회합니다.
        /// </remarks>
        /// <returns>성공 응답으로 결제환경별 결제전환율 조회 결과를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<AnalyticsPaymentStatusByPaymentClientChart> GetPaymentStatusByPaymentClientChartAsync(GetAnalyticsPaymentStatusByPaymentClientChartBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "analytics/charts/payment-status/by-payment-client"
                urlBuilder_.Append("analytics/charts/payment-status/by-payment-client");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AnalyticsPaymentStatusByPaymentClientChart>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApplyEscrowLogisticsError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ApplyEscrowLogisticsError>("<ul>\n<li><code>ForbiddenError</code>: \uc694\uccad\uc774 \uac70\uc808\ub41c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 연동 사업자 조회
        /// <br/>포트원 B2B 서비스에 연동된 사업자를 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 사업자 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bMemberCompany> GetB2bMemberCompanyAsync(string brn, bool? test)
        {
            return GetB2bMemberCompanyAsync(brn, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 연동 사업자 조회
        /// <br/>포트원 B2B 서비스에 연동된 사업자를 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 사업자 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bMemberCompany> GetB2bMemberCompanyAsync(string brn, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/member-companies/{brn}"
                urlBuilder_.Append("b2b-preview/member-companies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bMemberCompany>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bMemberCompanyNotFoundError</code>: \uc5f0\ub3d9 \uc0ac\uc5c5\uc790\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 사업자 연동
        /// <br/>포트원 B2B 서비스에 사업자를 연동합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<RegisterB2bMemberCompanyResponse> RegisterB2bMemberCompanyAsync(bool? test, RegisterB2bMemberCompanyBody body)
        {
            return RegisterB2bMemberCompanyAsync(test, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 사업자 연동
        /// <br/>포트원 B2B 서비스에 사업자를 연동합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<RegisterB2bMemberCompanyResponse> RegisterB2bMemberCompanyAsync(bool? test, RegisterB2bMemberCompanyBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/member-companies"
                urlBuilder_.Append("b2b-preview/member-companies");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<RegisterB2bMemberCompanyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 담당자 조회
        /// <br/>연동 사업자에 등록된 담당자를 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="contactId">담당자 ID</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 담당자 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bCompanyContact> GetB2bMemberCompanyContactAsync(string brn, string contactId, bool? test)
        {
            return GetB2bMemberCompanyContactAsync(brn, contactId, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 담당자 조회
        /// <br/>연동 사업자에 등록된 담당자를 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="contactId">담당자 ID</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 담당자 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bCompanyContact> GetB2bMemberCompanyContactAsync(string brn, string contactId, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(brn);

            ArgumentNullException.ThrowIfNull(contactId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/member-companies/{brn}/contacts/{contactId}"
                urlBuilder_.Append("b2b-preview/member-companies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/contacts/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(contactId, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCompanyContact>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bContactNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bContactNotFoundError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bContactNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bContactNotFoundError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bContactNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bContactNotFoundError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bContactNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bContactNotFoundError>("<ul>\n<li><code>B2bMemberCompanyNotFoundError</code>: \uc5f0\ub3d9 \uc0ac\uc5c5\uc790\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n<li><code>B2bContactNotFoundError</code>: \ub2f4\ub2f9\uc790\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bContactNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bContactNotFoundError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 사업자 인증서 등록 URL 조회
        /// <br/>연동 사업자의 인증서를 등록하기 위한 URL을 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 URL을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetB2bCertificateRegistrationUrlResponse> GetB2bCertificateRegistrationUrlAsync(string brn, bool? test)
        {
            return GetB2bCertificateRegistrationUrlAsync(brn, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 사업자 인증서 등록 URL 조회
        /// <br/>연동 사업자의 인증서를 등록하기 위한 URL을 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 URL을 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetB2bCertificateRegistrationUrlResponse> GetB2bCertificateRegistrationUrlAsync(string brn, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/member-companies/{brn}/certificate/registration-url"
                urlBuilder_.Append("b2b-preview/member-companies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/certificate/registration-url");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetB2bCertificateRegistrationUrlResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bMemberCompanyNotFoundError</code>: \uc5f0\ub3d9 \uc0ac\uc5c5\uc790\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 인증서 조회
        /// <br/>연동 사업자의 인증서를 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 인증서 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bCertificate> GetB2bCertificateAsync(string brn, bool? test)
        {
            return GetB2bCertificateAsync(brn, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 인증서 조회
        /// <br/>연동 사업자의 인증서를 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 인증서 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bCertificate> GetB2bCertificateAsync(string brn, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/member-companies/{brn}/certificate"
                urlBuilder_.Append("b2b-preview/member-companies/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/certificate");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificate>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>B2bMemberCompanyNotFoundError</code>: \uc5f0\ub3d9 \uc0ac\uc5c5\uc790\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n<li><code>B2bCertificateUnregisteredError</code>: \uc778\uc99d\uc11c\uac00 \ub4f1\ub85d\ub418\uc5b4 \uc788\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 담당자 ID 존재 여부 확인
        /// <br/>담당자 ID가 이미 사용중인지 확인합니다.
        /// </remarks>
        /// <param name="contactId">담당자 ID</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답입니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetB2bContactIdExistenceResponse> GetB2bContactIdExistenceAsync(string contactId, bool? test)
        {
            return GetB2bContactIdExistenceAsync(contactId, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 담당자 ID 존재 여부 확인
        /// <br/>담당자 ID가 이미 사용중인지 확인합니다.
        /// </remarks>
        /// <param name="contactId">담당자 ID</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답입니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetB2bContactIdExistenceResponse> GetB2bContactIdExistenceAsync(string contactId, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(contactId);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/member-companies/contacts/id-existence"
                urlBuilder_.Append("b2b-preview/member-companies/contacts/id-existence");
                urlBuilder_.Append('?');
                urlBuilder_.Append(System.Uri.EscapeDataString("contactId")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(contactId, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetB2bContactIdExistenceResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 예금주 조회
        /// <br/>원하는 계좌의 예금주를 조회합니다.
        /// </remarks>
        /// <param name="bank">은행</param>
        /// <param name="accountNumber">'-'를 제외한 계좌 번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetB2bBankAccountHolderResponse> GetB2bBankAccountHolderAsync(Bank bank, string accountNumber, bool? test)
        {
            return GetB2bBankAccountHolderAsync(bank, accountNumber, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 예금주 조회
        /// <br/>원하는 계좌의 예금주를 조회합니다.
        /// </remarks>
        /// <param name="bank">은행</param>
        /// <param name="accountNumber">'-'를 제외한 계좌 번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetB2bBankAccountHolderResponse> GetB2bBankAccountHolderAsync(Bank bank, string accountNumber, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(accountNumber);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/bank-accounts/{bank}/{accountNumber}/holder"
                urlBuilder_.Append("b2b-preview/bank-accounts/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(bank, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(accountNumber, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/holder");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetB2bBankAccountHolderResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>B2bBankAccountNotFoundError</code>: \uacc4\uc88c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n<li><code>B2bForeignExchangeAccountError</code>: \uacc4\uc88c \uc815\ubcf4 \uc870\ud68c\uac00 \ubd88\uac00\ub2a5\ud55c \uc678\ud654 \uacc4\uc88c\uc778 \uacbd\uc6b0</li>\n<li><code>B2bSuspendedAccountError</code>: \uc815\uc9c0 \uacc4\uc88c\uc778 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 503)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCertificateUnregisteredError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCertificateUnregisteredError>("<ul>\n<li><code>B2bRegularMaintenanceTimeError</code>: \uae08\uc735\uae30\uad00 \uc2dc\uc2a4\ud15c\uc774 \uc815\uae30 \uc810\uac80 \uc911\uc778 \uacbd\uc6b0</li>\n<li><code>B2bFinancialSystemFailureError</code>: \uae08\uc735\uae30\uad00 \uc7a5\uc560</li>\n<li><code>B2bFinancialSystemUnderMaintenanceError</code>: \uae08\uc735\uae30\uad00 \uc2dc\uc2a4\ud15c\uc774 \uc810\uac80 \uc911\uc778 \uacbd\uc6b0</li>\n<li><code>B2bFinancialSystemCommunicationError</code>: \uae08\uc735\uae30\uad00\uacfc\uc758 \ud1b5\uc2e0\uc5d0 \uc2e4\ud328\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 사업자 상태 조회
        /// <br/>원하는 사업자의 상태를 조회합니다. 포트원 B2B 서비스에 연동 및 등록되지 않은 사업자도 조회 가능합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 사업자 상태 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bCompanyState> GetB2bCompanyStateAsync(string brn, bool? test)
        {
            return GetB2bCompanyStateAsync(brn, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 사업자 상태 조회
        /// <br/>원하는 사업자의 상태를 조회합니다. 포트원 B2B 서비스에 연동 및 등록되지 않은 사업자도 조회 가능합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 사업자 상태 객체를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bCompanyState> GetB2bCompanyStateAsync(string brn, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/company/{brn}/state"
                urlBuilder_.Append("b2b-preview/company/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/state");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCompanyState>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCompanyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCompanyNotFoundError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCompanyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCompanyNotFoundError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCompanyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCompanyNotFoundError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCompanyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCompanyNotFoundError>("<ul>\n<li><code>B2bCompanyNotFoundError</code>: \uc0ac\uc5c5\uc790\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\ub294 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bCompanyNotFoundError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bCompanyNotFoundError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금계산서 역발행 요청
        /// <br/>공급자에게 세금계산서 역발행을 요청합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bTaxInvoice> RequestB2bTaxInvoiceReverseIssuanceAsync(bool? test, RequestB2bTaxInvoiceReverseIssuanceRequestBody body)
        {
            return RequestB2bTaxInvoiceReverseIssuanceAsync(test, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금계산서 역발행 요청
        /// <br/>공급자에게 세금계산서 역발행을 요청합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bTaxInvoice> RequestB2bTaxInvoiceReverseIssuanceAsync(bool? test, RequestB2bTaxInvoiceReverseIssuanceRequestBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/request-reverse-issuance"
                urlBuilder_.Append("b2b-preview/tax-invoices/request-reverse-issuance");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bTaxInvoice>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bSupplierNotFoundError</code>: \uacf5\uae09\uc790\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>B2bRecipientNotFoundError</code>: \uacf5\uae09\ubc1b\ub294\uc790\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금 계산서 조회
        /// <br/>등록된 세금 계산서를 공급자 혹은 공급받는자 문서번호로 조회합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bTaxInvoice> GetB2bTaxInvoiceAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test)
        {
            return GetB2bTaxInvoiceAsync(documentKey, brn, documentKeyType, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금 계산서 조회
        /// <br/>등록된 세금 계산서를 공급자 혹은 공급받는자 문서번호로 조회합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bTaxInvoice> GetB2bTaxInvoiceAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(documentKey);

            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/{documentKey}"
                urlBuilder_.Append("b2b-preview/tax-invoices/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(documentKey, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                urlBuilder_.Append(System.Uri.EscapeDataString("brn")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                if (documentKeyType != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("documentKeyType")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(documentKeyType, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bTaxInvoice>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bTaxInvoiceNotFoundError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금계산서 삭제
        /// <br/>세금계산서를 삭제합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task DeleteB2bTaxInvoiceAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test)
        {
            return DeleteB2bTaxInvoiceAsync(documentKey, brn, documentKeyType, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금계산서 삭제
        /// <br/>세금계산서를 삭제합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task DeleteB2bTaxInvoiceAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(documentKey);

            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("DELETE");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/{documentKey}"
                urlBuilder_.Append("b2b-preview/tax-invoices/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(documentKey, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                urlBuilder_.Append(System.Uri.EscapeDataString("brn")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                if (documentKeyType != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("documentKeyType")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(documentKeyType, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        return;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>B2bTaxInvoiceNonDeletableStatusError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc0ad\uc81c \uac00\ub2a5\ud55c \uc0c1\ud0dc\uac00 \uc544\ub2cc \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bTaxInvoiceNotFoundError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금계산서 발행
        /// <br/>역발행의 경우 역발행요청(REQUESTED) 상태, 정발행의 경우 임시저장(REGISTERED) 상태의 세금계산서를 발행합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bTaxInvoice> IssueB2bTaxInvoiceAsync(bool? test, IssueB2bTaxInvoiceRequestBody body)
        {
            return IssueB2bTaxInvoiceAsync(test, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금계산서 발행
        /// <br/>역발행의 경우 역발행요청(REQUESTED) 상태, 정발행의 경우 임시저장(REGISTERED) 상태의 세금계산서를 발행합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bTaxInvoice> IssueB2bTaxInvoiceAsync(bool? test, IssueB2bTaxInvoiceRequestBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/issue"
                urlBuilder_.Append("b2b-preview/tax-invoices/issue");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bTaxInvoice>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>B2bTaxInvoiceNotRequestedStatusError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc5ed\ubc1c\ud589 \ub300\uae30 \uc0c1\ud0dc\uac00 \uc544\ub2cc \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bTaxInvoiceNotFoundError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금계산서 역발행 요청 취소
        /// <br/>공급받는자가 공급자에게 세금계산서 역발행 요청한 것을 취소합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bTaxInvoice> CancelB2bTaxInvoiceRequestAsync(bool? test, CancelB2bTaxInvoiceRequestBody body)
        {
            return CancelB2bTaxInvoiceRequestAsync(test, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금계산서 역발행 요청 취소
        /// <br/>공급받는자가 공급자에게 세금계산서 역발행 요청한 것을 취소합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bTaxInvoice> CancelB2bTaxInvoiceRequestAsync(bool? test, CancelB2bTaxInvoiceRequestBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/cancel-request"
                urlBuilder_.Append("b2b-preview/tax-invoices/cancel-request");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bTaxInvoice>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>B2bTaxInvoiceNotRequestedStatusError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc5ed\ubc1c\ud589 \ub300\uae30 \uc0c1\ud0dc\uac00 \uc544\ub2cc \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bTaxInvoiceNotFoundError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금계산서 역발행 취소
        /// <br/>공급자가 발행 완료한 세금계산서를 국세청 전송 전 취소합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bTaxInvoice> CancelB2bTaxInvoiceIssuanceAsync(bool? test, CancelB2bTaxInvoiceIssuanceBody body)
        {
            return CancelB2bTaxInvoiceIssuanceAsync(test, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금계산서 역발행 취소
        /// <br/>공급자가 발행 완료한 세금계산서를 국세청 전송 전 취소합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bTaxInvoice> CancelB2bTaxInvoiceIssuanceAsync(bool? test, CancelB2bTaxInvoiceIssuanceBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/cancel-issuance"
                urlBuilder_.Append("b2b-preview/tax-invoices/cancel-issuance");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bTaxInvoice>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>B2bTaxInvoiceNotIssuedStatusError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \ubc1c\ud589\ub41c(ISSUED) \uc0c1\ud0dc\uac00 \uc544\ub2cc \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금계산서 역발행 요청 거부
        /// <br/>공급자가 공급받는자로부터 요청받은 세금계산서 역발행 건을 거부합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<B2bTaxInvoice> RefuseB2bTaxInvoiceRequestAsync(bool? test, RefuseB2bTaxInvoiceRequestBody body)
        {
            return RefuseB2bTaxInvoiceRequestAsync(test, body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금계산서 역발행 요청 거부
        /// <br/>공급자가 공급받는자로부터 요청받은 세금계산서 역발행 건을 거부합니다.
        /// </remarks>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <returns>성공 응답으로 세금계산서를 반환합니다.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<B2bTaxInvoice> RefuseB2bTaxInvoiceRequestAsync(bool? test, RefuseB2bTaxInvoiceRequestBody body, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(body);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                var content_ = new System.Net.Http.StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/refuse-request"
                urlBuilder_.Append("b2b-preview/tax-invoices/refuse-request");
                urlBuilder_.Append('?');
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bTaxInvoice>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n<li><code>B2bTaxInvoiceNotRequestedStatusError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc5ed\ubc1c\ud589 \ub300\uae30 \uc0c1\ud0dc\uac00 \uc544\ub2cc \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bTaxInvoiceNotFoundError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금 계산서 다건조회
        /// <br/>조회 기간 내 등록된 세금 계산서를 다건 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="pageNumber">페이지 번호
        /// <br/>0부터 시작하는 페이지 번호. 기본 값은 0.</param>
        /// <param name="pageSize">페이지 크기
        /// <br/>각 페이지 당 포함할 객체 수. 기본 값은 500이며 최대 1000까지 요청가능합니다.</param>
        /// <param name="from">조회 시작일</param>
        /// <param name="until">조회 종료일</param>
        /// <param name="dateType">조회 기간 기준</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetB2bTaxInvoicesResponse> GetB2bTaxInvoicesAsync(string brn, int? pageNumber, int? pageSize, string from, string until, B2bSearchDateType dateType, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test)
        {
            return GetB2bTaxInvoicesAsync(brn, pageNumber, pageSize, from, until, dateType, documentKeyType, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금 계산서 다건조회
        /// <br/>조회 기간 내 등록된 세금 계산서를 다건 조회합니다.
        /// </remarks>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="pageNumber">페이지 번호
        /// <br/>0부터 시작하는 페이지 번호. 기본 값은 0.</param>
        /// <param name="pageSize">페이지 크기
        /// <br/>각 페이지 당 포함할 객체 수. 기본 값은 500이며 최대 1000까지 요청가능합니다.</param>
        /// <param name="from">조회 시작일</param>
        /// <param name="until">조회 종료일</param>
        /// <param name="dateType">조회 기간 기준</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetB2bTaxInvoicesResponse> GetB2bTaxInvoicesAsync(string brn, int? pageNumber, int? pageSize, string from, string until, B2bSearchDateType dateType, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(brn);

            ArgumentNullException.ThrowIfNull(from);

            ArgumentNullException.ThrowIfNull(until);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices"
                urlBuilder_.Append("b2b-preview/tax-invoices");
                urlBuilder_.Append('?');
                urlBuilder_.Append(System.Uri.EscapeDataString("brn")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                if (pageNumber != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("pageNumber")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(pageNumber, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (pageSize != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("pageSize")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(pageSize, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Append(System.Uri.EscapeDataString("from")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(from, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                urlBuilder_.Append(System.Uri.EscapeDataString("until")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(until, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                urlBuilder_.Append(System.Uri.EscapeDataString("dateType")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(dateType, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                if (documentKeyType != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("documentKeyType")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(documentKeyType, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetB2bTaxInvoicesResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금 계산서 팝업 URL 조회
        /// <br/>등록된 세금 계산서 팝업 URL을 공급자 혹은 공급받는자 문서번호로 조회합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="includeMenu">메뉴 포함 여부
        /// <br/>팝업 URL에 메뉴 레이아웃을 포함 여부를 결정합니다. 기본 값은 true입니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetB2bTaxInvoicePopupUrlResponse> GetB2bTaxInvoicePopupUrlAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? includeMenu, bool? test)
        {
            return GetB2bTaxInvoicePopupUrlAsync(documentKey, brn, documentKeyType, includeMenu, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금 계산서 팝업 URL 조회
        /// <br/>등록된 세금 계산서 팝업 URL을 공급자 혹은 공급받는자 문서번호로 조회합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="includeMenu">메뉴 포함 여부
        /// <br/>팝업 URL에 메뉴 레이아웃을 포함 여부를 결정합니다. 기본 값은 true입니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetB2bTaxInvoicePopupUrlResponse> GetB2bTaxInvoicePopupUrlAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? includeMenu, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(documentKey);

            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/{documentKey}/popup-url"
                urlBuilder_.Append("b2b-preview/tax-invoices/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(documentKey, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/popup-url");
                urlBuilder_.Append('?');
                urlBuilder_.Append(System.Uri.EscapeDataString("brn")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                if (documentKeyType != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("documentKeyType")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(documentKeyType, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (includeMenu != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeMenu")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(includeMenu, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetB2bTaxInvoicePopupUrlResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bTaxInvoiceNotFoundError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금 계산서 프린트 URL 조회
        /// <br/>등록된 세금 계산서 프린트 URL을 공급자 혹은 공급받는자 문서번호로 조회합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetB2bTaxInvoicePrintUrlResponse> GetB2bTaxInvoicePrintUrlAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test)
        {
            return GetB2bTaxInvoicePrintUrlAsync(documentKey, brn, documentKeyType, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금 계산서 프린트 URL 조회
        /// <br/>등록된 세금 계산서 프린트 URL을 공급자 혹은 공급받는자 문서번호로 조회합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetB2bTaxInvoicePrintUrlResponse> GetB2bTaxInvoicePrintUrlAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(documentKey);

            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/{documentKey}/print-url"
                urlBuilder_.Append("b2b-preview/tax-invoices/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(documentKey, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/print-url");
                urlBuilder_.Append('?');
                urlBuilder_.Append(System.Uri.EscapeDataString("brn")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                if (documentKeyType != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("documentKeyType")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(documentKeyType, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetB2bTaxInvoicePrintUrlResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bTaxInvoiceNotFoundError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <remarks>
        /// 세금 계산서 PDF 다운로드 URL 조회
        /// <br/>등록된 세금 계산서 PDF 다운로드 URL을 공급자 혹은 공급받는자 문서번호로 조회합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetB2bTaxInvoicePdfDownloadUrlResponse> GetB2bTaxInvoicePdfDownloadUrlAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test)
        {
            return GetB2bTaxInvoicePdfDownloadUrlAsync(documentKey, brn, documentKeyType, test, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <remarks>
        /// 세금 계산서 PDF 다운로드 URL 조회
        /// <br/>등록된 세금 계산서 PDF 다운로드 URL을 공급자 혹은 공급받는자 문서번호로 조회합니다.
        /// </remarks>
        /// <param name="documentKey">세금계산서 문서 번호</param>
        /// <param name="brn">사업자등록번호</param>
        /// <param name="documentKeyType">문서 번호 유형
        /// <br/>path 파라미터로 전달된 문서번호 유형. 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.</param>
        /// <param name="test">테스트 모드 여부
        /// <br/>true 이면 테스트 모드로 실행되며, false 이거나 주어지지 않은 경우 테스트 모드를 사용하지 않습니다.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetB2bTaxInvoicePdfDownloadUrlResponse> GetB2bTaxInvoicePdfDownloadUrlAsync(string documentKey, string brn, B2bTaxInvoiceDocumentKeyType? documentKeyType, bool? test, System.Threading.CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(documentKey);

            ArgumentNullException.ThrowIfNull(brn);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using var request_ = new System.Net.Http.HttpRequestMessage();
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                // Operation Path: "b2b-preview/tax-invoices/{documentKey}/pdf-download-url"
                urlBuilder_.Append("b2b-preview/tax-invoices/");
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(documentKey, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append("/pdf-download-url");
                urlBuilder_.Append('?');
                urlBuilder_.Append(System.Uri.EscapeDataString("brn")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(brn, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                if (documentKeyType != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("documentKeyType")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(documentKeyType, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                if (test != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("test")).Append('=').Append(System.Uri.EscapeDataString(ConvertToString(test, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GetB2bTaxInvoicePdfDownloadUrlResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>InvalidRequestError</code>: \uc694\uccad\ub41c \uc785\ub825 \uc815\ubcf4\uac00 \uc720\ud6a8\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 401)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>UnauthorizedError</code>: \uc778\uc99d \uc815\ubcf4\uac00 \uc62c\ubc14\ub974\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bNotEnabledError</code>: B2B \uae30\ub2a5\uc774 \ud65c\uc131\ud654\ub418\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bTaxInvoiceNotFoundError</code>: \uc138\uae08\uacc4\uc0b0\uc11c\uac00 \uc874\uc7ac\ud558\uc9c0 \uc54a\uc740 \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 502)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<B2bExternalServiceError>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<B2bExternalServiceError>("<ul>\n<li><code>B2bExternalServiceError</code>: \uc678\ubd80 \uc11c\ube44\uc2a4\uc5d0\uc11c \uc5d0\ub7ec\uac00 \ubc1c\uc0dd\ud55c \uacbd\uc6b0</li>\n</ul>\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        protected readonly struct ObjectResponseResult<T>(T? responseObject, string responseText)
        {
            public T? Object { get; } = responseObject;

            public string Text { get; } = responseText;
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default, string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    using var streamReader = new System.IO.StreamReader(responseStream);
                    using var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader);
                    var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                    var typedBody = serializer.Deserialize<T>(jsonTextReader);
                    return new ObjectResponseResult<T>(typedBody, string.Empty);
                }
                catch (Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            switch (value)
            {
                case Enum:
                    {
                        var name = Enum.GetName(value.GetType(), value);
                        if (name != null)
                        {
                            var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                            if (field != null)
                            {
                                if (System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) is System.Runtime.Serialization.EnumMemberAttribute attribute)
                                {
                                    return attribute.Value ?? name;
                                }
                            }

                            var converted = Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                            return converted ?? string.Empty;
                        }

                        break;
                    }

                case bool v:
                    return Convert.ToString(v, cultureInfo).ToLowerInvariant();
                case byte[] v:
                    return Convert.ToBase64String(v);
                case string[] v:
                    return string.Join(",", v);
                default:
                    if (value.GetType().IsArray)
                    {
                        var valueArray = (Array)value;
                        var valueTextArray = new string[valueArray.Length];
                        for (var i = 0; i < valueArray.Length; i++)
                        {
                            valueTextArray[i] = ConvertToString(valueArray.GetValue(i)!, cultureInfo);
                        }
                        return string.Join(",", valueTextArray);
                    }

                    break;
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result ?? "";
        }
    }
}