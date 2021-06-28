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
    public class StreamService : IStreamService
    {
        private readonly IBlacknutApiClient _client;

        public StreamService(IBlacknutApiClient client)
        {
            _client = client;
        }

        public async Task<ClientResponse<PaginationModel<StreamModel>>> GetAsync(PagedRequest<StreamGetRequest> request)
        {
            var response = new ClientResponse<PaginationModel<StreamModel>>();

            try
            {
                var requestBuild = (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/streams")
                    .SetQueryParams(((PagedRequest)request).ParseQueryParams());

                if (request.Data != null)
                    requestBuild.SetQueryParams(request.Data.ParseQueryParams());

                var result =  await requestBuild.GetAsync();

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

        public async Task<ClientResponse<StreamModel>> GetByIdAsync(Guid id)
        {
            var response = new ClientResponse<StreamModel>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/stream/{id}")
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