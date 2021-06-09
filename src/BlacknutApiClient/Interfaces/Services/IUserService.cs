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
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns>ClientResponseModel<PaginationModel<UserModel>></returns>
        Task<ClientResponseModel<PaginationModel<UserModel>>> GetAsync(int page = 1, int limit = 50);
        /// <summary>
        /// Search user
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="email"></param>
        /// <returns>ClientResponseModel<UserModel></returns>
        Task<ClientResponseModel<UserModel>> SearchAsync(string partnerId, string email);
        /// <summary>
        /// Create new user
        /// </summary>
        /// <returns>ClientResponseModel<UserModel></returns>
        Task<ClientResponseModel<UserModel>> CreateAsync();
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientResponseModel<UserModel></returns>
        Task<ClientResponseModel<UserModel>> GetByIdAsync(Guid id);
        /// <summary>
        /// Update user partner Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oldPartnetId"></param>
        /// <param name="newPartnerId"></param>
        /// <returns>ClientResponseModel<UserModel></returns>
        Task<ClientResponseModel<UserModel>> UpdatePartnerIdAsync(Guid userId, Guid oldPartnetId, Guid newPartnerId);
        /// <summary>
        /// Get all subscriptions of a user (active and cancelled)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ClientResponseModel<IEnumerable<SubscriptionModel>></returns>
        Task<ClientResponseModel<IEnumerable<SubscriptionModel>>> GetSubscriptions(Guid userId);
        /// <summary>
        /// Get user streams
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ClientResponseModel<PaginationModel<StreamModel>>> GetStreams(Guid userId, int page = 1, int limit = 50);
        /// <summary>
        /// Get profiles/subaccounts of a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ClientResponseModel<IEnumerable<UserModel>></returns>
        Task<ClientResponseModel<IEnumerable<UserModel>>> GetProfilesAsync(Guid userId);
        /// <summary>
        /// Create a user token for the user.
        /// A user token is necessary to launch a game then.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ClientResponseModel<UserTokenModel></returns>
        Task<ClientResponseModel<UserTokenModel>> CreateTokenAsync(Guid userId);
    }
}