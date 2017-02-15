using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Notification.Text.Handler
{
    public class SmsSender
    {
        private TwilioRestClient _twilio = null;

        public string AccountId { get; set; }

        public string AuthToken { get; set; }

        public string From { get; set; }

        private void Init()
        {            
            _twilio = new TwilioRestClient(AccountId, AuthToken);
        }

        public void Send(string toAddress, string message)
        {
            Init();
            _twilio.SendMessage(From, toAddress, message);
        }
    }
}
