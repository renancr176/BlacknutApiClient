using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
using BlacknutApiClient.Models.Requests;
using BlacknutApiClient.Models.Responses;
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

        public async Task<ClientResponse<PaginationModel<UserModel>>> GetAsync(PagedRequest request)
        {
            var response = new ClientResponse<PaginationModel<UserModel>>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/users")
                    .SetQueryParams(request.ParseQueryParams())
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

        public async Task<ClientResponse<UserModel>> SearchAsync(UserSearchRequest request)
        {
            var response = new ClientResponse<UserModel>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/users/search")
                    .SetQueryParams(request.ParseQueryParams())
                    .GetJsonAsync<UserModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserModel>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserModel>> CreateAsync()
        {
            var response = new ClientResponse<UserModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/user")
                    .PostAsync();

                response.Data = await result.GetJsonAsync<UserModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserModel>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserModel>> GetByIdAsync(Guid id)
        {
            var response = new ClientResponse<UserModel>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/user/{id}")
                    .GetJsonAsync<UserModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserModel>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserModel>> UpdatePartnerIdAsync(Guid id, UpdatePartnerRequest request)
        {
            var response = new ClientResponse<UserModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/user/{id}/updatePartnerID")
                    .PostJsonAsync(request);

                response.Data = await result.GetJsonAsync<UserModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserModel>(e);
            }

            return response;
        }

        public async Task<ClientResponse<IEnumerable<SubscriptionModel>>> GetSubscriptionsAsync(Guid id)
        {
            var response = new ClientResponse<IEnumerable<SubscriptionModel>>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/user/{id}/subscriptions")
                    .GetJsonAsync<IEnumerable<SubscriptionModel>>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<IEnumerable<SubscriptionModel>>(e);
            }

            return response;
        }

        public async Task<ClientResponse<PaginationModel<StreamModel>>> GetStreamsAsync(Guid id, PagedRequest request)
        {
            var response = new ClientResponse<PaginationModel<StreamModel>>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/user/{id}/streams")
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

        public async Task<ClientResponse<IEnumerable<UserModel>>> GetProfilesAsync(Guid id)
        {
            var response = new ClientResponse<IEnumerable<UserModel>>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/user/{id}/profiles")
                    .GetJsonAsync<IEnumerable<UserModel>>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<IEnumerable<UserModel>>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserTokenModel>> CreateTokenAsync(Guid id)
        {
            var response = new ClientResponse<UserTokenModel>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/user/{id}/token")
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