using Confluent.Kafka;

namespace KafkaServices.Kafka.Consumer.Configs
{
    public class KafkaConsumerConfig<TKey, TValue> : ConsumerConfig
    {
        public string Topic { get; set; }
        public bool IsMessagePack { get; set; } = false;
        public KafkaConsumerConfig()
        {
            AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            EnableAutoOffsetStore = false;
        }
    }
}