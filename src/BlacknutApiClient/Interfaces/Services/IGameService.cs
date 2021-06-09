using System;
using System.Threading.Tasks;
using BlacknutApiClient.Models;

namespace BlacknutApiClient.Interfaces.Services
{
    public interface IGameService
    {
        /// <summary>
        /// List existing games
        /// </summary>
        /// <param name="page">This is the page number you want to retrieve</param>
        /// <param name="limit">This is the number of users per page</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<PaginationModel<GameModel>>> GetAsync(int page = 1, int limit = 50);
        /// <summary>
        /// Get one particular game
        /// </summary>
        /// <param name="id">This is the Blacknut game UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<GameModel>> GetById(Guid id);
    }
}