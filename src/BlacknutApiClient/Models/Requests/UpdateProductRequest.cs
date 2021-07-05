using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class UpdateProductRequest
    {
        [Required]
        public string OldProductId { get; set; }
        [Required]
        public string NewProductId { get; set; }
    }
}