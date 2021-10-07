using System;
using System.Collections.Generic;

namespace BattleshipKata.Messaging {
    public class InMemoryMessageBus : MessageBus {

        private Dictionary<Type, List<MessagesSubscriber>> messageSubscribers = new Dictionary<Type, List<MessagesSubscriber>>();

        public void SubscribeToMessagesOfType<T>(MessagesSubscriber subscriber) where T : Message {
            if (messageSubscribers.ContainsKey(typeof(T))) {
                messageSubscribers[typeof(T)].Add(subscriber);
            } else {
                messageSubscribers[typeof(T)] = new List<MessagesSubscriber> { subscriber };
            }
        }

        public void Publish<T>(T message) where T : Message {
            if (messageSubscribers.ContainsKey(message.GetType())) {
                messageSubscribers[message.GetType()].ForEach(subscriber => {
                    subscriber.Notify(message);
                });
            }
        }
    }
}