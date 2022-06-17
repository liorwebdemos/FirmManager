// inspired by https://stackoverflow.com/a/58331912

using System.Text.Json;

namespace WebApi.DAL.Helpers
{
    public static class JsonHelper
    {
        public static readonly JsonSerializerOptions CustomJsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static T? JsonDeserialize<T>(this string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString, CustomJsonSerializerOptions);
        }
    }
}
