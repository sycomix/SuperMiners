﻿using MetaData.User;
using SuperMinersServerApplication.WebService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersServerApplication.WebService.Services
{
    public partial class ServiceToClient : IServiceToClient
    {
        public void Kickout(string token)
        {
            this.InvokeCallback(token, "Kickout");
        }

        public void LogedIn(string token)
        {
            this.InvokeCallback(token, "LogedIn");
        }

        public void LogedOut(string token)
        {
            this.InvokeCallback(token, "LogedOut");
        }

        public void SetPlayerInfo(string token, PlayerInfo player)
        {
            this.InvokeCallback(token, "SetPlayerInfo", player);
        }
    }
}
