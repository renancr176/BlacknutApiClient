using System;

namespace BlacknutApiClient.Models
{
    public class TokenModel
    {
        /// <summary>
        /// The token
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Refresh token. Useful to generate anew token
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// Date of expiration of the token
        /// </summary>
        public DateTime ExpiresAt { get; set; }
        /// <summary>
        /// Delay of expiration of the userToken
        /// </summary>
        public int ExpiresIn { get; set; }
        /// <summary>
        /// Local date of creation of the token
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public TokenModel()
        {
            CreatedAt = DateTime.Now;
        }
    }
}