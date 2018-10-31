using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Griedy.API.Hubs
{
    public class CompressorHub : Hub
    {
        public void SendMessage(string msg)
        {
            Clients.All.Message(msg);
        }
    }
}