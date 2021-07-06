using System;
using System.Text.Json.Serialization;
using BlacknutApiClient.Enums;
using Newtonsoft.Json.Converters;

namespace BlacknutApiClient.Models
{
    public class SubscriptionModel
    {
        /// <summary>
        /// Unique ID of the subscription
        /// </summary>
        public string Uuid { get; set; }
        /// <summary>
        /// Unique Partner ID of the subscription
        /// </summary>
        public string? PartnerId { get; set; }
        /// <summary>
        /// Creation date of the subscription
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Unknow
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// UUID of the user attached to thesubscription
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Description of the subscription plan
        /// </summary>
        public PlanModel Plan { get; set; }
        /// <summary>
        /// Redemption code of the subscription
        /// </summary>
        public string RedemptionCode { get; set; }
        /// <summary>
        /// Start date of the subscription
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date of the subscription.
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Status of the subscription:{Pending, Active, Suspended, Canceled}
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public SubscriptionStatusEnum Status { get; set; }
    }
}