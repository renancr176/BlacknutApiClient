using System;
using BlacknutApiClient.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlacknutApiClient.Models
{
    public class MediaModel
    {
        /// <summary>
        /// Name of the media
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Creation date of the media
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Media kind: {main, background, snapshot, hero...} ​(Only available for images)
        /// This list is regularly updated.
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// Media format: {jpeg, png, gif, mp4}
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FormatEnum Format { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Url { get; set; }
    }
}