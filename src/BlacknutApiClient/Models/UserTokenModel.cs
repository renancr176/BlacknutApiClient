namespace BlacknutApiClient.Models
{
    public class UserTokenModel
    {
        /// <summary>
        /// User token that must be used by theuser to authenticate himself
        /// </summary>
        public TokenModel UserToken { get; set; }
        /// <summary>
        /// Family token that must be used bythe user to authenticate his family
        /// </summary>
        public TokenModel FamilyToken { get; set; }
    }
}