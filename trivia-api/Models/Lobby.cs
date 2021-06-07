using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivia_api.Models
{
    public class Lobby
    {
        private string id;
        private string owner;
        private string title;
        private string members;
        private string membersCounter;
        private string type;
        private string lobbyNumber;
        private DateTime published;
        private DateTime updated;

        public string Id
        {
            set => id = value;
            get => id;
        }
        public string Owner
        {
            set => owner = value;
            get => owner;
        }
        public string Title
        {
            set => title = value;
            get => title;
        }
        public string Members
        {
            set => members = value;
            get => members;
        }
        public string MembersCounter
        {
            set => membersCounter = value;
            get => membersCounter;
        }
        public string Type
        {
            set => type = value;
            get => type;
        }
        public string LobbyNumber
        {
            set => lobbyNumber = value;
            get => lobbyNumber;
        }
        public DateTime Published
        {
            set => published = value;
            get => published;
        }
        public DateTime Updated
        {
            set => updated = value;
            get => updated;
        }

        public Lobby()
        {
            Id = Guid.NewGuid().ToString();
            Published = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}
