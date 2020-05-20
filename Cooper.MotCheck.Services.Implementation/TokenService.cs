using Cooper.MotCheck.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly ITokenPostService tokenPostService;
        private readonly string clientId = "";
        private readonly string clientSecret = "";
        private readonly string state;

        private readonly string scopes = "";
        private readonly string authCallbackUrl = "";

        private TokenGrant token;

        public TokenService(ITokenPostService tokenPostService)
        {
            this.tokenPostService = tokenPostService;
            state = Guid.NewGuid().ToString();
        }

        public string GetTokenRequestRedirectUri()
        {
            var uri = $""
                + $"?response_type=code"
                + $"&client_id={clientId}"
                + (string.IsNullOrWhiteSpace(scopes) ? "" : $"&scopes={scopes}")
                + $"&redirect_uri={ authCallbackUrl.ToLowerInvariant() }";
            return uri;
        }

        public async Task RequestToken(string code)
        {
            var response = await tokenPostService.PostTokenRequestAsync(code, authCallbackUrl, clientId, clientSecret);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                token = null;
                return;
            }

            token = JsonConvert.DeserializeObject<TokenGrant>(content);
        }

        public string GetAuthenticationKey()
        {
            return token?.AccessToken;
        }
    }
}
