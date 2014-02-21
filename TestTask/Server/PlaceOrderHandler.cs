using System;
using System.Collections.Generic;
using System.Transactions;
using Message;
using NServiceBus;

namespace Server
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IBus Bus { get; set; }
        public static List<Student> Students = new List<Student>();
        private Student mCurrentStudent;

        public void Handle(PlaceOrder message)
        {
            WriteToDb(message.Student);
            Console.WriteLine(message.Student.ToString());
        }

        public void WriteToDb(Student s)
        {
            var t = Transaction.Current;
            t.TransactionCompleted += (sender, args) =>
                {
                    using (var db = new StudentsContext())
                    {
                        db.Students.Add(mCurrentStudent);
                        db.SaveChanges();
                    }
                };
            if (t != null)
            {
                mCurrentStudent = s;
            }
        }
    }
}
