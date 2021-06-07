using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace trivia_api.Models
{
    public class ChatMessage
    {
        private string senderConnectionId;
        private string message;
        private DateTime timestamp;

        public string SenderConnectionId
        {
            set => senderConnectionId = value;
            get => senderConnectionId;
        }
        public ClaimsPrincipal Sender{ set; get;}
        public string Message
        {
            set => message = value;
            get => message;
        }
        public DateTime Timestamp
        {
            set => timestamp = value;
            get => timestamp;

        }
    }
}