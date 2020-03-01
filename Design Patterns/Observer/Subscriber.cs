using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Subscriber : ISubscriber
    {
        string Notifications;
        public Subscriber(string NewNotification = "Currently I'm not subscribed to anything.")
        {
            this.Notifications = NewNotification;
        }
        public void Update(string newNotification)
        {
            this.Notifications = newNotification;
        }
        public string ActualNotifications
        {
            get
            {
                return this.Notifications;
            }
        }
    }
}
