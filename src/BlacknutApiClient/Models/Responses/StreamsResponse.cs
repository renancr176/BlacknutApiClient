using System.Collections.Generic;

namespace BlacknutApiClient.Models.Responses
{
    public class StreamsResponse : PaginationResponse
    {
        public IEnumerable<StreamModel> Streams { get; set; }
    }
}