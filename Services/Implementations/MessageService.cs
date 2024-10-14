using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Services.Implementations
{
    public partial class ChatService : IMessageService
    {

        private static Dictionary<string, IMessageServiceCallback> messageUsers = new Dictionary<string, IMessageServiceCallback>();

        public void SendMessage(string message, string username)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>();

            foreach (var userCallback in messageUsers.Values) 
            {
                if (userCallback != callback)
                {
                    userCallback.ReciveMessage(message, username);
                }
            }
        }

        public void StopMessaging(string username)
        {
            messageUsers.Remove(username);
        }

        public void StartMessaging(string username)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>(); 

            messageUsers.Add(username, callback);
        }
    }
}
