using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
using Flurl.Http;

namespace BlacknutApiClient.Services
{
    public class UserService : IUserService
    {
        private readonly IBlacknutApiClient _client;

        public UserService(IBlacknutApiClient client)
        {
            _client = client;
        }

        public async Task<ClientResponseModel<PaginationModel<UserModel>>> GetAsync(int page = 1, int limit = 50)
        {
            var response = new ClientResponseModel<PaginationModel<UserModel>>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/users")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .SetQueryParams(new { page_number = page, page_limit = limit })
                    .GetAsync();

                response.Data = await _client.GetPaginationAsync<UserModel>(result);
                var users = await result.GetJsonAsync<IEnumerable<UserModel>>();
                response.Data.Data = users;
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<PaginationModel<UserModel>>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<UserModel>> SearchAsync(Guid partnerId, string email)
        {
            var response = new ClientResponseModel<UserModel>();

            try
            {
                response.Data = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/users/search")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .SetQueryParams(new { partner_id = partnerId, email })
                    .GetJsonAsync<UserModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserModel>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<UserModel>> CreateAsync()
        {
            var response = new ClientResponseModel<UserModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/user")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PostAsync();

                response.Data = await result.GetJsonAsync<UserModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserModel>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<UserModel>> GetByIdAsync(Guid id)
        {
            var response = new ClientResponseModel<UserModel>();

            try
            {
                response.Data = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/user/{id}")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .GetJsonAsync<UserModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserModel>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<UserModel>> UpdatePartnerIdAsync(Guid id, Guid oldPartnerID, Guid newPartnerID)
        {
            var response = new ClientResponseModel<UserModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/user/{id}/updatePartnerID")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PostJsonAsync(new { oldPartnerID, newPartnerID });

                response.Data = await result.GetJsonAsync<UserModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserModel>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<IEnumerable<SubscriptionModel>>> GetSubscriptions(Guid id)
        {
            var response = new ClientResponseModel<IEnumerable<SubscriptionModel>>();

            try
            {
                response.Data = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/user/{id}/subscriptions")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .GetJsonAsync<IEnumerable<SubscriptionModel>>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<IEnumerable<SubscriptionModel>>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<PaginationModel<StreamModel>>> GetStreams(Guid id, int page = 1, int limit = 50)
        {
            var response = new ClientResponseModel<PaginationModel<StreamModel>>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/user/{id}/streams")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .SetQueryParams(new { page_number = page, page_limit = limit })
                    .GetAsync();

                response.Data = await _client.GetPaginationAsync<StreamModel>(result);
                var streams = await result.GetJsonAsync<IEnumerable<StreamModel>>();
                response.Data.Data = streams;
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<PaginationModel<StreamModel>>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<IEnumerable<UserModel>>> GetProfilesAsync(Guid id)
        {
            var response = new ClientResponseModel<IEnumerable<UserModel>>();

            try
            {
                response.Data = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/user/{id}/profiles")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .GetJsonAsync<IEnumerable<UserModel>>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<IEnumerable<UserModel>>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<UserTokenModel>> CreateTokenAsync(Guid id)
        {
            var response = new ClientResponseModel<UserTokenModel>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/user/{id}/token")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .PostAsync();

                response.Data = await result.GetJsonAsync<UserTokenModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserTokenModel>(e);
            }

            return response;
        }
    }
}