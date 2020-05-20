using Cooper.MotCheck.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services.Implementation
{
    public class ApiKeyTokenService : IServiceAuthenticationProvider
    {
        private readonly string apiKey = "";

        public string GetAuthenticationKey() => apiKey;
    }
}
