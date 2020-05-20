using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services
{
    public interface ITokenPostService
    {
        Task<HttpResponseMessage> PostTokenRequestAsync(string code, string redirectUri, string clientId, string clientSecret);
    }
}
