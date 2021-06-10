using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlacknutApiClient.Models;

namespace BlacknutApiClient.Interfaces.Services
{
    public interface IUserService
    {
        /// <summary>
        /// List all users which have been created with the partner account
        /// </summary>
        /// <param name="page">This is the page number you want to retrieve</param>
        /// <param name="limit">This is the number of users per page</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<PaginationModel<UserModel>>> GetAsync(int page = 1, int limit = 50);
        /// <summary>
        /// Search user
        /// </summary>
        /// <param name="partnerId">This is the Partner subscription ID</param>
        /// <param name="email">This is the user email</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<UserModel>> SearchAsync(Guid partnerId, string email);
        /// <summary>
        /// Create new user
        /// </summary>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<UserModel>> CreateAsync();
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<UserModel>> GetByIdAsync(Guid id);
        /// <summary>
        /// Update user partner Id
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <param name="oldPartnetID">Current partner ID</param>
        /// <param name="newPartnerID">New partner ID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<UserModel>> UpdatePartnerIdAsync(Guid id, Guid oldPartnetID, Guid newPartnerID);
        /// <summary>
        /// Get all subscriptions of a user (active and cancelled)
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<IEnumerable<SubscriptionModel>>> GetSubscriptions(Guid id);
        /// <summary>
        /// Get user streams
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <param name="page">This is the page number you want to retrieve</param>
        /// <param name="limit">This is the count of users per page</param>
        /// <returns></returns>
        Task<ClientResponseModel<PaginationModel<StreamModel>>> GetStreams(Guid id, int page = 1, int limit = 50);
        /// <summary>
        /// Get profiles/subaccounts of a user
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<IEnumerable<UserModel>>> GetProfilesAsync(Guid id);
        /// <summary>
        /// Create a user token for the user.
        /// A user token is necessary to launch a game then.
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<UserTokenModel>> CreateTokenAsync(Guid id);
    }
}