using MessagesApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessagesWebApi.Hubs

{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, string> _connections;

        public ChatHub(IDictionary<string, string> connections)
        {
            _botUser = "MyChat Bot";
            _connections = connections;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out string user))
            {
                _connections.Remove(Context.ConnectionId);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task Login(string userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection);

            _connections[Context.ConnectionId] = userConnection;

            await Clients.All.SendAsync("ReceiveMessage", _botUser, $"{userConnection} has joined");

           
        }

        public async Task SendMessage(string message)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out string userConnection))
            {
                await Clients.All.SendAsync("ReceiveMessage", userConnection, message);
            }
        }

    
    }
}
