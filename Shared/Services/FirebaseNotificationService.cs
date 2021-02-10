using Application.DTOs.Notifications;
using Application.DTOs.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MosCore.Application.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosCore.Infrastructure.Shared.Services
{
    public class FirebaseNotificationService : INotificationService
    {
        public NotificationSettings _notificationSettings { get; }
        public ILogger<FirebaseNotificationService> _logger { get; }

        public FirebaseNotificationService(IOptions<NotificationSettings> notificationSettings, ILogger<FirebaseNotificationService> logger)
        {
            _notificationSettings = notificationSettings.Value;
            _logger = logger;
        }

        public async Task SendAsync(NotificationRequest request)
        {
            try
            {
                //var email = new MimeMessage();
                //email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.From);
                //email.To.Add(MailboxAddress.Parse(request.To));
                //email.Subject = request.Subject;
                //var builder = new BodyBuilder();
                //builder.HtmlBody = request.Body;
                //email.Body = builder.ToMessageBody();
                //using var smtp = new SmtpClient();
                //smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                //smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                //await smtp.SendAsync(email);
                //smtp.Disconnect(true);

                //code to send notification
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
