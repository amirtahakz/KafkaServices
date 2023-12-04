using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using KafkaServices.Kafka.Producer.Configs;
using Microsoft.Extensions.Options;

namespace KafkaServices.Kafka.Producer
{
    public class KafkaProducer<TKey, TValue> : IDisposable
    {
        private readonly IProducer<TKey, TValue> _producer;
        private readonly string _topic;

        public KafkaProducer(
            IOptions<KafkaProducerConfig<TKey, TValue>> topicOptions,
            IProducer<TKey, TValue> producer)
        {
            _topic = topicOptions.Value.Topic;
            _producer = producer;
        }

        public async Task ProduceAsync(TKey key, TValue value , Headers headers = default)
        {
            var message = new Message<TKey, TValue>
            {
                Key = key,
                Value = value,
                Headers = headers
            };
            await _producer.ProduceAsync(_topic, message);
        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}