using System;
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
            string result = string.Empty;
            try
            {
                if (obj != null)
                    result = JsonConvert.SerializeObject(obj, settings);
            }
            catch (Exception ex)
            {
                result = string.Format("Error serializing the instance of {0}", obj.ToString());
            }
            return result;
        }
        public static T To<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
