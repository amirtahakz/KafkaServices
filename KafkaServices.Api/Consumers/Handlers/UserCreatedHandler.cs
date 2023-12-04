using KafkaServices.Api.Consumers.Models;
using KafkaServices.Kafka.Consumer;

namespace KafkaServices.Api.Consumers.Handlers
{
    public class UserCreatedHandler : IKafkaHandler<string, User>
    {
        public async Task HandleAsync(string key, User value)
        {
            Console.WriteLine(value);
        }
    }
}
