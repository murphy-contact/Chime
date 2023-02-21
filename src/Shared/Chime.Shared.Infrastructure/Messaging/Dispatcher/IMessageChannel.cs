using System.Threading.Channels;

namespace Chime.Shared.Infrastructure.Messaging.Dispatcher;

internal interface IMessageChannel
{
    ChannelReader<MessageEnvelope> Reader { get; }
    ChannelWriter<MessageEnvelope> Writer { get; }
}