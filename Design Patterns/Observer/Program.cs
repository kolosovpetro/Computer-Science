using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher p1 = new Publisher();
            Subscriber s1 = new Subscriber();
            Subscriber s2 = new Subscriber();
            Subscriber s3 = new Subscriber();

            // subscribers are not currently subscribed to anything, let's check it

            Console.WriteLine(s1.ActualNotifications);
            Console.WriteLine(s2.ActualNotifications);
            Console.WriteLine(s3.ActualNotifications);

            // subscribers decided to subscribe to Publisher p1

            p1.Subscribe(s1);
            p1.Subscribe(s2);
            p1.Subscribe(s3);

            // Are they really subscribed now ?
            Console.WriteLine(s1.ActualNotifications);
            Console.WriteLine(s2.ActualNotifications);
            Console.WriteLine(s3.ActualNotifications);

            // Publisher prapaired a new commercial for clothes
            p1.BusinessLogics("Hurry to buy new clothes with 50% discount!");

            // Subscribers: Oops, we get new notification !! :)
            Console.WriteLine(s1.ActualNotifications);
            Console.WriteLine(s2.ActualNotifications);
            Console.WriteLine(s3.ActualNotifications);



        }
    }
}
