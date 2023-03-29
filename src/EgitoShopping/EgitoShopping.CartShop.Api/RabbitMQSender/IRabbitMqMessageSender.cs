using EgitoShopping.MessageBus;

namespace EgitoShopping.CartShop.Api.RabbitMQSender
{
    public interface IRabbitMqMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
