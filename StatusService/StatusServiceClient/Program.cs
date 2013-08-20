using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using StatusServiceLiberary;

namespace StatusServiceClient
{
    class Program : IStatusUpdateCallback
    {
        static void Main(string[] args)
        {
            //InstanceContext instanceContext = new InstanceContext(new StatusServiceCallback());
            //StatusService client = new StatusService(instanceContext);
            //client.Subscribe();
        }

        public void OnStatusUpdate(string S)
        {
            Console.WriteLine("Received an updated on status: {0}", S);
        }
    }
}
