﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersServerApplication.WebService.Contracts
{
    public partial interface IServiceToClient
    {
        [Callback]
        void SendMessage(string token, string message);

        [Callback]
        void SendPlayerActionLog(string token);

        [Callback]
        void SendGameConfig(string token);

        [Callback]
        void SendNewNotice(string token, string title);
    }
}
