   M S B A M L   `   `   `  ���� [  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  I ESuperMinersWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SuperMinersWPF.ViewsSuperMinersWPF.Views C&clr-namespace:SuperMinersWPF.MyControlSuperMinersWPF.MyControl    SuperMinersWPF.Window1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     TwinForm@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     4Views"clr-namespace:SuperMinersWPF.Views     <	myControl&clr-namespace:SuperMinersWPF.MyControl     -   $	��660��$
��1100��  � Icon$  Logo128.ico��$	��620��$
��1000�� � 	Resources  !  RightTitleMouseOverBackground �� Color  TopListInfoTemplate � ColumnDefinitions  UserInfoTextBlockStyle �� 
TargetType �� Property �� Value  UserInfoTextBoxStyle  UserInfoRedButtonStyle  RedButtonBackground  RadioButtonStyle1 �� 
TargetType �Name	 J� SnapsToDevicePixels
 ��Name �� Triggers P� Property P� Value �� 
TargetName  MainPanelBackground��%8  &	        &	      &	 v    &	 �    &	 R    7  &	 �    7   7  7  7  7  �� $ 	#FFC8ECE7���� .R�� $��Stretch=� �� $	��150 ��� $	��150 ��� $	��150 �.+��� 
�������$��1q�._��� $��Center=�$��Center=�$��5q����� *Index+�� $��1��
�������$��1q�._��� $��Center=�$��Center=�$��5q����� *
NickName+�� $��2��
�������$��1q�._��� $��Center=�$��Center=�$��5q����� *Value+�� " ��.���  � ��
 �������  � ��$ Right=���  � ��$ 5q��� " ��.���  �@��
IsReadOnly . ��  � ��
 �������  � ��
 ���� ��  � ��$
 Auto����  � ��$ 5q��� " ��.���  � ��$	 100����  � ��$ 5q���  � ��8   ��  � ��
 ������� " 	�.���  � �� �� " 	�.R�� $ templateRoot��
������ 	 . .+��� $
 contentPresenter��$��1��|�.  #��z��#��z����. #	 z	 #��z�� P�  � �� . . ���  � ��$ 4,-1,0,0q�P�  �@J�IsMouseOver . . ��� $ templateRoot��8    � ��P�  � {� .  . ��� $ templateRoot��8   � ��P�  � �� . . ��� $ templateRoot��8   � ��P�  �@d�	IsChecked$
 trueY�. ��� $ templateRoot��8   � ��P�  Z�  �@d�	IsChecked. ��� $ templateRoot��8   � ��.��� #���   �� $	��280 ���  � RowDefinitions �� $
��Auto ��� $
��475* �.+�� -   $ 	panelLogo��  LogoPanelBackground#��[ .+��� $��Resources/logo.png��$
��None=�$��10q�� -   $ panelUserInfo��$��0��$��1�� 	 PlayerInfoBackground#��[	 .+�� $��5q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��1* ��� $
��Auto � �� $
��Auto ��� $
��111* ��� $
��Auto �.+��� $��0��$��	矿主：��#��[ $��16(�$��Right=�$��0,5,5,5q�$
��Bold"��� $��1��$��2�� �� Orientation$ 
Horizontal=�.+��� 
�������$��16(�$��5q�$
��Bold"����� *
UserName+�� $��16��$��Uniform=�$��Center=�$
��Left=����� *ExpLevelImg+�� $��16��$��Uniform=�$��Center=�$
��Left=����� *CreditLevelImg+�� $��1��#��[ �� ��� *Strings.Exp+ �� Mode$ OneWay=� 
 Language �� Source# [
 �� $� ���� $� ���� $��1��$��1��#��[ ���� *Exp+$ OneWay=��� -    ��Name$ btnInvitationFriends��$��1��$��2��$��邀请好友��  UserInfoButtonStyle#��[ �� -   $��lblShoppingCredits��$��2��#��[ $��积分 ���� -   $��txtShoppingCredits��$��2��$��1��#��[ ���� *ShoppingCreditsEnabled+$ OneWay=��� -   $ btnGetShoppingCredits��$��2��$��2��$��获取��#��[ �� $��3��#��[ �� ��� *Strings.RMB+$ OneWay=�# [
 �� $� ���� $� ���� $��3��$��1��#��[ ���� *RMB+$ OneWay=��� -   $ btnGetMoney��$��3��$��2��$��提现��#��[ �� $��4��#��[ �� ��� *Strings.GoldCoin+$ OneWay=�# [
 �� $� ���� $� ���� $��4��$��1��#��[ ���� *
GoldCoin+$ OneWay=��� -	   $ btnGoldCoinRecharge��$��4��$��2��$��购买��#��[ �� $��5��#��[ �� ��� *Strings.Stone+$ OneWay=�# [
 �� $� ���� $�储量���� $��5��$��1��#��[ ���� *WorkableStonesReserversText+$ OneWay=� �� StringFormat$
 0.00���� -
   $ btnMinesBuy��$��5��$��2��$��勘探��#��[ {��� *StoneReservesBuyable+$ OneWay=��� $��6��#��[ �� ��� *Strings.Miner+$ OneWay=�# [
 �� $� ���� $� ���� $��6��$��1��#��[ ���� *MinersCount+$ OneWay=��� -   $ btnMinersBuy��$��6��$��2��$��雇佣��#��[ �� $��7��#��[ �� ��� *Strings.Diamond+$ OneWay=�# [
 �� $� ���� $� ���� $��7��$��1��#��[ ���� *StockOfDiamonds+$ OneWay=��� -   $ btnDiamondsSell��$��7��$��2��$��出售��$y�	Collapsed=�#��[ �� -   $ btnExchangeDiamonds��$��7��$��2��$��兑换��#��[ �� $��8��#��[ �� ��� *Strings.Stone+$ OneWay=�# [
 �� $� ���� $� ���� $��8��$��1��#��[ ���� *SellableStones+$ OneWay=��� -   $ btnStonesSell��$��8��$��2��$��挂单出售��#��[ �� $��9��$y�	Collapsed=�#��[ �� $�矿石出售券���� $� ���� $� ���� $��9��$��1��$y�	Collapsed=�#��[ ���� *StoneSellQuan+$ OneWay=��� -   $��	lblGravel��$��9��$��0��$��碎片��#��[ $
��10,5q�y��� *GravelVisible+�� -   $��	txtGravel��$��9��$��1��#��[ ���� *Gravel+$ OneWay=�y��� *GravelVisible+�� -   $��btnRequestGravel��$��9��$��2��#��[ ���� *GravelButtonContent+{��� *GravelButtonEnable+y��� *GravelVisible+�� -   $��lblMakeAVowToGod��$��10��$��0��$��2��$*��$向神灵许愿，矿石不够用啊��#��[ $
��10,5q��� -   $��btnMakeAVowToGod��$��10��$��2��#��[ y��� *GravelVisible+{��� *BtnMakeAVowEnable+���� �� $�许愿(�� �� ��� *SurplusMakeAVowTimes+$ OneWay=� �� $�)���� $��12��$��3��
�������$��5q�$��Italic$�$
��Bold"��� $�当前产量： ���� $� ���� ��� *AllOutputPerDay+$ OneWay=��� $� ���� ��� *Strings.Stone+$ OneWay=�# [
 �� $� ���� $
�/天���� $��13��$��3��
�������$��5q�$��Italic$�$
��Bold"�y��� *OutputCountdownVisible+�� $%�距离下一次收益计算： ���� $� ���� ��� *OutputCountdownString+$ OneWay=��� $��14��$��	可收取��#��[ �� $��14��$��1�� �� 
IsReadOnly . #��[ ���� *TempOutputStonesString+$ OneWay=��� -   $ btnGatherStones��$��14��$��2��$��收取��#��[ �� $��15��$��3��$��	加工厂��$��Center=�#��[ $
��Bold"�$��5q��� $��16��$��0��$��昨日收益��#��[ �� -    ��Name$ txtYesterdayProfit��$��16��$��1�� . #��[ ���� *YesterdayFactoryProfitRate+$ OneWay=��� -   $ 
btnFactory��$��16��$��2��$��进入工厂��#��[ �� $y�	Collapsed=�$��17��#��[ $��0,5,5,5q��� $�有效时间���� $� ���� $� ���� $y�	Collapsed=�$��17��$��1��$ 
Horizontal=�$��2��.+��� $��0 天 00:00:00��$��28(�#��[ $
��Auto��� -   $ panelNotify��$��1��  NotifyPanelBackground#��[  �� �� $
��Auto �.+�� -   $��panelNotice�� �� $
��Auto ��� .+��� $��系统消息：��$
��10,5q�$
��Bold"�$��16(�$��Center=�$��Center=����	#FFFF3A1A�� -    ��Name$ txtLinkNotice��$��1��$
��10,5q�$��Italic$�$
��Bold"�$��16(�$��Center=�$
��Left=� J� RenderTransformOrigin$ 0.5,0.5&�z�T� -   txtLinkNoticeTranslate�� T� Y$ 0Q��� -    �Name$ 
linkNotice��.�消息通知�� $��1��$ 
Horizontal=�.+�	� -    	�Name$ btnShowDigStonesArea��#��[ $��0q� 	� 	GroupName$ 	ShowPanel�� d� 	IsChecked$
 TrueY�.��� $��
10,10,15,5q� �� �� .+��� $��Resources/a1.png��$
��None=�$��5q��� $��1��$��	采矿区��$��16(�	� -   $ btnShowStonesMarket��#��[ $��0q�$ 	ShowPanel��.��� $��
10,10,15,5q� �� �� .+��� $��Resources/b1.png��$
��None=�$��5q��� $��1��$��矿石市场��$��16(�	� -   $ btnShowTopList��$y�	Collapsed=�#��[ $��0q�$ 	ShowPanel��.��� $��
10,10,15,5q� �� �� .+��� $��Resources/f1.png��$
��None=�$��5q��� $��1��$��	排行榜��$��16(�	� -   $ btnShowChat��$y�	Collapsed=�#��[ $��0q�$ 	ShowPanel��.��� $��
10,10,15,5q� �� �� .+��� $��Resources/c1.png��$
��None=�$��5q��� $��1��$��	聊天室��$��16(�	� -    $ btnShowFunny��#��[ $��0q�$ 	ShowPanel��.��� $��
10,10,15,5q� �� �� .+��� $��Resources/d1.png��$
��None=�$��5q��� $��1��$��娱乐��$��16(�	� -!   $ btnMall��#��[ $��0q�$ 	ShowPanel��.��� $��
10,10,15,5q� �� �� .+��� $��Resources/e1.png��$
��None=�$��5q��� $��1��$��商城��$��16(�	� -"   $ btnShowMySuperMiners��#��[ $��0q�$ 	ShowPanel��.��� $��
10,10,15,5q� �� �� .+��� $��Resources/e1.png��$
��None=�$��5q��� $��1��$��我的矿场��$��16(��� $��1��$!��会员交流群：374992834��$y�	Collapsed=�
������  . $��Right=�$��Center=�$
��20,5q�$��16(�
���  ��$��Italic$�$
��Bold"�� -#   $ panelMainPage��$��1��$��1��$��10q�.+�2  ,SuperMinersWPF.Views.DigStoneAreaUserControl  -$     Name$ controlDigStoneArea��$y�Visible=�2  ,SuperMinersWPF.Views.StonesMarketUserControl  -%     Name$ controlStonesMarket��$y�	Collapsed=�/  )SuperMinersWPF.Views.MySuperMinersControl  -&      Name$  controlMySuperMiners��$y�	Collapsed=�+  %SuperMinersWPF.Views.FunnyUserControl  -'   !  Name$! controlFunny��$y�	Collapsed=�&   SuperMinersWPF.Views.MallControl  -(   "  Name$" controlMall��$y�	Collapsed=�-  'SuperMinersWPF.Views.StackMarketControl  -)   #  Name$# controlStack��$y�	Collapsed=�