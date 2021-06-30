using System.Collections.Generic;

namespace BlacknutApiClient.Models.Responses
{
    public class GamesResponse : PaginationResponse
    {
        public IEnumerable<GameModel> Games { get; set; }
    }
}