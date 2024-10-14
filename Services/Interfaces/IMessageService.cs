using System.ServiceModel;

namespace Services.Interfaces
{
    [ServiceContract (CallbackContract = typeof(IMessageServiceCallback))]
    public interface IMessageService
    {
        [OperationContract (IsOneWay = true)]
        void SendMessage(string message, string username);

        [OperationContract]
        void StopMessaging(string username);

        [OperationContract]
        void StartMessaging(string username);
    }

    [ServiceContract]
    public interface IMessageServiceCallback
    {
        [OperationContract]
        void ReciveMessage(string message, string username); 
    }
}
