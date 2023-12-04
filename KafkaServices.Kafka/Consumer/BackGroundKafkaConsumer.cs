using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using KafkaServices.Kafka._Utilities;
using KafkaServices.Kafka.Consumer.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace KafkaServices.Kafka.Consumer
{
    public class BackGroundKafkaConsumer<TKey, TValue> : BackgroundService
    {
        private readonly KafkaConsumerConfig<TKey, TValue> _config;
        private IKafkaHandler<TKey, TValue> _handler;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BackGroundKafkaConsumer(IOptions<KafkaConsumerConfig<TKey, TValue>> config,
            IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _config = config.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                _handler = scope.ServiceProvider.GetRequiredService<IKafkaHandler<TKey, TValue>>();

                var builder = new ConsumerBuilder<TKey, TValue>(_config).SetValueDeserializer(new KafkaDeserializer<TValue>());

                using (IConsumer<TKey, TValue> consumer = builder.Build())
                {
                    consumer.Subscribe(_config.Topic);

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var result = consumer.Consume(TimeSpan.FromMilliseconds(1000));

                        if (result != null)
                        {
                            await _handler.HandleAsync(result.Message.Key, result.Message.Value);

                            consumer.Commit(result);

                            consumer.StoreOffset(result);
                        }
                    }
                }
            }
        }
    }
}