using MessagesApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessagesWebApi.Hubs

{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private static readonly IDictionary<string, string> _connections;


        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out string user))
            {
                _connections.Remove(Context.ConnectionId);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task Login(string user)
        {
            _connections[Context.ConnectionId] = user;

        }

        public async Task ReceiveMessage(string user)
        {
            await Clients.User(user).SendAsync("ReceiveMessage");
        }

        public async Task ReceiveContact(string from, string to)
        {
            await Clients.User(from).SendAsync("ReceiveContact", to);
        }




    }
}
