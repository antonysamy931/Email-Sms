using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Mail.Handler
{
    public class EmailSender
    {
        SmtpClient client;

        public string SmtpHost
        {
            get { return client.Host; }
            set { client.Host = value; }
        }
        public int SmtpPort
        {
            get { return client.Port; }
            set { client.Port = value; }
        }

        public bool UseDefaultCredentials
        {
            get { return client.UseDefaultCredentials; }
            set { client.UseDefaultCredentials = value; }
        }

        public EmailSender()
        {
            client = new SmtpClient();
        }

        public EmailSender(string smtpHost, int smtpPort, bool useDefaultCredentials = false)
        {
            client = new SmtpClient();

            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            UseDefaultCredentials = useDefaultCredentials;
        }

        public void SendEmail(
            string subject,
            string fromAddress,
            IList<string> toAddressList,
            string body,
            MailPriority priority = MailPriority.Normal,
            IList<string> attachmentList = null,
            bool bodyIsHtml = true,
            IList<string> bccAddressList = null
        )
        {            
            MailMessage message = GetMailMessage(
                    subject, fromAddress, toAddressList, body, attachmentList, priority, bodyIsHtml, bccAddressList
                    );

            try
            {
                if (null != message && (attachmentList == null || message.Attachments.Count > 0))
                    client.Send(message);
            }
            catch (SmtpFailedRecipientException ex)
            {
                throw ex;
            }
        }


        public MailMessage GetMailMessage(
            string subject,
            string fromAddress,
            IList<string> toAddressList,
            string body,
            IList<string> attachmentList = null,
            MailPriority priority = MailPriority.Normal,
            bool bodyIsHtml = true,
            IList<string> bccAddressList = null
        )
        {
            MailMessage message = new MailMessage();
            message.Subject = subject;
            message.From = new MailAddress(fromAddress);
            if (null != toAddressList)
            {
                foreach (var emailAddress in toAddressList)
                {
                    message.To.Add(emailAddress);
                }
            }
            if (null != bccAddressList)
            {
                foreach (var emailAddress in bccAddressList)
                {
                    message.Bcc.Add(emailAddress);
                }
            }
            if (attachmentList != null)
            {
                foreach (var attachment in attachmentList)
                {
                    message.Attachments.Add(new Attachment(attachment));
                }
            }
            message.Priority = priority;
            message.IsBodyHtml = bodyIsHtml;
            message.Body = body;
            return message;
        }

    }
}
