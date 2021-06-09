﻿using System;
using System.Threading.Tasks;
using BlacknutApiClient.Models;

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
        Task<ClientResponseModel<SubscriptionModel>> CreateAsync(SubscriptionCreationModel model);
        /// <summary>
        /// Get subscription by id
        /// </summary>
        /// <param name="id">This is the Blacknut subscription UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> GetByIdAsync(Guid id);
        /// <summary>
        /// Update an existing subscription from subscription Blacknut UUID.
        /// It will cancel the current subscription and create a new one.
        /// </summary>
        /// <param name="id">This is the current Blacknut subscription UUID</param>
        /// <param name="oldProductID">This is the current product ID subscribed by the user</param>
        /// <param name="newProductID">This is the new product ID to subscribe the user</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> UpdateByIdAsync(Guid id, Guid oldProductID, Guid newProductID);
        /// <summary>
        /// Update an existing subscription from subscription Blacknut UUID.
        /// It will cancel the current subscription and create a new one.
        /// </summary>
        /// <param name="partnerID">This is the Partner subscription ID</param>
        /// <param name="oldProductID">This is the current product ID subscribed by the user</param>
        /// <param name="newProductID">This is the new product ID to subscribe the user</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> UpdateByPartnerIdAsync(Guid partnerID, Guid oldProductID, Guid newProductID);
        /// <summary>
        /// Update an existing subscription from subscription Blacknut UUID.
        /// It will cancel the current subscription and create a new one.
        /// </summary>
        /// <param name="redemptionCode">This is the customer redemption code</param>
        /// <param name="oldProductID">This is the current product ID subscribed by the user</param>
        /// <param name="newProductID">This is the new product ID to subscribe the user</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> UpdateByRedemptionCodeAsync(string redemptionCode, Guid oldProductID, Guid newProductID);
        /// <summary>
        /// Suspend an existing subscription.
        /// </summary>
        /// <param name="id">This is the Blacknut subscription UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> SuspendByIdAsync(Guid id);
        /// <summary>
        /// Suspend an existing subscription.
        /// </summary>
        /// <param name="partnerID">This is the Partner subscription ID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> SuspendByPartnerIdAsync(Guid partnerID);
        /// <summary>
        /// Suspend an existing subscription.
        /// </summary>
        /// <param name="redemptionCode">This is the customer redemption code</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> SuspendByRedemptionCodeAsync(string redemptionCode);
        /// <summary>
        /// Reactivate a suspended subscription.
        /// </summary>
        /// <param name="id">This is the Blacknut subscription UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> ReactivateByIdAsync(Guid id);
        /// <summary>
        /// Reactivate a suspended subscription.
        /// </summary>
        /// <param name="partnerID">This is the Partner subscription ID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> ReactivateByPartnerIdAsync(Guid partnerID);
        /// <summary>
        /// Reactivate a suspended subscription.
        /// </summary>
        /// <param name="redemptionCode">This is the customer redemption code</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> ReactivateByRedemptionCodeAsync(string redemptionCode);
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
        Task<ClientResponseModel<SubscriptionModel>> CancelByIdAsync(Guid id, DateTime? endDate = null);
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
        Task<ClientResponseModel<SubscriptionModel>> CancelByPartnerIdAsync(Guid partnerID, DateTime? endDate = null);
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
        Task<ClientResponseModel<SubscriptionModel>> CancelByRedemptionCodeAsync(string redemptionCode, DateTime? endDate = null);
        /// <summary>
        /// Attach a subscription to a user.
        /// </summary>
        /// <param name="id">This is the Blacknut subscription UUID</param>
        /// <param name="userId">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> AttachByIdAsync(Guid id, Guid userId);
        /// <summary>
        /// Attach a subscription to a user.
        /// </summary>
        /// <param name="partnerID">This is the Partner subscription ID</param>
        /// <param name="userId">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> AttachByPartnerIdAsync(Guid partnerID, Guid userId);
        /// <summary>
        /// Attach a subscription to a user.
        /// </summary>
        /// <param name="redemptionCode">This is the customer current redemption code</param>
        /// <param name="userId">This is the Blacknut user UUID</param>
        /// <returns>ClientResponseModel</returns>
        Task<ClientResponseModel<SubscriptionModel>> AttachByRedemptionCodeAsync(string redemptionCode, Guid userId);
    } 
}