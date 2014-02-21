using System;
using System.Data.Entity;
using System.Transactions;

namespace Server
{
    class Program
    {      
        static void Main(string[] args)
        {
            var t = Transaction.Current;
            Console.WriteLine(t==null);
        }
    }
}
