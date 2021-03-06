﻿using MetaData.Game.StoneStack;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProvider
{
    public class StoneStackDBProvider
    {
        public StoneStackDailyRecordInfo[] GetAllStoneStackDailyRecordInfo()
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                string sqlText = "SELECT * FROM  stonestackdailyrecordinfo order by id;";
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = sqlText;
                myconn.Open();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(table);

                var lists = MetaDBAdapter<StoneStackDailyRecordInfo>.GetStoneStackDailyRecordInfoFromDataTable(table);
                table.Clear();
                table.Dispose();
                adapter.Dispose();

                return lists;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public StoneStackDailyRecordInfo GetLastStoneStackDailyRecordInfo()
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                string sqlText = "SELECT * FROM  stonestackdailyrecordinfo order by id desc limit 1;";
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = sqlText;
                myconn.Open();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(table);

                var list = MetaDBAdapter<StoneStackDailyRecordInfo>.GetStoneStackDailyRecordInfoFromDataTable(table);
                table.Clear();
                table.Dispose();
                adapter.Dispose();

                if (list == null || list.Length != 1)
                {
                    return null;
                }

                return list[0];
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        /// <summary>
        /// 包括Waiting和Splited
        /// </summary>
        /// <returns></returns>
        public StoneDelegateSellOrderInfo[] GetAllNotFinishedStoneDelegateSellOrderInfo()
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                string sqlText = "SELECT n.* , p.UserName FROM  notfinishedstonedelegatesellorderinfo n left join playersimpleinfo p on n.UserID = p.id; ";
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = sqlText;
                myconn.Open();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(table);

                var lists = MetaDBAdapter<StoneDelegateSellOrderInfo>.GetStoneDelegateSellOrderInfoFromDataTable(table);
                table.Clear();
                table.Dispose();
                adapter.Dispose();

                return lists;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public bool ClearNotPayedNotFinishedStoneDelegateBuyOrder()
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                string sqlText = "delete FROM  notfinishedstonedelegatebuyorderinfo where `BuyState`  = @BuyState; ";
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = sqlText;
                mycmd.Parameters.AddWithValue("@BuyState", StoneDelegateBuyState.NotPayed);
                myconn.Open();

                mycmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        /// <summary>
        /// 包括Waiting和Splited
        /// </summary>
        /// <returns></returns>
        public StoneDelegateBuyOrderInfo[] GetAllNotFinishedStoneDelegateBuyOrderInfo()
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                string sqlText = "SELECT n.* , p.UserName FROM  notfinishedstonedelegatebuyorderinfo n left join playersimpleinfo p on n.UserID = p.id; ";
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = sqlText;
                myconn.Open();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(table);

                var lists = MetaDBAdapter<StoneDelegateBuyOrderInfo>.GetStoneDelegateBuyOrderInfoFromDataTable(table, false);
                table.Clear();
                table.Dispose();
                adapter.Dispose();

                return lists;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        /// <summary>
        /// 保存到完成表，并从未完成表中删除
        /// </summary>
        /// <param name="sellOrder"></param>
        /// <returns></returns>
        public bool SaveFinishedStoneDelegateSellOrderInfo(StoneDelegateSellOrderInfo sellOrder)
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myconn.CreateCommand();

                string cmdTextA = "insert into finishedstonedelegatesellorderinfo " +
                    "(`OrderNumber`, `UserID`, `Price`, `TradeStoneHandCount`, `FinishedStoneTradeHandCount`, `SellState`, `DelegateTime`, `IsSubOrder`, `ParentOrderNumber`, `FinishedTime` ) " +
                    " values " +
                    "(@OrderNumber, @UserID, @Price, @TradeStoneHandCount, @FinishedStoneTradeHandCount, @SellState, @DelegateTime, @IsSubOrder, @ParentOrderNumber, @FinishedTime); ";

                string cmdTextB = "delete from notfinishedstonedelegatesellorderinfo where `OrderNumber` = @OrderNumber ;";

                mycmd.CommandText = cmdTextA + cmdTextB;
                mycmd.Parameters.AddWithValue("@OrderNumber", sellOrder.OrderNumber);
                mycmd.Parameters.AddWithValue("@UserID", sellOrder.UserID);
                mycmd.Parameters.AddWithValue("@Price", sellOrder.SellUnit.Price);
                mycmd.Parameters.AddWithValue("@TradeStoneHandCount", sellOrder.SellUnit.TradeStoneHandCount);
                mycmd.Parameters.AddWithValue("@FinishedStoneTradeHandCount", sellOrder.FinishedStoneTradeHandCount);
                mycmd.Parameters.AddWithValue("@SellState", (int)sellOrder.SellState);
                mycmd.Parameters.AddWithValue("@DelegateTime", sellOrder.DelegateTime.ToDateTime());
                mycmd.Parameters.AddWithValue("@IsSubOrder", sellOrder.IsSubOrder);
                if (sellOrder.ParentOrderNumber == null)
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", DBNull.Value);
                }
                else
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", sellOrder.ParentOrderNumber);
                }
                mycmd.Parameters.AddWithValue("@FinishedTime", sellOrder.FinishedTime);

                myconn.Open();
                mycmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        /// <summary>
        /// 保存到未完成表
        /// </summary>
        /// <param name="sellOrder"></param>
        /// <returns></returns>
        public bool SaveWaitingStoneDelegateSellOrderInfo(StoneDelegateSellOrderInfo sellOrder, CustomerMySqlTransaction myTrans)
        {
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myTrans.CreateCommand();

                string cmdTextA = "insert into notfinishedstonedelegatesellorderinfo " +
                    "(`OrderNumber`, `UserID`, `Price`, `TradeStoneHandCount`, `FinishedStoneTradeHandCount`, `SellState`, `DelegateTime`, `IsSubOrder`, `ParentOrderNumber` ) " +
                    " values " +
                    "(@OrderNumber, @UserID, @Price, @TradeStoneHandCount, @FinishedStoneTradeHandCount, @SellState, @DelegateTime, @IsSubOrder, @ParentOrderNumber ); ";

                mycmd.CommandText = cmdTextA;
                mycmd.Parameters.AddWithValue("@OrderNumber", sellOrder.OrderNumber);
                mycmd.Parameters.AddWithValue("@UserID", sellOrder.UserID);
                mycmd.Parameters.AddWithValue("@Price", sellOrder.SellUnit.Price);
                mycmd.Parameters.AddWithValue("@TradeStoneHandCount", sellOrder.SellUnit.TradeStoneHandCount);
                mycmd.Parameters.AddWithValue("@FinishedStoneTradeHandCount", sellOrder.FinishedStoneTradeHandCount);
                mycmd.Parameters.AddWithValue("@SellState", (int)sellOrder.SellState);
                mycmd.Parameters.AddWithValue("@DelegateTime", sellOrder.DelegateTime.ToDateTime());
                mycmd.Parameters.AddWithValue("@IsSubOrder", sellOrder.IsSubOrder);
                if (sellOrder.ParentOrderNumber == null)
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", DBNull.Value);
                }
                else
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", sellOrder.ParentOrderNumber);
                }

                mycmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
            }
        }

        /// <summary>
        /// 保存到未完成表
        /// </summary>
        /// <param name="sellOrder"></param>
        /// <returns></returns>
        public bool SaveWaitingStoneDelegateSellOrderInfo(StoneDelegateSellOrderInfo sellOrder)
        {
            CustomerMySqlTransaction myTrans = MyDBHelper.Instance.CreateTrans();
            try
            {
                SaveWaitingStoneDelegateSellOrderInfo(sellOrder, myTrans);
                myTrans.Commit();
                return true;
            }
            catch (Exception exc)
            {
                myTrans.Rollback();
                throw exc;
            }
            finally
            {
                if (myTrans != null)
                {
                    myTrans.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sellOrder"></param>
        /// <param name="myTrans"></param>
        /// <returns></returns>
        public bool CancelSellStoneOrder(StoneDelegateSellOrderInfo sellOrder, CustomerMySqlTransaction myTrans)
        {
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myTrans.CreateCommand();

                //string cmdTextA = "update  notfinishedstonedelegatesellorderinfo set `SellState`=@SellState,`FinishedTime`=@FinishedTime where `OrderNumber` = @OrderNumber";

                //mycmd.CommandText = cmdTextA;
                //mycmd.Parameters.AddWithValue("@SellState", (int)sellOrder.SellState);
                //mycmd.Parameters.AddWithValue("@FinishedTime", sellOrder.FinishedTime.ToDateTime());
                //mycmd.Parameters.AddWithValue("@OrderNumber", sellOrder.OrderNumber);

                //mycmd.ExecuteNonQuery();
                //return true;


                string cmdTextA = "insert into stonedelegatesellordercanceledinfo " +
                    "(`OrderNumber`, `UserID`, `Price`, `TradeStoneHandCount`, `FinishedStoneTradeHandCount`, `SellState`, `DelegateTime`, `IsSubOrder`, `ParentOrderNumber`, `FinishedTime` ) " +
                    " values " +
                    "(@OrderNumber, @UserID, @Price, @TradeStoneHandCount, @FinishedStoneTradeHandCount, @SellState, @DelegateTime, @IsSubOrder, @ParentOrderNumber, @FinishedTime); ";

                string cmdTextB = "delete from notfinishedstonedelegatesellorderinfo where `OrderNumber` = @OrderNumber ;";

                mycmd.CommandText = cmdTextA + cmdTextB;
                mycmd.Parameters.AddWithValue("@OrderNumber", sellOrder.OrderNumber);
                mycmd.Parameters.AddWithValue("@UserID", sellOrder.UserID);
                mycmd.Parameters.AddWithValue("@Price", sellOrder.SellUnit.Price);
                mycmd.Parameters.AddWithValue("@TradeStoneHandCount", sellOrder.SellUnit.TradeStoneHandCount);
                mycmd.Parameters.AddWithValue("@FinishedStoneTradeHandCount", sellOrder.FinishedStoneTradeHandCount);
                mycmd.Parameters.AddWithValue("@SellState", (int)sellOrder.SellState);
                mycmd.Parameters.AddWithValue("@DelegateTime", sellOrder.DelegateTime.ToDateTime());
                mycmd.Parameters.AddWithValue("@IsSubOrder", sellOrder.IsSubOrder);
                if (sellOrder.ParentOrderNumber == null)
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", DBNull.Value);
                }
                else
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", sellOrder.ParentOrderNumber);
                }
                mycmd.Parameters.AddWithValue("@FinishedTime", sellOrder.FinishedTime);

                //myconn.Open();
                mycmd.ExecuteNonQuery();
                return true;

            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
            }
        }

        public StoneDelegateSellOrderInfo[] GetAllFinishedStoneDelegateSellOrderInfoByPlayer(string userName, MetaData.MyDateTime myBeginFinishedTime, MetaData.MyDateTime myEndFinishedTime, int pageItemCount, int pageIndex)
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myconn.CreateCommand();
                string sqlTextA = "SELECT n.* FROM  finishedstonedelegatesellorderinfo n ";

                StringBuilder builder = new StringBuilder();
                if (!string.IsNullOrEmpty(userName))
                {
                    builder.Append(" n.UserID = ( select id from   playersimpleinfo where UserName = @UserName ) ");
                    mycmd.Parameters.AddWithValue("@UserName", DESEncrypt.EncryptDES(userName));
                }
                if (myBeginFinishedTime != null && !myBeginFinishedTime.IsNull && myEndFinishedTime != null && !myEndFinishedTime.IsNull)
                {
                    if (builder.Length != 0)
                    {
                        builder.Append(" and ");
                    }
                    DateTime beginFinishedTime = myBeginFinishedTime.ToDateTime();
                    DateTime endFinishedTime = myEndFinishedTime.ToDateTime();
                    if (beginFinishedTime >= endFinishedTime)
                    {
                        return null;
                    }
                    builder.Append(" n.FinishedTime >= @beginFinishedTime and n.FinishedTime < @endFinishedTime ");
                    mycmd.Parameters.AddWithValue("@beginFinishedTime", beginFinishedTime);
                    mycmd.Parameters.AddWithValue("@endFinishedTime", endFinishedTime);
                }
                string sqlWhere = "";
                if (builder.Length > 0)
                {
                    sqlWhere = " where " + builder.ToString();
                }

                string sqlOrderLimit = " order by n.id desc ";
                if (pageItemCount > 0)
                {
                    int start = pageIndex <= 0 ? 0 : (pageIndex - 1) * pageItemCount;
                    sqlOrderLimit += " limit " + start.ToString() + ", " + pageItemCount;
                }

                string sqlAllText = "select ttt.*, s.UserName as UserName from " +
                                    " ( " + sqlTextA + sqlWhere + sqlOrderLimit +
                                    " ) ttt " +
                                    "  left join   playersimpleinfo s  on ttt.UserID = s.id ";

                mycmd.CommandText = sqlAllText;
                myconn.Open();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(table);

                var lists = MetaDBAdapter<StoneDelegateSellOrderInfo>.GetStoneDelegateSellOrderInfoFromDataTable(table);

                table.Clear();
                table.Dispose();
                adapter.Dispose();

                return lists;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public StoneDelegateSellOrderInfo[] GetNotFinishedStoneDelegateSellOrderInfoByPlayer(int userID)
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                string sqlText = "SELECT n.* , p.UserName FROM  notfinishedstonedelegatesellorderinfo n left join playersimpleinfo p on n.UserID = p.id where n.UserID = @UserID; ";
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = sqlText;
                mycmd.Parameters.AddWithValue("@UserID", userID);
                myconn.Open();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(table);

                var lists = MetaDBAdapter<StoneDelegateSellOrderInfo>.GetStoneDelegateSellOrderInfoFromDataTable(table);
                table.Clear();
                table.Dispose();
                adapter.Dispose();

                return lists;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        /// <summary>
        /// 保存到完成表
        /// </summary>
        /// <param name="buyOrder"></param>
        /// <returns></returns>
        public bool SaveFinishedStoneDelegateBuyOrderInfo(StoneDelegateBuyOrderInfo buyOrder)
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myconn.CreateCommand();

                string cmdTextA = "insert into finishedstonedelegatebuyorderinfo " +
                    "(`OrderNumber`, `UserID`, `Price`, `TradeStoneHandCount`, `PayType`, `FinishedStoneTradeHandCount`, `BuyState`, `DelegateTime`, `IsSubOrder`, `ParentOrderNumber`, `FinishedTime`, `AwardGoldCoin` ) " +
                    " values " +
                    "(@OrderNumber, @UserID, @Price, @TradeStoneHandCount, @PayType, @FinishedStoneTradeHandCount, @BuyState, @DelegateTime, @IsSubOrder, @ParentOrderNumber, @FinishedTime, @AwardGoldCoin); ";

                string cmdTextB = "delete from notfinishedstonedelegatebuyorderinfo where `OrderNumber` = @OrderNumber ;";

                mycmd.CommandText = cmdTextA + cmdTextB;
                mycmd.Parameters.AddWithValue("@OrderNumber", buyOrder.OrderNumber);
                mycmd.Parameters.AddWithValue("@UserID", buyOrder.UserID);
                mycmd.Parameters.AddWithValue("@Price", buyOrder.BuyUnit.Price);
                mycmd.Parameters.AddWithValue("@TradeStoneHandCount", buyOrder.BuyUnit.TradeStoneHandCount);
                mycmd.Parameters.AddWithValue("@PayType", (int)buyOrder.PayType);
                mycmd.Parameters.AddWithValue("@FinishedStoneTradeHandCount", buyOrder.FinishedStoneTradeHandCount);
                mycmd.Parameters.AddWithValue("@BuyState", (int)buyOrder.BuyState);
                mycmd.Parameters.AddWithValue("@DelegateTime", buyOrder.DelegateTime.ToDateTime());
                mycmd.Parameters.AddWithValue("@IsSubOrder", buyOrder.IsSubOrder);
                if (buyOrder.ParentOrderNumber == null)
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", DBNull.Value);
                }
                else
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", buyOrder.ParentOrderNumber);
                }
                mycmd.Parameters.AddWithValue("@FinishedTime", buyOrder.FinishedTime.ToDateTime());
                mycmd.Parameters.AddWithValue("@AwardGoldCoin", buyOrder.AwardGoldCoin);

                myconn.Open();
                mycmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        /// <summary>
        /// 主要给支付宝订单使用
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="buyState"></param>
        /// <returns></returns>
        public bool UpdateWaitingStoneDelegateBuyOrderState(string orderNumber, StoneDelegateBuyState buyState, CustomerMySqlTransaction myTrans)
        {
            MySqlCommand mycmd = null;
            try
            {
                string cmdText = "update notfinishedstonedelegatebuyorderinfo set `BuyState` = @BuyState where `OrderNumber` = @OrderNumber;";

                mycmd = myTrans.CreateCommand();
                mycmd.CommandText = cmdText;
                mycmd.Parameters.AddWithValue("@BuyState", (int)buyState);
                mycmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
                mycmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
            }
        }

        /// <summary>
        /// 保存到未完成表
        /// </summary>
        /// <param name="buyOrder"></param>
        /// <returns></returns>
        public bool SaveWaitingStoneDelegateBuyOrderInfo(StoneDelegateBuyOrderInfo buyOrder, CustomerMySqlTransaction myTrans)
        {
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myTrans.CreateCommand();

                string cmdTextA = "insert into notfinishedstonedelegatebuyorderinfo " +
                    "(`OrderNumber`, `UserID`, `Price`, `TradeStoneHandCount`, `PayType`, `FinishedStoneTradeHandCount`, `BuyState`, `DelegateTime`, `IsSubOrder`, `ParentOrderNumber`, `AlipayLink` ) " +
                    " values " +
                    "(@OrderNumber, @UserID, @Price, @TradeStoneHandCount, @PayType, @FinishedStoneTradeHandCount, @BuyState, @DelegateTime, @IsSubOrder, @ParentOrderNumber, @AlipayLink ); ";

                mycmd.CommandText = cmdTextA;
                mycmd.Parameters.AddWithValue("@OrderNumber", buyOrder.OrderNumber);
                mycmd.Parameters.AddWithValue("@UserID", buyOrder.UserID);
                mycmd.Parameters.AddWithValue("@Price", buyOrder.BuyUnit.Price);
                mycmd.Parameters.AddWithValue("@TradeStoneHandCount", buyOrder.BuyUnit.TradeStoneHandCount);
                mycmd.Parameters.AddWithValue("@PayType", (int)buyOrder.PayType);
                mycmd.Parameters.AddWithValue("@FinishedStoneTradeHandCount", buyOrder.FinishedStoneTradeHandCount);
                mycmd.Parameters.AddWithValue("@BuyState", (int)buyOrder.BuyState);
                mycmd.Parameters.AddWithValue("@DelegateTime", buyOrder.DelegateTime.ToDateTime());
                mycmd.Parameters.AddWithValue("@IsSubOrder", buyOrder.IsSubOrder);

                if (buyOrder.ParentOrderNumber == null)
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", DBNull.Value);
                }
                else
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", buyOrder.ParentOrderNumber);
                }
                mycmd.Parameters.AddWithValue("@AlipayLink", buyOrder.AlipayLink == null ? DBNull.Value : (object)buyOrder.AlipayLink);

                mycmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
            }
        }

        /// <summary>
        /// 保存到未完成表
        /// </summary>
        /// <param name="buyOrder"></param>
        /// <returns></returns>
        public bool SaveWaitingStoneDelegateBuyOrderInfo(StoneDelegateBuyOrderInfo buyOrder)
        {
            CustomerMySqlTransaction myTrans = MyDBHelper.Instance.CreateTrans();
            try
            {
                SaveWaitingStoneDelegateBuyOrderInfo(buyOrder, myTrans);
                myTrans.Commit();
                return true;
            }
            catch (Exception exc)
            {
                myTrans.Rollback();
                throw exc;
            }
            finally
            {
                if (myTrans != null)
                {
                    myTrans.Dispose();
                }
            }
        }

        public bool CancelBuyStoneOrder(StoneDelegateBuyOrderInfo buyOrder, CustomerMySqlTransaction myTrans)
        {
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myTrans.CreateCommand();

                //string cmdTextA = "update  notfinishedstonedelegatebuyorderinfo set `BuyState`=@BuyState,`FinishedTime`=@FinishedTime where `OrderNumber` = @OrderNumber";

                //mycmd.CommandText = cmdTextA;
                //mycmd.Parameters.AddWithValue("@BuyState", (int)buyOrder.BuyState);
                //mycmd.Parameters.AddWithValue("@FinishedTime", buyOrder.FinishedTime.ToDateTime());
                //mycmd.Parameters.AddWithValue("@OrderNumber", buyOrder.OrderNumber);

                //mycmd.ExecuteNonQuery();
                //return true;


                //mycmd = myconn.CreateCommand();

                string cmdTextA = "insert into stonedelegatebuyordercanceledinfo " +
                    "(`OrderNumber`, `UserID`, `Price`, `TradeStoneHandCount`, `PayType`, `FinishedStoneTradeHandCount`, `BuyState`, `DelegateTime`, `IsSubOrder`, `ParentOrderNumber`, `FinishedTime`, `AwardGoldCoin` ) " +
                    " values " +
                    "(@OrderNumber, @UserID, @Price, @TradeStoneHandCount, @PayType, @FinishedStoneTradeHandCount, @BuyState, @DelegateTime, @IsSubOrder, @ParentOrderNumber, @FinishedTime, @AwardGoldCoin); ";

                string cmdTextB = "delete from notfinishedstonedelegatebuyorderinfo where `OrderNumber` = @OrderNumber ;";

                mycmd.CommandText = cmdTextA + cmdTextB;
                mycmd.Parameters.AddWithValue("@OrderNumber", buyOrder.OrderNumber);
                mycmd.Parameters.AddWithValue("@UserID", buyOrder.UserID);
                mycmd.Parameters.AddWithValue("@Price", buyOrder.BuyUnit.Price);
                mycmd.Parameters.AddWithValue("@TradeStoneHandCount", buyOrder.BuyUnit.TradeStoneHandCount);
                mycmd.Parameters.AddWithValue("@PayType", (int)buyOrder.PayType);
                mycmd.Parameters.AddWithValue("@FinishedStoneTradeHandCount", buyOrder.FinishedStoneTradeHandCount);
                mycmd.Parameters.AddWithValue("@BuyState", (int)buyOrder.BuyState);
                mycmd.Parameters.AddWithValue("@DelegateTime", buyOrder.DelegateTime.ToDateTime());
                mycmd.Parameters.AddWithValue("@IsSubOrder", buyOrder.IsSubOrder);
                if (buyOrder.ParentOrderNumber == null)
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", DBNull.Value);
                }
                else
                {
                    mycmd.Parameters.AddWithValue("@ParentOrderNumber", buyOrder.ParentOrderNumber);
                }
                mycmd.Parameters.AddWithValue("@FinishedTime", buyOrder.FinishedTime.ToDateTime());
                mycmd.Parameters.AddWithValue("@AwardGoldCoin", buyOrder.AwardGoldCoin);

                //myconn.Open();
                mycmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
            }
        }

        public StoneDelegateBuyOrderInfo[] GetNotFinishedStoneDelegateBuyOrderInfoByPlayer(int userID)
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                string sqlText = "SELECT n.* , p.UserName FROM  notfinishedstonedelegatebuyorderinfo n left join playersimpleinfo p on n.UserID = p.id where n.UserID = @UserID; ";
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = sqlText;
                mycmd.Parameters.AddWithValue("@UserID", userID);
                myconn.Open();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(table);

                var lists = MetaDBAdapter<StoneDelegateBuyOrderInfo>.GetStoneDelegateBuyOrderInfoFromDataTable(table, false);

                table.Clear();
                table.Dispose();
                adapter.Dispose();

                return lists;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public StoneDelegateBuyOrderInfo[] GetAllFinishedStoneDelegateBuyOrderInfoByPlayer(string userName, MetaData.MyDateTime myBeginCreateTime, MetaData.MyDateTime myEndCreateTime, int pageItemCount, int pageIndex)
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myconn.CreateCommand();
                string sqlTextA = "SELECT n.* FROM  finishedstonedelegatebuyorderinfo n ";

                StringBuilder builder = new StringBuilder();
                if (!string.IsNullOrEmpty(userName))
                {
                    builder.Append(" n.UserID = ( select id from   playersimpleinfo where UserName = @UserName ) ");
                    mycmd.Parameters.AddWithValue("@UserName", DESEncrypt.EncryptDES(userName));
                }
                if (myBeginCreateTime != null && !myBeginCreateTime.IsNull && myEndCreateTime != null && !myEndCreateTime.IsNull)
                {
                    if (builder.Length != 0)
                    {
                        builder.Append(" and ");
                    }
                    DateTime beginCreateTime = myBeginCreateTime.ToDateTime();
                    DateTime endCreateTime = myEndCreateTime.ToDateTime();
                    if (beginCreateTime >= endCreateTime)
                    {
                        return null;
                    }
                    builder.Append(" n.DelegateTime >= @beginCreateTime and n.DelegateTime < @endCreateTime ");
                    mycmd.Parameters.AddWithValue("@beginCreateTime", beginCreateTime);
                    mycmd.Parameters.AddWithValue("@endCreateTime", endCreateTime);
                }
                string sqlWhere = "";
                if (builder.Length > 0)
                {
                    sqlWhere = " where " + builder.ToString();
                }

                string sqlOrderLimit = " order by n.id desc ";
                if (pageItemCount > 0)
                {
                    int start = pageIndex <= 0 ? 0 : (pageIndex - 1) * pageItemCount;
                    sqlOrderLimit += " limit " + start.ToString() + ", " + pageItemCount;
                }

                string sqlAllText = "select ttt.*, s.UserName as UserName from " +
                                    " ( " + sqlTextA + sqlWhere + sqlOrderLimit +
                                    " ) ttt " +
                                    "  left join   playersimpleinfo s  on ttt.UserID = s.id ";

                mycmd.CommandText = sqlAllText;
                myconn.Open();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                adapter.Fill(table);

                var lists = MetaDBAdapter<StoneDelegateBuyOrderInfo>.GetStoneDelegateBuyOrderInfoFromDataTable(table, true);
                table.Clear();
                table.Dispose();
                adapter.Dispose();

                return lists;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }

        public bool SaveStoneStackDailyRecordInfo(StoneStackDailyRecordInfo dailyInfo)
        {
            MySqlConnection myconn = MyDBHelper.Instance.CreateConnection();
            MySqlCommand mycmd = null;
            try
            {
                mycmd = myconn.CreateCommand();

                string cmdTextSelect = "select * from stonestackdailyrecordinfo where `Day` = @Day;";
                mycmd.CommandText = cmdTextSelect;
                mycmd.Parameters.AddWithValue("@Day", dailyInfo.Day);

                MySqlDataAdapter adapter = new MySqlDataAdapter(mycmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                adapter.Dispose();
                mycmd.Dispose();

                mycmd = myconn.CreateCommand();
                string cmdTextA = "";
                if (table.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(table.Rows[0]["id"]);

                    cmdTextA = "update stonestackdailyrecordinfo set `OpenPrice` = @OpenPrice, `ClosePrice` = @ClosePrice, `MinTradeSucceedPrice` = @MinTradeSucceedPrice, " +
                        " `MaxTradeSucceedPrice` = @MaxTradeSucceedPrice, `TradeSucceedStoneHandSum` = @TradeSucceedStoneHandSum, `TradeSucceedRMBSum` = @TradeSucceedRMBSum, " +
                        " `DelegateSellStoneSum` = @DelegateSellStoneSum, `DelegateBuyStoneSum` = @DelegateBuyStoneSum " +
                        " where `id` = @id ";

                    mycmd.Parameters.AddWithValue("@id", id);
                }
                else
                {
                    cmdTextA = "insert into stonestackdailyrecordinfo " +
                        "(`Day`, `OpenPrice`, `ClosePrice`, `MinTradeSucceedPrice`, `MaxTradeSucceedPrice`, `TradeSucceedStoneHandSum`, `TradeSucceedRMBSum`, `DelegateSellStoneSum`, `DelegateBuyStoneSum` ) " +
                        " values " +
                        "(@Day, @OpenPrice, @ClosePrice, @MinTradeSucceedPrice, @MaxTradeSucceedPrice, @TradeSucceedStoneHandSum, @TradeSucceedRMBSum, @DelegateSellStoneSum, @DelegateBuyStoneSum ); ";

                    mycmd.Parameters.AddWithValue("@Day", dailyInfo.Day);
                }

                mycmd.CommandText = cmdTextA;
                mycmd.Parameters.AddWithValue("@OpenPrice", dailyInfo.OpenPrice);
                mycmd.Parameters.AddWithValue("@ClosePrice", dailyInfo.ClosePrice);
                mycmd.Parameters.AddWithValue("@MinTradeSucceedPrice", dailyInfo.MinTradeSucceedPrice);
                mycmd.Parameters.AddWithValue("@MaxTradeSucceedPrice", dailyInfo.MaxTradeSucceedPrice);
                mycmd.Parameters.AddWithValue("@TradeSucceedStoneHandSum", dailyInfo.TradeSucceedStoneHandSum);
                mycmd.Parameters.AddWithValue("@TradeSucceedRMBSum", dailyInfo.TradeSucceedRMBSum);
                mycmd.Parameters.AddWithValue("@DelegateSellStoneSum", dailyInfo.DelegateSellStoneSum);
                mycmd.Parameters.AddWithValue("@DelegateBuyStoneSum", dailyInfo.DelegateBuyStoneSum);

                myconn.Open();
                mycmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (mycmd != null)
                {
                    mycmd.Dispose();
                }
                MyDBHelper.Instance.DisposeConnection(myconn);
            }
        }
    }
}
