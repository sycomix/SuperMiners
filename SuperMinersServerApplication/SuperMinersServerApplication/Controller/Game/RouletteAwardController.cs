﻿using MetaData;
using MetaData.Game.Roulette;
using SuperMinersServerApplication.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersServerApplication.Controller.Game
{
    public class RouletteAwardController
    {
        /// <summary>
        /// 奖项只限12个
        /// </summary>
        public RouletteAwardItem[] _listRouletteAwardItems = null;
        private object _lockAwardIems = new object();

        /// <summary>
        /// 临时中奖记录。key: UserName, value:AwardItemIndex
        /// </summary>
        public Dictionary<string, int> _tempRouletteWinnerRecord = new Dictionary<string, int>();

        /// <summary>
        /// 最终中奖记录。key: UserName
        /// </summary>
        public List<RouletteWinnerRecord> _finishedRouletteWinnerRecord = new List<RouletteWinnerRecord>();

        /// <summary>
        /// 奖池累计矿石数
        /// </summary>
        public int _tempTotalStone = 0;
        /// <summary>
        /// 0,1两个指数
        /// </summary>
        private int _largeAwardExponent = 0;

        private int _noneAwardIndex = -1;
        private int[] _level0AwardIndexes = null;
        private int[] _level1AwardIndexes = null;


        public object _lockStart = new object();

        public void Init()
        {
            try
            {
                //从数据库读取
                _listRouletteAwardItems = DBProvider.GameRouletteDBProvider.GetRouletteAwardItems();

                FindKeyIndex(this._listRouletteAwardItems, out this._noneAwardIndex, out this._level0AwardIndexes, out this._level1AwardIndexes);
                ReStartLargeAwardExponent();
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("RouletteAwardController.Init Exception", exc);
            }
        }

        private void ReStartLargeAwardExponent()
        {
            if (this._level1AwardIndexes == null || this._level1AwardIndexes.Length == 0)
            {
                _largeAwardExponent = 0;
            }
            else
            {
                _largeAwardExponent = new Random(1).Next(0, 100) % 2;
            }

            _tempTotalStone = 0;
        }

        private void FindKeyIndex(RouletteAwardItem[] items, out int noneIndex, out int[] level0AwardIndexes, out int[] level1AwardIndexes)
        {
            List<int> listLevel0Indexes = new List<int>();
            List<int> listLevel1Indexes = new List<int>();
            int noneAwardIndex = -1;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].RouletteAwardType == RouletteAwardType.None)
                {
                    noneAwardIndex = i;
                }
                if (items[i].IsLargeAward)
                {
                    if (10 <= items[i].ValueMoneyYuan && items[i].ValueMoneyYuan < 50)
                    {
                        listLevel0Indexes.Add(i);
                    }
                    if (50 <= items[i].ValueMoneyYuan)
                    {
                        listLevel1Indexes.Add(i);
                    }
                }
            }

            noneIndex = noneAwardIndex;
            level0AwardIndexes = listLevel0Indexes.ToArray();
            level1AwardIndexes = listLevel1Indexes.ToArray();
        }

        public bool SetAwardItems(RouletteAwardItem[] items)
        {
            try
            {
                if (items == null || items.Length != 12)
                {
                    return false;
                }

                int noneIndex = -1;
                int[] level0AwardIndexes = null;
                int[] level1AwardIndexes = null;
                FindKeyIndex(items, out noneIndex, out level0AwardIndexes, out level1AwardIndexes);

                if (noneIndex < 0)
                {
                    return false;
                }

                lock (_lockAwardIems)
                {
                    this._listRouletteAwardItems = items;
                    this._noneAwardIndex = noneIndex;
                    this._level0AwardIndexes = level0AwardIndexes;
                    this._level1AwardIndexes = level1AwardIndexes;
                    ReStartLargeAwardExponent();

                    //保存到数据库
                    DBProvider.GameRouletteDBProvider.SaveRouletteAwardItems(items);
                }
                return true;
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("SetAwardItems Exception.", exc);
                return false;
            }
        }

        public RouletteAwardItem[] GetAwardItems()
        {
            lock (_lockAwardIems)
            {
                return this._listRouletteAwardItems;
            }
        }

        public RouletteWinAwardResult Start(string userName)
        {
            RouletteWinAwardResult result = new RouletteWinAwardResult();
            if (_listRouletteAwardItems == null)
            {
                result.OperResultCode = OperResult.RESULTCODE_FALSE;
                return result;
            }

            lock (_lockStart)
            {
                _tempTotalStone += GlobalConfig.GameConfig.RouletteSpendStone;

                if (_largeAwardExponent == 0)
                {
                    if (_tempTotalStone >= 10 * GlobalConfig.GameConfig.Yuan_RMB * GlobalConfig.GameConfig.Stones_RMB)
                    {
                        if (this._level0AwardIndexes != null && this._level0AwardIndexes.Length != 0)
                        {
                            if (this._level0AwardIndexes.Length == 1)
                            {
                                result.WinAwardNumber = this._level0AwardIndexes[0];
                                result.OperResultCode = OperResult.RESULTCODE_TRUE;
                                return result;
                            }
                            else
                            {
                                int index = new Random(1).Next(100) % this._level0AwardIndexes.Length;
                                result.WinAwardNumber = this._level0AwardIndexes[index];
                                result.OperResultCode = OperResult.RESULTCODE_TRUE;
                                return result;
                            }
                        }
                    }
                }
                else
                {
                    if (_tempTotalStone >= 50 * GlobalConfig.GameConfig.Yuan_RMB * GlobalConfig.GameConfig.Stones_RMB)
                    {
                        if (this._level1AwardIndexes != null && this._level1AwardIndexes.Length != 0)
                        {
                            if (this._level1AwardIndexes.Length == 1)
                            {
                                result.WinAwardNumber = this._level1AwardIndexes[0];
                                result.OperResultCode = OperResult.RESULTCODE_TRUE;
                                return result;
                            }
                            else
                            {
                                int index = new Random(1).Next(100) % this._level1AwardIndexes.Length;
                                result.WinAwardNumber = this._level1AwardIndexes[index];
                                result.OperResultCode = OperResult.RESULTCODE_TRUE;
                                return result;
                            }
                        }
                    }
                }

                Random r = new Random(1);
                int value = r.Next(0, 100);
                float totalProbabilityMaxValue = 0;

                int winAwardNumber = this._noneAwardIndex;
                for (int i = 0; i < 12; i++)
                {
                    var awardItem = this._listRouletteAwardItems[i];
                    float itemProbabilityMaxValue = totalProbabilityMaxValue + awardItem.WinProbability * 100;
                    if (value < itemProbabilityMaxValue)
                    {
                        winAwardNumber = i;
                        break;
                    }

                    totalProbabilityMaxValue = itemProbabilityMaxValue;
                }

                result.WinAwardNumber = winAwardNumber;
                result.OperResultCode = OperResult.RESULTCODE_TRUE;

                if (_tempRouletteWinnerRecord.ContainsKey(userName))
                {
                    _tempRouletteWinnerRecord.Remove(userName);
                }
                _tempRouletteWinnerRecord.Add(userName, winAwardNumber);

                return result;
            }
        }

        public RouletteWinnerRecord Finish(int userID, string userName, int winAwardNumber)
        {
            int serverWinAwardNumber = -1;

            if (!this._tempRouletteWinnerRecord.TryGetValue(userName, out serverWinAwardNumber))
            {
                return null;
            }
            if (serverWinAwardNumber != winAwardNumber)
            {
                return null;
            }
            this._tempRouletteWinnerRecord.Remove(userName);
            
            RouletteWinnerRecord record = new RouletteWinnerRecord()
            {
                AwardItem = this._listRouletteAwardItems[winAwardNumber],
                UserID = userID,
                UserName = userName,
                WinTime = DateTime.Now,
                IsGot = false,
                IsPay = false
            };

            if (!this._listRouletteAwardItems[winAwardNumber].IsRealAward)
            {
                if (RouletteWinVirtualAwardPay != null)
                {
                    RouletteWinVirtualAwardPay(userName, this._listRouletteAwardItems[winAwardNumber]);
                }
                record.IsGot = true;
                record.IsPay = true;
            }

            //Save Record
            DBProvider.GameRouletteDBProvider.SaveRouletteWinnerRecord(record);

            //通知

            this._finishedRouletteWinnerRecord.Add(record);

            return record;
        }

        /// <summary>
        /// 领取奖励
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="recordID"></param>
        /// <param name="info1"></param>
        /// <param name="info2"></param>
        public int GetAward(string userName, int recordID, string info1, string info2)
        {
            RouletteWinnerRecord record = this._finishedRouletteWinnerRecord.FirstOrDefault(r => r.UserName == userName && r.RecordID == recordID);
            if (record == null)
            {
                return OperResult.RESULTCODE_GAME_WINAWARDRECORD_NOT_EXIST;
            }
            record.IsGot = true;
            //Save to DB
            //Notify Administrator

            return OperResult.RESULTCODE_TRUE;
        }

        public int PayAward(string playerUserName, int recordID)
        {
            RouletteWinnerRecord record = this._finishedRouletteWinnerRecord.FirstOrDefault(r => r.UserName == playerUserName && r.RecordID == recordID);
            if (record == null)
            {
                return OperResult.RESULTCODE_GAME_WINAWARDRECORD_NOT_EXIST;
            }

            record.IsPay = true;

            //save To DB
            //notify player

            return OperResult.RESULTCODE_TRUE;
        }

        public event Action<string, RouletteAwardItem> RouletteWinVirtualAwardPay;
    }
}