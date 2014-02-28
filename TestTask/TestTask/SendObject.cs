using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Message;
using NServiceBus;

namespace TestTask
{
    public class SendObject : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }
        private readonly CancellationTokenSource mCancellationTokenSource = new CancellationTokenSource();

        public void Start()
        {
            var token = mCancellationTokenSource.Token;
            var count = int.Parse(ConfigurationManager.AppSettings["ThreadsCount"]);
            var options = new ParallelOptions { MaxDegreeOfParallelism = count, CancellationToken = token };
            

            Console.WriteLine("Press 'Enter' to send messages. Press 'Esc' to cancel the process. ");
            Console.ReadLine();

            //separate thread for cancellation 
            ThreadPool.QueueUserWorkItem(state => CancellationProc());

            try
            {
                Parallel.For(0, 2000, options, i => SendObjects());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            mCancellationTokenSource.Cancel();
        }

        public void CancellationProc()
        {
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    mCancellationTokenSource.Cancel();
                }

                if (mCancellationTokenSource.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        public void SendObjects()
        {
            if (mCancellationTokenSource.IsCancellationRequested)
                return;
            var random = new Random(DateTime.Now.Millisecond);
            var student = new Student(random);
            Bus.Send("Service", new ObjectToSend { Student = student });
            Console.WriteLine("{0}\r\n{1}", student, "==========================================================================");
        }

        public void Stop()
        {
            mCancellationTokenSource.Cancel();
        }
    }
}
