using System.Collections.Generic;
using System.Net;

namespace BlacknutApiClient.Models
{
    public class ClientResponseModel<T>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public IEnumerable<ResponseErrorModel> Erros { get; set; } = new List<ResponseErrorModel>();
    }
}