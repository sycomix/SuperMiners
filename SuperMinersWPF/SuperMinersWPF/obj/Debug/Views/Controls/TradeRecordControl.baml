   M S B A M L   `   `   `  ����I  ESuperMinersWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SuperMinersWPF.Views.ControlsSuperMinersWPF.Views.Controls  5      6    0SuperMinersWPF.Views.Controls.TradeRecordControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      DtradeControl+clr-namespace:SuperMinersWPF.Views.Controls     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��547* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��交易类型��6   $��10q�6$   $��Center=�60   �� 5      -   5        $��cmbTradeType��5      $	��150��6+   $��10q�67    �� SelectedIndex$ 0��6C   $��Center=�6U   .@�5      �� $��支付宝付款记录��6   �� 5      $��金币充值记录��6   �� 5      $��矿工购买记录��6   �� 5      $��矿山购买记录��6   �� 5      $��灵币提现记录��6   �� 5      $$��委托买入矿石订单记录��6   �� 5      $$��委托卖出矿石订单记录��6   5      5      >   8SuperMinersWPF.Views.Controls.AlipayHistoryRecordControl  5   
   -   5          Name$ controlAlipayHistory��5   ?   $��1��62   6?   H   BSuperMinersWPF.Views.Controls.GoldCoinRechargeHistoryRecordControl  5   
   -   5          Name$ controlGoldCoinHistory��5   I   $��1��6<   $y�	Collapsed=�6i   B   <SuperMinersWPF.Views.Controls.MinerTradeHistoryRecordControl  5   
   -   5          Name$ controlMinerHistory��5   C   $��1��66   $y�	Collapsed=�6`   A   ;SuperMinersWPF.Views.Controls.MineTradeHistoryRecordControl  5    
   -   5          Name$ controlMineHistory��5    B   $��1��65   $y�	Collapsed=�6^   C   =SuperMinersWPF.Views.Controls.WithdrawRMBHistoryRecordControl  5!   
   -   5          Name$ controlWithdrawHistory��5!   D   $��1��67   $y�	Collapsed=�6d   I   CSuperMinersWPF.Views.Controls.StoneNotFinishedBuyTradeRecordControl  5"   
   -   5          Name$# controlStoneNotFinishedRecord��5"   J   $��1��6=   $y�	Collapsed=�6q   E   ?SuperMinersWPF.Views.Controls.StoneBuyTradeHistoryRecordControl  5#   
   -   5        	  Name$	 controlStoneBuyHistory��5#   F   $��1��69   $y�	Collapsed=�6f   F   @SuperMinersWPF.Views.Controls.StoneSellTradeHistoryRecordControl  5$   
   -	   5        
  Name$
 controlStoneSellHistory��5$   G   $��1��6:   $y�	Collapsed=�6h   H	   BSuperMinersWPF.Views.Controls.DelegateBuyStoneHistoryRecordControl	  5%   
   -
   5         	 Name$$ controlDelegateStoneBuyHistory��5%   I   $��1��6<   $y�	Collapsed=�6q   I
   CSuperMinersWPF.Views.Controls.DelegateSellStoneHistoryRecordControl
  5&   
   -   5         
 Name$% controlDelegateStoneSellHistory��5&   J   $��1��6=   $y�	Collapsed=�6s   5'      5(      