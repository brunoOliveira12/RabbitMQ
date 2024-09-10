using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace RabbitMq.Infra;
public class RabbitMqConnectionFactory : IConnectionFactory
{
    private readonly RabbitMqOptions _options;

    public RabbitMqConnectionFactory(IOptions<RabbitMqOptions> options)
    {
        _options = options.Value;
    }

    public IConnection CreateConnection()
    {
        var factory = new ConnectionFactory
        {
            HostName = _options.HostName,
            Port = _options.Port,
            UserName = _options.UserName,
            Password = _options.Password
        };

        return factory.CreateConnection();
    }

    public IAuthMechanismFactory AuthMechanismFactory(IList<string> mechanismNames)
    {
        throw new NotImplementedException();
    }

    public IConnection CreateConnection(string clientProvidedName)
    {
        throw new NotImplementedException();
    }

    public IConnection CreateConnection(IList<string> hostnames)
    {
        throw new NotImplementedException();
    }

    public IConnection CreateConnection(IList<string> hostnames, string clientProvidedName)
    {
        throw new NotImplementedException();
    }

    public IConnection CreateConnection(IList<AmqpTcpEndpoint> endpoints)
    {
        throw new NotImplementedException();
    }

    public IConnection CreateConnection(IList<AmqpTcpEndpoint> endpoints, string clientProvidedName)
    {
        throw new NotImplementedException();
    }

    public IDictionary<string, object> ClientProperties { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public ICredentialsProvider CredentialsProvider { get; set; }
    public ICredentialsRefresher CredentialsRefresher { get; set; }
    public ushort RequestedChannelMax { get; set; }
    public uint RequestedFrameMax { get; set; }
    public TimeSpan RequestedHeartbeat { get; set; }
    public bool UseBackgroundThreadsForIO { get; set; }
    public string VirtualHost { get; set; }
    public Uri Uri { get; set; }
    public string ClientProvidedName { get; set; }
    public TimeSpan HandshakeContinuationTimeout { get; set; }
    public TimeSpan ContinuationTimeout { get; set; }
}