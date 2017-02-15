using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Communicator.Model
{
    public class CommunicatorModel
    {
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public bool CanSendEmail { get; set; }

        public bool CanSendText { get; set; }

        public String Content { get; set; }
    }
}
