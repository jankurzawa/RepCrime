namespace RepCrime.EmailService.API.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
            => _emailConfig = emailConfig;

        public void SendEmail(CreateCrimeDTO crimeDTO)
            => Send(CreateEmailMessage(CreateMessageToSend(crimeDTO)));

        private EmailMessage CreateMessageToSend(CreateCrimeDTO crimeDTO)
            => new EmailMessage(
                new string[] { crimeDTO.Email },
                "Crime Report - Answer",
                $"We received your report.\nDetails: \n" +
                $"Date: {crimeDTO.Date}\n" +
                $"Address: {crimeDTO.Address}\n" +
                $"Type: {crimeDTO.Type}\n" +
                $"Description: {crimeDTO.Description}\n" +
                $"\nWe are thank you for keep world safe :)");

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    throw new CannotSendEmailException($"Cannot send email '{mailMessage.Subject}' to '{mailMessage.To}'.");
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
