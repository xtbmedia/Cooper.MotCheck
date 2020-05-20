using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> DeleteAsync<T>(Uri requestUri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, T body, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PutAsync<T>(Uri requestUri, T body, CancellationToken cancellationToken);
    }
}

