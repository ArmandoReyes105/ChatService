using System.ServiceModel;

namespace Services.Interfaces
{
    [ServiceContract(CallbackContract = typeof(ISessionServiceCallback))]
    public interface ISessionService
    {
        [OperationContract(IsOneWay = false)]
        bool LogIn(string username);

        [OperationContract(IsOneWay = true)]
        void LogOut(string username);
    }

    [ServiceContract]
    public interface ISessionServiceCallback
    {
        [OperationContract]
        void JoinToChat(string username);

        [OperationContract]
        void LeaveTheChat(string username); 
    }
}
