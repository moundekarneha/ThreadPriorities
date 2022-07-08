 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPriorities
{
    //Thread Priorities
    internal class Program
    {
        static long count1, count2;
        public static void IncreamentCount1()
        {
            while (true)
            {
                count1 += 1;
                Console.WriteLine("t1 : ");
            }
            
        }

        public static void IncreamentCount2()
        {
            while (true)
            {
                count2 += 1;
                Console.WriteLine("t2 : ");
            }

        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(IncreamentCount1);
            Thread t2 = new Thread(IncreamentCount2);

            //setting priorities - total 5
            t1.Priority = ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.Highest;
            t1.Start();
            t2.Start();

            //main method going to sleep
            Thread.Sleep(10000);
            Console.WriteLine("Main thread woke up");

            //thread Abort
            t1.Abort();
            t2.Abort();

            //join - to take main method till waits
            t1.Join();
            t2.Join();

            Console.WriteLine("Count 1 = " + count1);
            Console.WriteLine("Count 2 = " + count2);

            Console.ReadLine();
        }
    }
}
