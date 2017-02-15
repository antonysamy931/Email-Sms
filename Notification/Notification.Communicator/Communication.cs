using Notification.Common;
using Notification.Communicator.Interface;
using Notification.Communicator.Model;
using Notification.Mail.Handler;
using Notification.Text.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Communicator
{
    public class Communication : ICommunicator
    {
        public void Handler(CommunicatorModel model)
        {
            NotificationTypes type = model.CanSendEmail ? NotificationTypes.EMAIL : (model.CanSendText ? NotificationTypes.SMS : NotificationTypes.EMAIL);
            IHandler handler = GetHandler(type);
            if (type == NotificationTypes.EMAIL)
                handler.Send(model.Email, model.Content, model.Subject);
            else
                handler.Send(model.PhoneNumber, model.Content);
        }

        private IHandler GetHandler(NotificationTypes type)
        {
            if (type == NotificationTypes.EMAIL)
            {
                return new EmailHandler();
            }
            else
            {
                return new TextHandler();
            }
        }
    }
}
