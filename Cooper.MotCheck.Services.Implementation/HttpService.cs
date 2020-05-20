using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services.Implementation
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient client;
        private readonly IServiceAuthenticationProvider tokenService;

        public HttpService(IServiceAuthenticationProvider tokenService)
        {
            client = new HttpClient();
            this.tokenService = tokenService;
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            client.DefaultRequestHeaders.Add("x", tokenService.GetAuthenticationKey());
            return client.GetAsync(requestUri, cancellationToken);
        }

        public Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, T body, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(json));
            return client.PostAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsync<T>(Uri requestUri, T body, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(json));
            return client.PutAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteAsync<T>(Uri requestUri, CancellationToken cancellationToken)
        {
            return client.DeleteAsync(requestUri, cancellationToken);
        }
    }
}
