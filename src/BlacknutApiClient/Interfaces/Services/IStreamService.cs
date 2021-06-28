using System;
using System.Threading.Tasks;
using BlacknutApiClient.Models;
using BlacknutApiClient.Models.Requests;

namespace BlacknutApiClient.Interfaces.Services
{
    public interface IStreamService
    {
        /// <summary>
        /// List existing streams
        /// </summary>
        /// <param name="page">This is the page number you want to retrieve</param>
        /// <param name="limit">This is the number of users per page</param>
        /// <param name="userId">
        /// This parameter is optional
        /// This is the Blacknut user UUID
        /// </param>
        /// <param name="startDate">
        /// This parameter is optional
        /// Filters streams started after startDate
        /// </param>
        /// <param name="endDate">
        /// This parameter is optional
        /// Filters streams started before endDate
        /// </param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<PaginationModel<StreamModel>>> GetAsync(PagedRequest<StreamGetRequest> request);
        /// <summary>
        /// Get one particular stream
        /// </summary>
        /// <param name="id">This is the Blacknut stream UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<StreamModel>> GetByIdAsync(Guid id);
    }
}