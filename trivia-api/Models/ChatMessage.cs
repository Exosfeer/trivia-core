using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivia_api.Models
{
    public class ChatMessage
    {
        private int id;
        private string sender;
        private string message;
        private string displayname;
        private DateTime timestamp;

        public int Id
        {
            set => id = value;
            get => id;
        }
        public string Sender
        {
            set => sender = value;
            get => sender;
        }
        public string Message
        {
            set => message = value;
            get => message;
        }
        public string Displayname
        {
            set => displayname = value;
            get => displayname;
        }

        public DateTime Timestamp
        {
            set => timestamp = value;
            get => timestamp;

        }
    }
}