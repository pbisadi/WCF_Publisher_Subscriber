using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StatusServiceLiberary
{
    [ServiceContract(SessionMode = SessionMode.Required,        
        CallbackContract= typeof(IStatusUpdateCallback))]
    public interface IStatusService
    {
        [OperationContract(IsOneWay=true)]
        void Subscribe(string entryNumber);

        [OperationContract(IsOneWay = true)]
        void Unsubscribe();
    }

    public interface IStatusUpdateCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnStatusUpdate(Status S);
    }

    [DataContract]
    public class Status
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int Number;
    }

    [ServiceBehavior(InstanceContextMode= InstanceContextMode.PerSession)]
    public sealed class StatusService: IStatusService
    {
        static Dictionary<string, CallbackDelegate<Status>> callbacks = new Dictionary<string, CallbackDelegate<Status>>();

        public delegate void CallbackDelegate<T>(T t);
        public static CallbackDelegate<Status> MessageReceived;

        public void Subscribe(string entryNumber)
        {
                            IStatusUpdateCallback callback =
              OperationContext.Current.GetCallbackChannel<IStatusUpdateCallback>();

            if (callbacks.ContainsKey(entryNumber))
            {
                callbacks[entryNumber] += callback.OnStatusUpdate;
            }
            else
            {
                callbacks.Add(entryNumber, callback.OnStatusUpdate);
            }
           
            ICommunicationObject obj = (ICommunicationObject)callback;
            obj.Closing += new EventHandler(StatusService_Closed);
        }

        void StatusService_Closed(object sender, EventArgs e)
        {

            var removed = callbacks.FirstOrDefault(D => D.Value.Target.Equals(sender));
            System.Diagnostics.Debug.Assert(removed.Value != null);
            string oldKey = removed.Key;
            var newValue = removed.Value -((IStatusUpdateCallback)sender).OnStatusUpdate ;
            callbacks.Remove(oldKey);
            callbacks.Add(oldKey, newValue);
                
            Console.WriteLine("Closed Client Removed!");
        }

        public void Unsubscribe()
        {
            IStatusUpdateCallback callback =
              OperationContext.Current.GetCallbackChannel<IStatusUpdateCallback>();
            MessageReceived -= callback.OnStatusUpdate;
        }

        public static void UpdateClietns(string entryNumber, Status S)
        {
            if (callbacks.ContainsKey(entryNumber))
            {
                ((CallbackDelegate<Status>)callbacks[entryNumber]).Invoke(S);
            }
        }
    }
}
