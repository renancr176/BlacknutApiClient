using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
using Flurl.Http;

namespace BlacknutApiClient.Services
{
    public class StreamService : IStreamService
    {
        private readonly IBlacknutApiClient _client;

        public StreamService(IBlacknutApiClient client)
        {
            _client = client;
        }

        public async Task<ClientResponseModel<PaginationModel<StreamModel>>> GetAsync(int page = 1, int limit = 50, Guid? userId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var response = new ClientResponseModel<PaginationModel<StreamModel>>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/streams")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .SetQueryParams(new { page, limit, userId, startDate, endDate })
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

        public async Task<ClientResponseModel<StreamModel>> GetByIdAsync(Guid id)
        {
            var response = new ClientResponseModel<StreamModel>();

            try
            {
                response.Data = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/stream/{id}")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .GetJsonAsync<StreamModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<StreamModel>(e);
            }

            return response;
        }
    }
}