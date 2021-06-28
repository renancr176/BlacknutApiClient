using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlacknutApiClient.Models.Requests
{
    public class PagedRequest : BaseQueryParamRequest
    {
        [Range(1, Double.MaxValue)]
        [DefaultValue(1)]
        public int Page { get; set; } = 1;
        [Range(1, 100)]
        [DefaultValue(50)]
        public int Limit { get; set; } = 50;
    }

    public class PagedRequiedDataRequest<T> : PagedRequest
    {
        [Required]
        public T Data { get; set; }
    }

    public class PagedRequest<T> : PagedRequest
    {
        public T? Data { get; set; }
    }
}