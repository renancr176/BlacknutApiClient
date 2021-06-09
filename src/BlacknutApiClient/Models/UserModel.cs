using System;
using BlacknutApiClient.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlacknutApiClient.Models
{
    public class UserModel
    {
        /// <summary>
        /// Unique ID of the user
        /// </summary>
        public Guid Uuid { get; set; }
        /// <summary>
        /// Unique Partner ID
        /// </summary>
        public Guid? PartnetID { get; set; }
        /// <summary>
        /// Creation date of the subscription
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Informations about user profile:{Generic, Kids, PreTeens, Teens}
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserProfileEnum UserProfile { get; set; }
        /// <summary>
        /// If yes, it is the main account. Otherwise, it is asub profile
        /// </summary>
        public bool Master { get; set; }
        /// <summary>
        /// If master is false: Unique ID of the mainaccount.
        /// </summary>
        public Guid? MasterUuid { get; set; }
    }
}