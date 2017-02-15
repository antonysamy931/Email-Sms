using Notification.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Text.Handler
{
    public class TextHandler : IHandler
    {
        private SmsSender smsSender = null;

        public TextHandler()
        {
            this.smsSender = new SmsSender();
            this.smsSender.AccountId = ConfigurationManager.AppSettings["Twillio.AccountId"];
            this.smsSender.AuthToken = ConfigurationManager.AppSettings["Twillio.PassCode"];
            this.smsSender.From = ConfigurationManager.AppSettings["Twillio.Sender"];

            if (string.IsNullOrEmpty(this.smsSender.AccountId) 
                || string.IsNullOrEmpty(this.smsSender.AuthToken)
                || string.IsNullOrEmpty(this.smsSender.From))
                throw new Exception("Missing configuration related twilio account");

        }

        public void Send(string toAddress, string message, string subject = "")
        {
            this.smsSender.Send(toAddress, message);
        }
    }
}
