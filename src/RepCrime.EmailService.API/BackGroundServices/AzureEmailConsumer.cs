namespace RepCrime.EmailService.API.BackGroundServices
{
    public class AzureEmailConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private IEmailSender _emailSender;
        public AzureEmailConsumer(IConfiguration configuration, IEmailSender emailSender)
        {
            _configuration = configuration;
            _emailSender = emailSender;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var _queueClient = new QueueClient(_configuration["ConectionStringAzureQueue"], _configuration["Queues:LawEnforecementToEmailService"]);
            while (!stoppingToken.IsCancellationRequested)
            {
                var queueMessage = await _queueClient.ReceiveMessageAsync();
                if (queueMessage.Value != null)
                {
                    CreateCrimeDTO crimeDTO = JsonConvert.DeserializeObject<CreateCrimeDTO>(queueMessage.Value.MessageText);
                    _emailSender.SendEmail(crimeDTO);
                    await _queueClient.DeleteMessageAsync(queueMessage.Value.MessageId, queueMessage.Value.PopReceipt);
                }
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}
