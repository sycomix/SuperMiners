   M S B A M L   `   `   `  ����Y  USuperMinersCustomServiceSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  5   	   E    ?SuperMinersCustomServiceSystem.View.Windows.EditPlayerExpWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <	MyControl&clr-namespace:SuperMinersWPF.MyControl     5   	     � Title$  修改玩家贡献值��5   	   $	��200��6   $	��300��6&    � WindowStyle$ 
ToolWindow=�63    � WindowStartupLocation$ CenterScreen=�6L   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5	       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��	玩家：��6   $��5q�6   $��Right=�6*   �� 5   
   -   5        $��txtUserName��5   "   $��1��6    �� 
IsReadOnly . $��5q�6G   �� 5   
   $��1��6   $��0��6!   $��现有贡献值：��61   $��5q�6?   $��Right=�6J   �� 5   
   -   5        $��txtCurrentExp��5   /   $��1��6   $��1��6    . $��5q�6V   �� 5   
   $��3��6   $��修改后贡献值：��6!   $��5q�60   $��Right=�6;   -   'SuperMinersWPF.MyControl.NumericTextBox  5   
   -   5          Name$ numChangedExp��5   @   $��3��6#   $��1��60      Minimum$ 0Q�6W      Maximum$ 
1000000000Q�6c   $��5q�6x   �� 5   
   -   5        $��btnOK��5   2   $��4��6   $��2��6   $��确定��6?   $	��100��6L   $��Right=�6X   $��Bottom=�6t   $��	5,5,120,5q�6�   6�   �� 5   
   -   5        $��	btnCancel��5   2   $��4��6   $��2��6   $��取消��6C   $	��100��6P   $��Right=�6\   $��Bottom=�6x   $��5q�6�   6�   5      5      