using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class UpdatePartnerRequest
    {
        [Required]
        public string OldPartnetId { get; set; }
        [Required]
        public string NewPartnerId { get; set; }
    }
}