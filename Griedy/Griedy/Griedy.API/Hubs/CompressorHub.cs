using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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