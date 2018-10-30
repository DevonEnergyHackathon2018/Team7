using Microsoft.AspNet.SignalR;

namespace Griedy.API.Hubs
{
    public class CompressorHub : Hub
    {
        public void Send()
        {
            Clients.All.send();
        }
    }
}