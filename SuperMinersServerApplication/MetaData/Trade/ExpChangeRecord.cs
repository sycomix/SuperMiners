﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetaData.Trade
{
    [DataContract]
    public class ExpChangeRecord
    {
        [DataMember]
        public int UserID;

        [DataMember]
        public string UserName;

        [DataMember]
        public decimal AddExp;

        [DataMember]
        public decimal NewExp;

        [DataMember]
        public MyDateTime Time;

        /// <summary>
        /// MaxLength:100
        /// </summary>
        [DataMember]
        public string OperContent;
    }
}
