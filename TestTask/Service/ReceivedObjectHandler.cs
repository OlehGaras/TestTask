using System;
using System.Transactions;
using Message;
using NServiceBus;

namespace Service
{
    public class ReceivedObjectHandler : IHandleMessages<ObjectToSend>
    {
        public IBus Bus { get; set; }
        private readonly object mSyncDb = new object();

        public void Handle(ObjectToSend message)
        {
            var t = Transaction.Current;
            t.TransactionCompleted += (sender, args) => WriteToDb(message.Student);
        }

        public void WriteToDb(Student s)
        {
            lock (mSyncDb)
            {
                using (var db = new StudentsContext())
                {
                    db.Students.Add(s);
                    db.SaveChanges();
                }
                Console.WriteLine(s);
            }
        }

    }
}
