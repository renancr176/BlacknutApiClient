using System.Threading.Tasks;
using BlacknutApiClient.Models.Requests;
using BlacknutApiClient.Models.Responses;

namespace BlacknutApiClient.Interfaces.Services
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// Create a new subscription.
        /// If userID is given, the subscription will be attached to this user.
        /// If not, thesubscription will be available for the first user providing the redemptioncode of this subscription.
        /// If partnerID is given, the subscription will be created with this ID.
        /// If redemptionCode is given, the subscription will be created with thiscode.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> CreateAsync(SubscriptionCreateRequest request);
        /// <summary>
        /// Get subscription by id
        /// </summary>
        /// <param name="id">This is the Blacknut subscription UUID</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> GetByIdAsync(string id);

        #region Update product

        /// <summary>
        /// Update an existing subscription from subscription Blacknut UUID.
        /// It will cancel the current subscription and create a new one.
        /// </summary>
        /// <param name="id">This is the current Blacknut subscription UUID</param>
        /// <param name="oldProductID">This is the current product ID subscribed by the user</param>
        /// <param name="newProductID">This is the new product ID to subscribe the user</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> UpdateByIdAsync(string id, UpdateProductRequest request);
        /// <summary>
        /// Update an existing subscription from subscription Blacknut UUID.
        /// It will cancel the current subscription and create a new one.
        /// </summary>
        /// <param name="partnerID">This is the Partner subscription ID</param>
        /// <param name="oldProductID">This is the current product ID subscribed by the user</param>
        /// <param name="newProductID">This is the new product ID to subscribe the user</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> UpdateByPartnerIdAsync(string partnerID, UpdateProductRequest request);
        /// <summary>
        /// Update an existing subscription from subscription Blacknut UUID.
        /// It will cancel the current subscription and create a new one.
        /// </summary>
        /// <param name="redemptionCode">This is the customer redemption code</param>
        /// <param name="oldProductID">This is the current product ID subscribed by the user</param>
        /// <param name="newProductID">This is the new product ID to subscribe the user</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> UpdateByRedemptionCodeAsync(string redemptionCode, UpdateProductRequest request);

        #endregion

        #region Suspend

        /// <summary>
        /// Suspend an existing subscription.
        /// </summary>
        /// <param name="id">This is the Blacknut subscription UUID</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> SuspendByIdAsync(string id);
        /// <summary>
        /// Suspend an existing subscription.
        /// </summary>
        /// <param name="partnerID">This is the Partner subscription ID</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> SuspendByPartnerIdAsync(string partnerID);
        /// <summary>
        /// Suspend an existing subscription.
        /// </summary>
        /// <param name="redemptionCode">This is the customer redemption code</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> SuspendByRedemptionCodeAsync(string redemptionCode);

        #endregion

        #region Reactive

        /// <summary>
        /// Reactivate a suspended subscription.
        /// </summary>
        /// <param name="id">This is the Blacknut subscription UUID</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> ReactivateByIdAsync(string id);
        /// <summary>
        /// Reactivate a suspended subscription.
        /// </summary>
        /// <param name="partnerID">This is the Partner subscription ID</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> ReactivateByPartnerIdAsync(string partnerID);
        /// <summary>
        /// Reactivate a suspended subscription.
        /// </summary>
        /// <param name="redemptionCode">This is the customer redemption code</param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> ReactivateByRedemptionCodeAsync(string redemptionCode);

        #endregion

        #region Cancel

        /// <summary>
        /// Cancel an active subscription from a field.
        /// </summary>
        /// <remarks>If endDate is given, the subscription will be cancelled when the endDate is reached.</remarks>
        /// <param name="id">This is the Blacknut subscription UUID</param>
        /// <param name="endDate">
        /// This parameter is optional
        /// If it is not given, the endDate will be the current date
        /// </param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> CancelByIdAsync(string id, SubscriptionCancelRequest request);
        /// <summary>
        /// Cancel an active subscription from a field.
        /// </summary>
        /// <remarks>If endDate is given, the subscription will be cancelled when the endDate is reached.</remarks>
        /// <param name="partnerID">This is the Blacknut subscription UUID</param>
        /// <param name="endDate">
        /// This parameter is optional
        /// If it is not given, the endDate will be the current date
        /// </param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> CancelByPartnerIdAsync(string partnerID, SubscriptionCancelRequest request);
        /// <summary>
        /// Cancel an active subscription from a field.
        /// </summary>
        /// <remarks>If endDate is given, the subscription will be cancelled when the endDate is reached.</remarks>
        /// <param name="redemptionCode">This is the customer redemption code</param>
        /// <param name="endDate">
        /// This parameter is optional
        /// If it is not given, the endDate will be the current date
        /// </param>
        /// <returns>ClientResponseModel</returns>
        /// <see cref="SubscriptionResponse"/>
        Task<ClientResponse<SubscriptionResponse>> CancelByRedemptionCodeAsync(string redemptionCode, SubscriptionCancelRequest request);

        #endregion
    }
}