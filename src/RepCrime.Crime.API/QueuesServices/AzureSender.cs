namespace RepCrime.Crime.API.QueuesServices
{
    public class AzureSender : IPublisher
    {
        private IConfiguration _configuration;

        public AzureSender(IConfiguration configuration)
            => _configuration = configuration;

        public async void SendMessage<T>(T message)
            => await (new QueueClient(_configuration["ConectionStringAzureQueue"], _configuration["Queues:LawEnforecementToEmailService"]))
                .SendMessageAsync(JsonConvert.SerializeObject(message));
    }
}
