   M S B A M L   `   `   `  ���� I  ESuperMinersWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  c6clr-namespace:SuperMinersCustomServiceSystem.MyControl(SuperMinersCustomServiceSystem.MyControl  @    :SuperMinersWPF.Views.Windows.RouletteMyWinnedRecordsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <	MyControl&clr-namespace:SuperMinersWPF.MyControl     Fmyc6clr-namespace:SuperMinersCustomServiceSystem.MyControl       � Title$'  !我的幸运大转盘中奖记录��   PlayerInfoBackground#���   
�������$	��500��$	��700�� � WindowStartupLocation$ CenterScreen=�.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1�� �� Orientation$ 
Horizontal=�.+��� $��已领取：��$��
10,10,5,10q�$��Center=��� -   $��cmbIsGot�� �� SelectedIndex$ 0��$��	0,10,5,10q�$��70��$��Center=�.@��� $��全部���� $��	未支付���� $��	已支付���� $��已支付：��$��
10,10,5,10q�$��Center=��� -   $��cmbIsPay��$ 0��$��	0,10,5,10q�$��70��$��Center=�.@��� $��全部���� $��	未支付���� $��	已支付���� $��2��$ 
Horizontal=�.+��� $��中奖时间：从��$��
10,10,5,10q�$��Center=�F   @SuperMinersCustomServiceSystem.MyControl.MyDateTimePickerControl  -     Name$ dpStartWinTime��$��Center=�   ShowTime .  �� $	��到��$��Center=�  -   $ dpEndWinTime��$��Center=� .  �� $��3��$ 
Horizontal=�.+��� -   $��	btnSearch��$��查询��$	��100��$��10q�$��Center=��� $��每页显示：30 行��$��50,10,10,10q�$��Center=��� -   $��btnPreviousPage��$��	上一页��$��70��$��10q�$��Center=��� $��当前显示第��$
��5,10q�$��Center=�-   'SuperMinersWPF.MyControl.NumericTextBox  -     Name$ numPageIndex��$��50�� �� 
IsReadOnly . $
��5,10q�$��Center=�	   Minimum$	 1Q�
   Maximum$
 10000000Q��� $	��页��$
��5,10q�$��Center=��� -   $��btnNextPage��$��	下一页��$��70��$��10q�$��Center=�&   System.Windows.Controls.DataGrid  -	   $��datagrid��$��4��   AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ 所中奖项��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *AwardItemName+  $ * $ 中奖时间�� �� *	WinTime+  $ * $ 领奖QQ�� �� *
GotInfo1+  $ * $ 领奖电话�� �� *
GotInfo2+  $ * $ 是否领取�� �� *IsGot+  $ * $ 领取时间�� �� *	GotTime+  $ * $ 是否支付�� �� *IsPay+  $ * $ 支付时间�� �� *	PayTime+4  .System.Windows.Controls.DataGridTemplateColumn  $ *    CellTemplate �� .R��� -
   $��领取��$��70��$��Center=�$��Center=�y��� *GetButtonVisibility+