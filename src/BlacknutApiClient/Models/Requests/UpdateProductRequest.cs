using System;
using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class UpdateProductRequest
    {
        [Required]
        public Guid OldProductId { get; set; }
        [Required]
        public Guid NewProductId { get; set; }
    }
}