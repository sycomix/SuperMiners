   M S B A M L   `   `   `  ���� I  ESuperMinersWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  c6clr-namespace:SuperMinersCustomServiceSystem.MyControl(SuperMinersCustomServiceSystem.MyControl  B    <SuperMinersWPF.Views.Controls.MinerTradeHistoryRecordControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <	MyControl&clr-namespace:SuperMinersWPF.MyControl     Fmyc6clr-namespace:SuperMinersCustomServiceSystem.MyControl     @d2http://schemas.microsoft.com/expression/blend/2008     .���   � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��矿工交易历史记录��$��18(�$
��Bold"�$��10q��� $��1�� �� Orientation$ 
Horizontal=�.+��� $��创建时间：从��$��
10,10,5,10q�$��Center=�F   @SuperMinersCustomServiceSystem.MyControl.MyDateTimePickerControl  -     Name$ dpStartCreateTime��$��Center=�   ShowTime .  �� $	��到��$��Center=�  -   $ dpEndCreateTime��$��Center=� .  �� $��2��$ 
Horizontal=�.+��� -   $��	btnSearch��$��查询��$	��100��$��10q�$��Center=��� $��每页显示：30 行��$��50,10,10,10q�$��Center=��� -   $��btnPreviousPage��$��	上一页��$��70��$��10q�$��Center=��� $��当前显示第��$
��5,10q�$��Center=�-   'SuperMinersWPF.MyControl.NumericTextBox  -     Name$ numPageIndex��$��50�� �� 
IsReadOnly . $
��5,10q�$��Center=�   Minimum$ 1Q�   Maximum$ 10000000Q��� $	��页��$
��5,10q�$��Center=��� -   $��btnNextPage��$��	下一页��$��70��$��10q�$��Center=�&   System.Windows.Controls.DataGrid  -   $��datagrid��$��3��   AutoGenerateColumns .  	   
IsReadOnly	 . 
   SelectionMode$
 Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ 玩家用户名��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
UserName+  $ * $ 购买矿工�� �� *GainMinersCount+  $ * $ 花费金币�� �� *SpendGoldCoin+  $ * $ 购买时间�� �� *Time+