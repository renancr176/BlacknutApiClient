using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace BlacknutApiClient.Models.Responses
{
    public class ClientResponse<T>
    {
        [DefaultValue(HttpStatusCode.OK)]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        [DefaultValue(true)]
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public IEnumerable<ErrorResponse> Errors { get; set; } = new List<ErrorResponse>();
    }
}