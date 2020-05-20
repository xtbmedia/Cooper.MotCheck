using System;
using System.Collections.Generic;
using System.Text;

namespace Cooper.MotCheck.Services
{
    public interface IServiceAuthenticationProvider
    {
        public string GetAuthenticationKey();
    }
}
