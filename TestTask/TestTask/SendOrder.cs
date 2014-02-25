using System;
using System.Threading;
using Message;
using NServiceBus;

namespace TestTask
{
    public class SendOrder : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            for (int i = 0; i < 200;i++ )
            {
                SendObject();
            }
        }

        public void SendObject()
        {
            var student = new Student();
            
            Bus.Send("Service", new PlaceOrder {Student = student});
            Console.WriteLine(student.ToString());
            Console.WriteLine("==========================================================================");
            Thread.Sleep(5);
        }

        public void Stop()
        {

        }
    }
}
