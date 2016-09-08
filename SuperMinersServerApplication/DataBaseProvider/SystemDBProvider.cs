﻿using MetaData.SystemConfig;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProvider
{
    public class SystemDBProvider
    {
        #region GameConfig

        public GameConfig GetGameConfig()
        {
            GameConfig config = null;
            MySqlConnection myconn = null;
            try
            {
                myconn = MyDBHelper.Instance.CreateConnection();
                myconn.Open();

                DataTable dt = new DataTable();

                string cmdText = "SELECT * FROM gameconfig";
                MySqlCommand mycmd = new MySqlCommand(cmdText, myconn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    config = new GameConfig();
                    config.Yuan_RMB = Convert.ToDecimal(dt.Rows[0]["Yuan_RMB"]);
                    config.RMB_GoldCoin = Convert.ToDecimal(dt.Rows[0]["RMB_GoldCoin"]);
                    config.RMB_Mine = Convert.ToDecimal(dt.Rows[0]["RMB_Mine"]);
                    config.GoldCoin_Miner = Convert.ToDecimal(dt.Rows[0]["GoldCoin_Miner"]);
                    config.Stones_RMB = Convert.ToDecimal(dt.Rows[0]["Stones_RMB"]);
                    config.Diamonds_RMB = Convert.ToDecimal(dt.Rows[0]["Diamonds_RMB"]);
                    config.StoneBuyerAwardGoldCoinMultiple = Convert.ToDecimal(dt.Rows[0]["StoneBuyerAwardGoldCoinMultiple"]);
                    config.OutputStonesPerHour = Convert.ToDecimal(dt.Rows[0]["OutputStonesPerHour"]);
                    config.TempStoneOutputValidHour = Convert.ToInt32(dt.Rows[0]["TempStoneOutputValidHour"]);
                    config.StonesReservesPerMines = Convert.ToDecimal(dt.Rows[0]["StonesReservesPerMines"]);
                    config.ExchangeExpensePercent = Convert.ToDecimal(dt.Rows[0]["ExchangeExpensePercent"]);
                    config.ExchangeExpenseMinNumber = Convert.ToDecimal(dt.Rows[0]["ExchangeExpenseMinNumber"]);
                    config.UserMaxHaveMinersCount = Convert.ToInt32(dt.Rows[0]["UserMaxHaveMinersCount"]);
                    config.BuyOrderLockTimeMinutes = Convert.ToInt32(dt.Rows[0]["BuyOrderLockTimeMinutes"]);
                    config.CanExchangeMinExp = Convert.ToInt32(dt.Rows[0]["CanExchangeMinExp"]);
                    config.CanDiscountMinExp = Convert.ToInt32(dt.Rows[0]["CanDiscountMinExp"]);
                    config.Discount = Convert.ToDecimal(dt.Rows[0]["Discount"]);

                    dt.Dispose();
                }

                mycmd.Dispose();

                return config;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public bool SaveGameConfig(GameConfig config, CustomerMySqlTransaction trans)
        {
            MySqlCommand mycmd = trans.CreateCommand();
            string cmdText = "delete from gameconfig; " +
                "insert into gameconfig (`Yuan_RMB`, `RMB_GoldCoin`, `RMB_Mine`, `GoldCoin_Miner`, `Stones_RMB`, `Diamonds_RMB`, `StoneBuyerAwardGoldCoinMultiple`, `OutputStonesPerHour`, `TempStoneOutputValidHour`, `StonesReservesPerMines`,  `ExchangeExpensePercent`, `ExchangeExpenseMinNumber`, `UserMaxHaveMinersCount`, `BuyOrderLockTimeMinutes`, `CanExchangeMinExp`, `CanDiscountMinExp`, `Discount`) values " +
                                    " (@Yuan_RMB, @RMB_GoldCoin, @RMB_Mine, @GoldCoin_Miner, @Stones_RMB, @Diamonds_RMB, @StoneBuyerAwardGoldCoinMultiple, @OutputStonesPerHour, @TempStoneOutputValidHour, @StonesReservesPerMines, @ExchangeExpensePercent, @ExchangeExpenseMinNumber, @UserMaxHaveMinersCount, @BuyOrderLockTimeMinutes, @CanExchangeMinExp, @CanDiscountMinExp, @Discount)";
            mycmd.CommandText = cmdText;
            mycmd.Parameters.AddWithValue("@Yuan_RMB", config.Yuan_RMB);
            mycmd.Parameters.AddWithValue("@RMB_GoldCoin", config.RMB_GoldCoin);
            mycmd.Parameters.AddWithValue("@RMB_Mine", config.RMB_Mine);
            mycmd.Parameters.AddWithValue("@GoldCoin_Miner", config.GoldCoin_Miner);
            mycmd.Parameters.AddWithValue("@Stones_RMB", config.Stones_RMB);
            mycmd.Parameters.AddWithValue("@Diamonds_RMB", config.Diamonds_RMB);
            mycmd.Parameters.AddWithValue("@StoneBuyerAwardGoldCoinMultiple", config.StoneBuyerAwardGoldCoinMultiple);
            mycmd.Parameters.AddWithValue("@OutputStonesPerHour", config.OutputStonesPerHour);
            mycmd.Parameters.AddWithValue("@TempStoneOutputValidHour", config.TempStoneOutputValidHour);
            mycmd.Parameters.AddWithValue("@StonesReservesPerMines", config.StonesReservesPerMines);
            mycmd.Parameters.AddWithValue("@ExchangeExpensePercent", config.ExchangeExpensePercent);
            mycmd.Parameters.AddWithValue("@ExchangeExpenseMinNumber", config.ExchangeExpenseMinNumber);
            mycmd.Parameters.AddWithValue("@UserMaxHaveMinersCount", config.UserMaxHaveMinersCount);
            mycmd.Parameters.AddWithValue("@BuyOrderLockTimeMinutes", config.BuyOrderLockTimeMinutes);
            mycmd.Parameters.AddWithValue("@CanExchangeMinExp", config.CanExchangeMinExp);
            mycmd.Parameters.AddWithValue("@CanDiscountMinExp", config.CanDiscountMinExp);
            mycmd.Parameters.AddWithValue("@Discount", config.Discount);

            mycmd.ExecuteNonQuery();
            //mycmd.Dispose();

            return true;
        }

        #endregion

        #region IncomeMoneyAccount

        public IncomeMoneyAccount GetIncomeMoneyAccountConfig()
        {
            IncomeMoneyAccount config = null;
            MySqlConnection myconn = null;
            try
            {
                myconn = MyDBHelper.Instance.CreateConnection();
                myconn.Open();

                DataTable dt = new DataTable();

                string cmdText = "SELECT * FROM incomemoneyaccount";
                MySqlCommand mycmd = new MySqlCommand(cmdText, myconn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    config = new IncomeMoneyAccount();
                    config.IncomeMoneyAlipay = Convert.ToString(dt.Rows[0]["IncomeMoneyAlipay"]);
                    config.IncomeMoneyAlipayRealName = Convert.ToString(dt.Rows[0]["IncomeMoneyAlipayRealName"]);
                    config.Alipay2DCode = (byte[])dt.Rows[0]["Alipay2DCode"];
                    dt.Dispose();
                }

                mycmd.Dispose();

                return config;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public bool SaveIncomeMoneyAccountConfig(IncomeMoneyAccount config)
        {
            MySqlConnection myconn = null;
            try
            {
                myconn = MyDBHelper.Instance.CreateConnection();
                myconn.Open();

                string cmdText = "delete from incomemoneyaccount; " +
                    "insert into incomemoneyaccount (IncomeMoneyAlipay, IncomeMoneyAlipayRealName, Alipay2DCode) values " +
                                        " (@IncomeMoneyAlipay, @IncomeMoneyAlipayRealName, @Alipay2DCode)";
                MySqlCommand mycmd = new MySqlCommand(cmdText, myconn);
                mycmd.Parameters.AddWithValue("@IncomeMoneyAlipay", config.IncomeMoneyAlipay);
                mycmd.Parameters.AddWithValue("@IncomeMoneyAlipayRealName", config.IncomeMoneyAlipayRealName);
                mycmd.Parameters.AddWithValue("@Alipay2DCode", config.Alipay2DCode);
                
                mycmd.ExecuteNonQuery();
                mycmd.Dispose();

                return true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        #endregion

        #region RegisterUserConfig

        public RegisterUserConfig GetRegisterUserConfig()
        {
            RegisterUserConfig config = null;
            MySqlConnection myconn = null;
            try
            {
                myconn = MyDBHelper.Instance.CreateConnection();
                myconn.Open();

                DataTable dt = new DataTable();

                string cmdText = "SELECT * FROM registeruserconfig";
                MySqlCommand mycmd = new MySqlCommand(cmdText, myconn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    config = new RegisterUserConfig();
                    config.UserCountCreateByOneIP = Convert.ToInt32(dt.Rows[0]["UserCountCreateByOneIP"]);
                    config.GiveToNewUserExp = Convert.ToDecimal(dt.Rows[0]["GiveToNewUserExp"]);
                    config.GiveToNewUserGoldCoin = Convert.ToDecimal(dt.Rows[0]["GiveToNewUserGoldCoin"]);
                    config.GiveToNewUserMines = Convert.ToDecimal(dt.Rows[0]["GiveToNewUserMines"]);
                    config.GiveToNewUserMiners = Convert.ToInt32(dt.Rows[0]["GiveToNewUserMiners"]);
                    config.GiveToNewUserStones = Convert.ToDecimal(dt.Rows[0]["GiveToNewUserStones"]);
                    config.FirstAlipayRechargeGoldCoinAwardMultiple = Convert.ToSingle(dt.Rows[0]["FirstAlipayRechargeGoldCoinAwardMultiple"]);

                    dt.Dispose();
                }

                mycmd.Dispose();

                return config;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public bool SaveRegisterUserConfig(RegisterUserConfig config, CustomerMySqlTransaction trans)
        {
            MySqlCommand mycmd = trans.CreateCommand();
            string cmdText = "delete from registeruserconfig; " +
                "insert into registeruserconfig (UserCountCreateByOneIP, GiveToNewUserExp, GiveToNewUserGoldCoin, GiveToNewUserMines, GiveToNewUserMiners, GiveToNewUserStones, FirstAlipayRechargeGoldCoinAwardMultiple ) values " +
                                    " (@UserCountCreateByOneIP, @GiveToNewUserExp, @GiveToNewUserGoldCoin, @GiveToNewUserMines, @GiveToNewUserMiners, @GiveToNewUserStones, @FirstAlipayRechargeGoldCoinAwardMultiple )";
            mycmd.CommandText = cmdText;
            mycmd.Parameters.AddWithValue("@UserCountCreateByOneIP", config.UserCountCreateByOneIP);
            mycmd.Parameters.AddWithValue("@GiveToNewUserExp", config.GiveToNewUserExp);
            mycmd.Parameters.AddWithValue("@GiveToNewUserGoldCoin", config.GiveToNewUserGoldCoin);
            mycmd.Parameters.AddWithValue("@GiveToNewUserMines", config.GiveToNewUserMines);
            mycmd.Parameters.AddWithValue("@GiveToNewUserMiners", config.GiveToNewUserMiners);
            mycmd.Parameters.AddWithValue("@GiveToNewUserStones", config.GiveToNewUserStones);
            mycmd.Parameters.AddWithValue("@FirstAlipayRechargeGoldCoinAwardMultiple", config.FirstAlipayRechargeGoldCoinAwardMultiple);

            mycmd.ExecuteNonQuery();
            //mycmd.Dispose();

            return true;
        }

        #endregion

        #region AwardReferrerConfig

        public List<AwardReferrerConfig> GetAwardReferrerConfig()
        {
            List<AwardReferrerConfig> listAwardConfig = new List<AwardReferrerConfig>();
            MySqlConnection myconn = null;
            try
            {
                myconn = MyDBHelper.Instance.CreateConnection();
                myconn.Open();

                DataTable dt = new DataTable();

                string cmdText = "SELECT * FROM awardreferrerconfig";
                MySqlCommand mycmd = new MySqlCommand(cmdText, myconn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AwardReferrerConfig config = new AwardReferrerConfig();
                    config.ReferLevel = Convert.ToInt32(dt.Rows[i]["ReferLevel"]);
                    config.AwardReferrerExp = Convert.ToDecimal(dt.Rows[i]["AwardReferrerExp"]);
                    config.AwardReferrerGoldCoin = Convert.ToDecimal(dt.Rows[i]["AwardReferrerGoldCoin"]);
                    config.AwardReferrerMines = Convert.ToDecimal(dt.Rows[i]["AwardReferrerMines"]);
                    config.AwardReferrerMiners = Convert.ToInt32(dt.Rows[i]["AwardReferrerMiners"]);
                    config.AwardReferrerStones = Convert.ToDecimal(dt.Rows[i]["AwardReferrerStones"]);
                    config.AwardReferrerDiamond = Convert.ToDecimal(dt.Rows[i]["AwardReferrerDiamond"]);
                    listAwardConfig.Add(config);
                }

                dt.Dispose();
                mycmd.Dispose();

                return listAwardConfig;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public bool SaveAwardReferrerConfig(List<AwardReferrerConfig> ListConfig, CustomerMySqlTransaction trans)
        {
            MySqlCommand mycmd = trans.CreateCommand();
            mycmd.CommandText = "delete from awardreferrerconfig; ";
            mycmd.ExecuteNonQuery();

            mycmd.CommandText = "insert into awardreferrerconfig (ReferLevel, AwardReferrerExp, AwardReferrerGoldCoin, AwardReferrerMines, AwardReferrerMiners, AwardReferrerStones, AwardReferrerDiamond ) values " +
                " (@ReferLevel, @AwardReferrerExp, @AwardReferrerGoldCoin, @AwardReferrerMines, @AwardReferrerMiners, @AwardReferrerStones, @AwardReferrerDiamond )";

            mycmd.Parameters.Add("@ReferLevel", MySqlDbType.Int32);
            mycmd.Parameters.AddWithValue("@AwardReferrerExp", MySqlDbType.Float);
            mycmd.Parameters.AddWithValue("@AwardReferrerGoldCoin", MySqlDbType.Float);
            mycmd.Parameters.AddWithValue("@AwardReferrerMines", MySqlDbType.Float);
            mycmd.Parameters.AddWithValue("@AwardReferrerMiners", MySqlDbType.Int32);
            mycmd.Parameters.AddWithValue("@AwardReferrerStones", MySqlDbType.Float);
            mycmd.Parameters.AddWithValue("@AwardReferrerDiamond", MySqlDbType.Float);

            foreach (var config in ListConfig)
            {
                mycmd.Parameters["@ReferLevel"].Value = config.ReferLevel;
                mycmd.Parameters["@AwardReferrerExp"].Value = config.AwardReferrerExp;
                mycmd.Parameters["@AwardReferrerGoldCoin"].Value = config.AwardReferrerGoldCoin;
                mycmd.Parameters["@AwardReferrerMines"].Value = config.AwardReferrerMines;
                mycmd.Parameters["@AwardReferrerMiners"].Value = config.AwardReferrerMiners;
                mycmd.Parameters["@AwardReferrerStones"].Value = config.AwardReferrerStones;
                mycmd.Parameters["@AwardReferrerDiamond"].Value = config.AwardReferrerDiamond;
                mycmd.ExecuteNonQuery();
            }

            //mycmd.Dispose();
            return true;
        }

        #endregion
    }
}
