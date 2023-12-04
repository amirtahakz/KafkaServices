using Confluent.Kafka;

namespace KafkaServices.Kafka.Producer.Configs
{
    public class KafkaProducerConfig<TKey, TValue> : ProducerConfig
    {
        public string Topic { get; set; }
    }
}