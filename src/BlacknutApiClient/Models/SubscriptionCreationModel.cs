using System;

namespace BlacknutApiClient.Models
{
    public class SubscriptionCreationModel
    {
        /// <summary>
        /// This is the product ID of the Blacknut plan
        /// </summary>
        public Guid ProductID { get; set; }
        /// <summary>
        /// This parameter is optiona
        /// This is the Blacknut user UUID
        /// </summary>
        public Guid? UserID { get; set; }
        /// <summary>
        /// This parameter is optional
        /// This is the partner subscription ID
        /// </summary>
        public Guid? PartnerID { get; set; }
        /// <summary>
        /// This parameter is optional
        /// This is the customer redemption code
        /// </summary>
        public string RedemptionCode { get; set; }
        /// <summary>
        /// This parameter is optional
        /// This is the URL that will be called as an HTTP POST request without body by Blacknut Backend after subscription is redeemed
        /// </summary>
        public string CallbackURL { get; set; }

        public SubscriptionCreationModel(Guid productId)
        {
            ProductID = productId;
        }
    }
}