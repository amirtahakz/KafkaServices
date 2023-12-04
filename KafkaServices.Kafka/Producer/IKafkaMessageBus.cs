using Confluent.Kafka;
using System.Threading.Tasks;

namespace KafkaServices.Kafka.Producer
{
    public interface IKafkaMessageBus<TKey, TValue>
    {
        Task PublishAsync(TKey key, TValue message, Headers headers = default);
    }
}