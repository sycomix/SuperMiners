   M S B A M L   `   `   `  ���� Y  USuperMinersCustomServiceSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  c6clr-namespace:SuperMinersCustomServiceSystem.MyControl(SuperMinersCustomServiceSystem.MyControl  Y    SSuperMinersCustomServiceSystem.View.Controls.TradeSystem.AlipayHistoryRecordControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <	MyControl&clr-namespace:SuperMinersWPF.MyControl     Fmyc6clr-namespace:SuperMinersCustomServiceSystem.MyControl     .���   � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $!��支付宝付款历史记录��$��18(�$
��Bold"�$��10q��� $��1�� �� Orientation$ 
Horizontal=�.+��� $��商品订单号：��$��
10,10,5,10q�$��Center=��� -   $��txtOrderNumber��$��	0,10,5,10q�$	��100�� �� 	MaxLength$ 64��$��Center=��� $��支付宝订单号：��$��
10,10,5,10q�$��Center=��� -   $��txtAlipayOrderNumber��$��	0,10,5,10q�$	��100��$ 64��$��Center=��� $��付款账户：��$��
10,10,5,10q�$��Center=��� -   $��txtBuyerEmail��$��	0,10,5,10q�$	��100��$ 64��$��Center=��� $��玩家用户名：��$��
10,10,5,10q�$��Center=��� -   $��txtPlayerUserName��$��	0,10,5,10q�$	��100��$ 64��$��Center=��� $��2��$ 
Horizontal=�.+��� $��付款时间：从��$��
10,10,5,10q�$��Center=�F   @SuperMinersCustomServiceSystem.MyControl.MyDateTimePickerControl  -     Name$ dpStartPayTime��$��Center=�   ShowTime .     TimeTickType$ 
StartOfDay=��� $	��到��$��Center=�  -   $ dpEndPayTime��$��Center=� .  $ EndOfDay=��� $��3��$ 
Horizontal=�.+��� -   $��	btnSearch��$��查询��$	��100��$��10q�$��Center=��� $��每页显示：30 行��$��50,10,10,10q�$��Center=��� -   $��btnPreviousPage��$��	上一页��$��70��$��10q�$��Center=��� $��当前显示第��$
��5,10q�$��Center=�-   'SuperMinersWPF.MyControl.NumericTextBox  -	     Name$ numPageIndex��$��50�� �� 
IsReadOnly . $
��5,10q�$��Center=�   Minimum$ 1Q�	   Maximum$	 10000000Q��� $	��页��$
��5,10q�$��Center=��� -
   $��btnNextPage��$��	下一页��$��70��$��10q�$��Center=�&   System.Windows.Controls.DataGrid  -   $��datagrid��$��4��
   AutoGenerateColumns
 .     
IsReadOnly .    SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ 商品订单号��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *out_trade_no+  $ * $ 	用户名�� �� *	user_name+  $ * $ 订单类型�� �� *TradeTypeText+  $ * $ 支付宝订单号�� �� *alipay_trade_no+  $ * $ 付款账户�� �� *buyer_email+  $ * $ 支付金额�� �� *	total_fee+  $ * $ 价值灵币�� �� *	value_rmb+  $ * $ 付款时间�� �� *
pay_time+�� $��5��$ 
Horizontal=�$
��20,5q�.+��� $?��9当前页面总计支付宝付款金额（人民币元）��$��10q��� -   $��txtSumAlipayYuan��$	��200��$��10q� . �� $��价值灵币��$��10q��� -   $��	txtSumRMB��$	��200��$��10q� . 