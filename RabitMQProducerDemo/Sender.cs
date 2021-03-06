using RabbitMQ.Client;
using System;
using System.Text;

namespace RabitMQProducerDemo
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "HelloTestQ1", durable: false, exclusive: false, autoDelete: false, arguments: null);
                string message = "Hello World";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "HelloTestQ1",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("[x] sent  {0}", message);
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
