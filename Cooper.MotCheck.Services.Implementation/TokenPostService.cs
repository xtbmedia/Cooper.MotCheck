using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services.Implementation
{
    public class TokenPostService : ITokenPostService
    {
        private readonly string tokenProviderUri = "";

        public Task<HttpResponseMessage> PostTokenRequestAsync(string code, string redirectUri, string clientId, string clientSecret)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string> {
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", redirectUri.ToLowerInvariant()}
            });

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "basic", 
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"))
            );
            return httpClient.PostAsync(tokenProviderUri, content, CancellationToken.None);
        }

    }
}
