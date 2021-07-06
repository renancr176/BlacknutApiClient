using System;
using System.Text.Json.Serialization;
using BlacknutApiClient.Enums;
using Newtonsoft.Json.Converters;

namespace BlacknutApiClient.Models
{
    public class UserModel
    {
        /// <summary>
        /// Unique ID of the user
        /// </summary>
        public string Uuid { get; set; }
        /// <summary>
        /// Unique Partner ID
        /// </summary>
        public string? PartnerId { get; set; }
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
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public UserProfileEnum UserProfile { get; set; }
        /// <summary>
        /// If yes, it is the main account. Otherwise, it is asub profile
        /// </summary>
        public bool Master { get; set; }
        /// <summary>
        /// If master is false: Unique ID of the mainaccount.
        /// </summary>
        public string? MasterUuid { get; set; }
    }
}