using Newtonsoft.Json;

namespace FoodHome.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson<T>(this ISession session, string key ,List<T> value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static List<T> GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(List<T>) : JsonConvert.DeserializeObject<List<T>>(value);
        }
    }
}
