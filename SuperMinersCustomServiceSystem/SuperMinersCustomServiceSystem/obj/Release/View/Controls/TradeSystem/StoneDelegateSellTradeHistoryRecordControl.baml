   M S B A M L   `   `   `  ���� Y  USuperMinersCustomServiceSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  c6clr-namespace:SuperMinersCustomServiceSystem.MyControl(SuperMinersCustomServiceSystem.MyControl  i    cSuperMinersCustomServiceSystem.View.Controls.TradeSystem.StoneDelegateSellTradeHistoryRecordControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <	MyControl&clr-namespace:SuperMinersWPF.MyControl     Fmyc6clr-namespace:SuperMinersCustomServiceSystem.MyControl     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .���   � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $*��$股市矿石委托卖出历史记录��$��18(�$
��Bold"�$��10q�� $��1��  �� �� �� .+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��卖家用户名：��$��
10,10,5,10q�$��Center=��� -   $��txtBuyerSellerName��$��	0,10,5,10q�$	��100�� �� 	MaxLength$ 64��$��Center=��� $��成交时间：从��$��
10,10,5,10q�$��Center=�F   @SuperMinersCustomServiceSystem.MyControl.MyDateTimePickerControl  -     Name$ dpStartSellFinishedTime��$��Center=�   ShowTime .     TimeTickType$ 
StartOfDay=��� $	��到��$��Center=�  -   $ dpEndSellFinishedTime��$��Center=� .  $ EndOfDay=��� $��2��$ 
Horizontal=�.+��� -   $��	btnSearch��$��查询��$	��100��$��10q�$��Center=��� $��每页显示：30 行��$��50,10,10,10q�$��Center=��� -   $��btnPreviousPage��$��	上一页��$��70��$��10q�$��Center=��� $��当前显示第��$
��5,10q�$��Center=�-   'SuperMinersWPF.MyControl.NumericTextBox  -     Name$ numPageIndex��$��50�� �� 
IsReadOnly . $
��5,10q�$��Center=�   Minimum$ 1Q�	   Maximum$	 10000000Q��� $	��页��$
��5,10q�$��Center=��� -   $��btnNextPage��$��	下一页��$��70��$��10q�$��Center=�&   System.Windows.Controls.DataGrid  -   $��	dgRecords��$��2��$��5q�
   AutoGenerateColumns
 .  $��Center=����� *ListStoneDelegateSellOrders+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 卖家用户名��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *SellUserName+ �� Mode$ OneWay=�  $ 	订单号��$ *  .  �� *OrderNumber+$ OneWay=�  $ 价格��$ *  .  �� *Price+$ OneWay=�  $ 交易手数��$ *  .  �� *TradeStoneHandCount+$ OneWay=�  $ 完成交易手数��$ *  .  �� *FinishedStoneTradeHandCount+$ OneWay=�  $ 出售状态��$ *  .  �� *SellStateText+$ OneWay=�  $ 委托时间��$ *  .  �� *CreateTimeText+$ OneWay=�  $ 完成时间��$ *  .  �� *FinishedTimeText+$ OneWay=��� $��3��$ 
Horizontal=�$
��20,5q�.+��� $)��#当前页面总计交易矿石(手)��$��10q��� -	   $��txtSumStone��$	��200�� . $��10q����� *(&SumListSellStoneOrderRecords_StoneHand+$ OneWay=��� $��总计价值灵币��$��10q��� -
   $��	txtSumRMB��$	��200�� . $��10q����� *" SumListSellStoneOrderRecords_RMB+$ OneWay=�