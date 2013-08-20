using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusServiceLiberary;

namespace StatusServiceClient
{
    class StatusServiceCallback : IStatusUpdateCallback
    {
        public void OnStatusUpdate(string S)
        {
            Console.WriteLine("Received an updated on status: {0}", S);
        }
    }
}
