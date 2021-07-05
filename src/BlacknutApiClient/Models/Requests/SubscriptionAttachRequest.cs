using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class SubscriptionAttachRequest
    {
        [Required]
        public string UserId { get; set; }
    }
}