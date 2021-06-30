using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BlacknutApiClient.Models.Requests
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class BaseQueryParamRequest
    {
        public Dictionary<string, string> ParseQueryParams()
        {
            var stringParams = JsonConvert.SerializeObject(this, settings: new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(stringParams, new KeyValuePairConverter());
        }
    }
}