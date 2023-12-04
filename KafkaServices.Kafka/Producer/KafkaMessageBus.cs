using Confluent.Kafka;
using System.Threading.Tasks;

namespace KafkaServices.Kafka.Producer
{
    public class KafkaMessageBus<TKey, TValue> : IKafkaMessageBus<TKey, TValue>
    {
        public readonly KafkaProducer<TKey, TValue> _producer;
        public KafkaMessageBus(KafkaProducer<TKey, TValue> producer)
        {
            _producer = producer;
        }
        public async Task PublishAsync(TKey key, TValue message, Headers headers = default)
        {
            await _producer.ProduceAsync(key, message);
        }
    }
}