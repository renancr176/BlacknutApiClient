using System;
using System.ComponentModel;

namespace BlacknutApiClient
{
    public class BlacknutCredentials
    {
        private static string defaultXBlkUserAgent = "Blacknut/5.0.0 {0}/1.0.0";
        public static string configSection = "Blacknut";

        public string ApiUrl { get; set; }

        #region Madatory Headers

        [DisplayName("Content-Type")]
        public string ContentType { get; private set; } = "application/json";

        [DisplayName("Accept-Language")]
        public string AcceptLanguage { get; set; } = "en-US";

        [DisplayName("X-Blk-User-Agent")]
        public string XBlkUserAgent { get; set; } = defaultXBlkUserAgent;

        #endregion

        #region Auth Headers

        [DisplayName("X-Blk-Partner-Secret")]
        public string Secret { get; set; }

        #endregion

        public PartnerCredentials PartnerCredentials { get; set; } = new PartnerCredentials();

        public bool Ok()
        {
            if (!string.IsNullOrEmpty(ApiUrl)
                && Uri.IsWellFormedUriString(ApiUrl, UriKind.Absolute)
                && !string.IsNullOrEmpty(AcceptLanguage)
                && !string.IsNullOrEmpty(XBlkUserAgent)
                && XBlkUserAgent != defaultXBlkUserAgent
                && PartnerCredentials.Ok())
                return true;
            return false;
        }
    }

    public class PartnerCredentials
    {
        public string PartnerCode { get; set; }
        public string PartnetSecret { get; set; }

        public bool Ok()
        {
            if (!string.IsNullOrEmpty(PartnerCode)
                && !string.IsNullOrEmpty(PartnetSecret))
                return true;
            return false;
        }
    }
}