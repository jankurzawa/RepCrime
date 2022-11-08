namespace RepCrime.EmailService.API.Services
{
    public interface IEmailSender
    {
        void SendEmail(CreateCrimeDTO crimeDTO);
    }
}