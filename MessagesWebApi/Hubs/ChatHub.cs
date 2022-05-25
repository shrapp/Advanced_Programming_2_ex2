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
            _connections[Context.ConnectionId] = userConnection;

        }

        public async Task ReceiveMessage(string user)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out string userConnection))
            {
                await Clients.User(user).SendAsync("ReceiveMessage", userConnection, message);
            }
        }

    
    }
}
