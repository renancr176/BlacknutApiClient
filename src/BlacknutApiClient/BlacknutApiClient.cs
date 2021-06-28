using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlacknutApiClient.Extensions;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Models;
using BlacknutApiClient.Models.Responses;
using Flurl;
using Flurl.Http;

namespace BlacknutApiClient
{
    public class BlacknutApiClient : IBlacknutApiClient
    {
        public AuthenticationClient AuthenticationClient { get; private set; }

        public BlacknutApiClient(BlacknutCredentials credentials)
        {
            AuthenticationClient = new AuthenticationClient(credentials);
        }

        public async Task<IFlurlRequest> GetBaseUrlAsync()
        {
            if (!AuthenticationClient.AuthenticationData.Authenticated)
            {
                if (string.IsNullOrEmpty(AuthenticationClient.AuthenticationData.Token))
                    await AuthenticationClient.AuthenticateAsync();
                else
                    await AuthenticationClient.RefreshAsync();
            }

            if (!AuthenticationClient.AuthenticationData.Authenticated)
                throw new Exception("Client not authenticated.");

            var url = new Url(AuthenticationClient.Credentials.ApiUrl)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.ContentType), AuthenticationClient.Credentials.ContentType)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.AcceptLanguage), AuthenticationClient.Credentials.AcceptLanguage)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.XBlkUserAgent), AuthenticationClient.Credentials.XBlkUserAgent)
                .WithOAuthBearerToken(AuthenticationClient.AuthenticationData.Token);

            return url;
        }

        public async Task<ClientResponse<T>> GetErrorsAsync<T>(FlurlHttpException exception)
        {
            var clientResponse = new ClientResponse<T>()
            {
                StatusCode = exception.Call.HttpResponseMessage.StatusCode,
                Success = exception.Call.HttpResponseMessage.IsSuccessStatusCode
            };

            try
            {
                clientResponse.Errors = (await exception.GetResponseJsonAsync<ClientResponse<T>>())?.Errors;
            }
            catch (Exception) {}

            return clientResponse;
        }

        public async Task<PaginationModel<T>> GetPaginationAsync<T>(IFlurlResponse response)
        {
            // TODO: Check how to obtain the "meta" (pagination object) from response.
            //var pagination = response.ResponseMessage.Headers.GetValues("meta");

            return new PaginationModel<T>();
        }
    }
}