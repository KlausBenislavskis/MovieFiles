using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MovieFiles.Adapters
{
    public class MovieApiUtil
    {
        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };


        public static T? ConvertApiMessage<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response, jsonSettings);
        }
    }
}