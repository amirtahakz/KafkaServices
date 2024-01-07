using MessagePack.Resolvers;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaServices.Kafka._Utilities
{
    public static class ExtentionMessagePack
    {
        public static TValue Deserialize<TValue>(byte[] data)
        {
            var resolver = CompositeResolver.Create(
                                    NativeDateTimeResolver.Instance,
                                    StandardResolver.Instance,
                                    DynamicEnumResolver.Instance,
                                    DynamicUnionResolver.Instance,
                                    DynamicObjectResolverAllowPrivate.Instance
                                   );
            var options = new MessagePackSerializerOptions(resolver); // MessagePackSerializerOptions.Standard.WithResolver(resolver);

            return MessagePackSerializer.Deserialize<TValue>(data, options: MessagePackSerializerOptions.Standard);
        }
    }
}
