using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using StatusServiceLiberary;
using System.Threading;

namespace StatusServiceHost
{
    class Program
    {
        private static int count;

        public static int Count
        {
            get
            {
                count += 1;
                return count;
            }
        }

        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(StatusService));            
            host.Open();
            Console.WriteLine("Service Started");
            Timer timer = new Timer(delegate(object state)
            {
                int count = Count;
                try
                {
                    StatusService.UpdateClietns((count % 3).ToString(), new Status() { Name = count.ToString() });
                    Console.WriteLine(count);
                    //if (StatusService.MessageReceived != null)
                    //{
                    //    Console.WriteLine(
                    //      StatusService.MessageReceived.GetInvocationList().Length.ToString() +
                    //      " Subscribers");
                    //    Status S = new Status() { Name = Count.ToString() };
                    //    Console.WriteLine("Sent: " + Count);
                    //}
                    //else
                    //{
                    //    Console.WriteLine("0 Subscribers");
                    //    Console.WriteLine("Skipped: " + Count.ToString());
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }, null, 1000, 1000);

            Console.ReadKey(true);
            host.Close();
        }
    }
}
