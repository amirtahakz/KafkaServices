# KafkaServices
# Usage In Consumers:

# IN Your Program.cs:
#region Consumers Configs

services.AddKafkaConsumer<string, User, UserCreatedHandler>(p =>
{
    p.Topic = "users";
    p.GroupId = "users_group";
    p.BootstrapServers = "localhost:9092";
});
#endregion

# Add Handler & Your Model:

public class UserCreatedHandler : IKafkaHandler<string, User>
    {
        public async Task HandleAsync(string key, User value)
        {
            Console.WriteLine(value);
        }
    }

    
    
# Usage In Producers:

# IN Your Program.cs:
#region Producers Config
services.AddKafkaMessageBus();
services.AddKafkaProducer<string, User>(p =>
{
    p.Topic = "users";
    p.BootstrapServers = "localhost:9092";
});
#endregion

# In Your Handler:
private readonly IKafkaMessageBus<string, User> _bus;

public HomeController(IKafkaMessageBus<string, User> bus)
{
    _bus = bus;
}

_bus.PublishAsync(model.Email, model);

