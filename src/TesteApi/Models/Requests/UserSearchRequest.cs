using System;
using System.ComponentModel.DataAnnotations;

namespace TesteApi.Models.Requests
{
    public class UserSearchRequest
    {
        [Required]
        public Guid PartnerId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}