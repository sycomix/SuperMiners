   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   SuperMinersWPF%   SuperMinersWPF.Views.BusyWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9System&clr-namespace:System;assembly=mscorlib     $��Stretch=�$��Center=�$��Center=�$��80��$	��300��  � ShowInTaskbar  .  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=����	#FF999999.��� -    �Name$ 
LayoutRoot��$��2q�.+���  �� Orientation$ 
Horizontal=�$��5q�$��Center=�.+��  � IsIndeterminate . $��50��$��30�� � 	Resources    DotSize��%   &	        X�7Q�����  �� 
TargetType" �.��� 	 �� Property	 � ��
 �� Value
 ��  �� 
TargetType" �.R�� '  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  CommonStates��   States.    System.Windows.VisualState  Indeterminate��   
Storyboard. ��  g� RepeatBehavior$ Forever��.��T�  g� 	BeginTime$ 00:00:00X� g� Duration$ 00:00:00.001D� �� TargetProperty$ (Control.IsEnabled)� �� 
TargetName$ content��..�i�  R� KeyTime$ 00:00:00�� R� Value ��	False��W� $ 0:0:1D�	 W� To$	 360X�$V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�$
 Dots��.+���  ��Name$ content��#��z��#��z��� $
 Dots�� J� RenderTransformOrigin$ 0.5,0.5&�$��Center=�$��Center=�z�V� .~��� �� ��  �� Angle$ 0Q�T� .+��� $��Center=�$��Center=�$ 0.5,0.5&�����  �� RelativeSource �� *TemplatedParent+ �� Path$ Width�����  �� *TemplatedParent+$ Height�.+�A� #��[  #��[   �� Left$ 42��
 �� Top$ 7��
������� �� Stretch$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&�����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $	 -30Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#E8C0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� � UseLayoutRounding .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $	 -60Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#D1C0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $	 -90Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#BAC0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $
 -120Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#A3C0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $
 -150Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#8CC0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $
 -180Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#75C0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $
 -210Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#5EC0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $
 -240Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#47C0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $
 -270Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#30C0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $
 -300Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#19C0C0C0$
 Fill=��� $��Center=�$��Center=�$ 0.5,0.5&� .  ����  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�z�V� .~��� �� �� $
 -330Q�T� .+�A� #��[  #��[  $ 42��$ 7�����	#02C0C0C0$
 Fill=��� $��Center=�.+��� -   $��
txtMessage��$
��10,0q�$��Center=�$��20(�$��Black"�����   Language  �� Source#  [ $ Strings.PleaseWait�! �� StringFormat$! {0}...��� -   $	��prg��$	��300��$��10q�$y�	Collapsed=��� -   $��btnClose��$��×��$��20��$��20��$��Right=�$	��Top=�$��5q�