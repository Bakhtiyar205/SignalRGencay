using Microsoft.AspNetCore.SignalR;
using System.Data;

namespace SignalR.Hubs
{
    public class MessageHub : Hub
    {

        //For send message without group
        //public async Task SendMessageAsync(string message,IReadOnlyList<string> connectionIds)
        //For send message with group
        public async Task SendMessageAsync(string message, string groupName, IReadOnlyList<string> connectionIds)
        {
            #region Caller
            ////Only for connection with client who send notification to server
            //await Clients.Caller.SendAsync("receiveMessage", message);

            #endregion
            #region All
            ////Create Connection with who linked(connected) to server
            //await Clients.All.SendAsync("receiveMessage", message);

            #endregion
            #region Other
            ////Send Messages who connected to server except from who send data
            //await Clients.Others.SendAsync("receiveMessage", message);

            #endregion
            #region Hub Clients Methods
            #region AllExcept
            ////Send notiification who connected to the server except declared clients
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);


            #endregion
            #region Client
            ////Send notification for specific client
            //await Clients.Client(connectionIds.FirstOrDefault()!).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            ////Send notification who declared 
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            ////Send notification who subscribed to group
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region GroupExcept
            ////Send notification except  declared clients on declared group
            //await Clients.GroupExcept(groupName,connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Groups
            ////Send to mesasge to the groups
            //await Clients.Groups(groupNames).SendAsync("receiveMessage", message);
            #endregion
            #region OthersInGroup
            ////Send mesasge to the groub members except from who send data
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage",message);
            #endregion
            #region User
            ////Send notification who is authenticated
            #endregion
            #region Users
            ////Send notification who are authenticated

            #endregion
            #endregion
        }

        public override async Task OnConnectedAsync()
        {
          await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task AddGroup(string connectionId, string groupName)
        {
           await Groups.AddToGroupAsync(connectionId, groupName); 
        }
    }
}
