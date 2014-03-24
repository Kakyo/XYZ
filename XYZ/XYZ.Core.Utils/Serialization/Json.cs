using Newtonsoft.Json;

namespace XYZ.Serialization
{
    public static class Json
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static string From(object obj)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }
        public static T To<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
