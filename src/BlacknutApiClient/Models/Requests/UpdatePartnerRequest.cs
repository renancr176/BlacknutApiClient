using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class UpdatePartnerRequest
    {
        [Required]
        public string OldPartnerId { get; set; }
        [Required]
        public string NewPartnerId { get; set; }
    }
}