using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
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

        public async Task<ClientResponseModel<PaginationModel<GameModel>>> GetAsync(int page = 1, int limit = 50)
        {
            var response = new ClientResponseModel<PaginationModel<GameModel>>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/games")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .SetQueryParams(new { page, limit })
                    .GetAsync();

                response.Data = await _client.GetPaginationAsync<GameModel>(result);
                var users = await result.GetJsonAsync<IEnumerable<GameModel>>();
                response.Data.Data = users;
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<PaginationModel<GameModel>>(e);
            }

            return response;
        }

        public async Task<ClientResponseModel<GameModel>> GetById(Guid id)
        {
            var response = new ClientResponseModel<GameModel>();

            try
            {
                response.Data = await _client.BaseUrl.AppendPathSegment($"/api/v1/partner/game/{id}")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .GetJsonAsync<GameModel>();
            }
            catch (FlurlHttpException e)
            {
                response = await _client.GetErrorsAsync<GameModel>(e);
            }

            return response;
        }
    }
}