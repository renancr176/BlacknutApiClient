using System;
using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class SubscriptionAttachRequest
    {
        [Required]
        public Guid UserId { get; set; }
    }
}