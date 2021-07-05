using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class UserCreateRequest
    {
        [Required]
        [MinLength(1)]
        public string PartnerId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}