using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivia_api.Models;

namespace trivia_api.Hubs.Interfaces
{
    public interface IGlobalChat
    {
        Task ReceiveMessage(string sender, string message);
        Task ReceiveMessageObject(ChatMessage messageObject);
        Task BroadcastMessage(string sender, string message);
    }
}
