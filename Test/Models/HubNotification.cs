using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class HubNotification : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void SendNotifications(string message)
        {
            Clients.All.receiveNotification(message);
        }
        
    }
}