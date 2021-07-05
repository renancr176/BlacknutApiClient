using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class SubscriptionCreateRequest
    {
        /// <summary>
        /// This is the product ID of the Blacknut plan
        /// </summary>
        [Required]
        public string ProductID { get; set; }
        /// <summary>
        /// This parameter is optional
        /// This is the Blacknut user UUID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// This parameter is optional
        /// This is the partner subscription ID
        /// </summary>
        public string PartnerID { get; set; }
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
    }
}