using System;

namespace BlacknutApiClient.Models.Requests
{
    public class StreamGetRequest : BaseQueryParamRequest
    {
        public string? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}