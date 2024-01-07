using System;
using System.Buffers.Text;
using System.Text;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace KafkaServices.Kafka._Utilities
{
    internal sealed class KafkaDeserializer<TValue> : IDeserializer<TValue>
    {
        public TValue Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {

            if (typeof(TValue) == typeof(Null))
            {
                if (data.Length > 0)
                    throw new ArgumentException("Data Is Null");
                return default;
            }

            if (typeof(TValue) == null)
            {
                if (data.Length > 0)
                    throw new ArgumentException("Data Is Null");
                return default;
            }

            if (typeof(TValue) == typeof(Ignore))
                return default;


            var dataJson = Encoding.UTF8.GetString(data);

            if (typeof(TValue) == typeof(string))
                return (dynamic)dataJson;

            return JsonConvert.DeserializeObject<TValue>(dataJson);
        }
    }

}