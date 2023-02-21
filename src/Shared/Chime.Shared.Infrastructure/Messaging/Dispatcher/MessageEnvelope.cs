using Chime.Shared.Abstractions.Messaging;

namespace Chime.Shared.Infrastructure.Messaging.Dispatcher;

internal record MessageEnvelope(IMessage Message
    // , IMessageContext MessageContext
);