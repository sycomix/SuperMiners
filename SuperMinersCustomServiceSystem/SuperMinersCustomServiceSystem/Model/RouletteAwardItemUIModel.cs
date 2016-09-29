﻿using MetaData.Game.Roulette;
using System;
#if Client
using SuperMinersWPF.Models;
#endif
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersCustomServiceSystem.Model
{
    public class RouletteAwardItemUIModel : BaseModel
    {
        public RouletteAwardItemUIModel(RouletteAwardItem parent)
        {
            this.ParentObject = parent;
        }

        private RouletteAwardItem _parentObject;

        public RouletteAwardItem ParentObject
        {
            get { return _parentObject; }
            set
            {
                _parentObject = value;
                NotifyPropertyChange("ID");
                NotifyPropertyChange("AwardName");
                NotifyPropertyChange("AwardNumber");
                NotifyPropertyChange("RouletteAwardType");
                NotifyPropertyChange("ValueMoneyYuan");
                NotifyPropertyChange("IsLargeAward");
                NotifyPropertyChange("IsRealAward");
                NotifyPropertyChange("WinProbability");
            }
        }

        public int ID
        {
            get { return this.ParentObject.ID; }
        }

        public string AwardName
        {
            get { return this.ParentObject.AwardName; }
            set
            {
                this.ParentObject.AwardName = value;
            }
        }

        public int AwardNumber
        {
            get { return this.ParentObject.AwardNumber; }
            set
            {
                this.ParentObject.AwardNumber = value;
            }
        }

        public RouletteAwardType RouletteAwardType
        {
            get { return this.ParentObject.RouletteAwardType; }
            set
            {
                this.ParentObject.RouletteAwardType = value;
            }
        }

        /// <summary>
        /// 价值人民币
        /// </summary>
        public float ValueMoneyYuan
        {
            get { return this.ParentObject.ValueMoneyYuan; }
            set
            {
                this.ParentObject.ValueMoneyYuan = value;
            }
        }

        public bool IsLargeAward
        {
            get { return this.ParentObject.IsLargeAward; }
            set
            {
                this.ParentObject.IsLargeAward = value;
            }
        }

        /// <summary>
        /// 是否为实物奖品，除了系统内部的都称为实物
        /// </summary>
        public bool IsRealAward
        {
            get { return this.ParentObject.IsRealAward; }
            set
            {
                this.ParentObject.IsRealAward = value;
            }
        }

        /// <summary>
        /// 中奖概率倍数，整数值，计算时将所有中中奖概率加一起求百分比
        /// </summary>
        public float WinProbability
        {
            get { return this.ParentObject.WinProbability; }
            set
            {
                this.ParentObject.WinProbability = value;
            }
        }

    }
}
