using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Services.Implementations
{
    public partial class ChatService : ISessionService
    {
        private static Dictionary<string, ISessionServiceCallback> sessionUsers = new Dictionary<string, ISessionServiceCallback>(); 
        public bool LogIn(string username)
        {
            bool result = false;
            var callback = OperationContext.Current.GetCallbackChannel<ISessionServiceCallback>();

            if (!sessionUsers.ContainsKey(username))
            {
                sessionUsers.Add(username, callback);
                Console.WriteLine($"{username} se ha unido al chat");
                
                foreach(var userCallback in sessionUsers.Values)
                {
                    if (userCallback != callback)
                    {
                        userCallback.JoinToChat(username); 
                    }
                }

                result = true;

            }

            return result; 
        }

        public void LogOut(string username) 
        {
            sessionUsers.Remove(username);
            Console.WriteLine($"{username} ha dejado el chat");
            
            foreach (var userCallback in sessionUsers.Values)
            {
                userCallback.LeaveTheChat(username); 
            }
        }
    }
}
