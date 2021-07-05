using System.Threading.Tasks;
using BlacknutApiClient.Models.Requests;
using BlacknutApiClient.Models.Responses;

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
        /// <see cref="UsersResponse"/>
        Task<ClientResponse<UsersResponse>> GetAsync(PagedRequest request);
        /// <summary>
        /// Search user
        /// </summary>
        /// <param name="partnerId">This is the Partner subscription ID</param>
        /// <param name="email">This is the user email</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="UserResponse"/>
        Task<ClientResponse<UserResponse>> SearchAsync(UserSearchRequest request);
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="UserResponse"/>
        Task<ClientResponse<UserResponse>> CreateAsync(UserCreateRequest request);
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="UserResponse"/>
        Task<ClientResponse<UserResponse>> GetByIdAsync(string id);
        /// <summary>
        /// Update user partner Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="UserResponse"/>
        Task<ClientResponse<UserResponse>> UpdatePartnerIdAsync(string id, UpdatePartnerRequest request);
        /// <summary>
        /// Get all subscriptions of a user (active and cancelled)
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionsResponse"/>
        Task<ClientResponse<SubscriptionsResponse>> GetSubscriptionsAsync(string id);
        /// <summary>
        /// Get user streams
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <param name="page">This is the page number you want to retrieve</param>
        /// <param name="limit">This is the count of users per page</param>
        /// <returns>ClientResponse</returns>
        /// <see cref="SubscriptionsResponse"/>
        Task<ClientResponse<StreamsResponse>> GetStreamsAsync(string id, PagedRequest request);
        /// <summary>
        /// Get profiles/subaccounts of a user
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponse<UsersResponse>> GetProfilesAsync(string id);
        /// <summary>
        /// Create a user token for the user.
        /// A user token is necessary to launch a game then.
        /// </summary>
        /// <param name="id">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponse<UserTokenResponse>> CreateTokenAsync(string id);
    }
}