using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BlacknutApiClient.Models.Requests
{
    public class UserCreateRequest
    {
        [Required]
        [MinLength(1)]
        public string PartnerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}