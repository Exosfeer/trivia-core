using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace trivia_api.Hubs
{
    /**
     * This class is the default standard for all Hubs used in this IPS project.
     * This class allows clients to sent and retrieve messages by the default methods defined on https://docs.microsoft.com/aspnet/core/signalr/hubs
     **/
    public class HubStandard : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
