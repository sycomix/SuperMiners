   M S B A M L   `   `   `  ���� I  ESuperMinersWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  c6clr-namespace:SuperMinersCustomServiceSystem.MyControl(SuperMinersCustomServiceSystem.MyControl  I    CSuperMinersWPF.Views.Controls.StoneNotFinishedBuyTradeRecordControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <	MyControl&clr-namespace:SuperMinersWPF.MyControl     Fmyc6clr-namespace:SuperMinersCustomServiceSystem.MyControl     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -   .���   � RowDefinitions  �� $
��Auto ��� .+��� -   $��btnRefreshMySelfOrders��$��刷新��$	��100��$��30,10q�$
��Left=��� $��1��$
��Auto=�.��� $��5q�  �� $
��Auto ��� $
��Auto �.+�9� -    9�Name$ expBuyOrders��$��买入交易��.���� -   $��listboxMyBuyOrders��$��Disabled=�$��Stretch=����� .R��� $��5q�
�������$��1q� �� CornerRadius$ 5��
����ح�._��   �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ���  � ColumnDefinitions �� $
��Auto �$	��150���� $��* �.+��� $��订单号：��$
��10,5q�$��18(�$
��Bold"�$��Center=�$��Right=��� $��1��$��18(�$
��Bold"�$
��10,5q�$��Center=����� *OrderNumber+�� $��1��$��0��$��	卖方：��$
��10,5q�$��Center=�$��Right=��� $��1��$��1�� �� 
IsReadOnly . $
��10,5q�$��Center=����� *SellerUserName+ �� Mode$ OneWay=��� $��2��$��0��$��出售矿石：��$
��10,5q�$��Center=�$��Right=��� $��2��$��1��$
��10,5q�$��Center=����� *SellStonesCount+$ OneWay=��� $��3��$��0��$��交易金额：��$
��10,5q�$��Center=�$��Right=��� $��3��$��1�� . $
��10,5q�$��Center=����� *
ValueRMB+$ OneWay=��� $��4��$��0��$��可奖励金币：��$
��10,5q�$��Center=�$��Right=��� $��4��$��1�� . $
��10,5q�$��Center=����� *AwardGoldCoin+$ OneWay=��� $��5��$��0��$��出售时间：��$
��10,5q�$��Center=�$��Right=��� $��5��$��1�� . $
��10,5q�$��Center=����� *
SellTime+$ OneWay=��� $��6��$��0��$��锁定时间：��$
��10,5q�$��Center=�$��Right=��� $��6��$��1�� . $
��10,5q�$��Center=����� *
LockedTime+$ OneWay=��� $��7��$��0��$��	付款：��$
��10,5q�$��Center=�$��Right=��� $��7��$��1�� �� Orientation$ 
Horizontal=�$
��10,5q�.+��� $��请在��$��Center=�y��� *ValidTimeVisibility+�� $��Center=����� *ValidTimeSecondsString+y��� *ValidTimeVisibility+�� $��	内付款��$��Center=�y��� *ValidTimeVisibility+��  ��Name$ btnPay��-   $��	去付款��$
��20,0q�$��70��$��Center=�y��� *ValidTimeVisibility+�� $��btnCancelPay��-   $��取消订单��$
��20,0q�$��70��$��Center=�y��� *ValidTimeVisibility+�� $��如果已经付款，请��$��Center=�$��5q�y��� *ValidTimeVisibility+�� $ 	btnAppeal��-   $��70��$
��20,0q�$��Center=����� *HandleButtonContext+{��� *HandleButtonNotEnable+9� -   $ expSellOrders��$��1��$��卖出交易��.���� -	   $��listboxMySellOrders��$��Disabled=�$��Stretch=����� .R��� $��5q�
�������$��1q�$ 5��._��   �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ���  �� $
��Auto �$	��150���� $��* �.+��� $��订单号：��$
��10,5q�$��18(�$
��Bold"�$��Center=�$��Right=��� $��1��$��18(�$
��Bold"�$
��10,5q�$��Center=����� *OrderNumber+�� $��2��$��0��$��出售矿石：��$
��10,5q�$��Center=�$��Right=��� $��2��$��1��$
��10,5q�$��Center=����� *SellStonesCount+$ OneWay=��� $��3��$��0��$��交易金额：��$
��10,5q�$��Center=�$��Right=��� $��3��$��1�� . $
��10,5q�$��Center=����� *
ValueRMB+$ OneWay=��� $��4��$��0��$��手续费：��$
��10,5q�$��Center=�$��Right=��� $��4��$��1�� . $
��10,5q�$��Center=����� *	Expense+$ OneWay=��� $��5��$��0��$��出售时间：��$
��10,5q�$��Center=�$��Right=��� $��5��$��1�� . $
��10,5q�$��Center=����� *
SellTime+$ OneWay=��� $��6��$��0��$��订单状态：��$
��10,5q�$��Center=�$��Right=��� $��6��$��1�� . $
��10,5q�$��Center=����� *OrderStateString+$ OneWay=��� $��btnCancelSellStone��-
   $��7��$��取消出售矿石��$��70��$
��20,5q�$��Center=�$��Center=�