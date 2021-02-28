using System.Text.Json;

namespace WebPortal.helpers
{
    public class JsonDeserializeHelper
    {
        public static T ToObject<T>(JsonElement element)
        {
            var json = element.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}