using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Around_VietNam_Web.Services
{

    // Configure mailing service, inject value from appsettings.json
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
    // Send mail service
    public class SendMailService : IEmailSender
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<SendMailService> _logger;
        // _mailSettings is injected via system service
        public SendMailService(IOptions<MailSettings> mailSettings, ILogger<SendMailService> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
            logger.LogInformation("Create SendMailService");
        }
      
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            // Set the sender and from addresses of the email message
            message.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
            message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            // Sets the recipient address of the email message
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            // Set the body of email message
            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            // Using SmtpClient's MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(message);
            }catch(Exception ex)
            {
                // Email sending failed, email content will be saved to MailsSave folder
                System.IO.Directory.CreateDirectory("MailsSave");
                var emailSaveFile = string.Format(@"MailsSave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailSaveFile);

                _logger.LogInformation("Error sending mail, save at - ", emailSaveFile);
                _logger.LogError(ex.Message);
            }
            smtp.Disconnect(true);
            _logger.LogInformation("Send mail to: " + email);
        }
    }
}

    
