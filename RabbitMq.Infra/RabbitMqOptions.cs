using RabbitMQ.Client;
using System;

namespace RabbitMq.Infra;

public class RabbitMqOptions
{
    public RabbitMqOptions(string? hostName, string? userName, string? password)
    {
        HostName = hostName;
        UserName = userName;
        Password = password;
    }
    public RabbitMqOptions() { }

    public string? HostName { get; set; }
    public int Port { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}