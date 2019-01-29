using System.Net;
using System.Net.Mail;

namespace Northwind.Application.MailNotifications
{
    public class SendMailNotification
    {
        public SendMailNotification(string mailNotificationSubject, string mailNotificationBody)
        {
            string mailNotificationSystemAddress = "notification_system@gmail.com";
            string adminAddress = "admin@example.com";
            string mailNotificationServerHost = "smtp.gmail.com";
            int mailNotificationServerPort = 587;
            MailMessage mailNotification = new MailMessage();
            SmtpClient mailNotificationServer = new SmtpClient(mailNotificationServerHost);
            mailNotification.From = new MailAddress(mailNotificationSystemAddress);
            mailNotification.To.Add(adminAddress);
            mailNotification.Subject = mailNotificationSubject;
            mailNotification.Body = mailNotificationBody;
            mailNotificationServer.Port = mailNotificationServerPort;
            mailNotificationServer.Credentials = new System.Net.NetworkCredential("shahid@reckonbits.com.pk", "your password");
            mailNotificationServer.EnableSsl = true;
            mailNotificationServer.Send(mailNotification);
        }
    }
}


