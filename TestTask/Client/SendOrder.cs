using System;
using Message;
using NServiceBus;
using NServiceBus.Unicast;

namespace Client
{
    public class SendOrder : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {          
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            while (Console.ReadLine() != null)
            {
                Bus.Send("Server", new Student());
                Console.WriteLine("==========================================================================");
            }
        }

        public void Stop()
        {

        }
    }
}
