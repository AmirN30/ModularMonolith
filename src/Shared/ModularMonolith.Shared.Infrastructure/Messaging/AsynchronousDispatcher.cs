using System.Threading.Tasks;
using ModularMonolith.Shared.Abstractions.Messaging;

namespace ModularMonolith.Shared.Infrastructure.Messaging
{
    internal sealed class AsynchronousDispatcher : IAsynchronousDispatcher
    {
        private readonly IMessageChannel _channel;

        public AsynchronousDispatcher(IMessageChannel channel)
        {
            _channel = channel;
        }

        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage
        {
            await _channel.Writer.WriteAsync(message);
        }
    }
}