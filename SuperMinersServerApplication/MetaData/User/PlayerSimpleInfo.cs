﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetaData.User
{
    /// <summary>
    /// 玩家基本信息
    /// </summary>
    [DataContract]
    public class PlayerSimpleInfo
    {
        [DataMember]
        public int UserID { get; set; }

        /// <summary>
        /// 玩家登录名，限制登录使用
        /// </summary>
        [DataMember]
        public string UserLoginName { get; set; }

        /// <summary>
        /// maxlength=15，为了兼容老代码，所以查询还是以UserName为准。
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        //[DataMember]
        //public string NickName { get; set; }

        /// <summary>
        /// minlength= 6, maxlength=15
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public PlayerGroupType GroupType { get; set; }

        [DataMember]
        public bool IsAgentReferred { get; set; }

        [DataMember]
        public int AgentReferredLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int AgentUserID { get; set; }

        /// <summary>
        /// 支付宝账户，加密，MaxLength=30
        /// </summary>
        [DataMember]
        public string Alipay { get; set; }

        /// <summary>
        /// 支付宝账户真实姓名
        /// </summary>
        [DataMember]
        public string AlipayRealName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IDCardNo { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string QQ { get; set; }

        /// <summary>
        /// 用户注册时的IP
        /// </summary>
        [DataMember]
        public string RegisterIP { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        [DataMember]
        public string InvitationCode { get; set; }

        #region RegisterTime

        /// <summary>
        /// 用户注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }
        [DataMember]
        public string RegisterTimeString
        {
            get
            {
                if (this.RegisterTime == null)
                {
                    return "";
                }
                return this.RegisterTime.ToString();
            }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        RegisterTime = DateTime.Parse(value);
                    }
                }
                catch (Exception)
                {
                    RegisterTime = Common.INVALIDTIME;
                }
            }
        }

        #endregion

        /// <summary>
        /// 上一次登录时间，用20150101表示无效日期
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        [DataMember]
        public string LastLoginTimeString
        {
            get
            {
                if (this.LastLoginTime == null)
                {
                    return "";
                }
                return this.LastLoginTime.ToString();
            }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        LastLoginTime = DateTime.Parse(value);
                    }
                }
                catch (Exception)
                {
                    LastLoginTime = null;
                }
            }
        }

        [DataMember]
        public string LastLoginIP { get; set; }

        [DataMember]
        public string LastLoginMac { get; set; }

        /// <summary>
        /// 上一次登出时间，用20150101表示无效日期
        /// </summary>
        public DateTime? LastLogOutTime { get; set; }
        [DataMember]
        public string LastLogOutTimeString
        {
            get
            {
                if (LastLogOutTime == null)
                {
                    return "";
                }
                return this.LastLogOutTime.ToString();
            }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        LastLogOutTime = DateTime.Parse(value);
                    }
                }
                catch (Exception)
                {
                    LastLogOutTime = null;
                }
            }
        }

        /// <summary>
        /// 推荐人
        /// </summary>
        [DataMember]
        public string ReferrerUserName { get; set; }

        [DataMember]
        public PostAddress[] AddressList { get; set; }

    }

    public enum PlayerGroupType
    {
        NormalPlayer=0,
        TestPlayer,
        AgentPlayer,
    }
}
