using System;
using Message;
using NServiceBus;

namespace Server
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IBus Bus { get; set; }
        public void Handle(PlaceOrder message)
        {
            Console.WriteLine(message.Student.ToString());
        }
    }
}
