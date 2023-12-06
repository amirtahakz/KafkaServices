using System;
using System.Text;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace KafkaServices.Kafka._Utilities
{
    internal sealed class KafkaSerializer<TValue> : ISerializer<TValue>
    {
        public byte[] Serialize(TValue data, SerializationContext context)
        {
            if (typeof(TValue) == typeof(Null))
                return null;

            if (typeof(TValue) == typeof(Ignore))
                throw new NotSupportedException("Not Supported.");

            var json = JsonConvert.SerializeObject(data);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}