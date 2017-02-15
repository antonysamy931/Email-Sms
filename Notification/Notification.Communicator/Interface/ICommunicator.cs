using Notification.Communicator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Communicator.Interface
{
    interface ICommunicator
    {
        void Handler(CommunicatorModel model);        
    }
}
