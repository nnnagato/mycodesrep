   M S B A M L   `   `   `  ����  DateTimeServer    DateTimeServer.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  DateTime Server��5      $	��400��6   $	��600��6&   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Local Port:��6   $��5,5,17,5q�6'   �� 5   
   -   5         ��Name$ localPortTextBox��5      $��10,5,0,5q�6,   $��1��6>   $
��Left=�6N   $	��130��6i   �� 5   
   $��Remote Address:��6   $��249,8,163,8q�6+   $��1��6@    J� RenderTransformOrigin$ 0.499,0.614&�6P   �� 5   
   -   5        $ remoteAddressTextBox��5      $��1��60   $��	343,8,0,8q�6@   $
��Left=�6S   $	��135��6n   �� 5   
   $��Remote Port:��6   $��2��6(   $��249,10,205,287q�65   $��1��6M   �� 5   
   -   5        $ remotePortTextBox��5      $��2��6-   $��1��6:   $��
322,10,0,0q�6J   $
��Left=�6^   $	��175��6y   $��23��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ startButton��5      $��Start��6&   $��3��66   $��5q�6C   6N   �� 5   
   $��2��6   $��
10,106,5,5q�6$   $��2��68   .��5      �� -   5        $ chatTextBox��5       �� 
IsReadOnly$
 True��6+   $	��243��6=   5      �� 5   
   -   5        $ messageTextBox��5      $��3��6*   $��1��67   $��	5,5,271,5q�6G   �� 5   
   -   5        $ 
sendButton��5      $
��Send��6%   $��3��64   $��1��6A   $��	235,5,5,5q�6Q   6d   5      5      