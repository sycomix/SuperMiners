   M S B A M L   `   `   `  ����I  ESuperMinersWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  5   	   F    @SuperMinersWPF.Views.Windows.StoneFactoryProfitRMBWithdrawWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <	myControl&clr-namespace:SuperMinersWPF.MyControl     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$ 
ToolWindow=�5   	    � Title$$ 从加工厂提取凝练收益��5   	   $	��200��6   $	��300��6)   .��5      � $��10q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��可提取灵币：��6   $��5q�6"   $��Center=�6-   $��Right=�6H   �� 5   
   -   5        $��txtWithdrawableRMB��5   "   $��1��6    �� 
IsReadOnly . $��5q�6N   $��Center=�6Y   �� 5   
   $��1��6   $��本次提取：��6!   $��5q�6.   $��Center=�69   $��Right=�6T   -   'SuperMinersWPF.MyControl.NumericTextBox  5   
   -   5          Name$ numWithdrawRMB��5   @   $��1��6#   $��1��60      DecimalPlaces$ 2��6X   $��5q�6j   $��Center=�6u   �� 5   
   -   5        $��	btnCancel��5   .   $��2��6   $��2��6   $��取消��6?   $	��100��6L   $��30��6X   $��10q�6d   $��Right=�6p   $��Center=�6�   6�   �� 5   
   -   5        $��btnOK��5   2   $��2��6   $��2��6   $��确定��6?   $	��100��6L   $��30��6X   $��10,10,130,10q�6d   $��Right=�6z   6�   5      5      