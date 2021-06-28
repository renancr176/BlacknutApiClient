using System;
using System.ComponentModel.DataAnnotations;

namespace TesteApi.Models.Requests
{
    public class PagedRequest
    {
        [Range(1, Double.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(1, 100)]
        public int Limit { get; set; } = 50;
    }

    public class PagedRequest<T> : PagedRequest
    {
        public T Data { get; set; }
    }
}