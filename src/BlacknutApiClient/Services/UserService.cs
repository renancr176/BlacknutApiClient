using System;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
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

        public async Task<ClientResponse<UsersResponse>> GetAsync(PagedRequest request)
        {
            var response = new ClientResponse<UsersResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment("/api/v1/partner/users")
                    .SetQueryParams(request.ParseQueryParams())
                    .GetJsonAsync<UsersResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UsersResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserResponse>> SearchAsync(UserSearchRequest request)
        {
            var response = new ClientResponse<UserResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment("/api/v1/partner/users/search")
                    .SetQueryParams(request.ParseQueryParams())
                    .GetJsonAsync<UserResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserResponse>> CreateAsync()
        {
            var response = new ClientResponse<UserResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment("/api/v1/partner/user")
                    .PostAsync();

                response.Data = await result.GetJsonAsync<UserResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserResponse>> GetByIdAsync(Guid id)
        {
            var response = new ClientResponse<UserResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment($"/api/v1/partner/user/{id}")
                    .GetJsonAsync<UserResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserResponse>> UpdatePartnerIdAsync(Guid id, UpdatePartnerRequest request)
        {
            var response = new ClientResponse<UserResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment($"/api/v1/partner/user/{id}/updatePartnerID")
                    .PostJsonAsync(request);

                response.Data = await result.GetJsonAsync<UserResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<SubscriptionsResponse>> GetSubscriptionsAsync(Guid id)
        {
            var response = new ClientResponse<SubscriptionsResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment($"/api/v1/partner/user/{id}/subscriptions")
                    .GetJsonAsync<SubscriptionsResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<SubscriptionsResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<StreamsResponse>> GetStreamsAsync(Guid id, PagedRequest request)
        {
            var response = new ClientResponse<StreamsResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment($"/api/v1/partner/user/{id}/streams")
                    .GetJsonAsync<StreamsResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<StreamsResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UsersResponse>> GetProfilesAsync(Guid id)
        {
            var response = new ClientResponse<UsersResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment($"/api/v1/partner/user/{id}/profiles")
                    .GetJsonAsync<UsersResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UsersResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<UserTokenResponse>> CreateTokenAsync(Guid id)
        {
            var response = new ClientResponse<UserTokenResponse>();

            try
            {
                var result = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment($"/api/v1/partner/user/{id}/token")
                    .PostAsync();

                response.Data = await result.GetJsonAsync<UserTokenResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<UserTokenResponse>(e);
            }

            return response;
        }
    }
}