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
        public IFlurlRequest BaseUrl => GetBaseUrl();

        public BlacknutApiClient(BlacknutCredentials credentials)
        {
            AuthenticationClient = new AuthenticationClient(credentials);
        }

        private IFlurlRequest GetBaseUrl()
        {
            if (!AuthenticationClient.AuthenticationData.Authenticated)
            {
                if(string.IsNullOrEmpty(AuthenticationClient.AuthenticationData.Token))
                    Task.WaitAll(AuthenticationClient.AuthenticateAsync());
                else
                    Task.WaitAll(AuthenticationClient.RefreshAsync());
            }

            if (!AuthenticationClient.AuthenticationData.Authenticated)
                throw new Exception("Client not authenticated.");

            var url = new Url(AuthenticationClient.Credentials.ApiUrl)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.ContentType), AuthenticationClient.Credentials.ContentType)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.AcceptLanguage), AuthenticationClient.Credentials.AcceptLanguage)
                .WithHeader(ReflectionExtensions.GetPropertyDisplayName<BlacknutCredentials>(i => i.XBlkUserAgent), AuthenticationClient.Credentials.XBlkUserAgent);

            return url;
        }

        public async Task<ClientResponse<T>> GetErrorsAsync<T>(FlurlHttpException exception)
        {
            IEnumerable<ErrorResponse> erros = new List<ErrorResponse>();

            try
            {
                erros = await exception.GetResponseJsonAsync<IEnumerable<ErrorResponse>>();
            }
            catch (Exception) {}

            return new ClientResponse<T>()
            {
                StatusCode = exception.Call.HttpResponseMessage.StatusCode,
                Success = exception.Call.HttpResponseMessage.IsSuccessStatusCode,
                Erros = erros
            };
        }

        public async Task<PaginationModel<T>> GetPaginationAsync<T>(IFlurlResponse response)
        {
            // TODO: Check how to obtain the "meta" (pagination object) from response.
            //var pagination = response.ResponseMessage.Headers.GetValues("meta");

            return new PaginationModel<T>();
        }
    }
}