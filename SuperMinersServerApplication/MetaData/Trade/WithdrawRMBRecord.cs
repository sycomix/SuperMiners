﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetaData.Trade
{
    [DataContract]
    public class WithdrawRMBRecord
    {
        [DataMember]
        public int id;

        [DataMember]
        public int PlayerUserID;

        [DataMember]
        public string PlayerUserName = "";

        [DataMember]
        public string AlipayAccount = "";

        [DataMember]
        public string AlipayRealName = "";

        [DataMember]
        public decimal WidthdrawRMB = 0;

        /// <summary>
        /// 提现人民币金额全部向下取整
        /// </summary>
        [DataMember]
        public int ValueYuan = 0;

        public DateTime CreateTime = Common.INVALIDTIME;
        [DataMember]
        public string CreateTimeString
        {
            get
            {
                return this.CreateTime.ToString();
            }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (!DateTime.TryParse(value, out CreateTime))
                        {
                            CreateTime = Common.INVALIDTIME;
                        }
                    }
                }
                catch (Exception)
                {
                    CreateTime = Common.INVALIDTIME;
                }
            }
        }


        //[DataMember]
        //public bool IsPayedSucceed = false;

        [DataMember]
        public RMBWithdrawState State = RMBWithdrawState.Waiting;

        [DataMember]
        public string AdminUserName;

        [DataMember]
        public string AlipayOrderNumber = "";

        [DataMember]
        public string Message = "";

        /// <summary>
        /// 处理时间（包括拒绝）
        /// </summary>
        public DateTime? PayTime;
        [DataMember]
        public string PayTimeString
        {
            get
            {
                if (PayTime == null || !PayTime.HasValue)
                {
                    return "";
                }
                return this.PayTime.Value.ToString();
            }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        PayTime = null;
                    }
                    PayTime = DateTime.Parse(value);
                }
                catch (Exception)
                {
                    PayTime = Common.INVALIDTIME;
                }
            }
        }

    }

    public enum RMBWithdrawState
    {
        Waiting,
        Payed,
        Rejected
    }
}
