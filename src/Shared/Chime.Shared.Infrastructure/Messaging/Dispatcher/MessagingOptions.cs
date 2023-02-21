namespace Chime.Shared.Infrastructure.Messaging.Dispatcher;

// https://www.hangfire.io/
internal sealed class MessagingOptions
{
    public bool UseAsyncDispatcher { get; set; }
}