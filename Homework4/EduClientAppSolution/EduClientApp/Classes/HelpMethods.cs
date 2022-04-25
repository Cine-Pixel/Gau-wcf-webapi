using System.Text.Json;

namespace EduClientApp.Classes
{
    public static class HelpMethods
    {
        public static T Deserialize<T>(string json) where T: new()
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static string SerializeToXml<T>(T source)
        {
            return JsonSerializer.Serialize(source);
        }
    }
}
