using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class UserSearchRequest : BaseQueryParamRequest
    {
        public string PartnerId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}