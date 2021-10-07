
namespace BattleshipKata.Messaging {
    public interface MessagesSubscriber {

        void Notify(Message message);
    }
}