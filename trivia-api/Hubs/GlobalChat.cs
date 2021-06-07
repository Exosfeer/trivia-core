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
            ChatMessage messageObject = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = message,
                Timestamp = DateTime.Now

            };
            await Clients.All.ReceiveMessage(messageObject);
        }

        /**
         * Sent the message to all clients, including the client that invokes this method.
         * @message A string that contains a message for a client.
         */
        public async Task BroadcastMessage(string message)
        {
            ChatMessage messageObject = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = message,
                Timestamp = DateTime.Now

            };
            await Clients.All.ReceiveMessage(messageObject);

/*            await Clients.All.ReceiveMessageObject(messageObject);
*/
            //sentmessage
        }

        /**
         * Sent the message to the client that invokes this method.
         * @message A string that contains a message for a client.
         */
        public async Task MessageToCaller(string message)
        {
            ChatMessage messageObject = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = message,
                Timestamp = DateTime.Now

            };
            await Clients.Caller.ReceiveMessage(messageObject);
        }

        /**
         * Sent the message to all clients, except the client that invokes this method.
         * @message A string that contains a message for a client.
         */
        public async Task MessageToOthers(string message)
        {
            ChatMessage messageObject = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = message,
                Timestamp = DateTime.Now

            };
            await Clients.Others.ReceiveMessage(messageObject);
        }

        /**
         * Sent the message to all clients asyncrhonusly of the specified group.
         * @groupName A specified name of a group containing connected clients.
         * @message A string that contains a message for a client.
         */
        public async Task MessageToGroup(string groupName, string message)
        {
            ChatMessage messageObject = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = message,
                Timestamp = DateTime.Now

            };
            await Clients.Group(groupName).ReceiveMessage(messageObject);
        }

        /**
         * The specified group name will add the currently connected client.
         * The client receives a message of this addition.
         * The group clients receives a message of this addition.
         * @groupName A specified name of a group containing connected clients.
         */
        public async Task AddClientToGroup(string groupName)
        {
            ChatMessage messageObjectCaller = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = "You have been added to \"{groupName}\" group",
                Timestamp = DateTime.Now

            };
            ChatMessage messageObjectOthers = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = "Client [{Context.ConnectionId}] has been added to \"{groupName}\" group",
                Timestamp = DateTime.Now

            };
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.ReceiveMessage(messageObjectCaller);
            await Clients.Others.ReceiveMessage(messageObjectOthers);
        }

        /**
         * The specified group name will remove the currently connected client.
         * The client receives a message of this removal.
         * The group clients receives a message of this removal.
         * @groupName A specified name of a group containing connected clients.
         */
        public async Task RemoveClientFromGroup(string groupName)
        {
            ChatMessage messageObjectCaller = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = "You have been removed to \"{groupName}\" group",
                Timestamp = DateTime.Now

            };
            ChatMessage messageObjectOthers = new ChatMessage()
            {
                SenderConnectionId = Context.ConnectionId,
                Sender = Context.User,
                Message = "Client [{Context.ConnectionId}] has been removed to \"{groupName}\" group",
                Timestamp = DateTime.Now

            };
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.ReceiveMessage(messageObjectCaller);
            await Clients.Others.ReceiveMessage(messageObjectOthers);
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
