using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
using BlacknutApiClient.Models.Requests;
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

        public async Task<ClientResponseModel<PaginationModel<GameModel>>> GetAsync(PagedRequest request)
        {
            var response = new ClientResponseModel<PaginationModel<GameModel>>();

            try
            {
                var result = await _client.BaseUrl.AppendPathSegment("/api/v1/partner/games")
                    .WithOAuthBearerToken(_client.AuthenticationClient.AuthenticationData.Token)
                    .SetQueryParams(request.ParseQueryParams())
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

        public async Task<ClientResponseModel<GameModel>> GetByIdAsync(Guid id)
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