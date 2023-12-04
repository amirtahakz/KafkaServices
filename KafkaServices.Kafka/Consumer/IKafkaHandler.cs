using System.Threading.Tasks;

namespace KafkaServices.Kafka.Consumer
{
    public interface IKafkaHandler<TKey, TValue>
    {
        Task HandleAsync(TKey key, TValue value);
    }
}