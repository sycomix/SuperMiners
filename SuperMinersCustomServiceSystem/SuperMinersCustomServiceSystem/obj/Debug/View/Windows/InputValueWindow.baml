   M S B A M L   `   `   `  ����Y  USuperMinersCustomServiceSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl  5   	   B    <SuperMinersCustomServiceSystem.View.Windows.InputValueWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   3my&clr-namespace:SuperMinersWPF.MyControl    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  InputValueWindow��5   	   $	��200��6"   $	��300��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $	��73* �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   .+�5   
   �� -   5        $��lblMsg��5      $��5q�6"   $
��Wrap=�6-   -   'SuperMinersWPF.MyControl.NumericTextBox  5   
   -   5          Name$ numValue��5   )   $��1��6      Value$ 0Q�6;   $��5q�6E   �� 5   
   -   5        $��	btnCancel��5      $��2��6   $��取消��6/   $	��100��6<   $��Right=�6H   $��5q�6d    �� IsCancel . 6�   �� 5   
   -   5        $��btnOK��5      $��2��6   $��确定��6+   $	��100��68   $��Right=�6D   $��	5,5,110,5q�6`    �� 	IsDefault . 6�   5      5      