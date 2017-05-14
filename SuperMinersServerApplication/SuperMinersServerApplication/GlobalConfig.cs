﻿using MetaData.SystemConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersServerApplication
{
    public static class GlobalConfig
    {
        private static object _lockGameConfig = new object();
        private static GameConfig _gameConfig = null;
        public static GameConfig GameConfig
        {
            get
            {
                lock (_lockGameConfig)
                {
                    return _gameConfig;
                }
            }
            set
            {
                lock (_lockGameConfig)
                {
                    _gameConfig = value;
                }
            }
        }

        private static object _lockIncomeMoneyAccount = new object();
        private static IncomeMoneyAccount _incomeMoneyAccount = null;
        public static IncomeMoneyAccount IncomeMoneyAccount
        {
            get
            {
                lock (_lockIncomeMoneyAccount)
                {
                    return _incomeMoneyAccount;
                }
            }
            set
            {
                lock (_lockIncomeMoneyAccount)
                {
                    _incomeMoneyAccount = value;
                }
            }
        }

        private static object _lockRegisterUserConfig = new object();
        private static RegisterUserConfig _registerUserConfig = null;
        public static RegisterUserConfig RegisterPlayerConfig
        {
            get
            {
                lock (_lockRegisterUserConfig)
                {
                    return _registerUserConfig;
                }
            }
            set
            {
                lock (_lockRegisterUserConfig)
                {
                    _registerUserConfig = value;
                }
            }
        }

        public static AwardReferrerLevelConfig AwardReferrerLevelConfig;

        /// <summary>
        /// 玩家购买远程服务三层返利，按积分值比例返灵币
        /// </summary>
        public static decimal[] BuyRemoteServiceAwardRMBConfig = new decimal[] { 0.08m, 0.05m, 0.03m };

        public static RouletteConfig RouletteConfig = new RouletteConfig();

        public static string CurrentClientVersion = "";

    }
}
