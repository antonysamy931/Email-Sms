using Notification.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Mail.Handler
{
    public class EmailHandler : IHandler
    {
        private EmailSender emailSender = null;

        public EmailHandler()
        {
            this.emailSender = new EmailSender();
            this.emailSender.SmtpHost = ConfigurationManager.AppSettings["smtpHost"];
            this.emailSender.SmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);

            if (string.IsNullOrEmpty(this.emailSender.SmtpHost)
                || this.emailSender.SmtpPort == 0)
                throw new Exception("Missing configuration related SMTP");
        }

        public void Send(string toAddress, string message, string subject = "")
        {
            subject = string.IsNullOrEmpty(subject) ? ConfigurationManager.AppSettings["default.subject"] : subject;
            List<string> ToAddress = toAddress.Split(',').Select(x => x).ToList<string>();
            this.emailSender.SendEmail(subject, GetFromAddress(), ToAddress, message, MailPriority.Normal);
        }

        private string GetFromAddress()
        {
            return ConfigurationManager.AppSettings["default.fromAddress"];
        }
    }
}
