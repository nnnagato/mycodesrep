   M S B A M L   `   `   `  ????>  :hw3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:hw3hw3  5   	       hw3.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:hw3     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? .+?5
   
   ?? $??Фраза:??6   $
??Left=?6!   $??	10,10,0,0q?6<   $	??Top=?6O   $??61??6g   $??27??6r   ?? 5   
   -   5         ??Name$ vvodbox??5      $
??Left=?6#   $??23??6>   $??	10,42,0,0q?6J    ?? TextWrapping$
 Wrap=?6]   $-??'Это надо зашифровать.??6q   $	??Top=?6?   $	??368??6?   ?? 5   
   $??Фраза-ключ:??6   $
??Left=?6&   $??	10,70,0,0q?6A   $	??Top=?6T   ?? 5   
   -   5        $ keybox??5      $
??Left=?6"   $??23??6=   $??
10,101,0,0q?6I   $
 Wrap=?6]   $4??.Через это надо шифровать.??6q   $	??Top=?6?   $	??368??6?   ?? 5   
   -   5         ??Name$	 but??5      $??Зашифровать??6   $
??Left=?64   $??
592,42,0,0q?6O   $	??Top=?6c   $	??116??6{   $??23??6?   6?   ?? 5   
   -   5         ??Name$ reslabel??5      $??Результат:??6"   $
??Left=?67   $??
10,201,0,0q?6R   $	??Top=?6f   $y?Hidden=?6~   ?? 5   
   -   5        $ resbox??5      $
??Left=?6"   $??23??6=   $??
10,232,0,0q?6I   $
 Wrap=?6]   $?? ??6q   $	??Top=?6y   $	??368??6?   $y?Hidden=?6?   ?? 5   
   -   5         ??Name$ 	code_mode??5      $
??Left=?6&   $??
436,43,0,0q?6A   $	??Top=?6U   $	??120??6m   .@?5      ?? $??Зашифровать??6   ?? 5      $??Расшифровать??6   5      5      5      