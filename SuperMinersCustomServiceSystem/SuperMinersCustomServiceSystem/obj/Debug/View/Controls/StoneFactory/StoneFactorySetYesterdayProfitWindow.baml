   M S B A M L   `   `   `  ����Y  USuperMinersCustomServiceSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  5   	   d    ^SuperMinersCustomServiceSystem.View.Controls.StoneFactory.StoneFactorySetYesterdayProfitWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <	myControl&clr-namespace:SuperMinersWPF.MyControl     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$ 
ToolWindow=�6.    � Title$' !设置矿石工厂昨日收益率��5   	   $	��200��6   $	��300��6*   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��203* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��昨日总矿石机数：��6   $��5q�6$   $��Center=�6/   $��Right=�6J   �� 5   
   -   5        $��txtTotalValidStoneCount��5   "   $��1��6   $��5q�6A    �� 
IsReadOnly . $��Center=�6^   �� 5   
   $��1��6   $��0��6!   $*��$设置单机收益（人民币）：��61   $��5q�6E   $��Center=�6P   -   'SuperMinersWPF.MyControl.NumericTextBox  5   
   -   5          Name$ numSetProfitYuan��5   @   -   'SuperMinersWPF.MyControl.NumericTextBox   ValueChanged$# numSetProfitYuan_ValueChanged��6�   $��1��6#   $��1��60      DecimalPlaces$ 2��6Z   	   Maximum$	 100000Q�6l   $��5q�6}   $��Center=�6�   6�   �� 5   
   $��2��6   $��0��6!   $'��!换算单机收益（灵币）：��61   $��5q�6D   $��Center=�6O   $��Right=�6j   �� 5   
   -   5        $��txtProfitRMB��5   /   $��2��6   $��1��6    . $��5q�6U   $��Center=�6`   �� 5   
   -   5        $��	btnCancel��5   2   $��3��6   $��2��6   $��取消��6C   $	��100��6P   $��30��6\   $��10q�6h   $��Center=�6t   $��Right=�6�   6�   �� 5   
   -   5        $��btnOK��5   2   $��3��6   $��2��6   $��确定��6?   $	��100��6L   $��30��6X   $��10,10,130,10q�6d   $��Center=�6z   $��Right=�6�   6�   5      5      