
namespace BattleshipKata.Messaging {
    public interface MessageBus {

        void SubscribeToMessagesOfType<T>(MessagesSubscriber subscriber) where T : Message;
        void Publish<T>(T message) where T : Message;   
    }
}