   M S B A M L   `   `   `  ����V  RHomeTask_C_sharp_55_ADO_Net, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HomeTask_C_sharp_55_ADO_NetHomeTask_C_sharp_55_ADO_Net  5   	   ,    &HomeTask_C_sharp_55_ADO_Net.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HomeTask_C_sharp_55_ADO_Net     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   �� ��6   �� *	Servers+   Serv �� Source# [   �� SelectedItem 6P   �� *CurrentServerName+# [  ��5      �� 5      .R�5      �� ��6    �� *
servername+6>   5      5      �� 5   
   $
��Wrap=�6   $��1��6(   ��Use this selection to connected to Microsoft SQL server 2005 or above, or to Microsoft SQL Azure using the .NET Framework Data Provider for SQL Server6�   � 5   
   $��1��6   $��2��6    5      �� 5      6%   �� 5      6%   �� 5       6%   �� 5!      6%   �� 5"      6%   �� 5#      6%   �� 5$      6%   �� 5%      6%   �� 5&      6%   .+�5(      �� -   5        $��9(�5(      $��10,5,0,5q�6:   $��7��6L   ��6\   �� *continuaBtn+# [  .��6�   
Continue6�   �� 5)      -   5        $��5q�5)      $��8��6    .��6E   Cancel6M   5*      5+      5,      