using System;
using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class UpdatePartnerRequest
    {
        [Required]
        public Guid OldPartnetId { get; set; }
        [Required]
        public Guid NewPartnerId { get; set; }
    }
}