﻿using MetaData.Game.RaideroftheLostArk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersWPF.Models
{
    public class RaiderPlayerBetInfoUIModel : BaseModel
    {
        public RaiderPlayerBetInfoUIModel(RaiderPlayerBetInfo parent)
        {
            this.ParentObject = parent;
        }

        private RaiderPlayerBetInfo _parentObject;

        public RaiderPlayerBetInfo ParentObject
        {
            get { return _parentObject; }
            set
            {
                _parentObject = value;

                NotifyPropertyChange("ID");
                NotifyPropertyChange("RaiderRoundID");
                NotifyPropertyChange("UserName");
                NotifyPropertyChange("BetStones");
                NotifyPropertyChange("TimeText");
                NotifyPropertyChange("ShortTimeText");
            }
        }

        public int ID
        {
            get
            {
                return this._parentObject.ID;
            }
        }

        public int RaiderRoundID
        {
            get
            {
                return this._parentObject.RaiderRoundID;
            }
        }

        public string UserName
        {
            get
            {
                return this._parentObject.UserName;
            }
        }

        public int BetStones
        {
            get
            {
                return this._parentObject.BetStones;
            }
        }

        public string TimeText
        {
            get
            {
                return this._parentObject.Time.ToDateTime().ToString();
            }
        }

        public string ShortTimeText
        {
            get
            {
                return this._parentObject.Time.ToDateTime().ToLongTimeString();
            }
        }
    }
}
