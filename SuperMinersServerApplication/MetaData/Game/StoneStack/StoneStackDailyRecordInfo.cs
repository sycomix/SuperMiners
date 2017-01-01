﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetaData.Game.StoneStack
{
    [DataContract]
    public class StoneStackDailyRecordInfo
    {
        [DataMember]
        public MyDateTime Day;

        private decimal _openPrice;

        [DataMember]
        public decimal OpenPrice
        {
            get
            {
                return this._openPrice;
            }
            set
            {
                this._openPrice = value;
                if (value != 0)
                {
                    this.LimitUpPrice = Math.Round(value * 1.1m, 2);
                    this.LimitDownPrice = Math.Round(value * 0.9m, 2);
                }
            }
        }

        [DataMember]
        public decimal ClosePrice;

        /// <summary>
        /// 涨停价= OpenPrice * 110%(取两位小数)
        /// </summary>
        [DataMember]
        public decimal LimitUpPrice;

        /// <summary>
        /// 跌停价= OpenPrice * 90%(取两位小数)
        /// </summary>
        [DataMember]
        public decimal LimitDownPrice;

        /// <summary>
        /// 最低成交价(计买入价)
        /// </summary>
        [DataMember]
        public decimal MinTradeSucceedPrice;

        /// <summary>
        /// 最高成交价(计买入价)
        /// </summary>
        [DataMember]
        public decimal MaxTradeSucceedPrice;

        [DataMember]
        public int TradeSucceedStoneHandSum;

        [DataMember]
        public decimal TradeSucceedRMBSum;

        [DataMember]
        public int DelegateSellStoneSum;

        [DataMember]
        public int DelegateBuyStoneSum;

    }
}
