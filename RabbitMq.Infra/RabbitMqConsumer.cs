using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMq.Infra;

public class RabbitMqConsumer(IConnectionFactory connectionFactory)
{
    public void ConsumeMessages()
    {
        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue:
            "my_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();

            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Received message: {message}");

            channel.BasicAck(deliveryTag:
                ea.DeliveryTag, multiple: false);
        };

        channel.BasicConsume(queue: "my_queue", autoAck: false, consumer: consumer);
    }
}