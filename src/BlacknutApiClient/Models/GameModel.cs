using System;
using System.Collections.Generic;
using BlacknutApiClient.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlacknutApiClient.Models
{
    public class GameModel
    {
        /// <summary>
        /// Unique ID of the game
        /// </summary>
        public string GlobalId { get; set; }
        /// <summary>
        /// Unique ID of the game
        /// </summary>
        public string Uuid { get; set; }
        /// <summary>
        /// Creation date of the game
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// List of supported controllers.
        /// </summary>
        public IEnumerable<string> Controllers { get; set; } = new List<string>();
        /// <summary>
        /// The developer name of the game
        /// </summary>
        public string Developer { get; set; }
        /// <summary>
        /// List of supported devices:{computer, phone, tablet, tv}
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public IEnumerable<DeviceEnum> Devices { get; set; } = new List<DeviceEnum>();
        
        /// <summary>
        /// List of images describing the game
        /// </summary>
        public IEnumerable<MediaModel> Images { get; set; }
        /// <summary>
        /// True if game is multiplayer
        /// </summary>
        public bool Multiplayer { get; set; }
        /// <summary>
        /// Name of the game
        /// </summary>
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Rating { get; set; }
        public IEnumerable<MediaModel> Videos { get; set; }
    }
}