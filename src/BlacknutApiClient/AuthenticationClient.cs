using System;
using System.Threading.Tasks;
using BlacknutApiClient.Extensions;
using Flurl;
using Flurl.Http;

namespace BlacknutApiClient
{
    public class AuthenticationClient
    {
        public BlacknutCredentials Credentials { get; private set; }

        public AuthenticationData AuthenticationData { get; private set; } = new AuthenticationData();

        public AuthenticationClient(BlacknutCredentials credentials)
        {
            credentials.XBlkUserAgent =
                string.Format(credentials.XBlkUserAgent, credentials.PartnerCredentials?.PartnerCode);

            if (!credentials.Ok())
                throw new Exception("Credentials not set.");

            Credentials = credentials;
        }

        public async Task AuthenticateAsync()
        {
            var result = await new Url(Credentials.ApiUrl).Clone()
                .AppendPathSegment("/api/v1/partner/token")
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.ContentType), Credentials.ContentType)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.AcceptLanguage), Credentials.AcceptLanguage)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.XBlkUserAgent), Credentials.XBlkUserAgent)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.Secret), Credentials.Secret)
                .PostJsonAsync(Credentials.PartnerCredentials);

            AuthenticationData = await result.GetJsonAsync<AuthenticationData>();
        }

        public async Task RefreshAsync()
        {
            var result = await new Url(Credentials.ApiUrl).Clone()
                .AppendPathSegment("/api/v1/partner/refresh")
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.ContentType), Credentials.ContentType)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.AcceptLanguage), Credentials.AcceptLanguage)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.XBlkUserAgent), Credentials.XBlkUserAgent)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.Secret), Credentials.Secret)
                .PostJsonAsync(new { refreshToken = AuthenticationData.RefreshToken });

            AuthenticationData = await result.GetJsonAsync<AuthenticationData>();
        }
    }

    public class AuthenticationData
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool Authenticated => !string.IsNullOrEmpty(Token)
                                     && DateTime.Now < CreatedAt.AddHours(1);

        public AuthenticationData()
        {
            CreatedAt = DateTime.Now;
        }
    }
}