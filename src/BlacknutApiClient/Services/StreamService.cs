using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
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

        public async Task<ClientResponse<StreamsResponse>> GetAsync(PagedRequest<StreamGetRequest> request)
        {
            var response = new ClientResponse<StreamsResponse>();

            try
            {
                var requestBuild = (await _client.GetBaseUrlAsync())
                    .AppendPathSegment("/api/v1/partner/streams")
                    .SetQueryParams(((PagedRequest)request).ParseQueryParams());

                if (request.Data != null)
                    requestBuild.SetQueryParams(request.Data.ParseQueryParams());

                response.Data = await requestBuild.GetJsonAsync<StreamsResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<StreamsResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<StreamResponse>> GetByIdAsync(string id)
        {
            var response = new ClientResponse<StreamResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync())
                    .AppendPathSegment($"/api/v1/partner/stream/{id}")
                    .GetJsonAsync<StreamResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<StreamResponse>(e);
            }

            return response;
        }
    }
}