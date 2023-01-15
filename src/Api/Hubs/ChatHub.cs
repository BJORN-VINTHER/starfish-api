using Microsoft.AspNetCore.SignalR;

namespace Application
{
    public interface IChatHub
    {
        public Task BroadcastMessage(string user, string message);
    }

    public class ChatHub : Hub<IChatHub>
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.BroadcastMessage(user, message);
        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var codeValue = httpContext.Request.Query["code"].ToString();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}