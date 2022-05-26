using MessagesApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessagesWebApi.Hubs

{
    public class ChatHub : Hub
    {
        //private readonly string _botUser;
        private readonly IDictionary<string, string> _connections;

        public ChatHub(IDictionary<string, string> conn)
        {
            _connections = conn;
        }


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

        public async Task ReceiveMessage()
        {
            if (_connections.TryGetValue(Context.ConnectionId, out string user))
            {
                //await Clients.User(user).SendAsync("ReceiveMessage");
                await Clients.All.SendAsync("ReceiveMessage");
            }
        }

        //public async Task ReceiveContact(string from, string to)
        //{
        //    await Clients.User(from).SendAsync("ReceiveContact", to);
        //}




    }
}
