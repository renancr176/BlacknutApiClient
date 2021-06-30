using System;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models.Requests;
using BlacknutApiClient.Models.Responses;
using Flurl.Http;

namespace BlacknutApiClient.Services
{
    public class GameService : IGameService
    {
        private readonly IBlacknutApiClient _client;

        public GameService(IBlacknutApiClient client)
        {
            _client = client;
        }

        public async Task<ClientResponse<GamesResponse>> GetAsync(PagedRequest request)
        {
            var response = new ClientResponse<GamesResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment("/api/v1/partner/games")
                    .SetQueryParams(request.ParseQueryParams())
                    .GetJsonAsync<GamesResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<GamesResponse>(e);
            }

            return response;
        }

        public async Task<ClientResponse<GameResponse>> GetByIdAsync(Guid id)
        {
            var response = new ClientResponse<GameResponse>();

            try
            {
                response.Data = await (await _client.GetBaseUrlAsync()).AppendPathSegment($"/api/v1/partner/game/{id}")
                    .GetJsonAsync<GameResponse>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<GameResponse>(e);
            }

            return response;
        }
    }
}