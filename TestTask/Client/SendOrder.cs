using System;
using System.Configuration;
using System.Transactions;
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
            var t = Transaction.Current;
            Console.WriteLine(t == null);
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");
            var count = int.Parse(ConfigurationManager.AppSettings["ThreadsCount"]);

            while (Console.ReadLine() != null)
            {
                var st = new Student();
                Bus.Send("Server", new PlaceOrder { Student = st });
                Console.WriteLine(st.ToString());
                Console.WriteLine("==========================================================================");
            }
        }

        public void SendObjects()
        {
        }

        public void Stop()
        {

        }
    }
}
