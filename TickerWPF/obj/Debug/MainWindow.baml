   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   D @TickerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TickerWPF.ConverterTickerWPF.Converter 5   	      TickerWPF.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   3local!clr-namespace:TickerWPF.Converter     5   	     � Title$  
Ticker App��5   	   $	��220��5   	   $	��400��5	   	    � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5
      5  /TickerWPF.Converter.PercentChangeColorConverter   PercentChangeColorConverter��%   &	          5   
   6,   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $��* �6   �� 5$      $��* �6   .+�5&   
   &   System.Windows.Controls.DataGrid     
IsReadOnly . $��Stretch=�5(      "   VerticalScrollBarVisibility$
 Auto=�5)      $��0��5*      $��3��5+      $��0��5,      $��4��5-         AutoGenerateColumns .  ��5&      �� *Equity+	   Columns	 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ��  �� Path$
 Name�6Q     52      $
 Exchange��6%   $ * 6Y    67   �� $ Exchange�6Y     53      $

 Last��6%   $ * 6W    63   �� $ 
Price.Last�6W     54      $

 Open��6%   $ * 6W    63   �� $ 
Price.Open�6W     55      $
 Change��6%   $ * 6b    65   �� $ Price.PercentChange�   
Foreground 6l   �� $ PercentChange� �� 	Converter# [  57      59      5:      