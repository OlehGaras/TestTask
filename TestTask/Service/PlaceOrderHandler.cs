using System;
using System.Transactions;
using Message;
using NServiceBus;

namespace Service
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IBus Bus { get; set; }
        private Student mCurrentStudent;
        private readonly object mSyncObj = new object();

        public void Handle(PlaceOrder message)
        {
            lock (mSyncObj)
            {
                var t = Transaction.Current;
                t.TransactionCompleted += (sender, args) => WriteToDb(mCurrentStudent);
                if (t != null)
                {
                    mCurrentStudent = message.Student;
                }
                Console.WriteLine(message.Student);
            }
        }

        public void WriteToDb(Student s)
        {

            using (var db = new StudentsContext())
            {
                db.Students.Add(mCurrentStudent);
                db.SaveChanges();
            }

        }
    }
}
