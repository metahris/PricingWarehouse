using System.Text.Json;

namespace PricingWarehouse.Infrastructure
{
    public interface IObjectSerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string obj);
        T Clone<T>(T source);
    }
    public class ObjectSerializer : IObjectSerializer
    {
        public string Serialize<T>(T obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj);
            }
            catch (Exception exc)
            {
                throw new Exception($"Failed to serialize object of type {typeof(T).FullName}", exc);
            }
        }
        public T Deserialize<T>(string obj)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(obj);
            }
            catch (Exception exc)
            {

                throw new Exception($"Failed to deserialize object of type {typeof(T).FullName}", exc);
            }
        }
        public T Clone<T>(T source)
        {
            var serialized = Serialize(source);
            return Deserialize<T>(serialized);
        }
    }
}

