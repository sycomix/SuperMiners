   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   MainPanelBackground  �� Color  LogoPanelBackground  NotifyPanelBackground  PlayerInfoBackground " DataGridColumnHeaderBackground  SubWindowStyle �� 
TargetType �� Property �� Value  	Color_024  RedButtonBackground  SliderCheckBox �� 
TargetType �� Orientation'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 g� Duration	
 W� To �� TargetProperty �� 
TargetName ��Name W� From �� ElementName �� Path	 �� To �� From ��Name �� CornerRadius J� RenderTransformOrigin J� Opacity ��Name 	 UserInfoButtonStyle�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      %�  &	        &	      &	 *     &	 ?     &	 T     &	 i     &	 	    &	     &	 1    7  &		 �    7  7  �� $  	#FFF0F0F0���� $  	#FF4CADA6���� $  	#FF90E5DF���� $  	#FF313443���� $  	#FFAFBCBB���� " �.���  � ��$	 500����  � ��$	 600����  �@�
ResizeMode$ NoResize=���  �@�Topmost . ��  �@�ShowInTaskbar .  ��	#FF00AADE���� $  	#FFF69068���� " ��.���  � ��$ 1q���  �@�Cursor$
 Hand����  � �� �� " ��.R��� 
������ $ 
Horizontal=�   CommonStates��.   
Normal��  	MouseOver��  Pressed��  Disabled��. �� .��W� $	 0D�$	
 .55X�$ (UIElement.Opacity)�$ contentPresenter��W� $	 0D�$
 1X�$ (UIElement.Opacity)�$ disabled��  CheckStates��.   Checked��. �� $ Storyboard1��.��W� $ 	CheckFlag��$8 2(UIElement.RenderTransform).(TranslateTransform.X)�$
 14X�$	 
00:00:00.1D� �� $ 
baseBorder��$ RenderTransform.X��� $ 
baseBorder��$1 +(Border.Background).(SolidColorBrush.Color)�8   $	 
00:00:00.1D� �� $ 
baseBorder��$ 
Background�  	Unchecked��. �� $ Storyboard2��.��W� $ 	CheckFlag��$8 2(UIElement.RenderTransform).(TranslateTransform.X)�$
 0X�$	 
00:00:00.1D� �� $ 
baseBorder��$ RenderTransform.X��� $ 
baseBorder��$1 +(Border.Background).(SolidColorBrush.Color)�$
 GrayX�$	 
00:00:00.1D� �� $ 
baseBorder��$ 
Background�.+�� .+��� $ 
baseBorder��$��1q�
����ح�$��35��$��20��$ 10��._��� .+��� $ 	CheckFlag��
�������$ 10��$��Center=�$��1q�$��19��$��18��$ 0.5,0.5&�z�T� �� $ disabled��$��1q����	#A0C3C3C3$��35��$��20��$ 0Q�$ 10���� $ contentPresenter��#��z��#��z��#��z��#��z��#��z���� " ��.���  � ��$ 75����  � ��$ 5q���  � ��$ 1q���  � ��8   ��  � ��
 ���� ��  � ��8  