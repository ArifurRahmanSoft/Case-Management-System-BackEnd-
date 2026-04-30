using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTG_ERPWebApi
{
    public class SignalR_Hub : Hub
    {
        //[EnableCors("AppPolicy")]
        public async Task ExecuteChats(string messages)
        {
            await Clients.All.SendAsync("ChatsStart", messages);
        }
    }
}
