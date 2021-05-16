using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivia_api.Hubs.Interfaces;
using trivia_api.Models;

namespace trivia_api.Hubs
{
    /**
     * This class is a strongly typed SignalR Connected Client HUB for my IPS project.
     * This class allows front-end clients to call any method through the correct rounting path.
     * Using the interface IConnectedClient methods.
     **/
    public class GlobalChat : Hub<IGlobalChat>
    {

        /**
         * Sent the message to all clients, including the client that invokes this method.
         * @message A string that contains a message for a client.
         */
        public async Task MessageToAll(string message)
        {
            await Clients.All.ReceiveMessage(Context.User.Identity.Name,message);
        }

        /**
         * Sent the message to all clients, including the client that invokes this method.
         * @message A string that contains a message for a client.
         */
        public async Task BroadcastMessage(string message)
        {
            ChatMessage messageObject = new ChatMessage()
            {
                //Id = Context.User.Identity.Name,
                Id = 1337,
                Sender = "client-1337",
                Message = message,
                Displayname = "displayname1",
                Timestamp = DateTime.Now

            };
            //await Clients.All.ReceiveMessage(Context.User.Identity.Name, message);
            await Clients.All.ReceiveMessageObject(messageObject);

            //sentmessage
        }

        /**
         * Sent the message to the client that invokes this method.
         * @message A string that contains a message for a client.
         */
        public async Task MessageToCaller(string message)
        {
            await Clients.Caller.ReceiveMessage(Context.User.Identity.Name, message);
        }

        /**
         * Sent the message to all clients, except the client that invokes this method.
         * @message A string that contains a message for a client.
         */
        public async Task MessageToOthers(string message)
        {
            await Clients.Others.ReceiveMessage(Context.User.Identity.Name, message);
        }

        /**
         * Sent the message to all clients asyncrhonusly of the specified group.
         * @groupName A specified name of a group containing connected clients.
         * @message A string that contains a message for a client.
         */
        public async Task MessageToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).ReceiveMessage(Context.User.Identity.Name, message);
        }

        /**
         * The specified group name will add the currently connected client.
         * The client receives a message of this addition.
         * The group clients receives a message of this addition.
         * @groupName A specified name of a group containing connected clients.
         */
        public async Task AddClientToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.ReceiveMessage(Context.User.Identity.Name, $"You have been added to \"{groupName}\" group");
            await Clients.Others.ReceiveMessage(Context.User.Identity.Name, $"Client [{Context.ConnectionId}] has been added to \"{groupName}\" group");
        }

        /**
         * The specified group name will remove the currently connected client.
         * The client receives a message of this removal.
         * The group clients receives a message of this removal.
         * @groupName A specified name of a group containing connected clients.
         */
        public async Task RemoveClientFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.ReceiveMessage(Context.User.Identity.Name, $"You have been removed to \"{groupName}\" group");
            await Clients.Others.ReceiveMessage(Context.User.Identity.Name, $"Client [{Context.ConnectionId}] has been removed to \"{groupName}\" group");
        }

        /**
         * An event override.
         * This method will invoke when the system recieves a newly connected client.
         * The group "ConnectedClients" will add the currently connected client.
         */
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "ConnectedClients");
            await base.OnConnectedAsync();
        }

        /**
         * An event override.
         * This method will invoke when the system disconnect with the specified connected client.
         * The group "ConnectedClients" will remove the currently connected client.
         * If an error occurs it will catch the exception.
         */
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "ConnectedClients");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
