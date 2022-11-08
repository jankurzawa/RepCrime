namespace RepCrime.Crime.API.QueuesServices
{
    public class RabbitSender : IPublisher
    {
        private IConnection _connection;
        private IConfiguration _configuration;

        public RabbitSender(IConfiguration configuration)
        {
            CreateConnection();
            _configuration = configuration;
        }
        public void SendMessage<T>(T message)
        {
            if (_connection == null) CreateConnection(); 
            using (var channel = _connection.CreateModel())
            {
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish("", _configuration["Queues:LawEnforecementToEmailService"], null, body);
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "rabbitmq" };
                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                throw new BadHostNameException("rabbitmq hostname is not correct");
            }
        }
    }
}
