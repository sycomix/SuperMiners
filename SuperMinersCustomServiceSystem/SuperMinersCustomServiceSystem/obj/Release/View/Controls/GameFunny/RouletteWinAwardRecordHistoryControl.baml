   M S B A M L   `   `   `  ���� Y  USuperMinersCustomServiceSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  c6clr-namespace:SuperMinersCustomServiceSystem.MyControl(SuperMinersCustomServiceSystem.MyControl  a    [SuperMinersCustomServiceSystem.View.Controls.GameFunny.RouletteWinAwardRecordHistoryControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <	MyControl&clr-namespace:SuperMinersWPF.MyControl     Fmyc6clr-namespace:SuperMinersCustomServiceSystem.MyControl     .���   � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $'��!幸运大转盘中奖历史记录��$��18(�$
��Bold"�$��10q��� $��1�� �� Orientation$ 
Horizontal=�.+��� $��玩家用户名：��$��
10,10,5,10q�$��Center=��� -   $��txtUserName��$��	0,10,5,10q�$	��100�� �� 	MaxLength$ 64��$��Center=��� $��中奖信息��$��	0,10,5,10q�$��Center=��� -   $��cmbAwardItems��$	��200��$��
10,10,5,10q�$��Center=� �� DisplayMemberPath$ 	AwardName�� �� SelectedValuePath$ ID���� $��已领取：��$��
10,10,5,10q�$��Center=��� -   $��cmbIsGot�� �� SelectedIndex$ 0��$��	0,10,5,10q�$��70��$��Center=�.@��� $��全部���� $��	未支付���� $��	已支付���� $��已支付：��$��
10,10,5,10q�$��Center=��� -   $��cmbIsPay��$ 0��$��	0,10,5,10q�$��70��$��Center=�.@��� $��全部���� $��	未支付���� $��	已支付���� $��2��$ 
Horizontal=�.+��� $��中奖时间：从��$��
10,10,5,10q�$��Center=�F   @SuperMinersCustomServiceSystem.MyControl.MyDateTimePickerControl  -     Name$ dpStartWinTime��$��Center=�   ShowTime .     TimeTickType$ 
StartOfDay=��� $	��到��$��Center=�  -   $ dpEndWinTime��$��Center=� .  $ EndOfDay=��� $��3��$ 
Horizontal=�.+��� -   $��	btnSearch��$��查询��$	��100��$��10q�$��Center=��� $��每页显示：30 行��$��50,10,10,10q�$��Center=��� -   $��btnPreviousPage��$��	上一页��$��70��$��10q�$��Center=��� $��当前显示第��$
��5,10q�$��Center=�-   'SuperMinersWPF.MyControl.NumericTextBox  -	   	  Name$	 numPageIndex��$��50��
 �� 
IsReadOnly
 . $
��5,10q�$��Center=�   Minimum$ 1Q�   Maximum$ 10000000Q��� $	��页��$
��5,10q�$��Center=��� -
   $��btnNextPage��$��	下一页��$��70��$��10q�$��Center=�&   System.Windows.Controls.DataGrid  -   $��datagrid��$��4��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ 记录ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
RecordID+  $ * $ 	用户名�� �� *
UserName+  $ * $ 所中奖项�� �� *AwardItemName+  $ * $ 中奖时间�� �� *	WinTime+  $ * $ 领奖QQ�� �� *
GotInfo1+  $ * $ 领奖电话�� �� *
GotInfo2+  $ * $ 是否领取�� �� *IsGot+  $ * $ 领取时间�� �� *	GotTime+  $ * $ 是否支付�� �� *IsPay+  $ * $ 支付时间�� �� *	PayTime+