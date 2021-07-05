using System.Collections.Generic;

namespace BlacknutApiClient.Models.Responses
{
    public class ProfilesResponse
    {
        public IEnumerable<UserModel> Profiles { get; set; }
    }
}