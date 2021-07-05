using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class UserSearchRequest : BaseQueryParamRequest
    {
        [Required]
        public string PartnerId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}