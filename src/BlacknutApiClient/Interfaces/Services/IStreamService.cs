using System.Threading.Tasks;
using BlacknutApiClient.Models.Requests;
using BlacknutApiClient.Models.Responses;

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
        /// <see cref="StreamsResponse"/>
        Task<ClientResponse<StreamsResponse>> GetAsync(PagedRequest<StreamGetRequest> request);
        /// <summary>
        /// Get one particular stream
        /// </summary>
        /// <param name="id">This is the Blacknut stream UUID</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="StreamResponse"/>
        Task<ClientResponse<StreamResponse>> GetByIdAsync(string id);
    }
}