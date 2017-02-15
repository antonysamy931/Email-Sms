using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Common
{
    public interface IHandler
    {
        void Send(string toAddress, string message, string subject = "");
    }
}
