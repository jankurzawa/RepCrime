namespace RepCrime.EmailService.API.BackGroundServices
{
    public class RabbitEmailConsumer : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private IConfiguration _configuration;
        private IEmailSender _emailSender;
        public RabbitEmailConsumer(IConfiguration configuration, IEmailSender emailSender)
        {
            _configuration = configuration;
            _emailSender = emailSender;
            CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_configuration["Queues:LawEnforecementToEmailService"], true, false, false, null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                CreateCrimeDTO crimeDTO = JsonConvert.DeserializeObject<CreateCrimeDTO>(content);
                _emailSender.SendEmail(crimeDTO);
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(_configuration["Queues:LawEnforecementToEmailService"], autoAck: false, consumer: consumer);
            return Task.CompletedTask;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "rabbitmq" };
                _connection = factory.CreateConnection();
            }
            catch (Exception e)
            {
                throw new BadHostNameException("rabbitmq hostname is not correct");
            }
        }
    }
}
