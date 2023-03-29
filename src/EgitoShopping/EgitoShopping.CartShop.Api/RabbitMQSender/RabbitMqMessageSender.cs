using EgitoShopping.MessageBus;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using EgitoShopping.CartShop.Application.DTOs;

namespace EgitoShopping.CartShop.Api.RabbitMQSender
{
    public class RabbitMqMessageSender : IRabbitMqMessageSender
    {
        private readonly IConfiguration _configuration;
        private IConnection _connection;

        public RabbitMqMessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage(BaseMessage baseMessage, string queueName)
        {
            string _hostName = _configuration.GetValue<string>("RabbitMQ:hostName");
            string _password = _configuration.GetValue<string>("RabbitMQ:password");
            string _userName = _configuration.GetValue<string>("RabbitMQ:userName");

            var factory = new ConnectionFactory { 
                HostName = _hostName,
                UserName = _userName,
                Password = _password
            };

            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);

            byte[] body = GetMessageAsByteArray(baseMessage);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }

        private byte[] GetMessageAsByteArray(BaseMessage baseMessage)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize<CheckoutHeaderDTO>((CheckoutHeaderDTO)baseMessage, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }
    }
}
