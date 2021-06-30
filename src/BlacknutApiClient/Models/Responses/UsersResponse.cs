using System.Collections.Generic;

namespace BlacknutApiClient.Models.Responses
{
    public class UsersResponse : PaginationResponse
    {
        public IEnumerable<UserModel> Users { get; set; }
    }
}