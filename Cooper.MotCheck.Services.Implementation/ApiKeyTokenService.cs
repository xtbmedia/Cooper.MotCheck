namespace Cooper.MotCheck.Services.Implementation
{
    public class ApiKeyTokenService : IServiceAuthenticationProvider
    {
        private readonly string apiKey = "";

        public string GetAuthenticationKey() => apiKey;
    }
}
