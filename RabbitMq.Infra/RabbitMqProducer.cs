using System.Text;
using RabbitMQ.Client;

namespace RabbitMq.Infra;

public class RabbitMqProducer(IConnectionFactory connectionFactory)
{
    public void PublishMessage(string message)
    {
        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();


        channel.QueueDeclare(queue:
            "my_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "", routingKey: "my_queue",
            basicProperties: null, body:
            body);

        Console.WriteLine($" [x] Enviado: {message}");
    }
}