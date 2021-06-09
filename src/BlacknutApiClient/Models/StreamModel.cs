using System;
using BlacknutApiClient.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlacknutApiClient.Models
{
    public class StreamModel
    {
        /// <summary>
        /// Unique ID of the launched game
        /// </summary>
        public Guid GameId { get; set; }
        /// <summary>
        /// Unique ID of the launched game
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Unique ID of the launched game
        /// </summary>
        public string Game { get; set; }
        /// <summary>
        /// Duration of the stream
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// End date of the stream
        /// </summary>
        public DateTime? EndedAt { get; set; }
        /// <summary>
        /// Device type used for the stream:{computer, phone, tablet, tv}
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DeviceEnum Device { get; set; }
        /// <summary>
        /// Stream provider name
        /// </summary>
        public string Provider { get; set; }
        /// <summary>
        /// Stream status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// UUID of the user that started the stream
        /// </summary>
        public Guid UserUuid { get; set; }
        /// <summary>
        /// Email of the user that started the stream
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// Name of the user that started the stream
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Delay before the stream started
        /// </summary>
        public int WaitDuration { get; set; }
    }
}