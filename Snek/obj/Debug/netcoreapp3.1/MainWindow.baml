   M S B A M L   `   `   `  ����?  ;Snek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnekSnek  5   	       Snek.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Snek     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$
 Snek��5
   	   $	��450��6   $	��380��6#    � Icon$9 3C:\Users\Dzova\Desktop\Snek\Snek\Images\favicon.ico��6/    � AllowsTransparency$
 True��5   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   ��5      �� 5      .��5      �  � Color$ #003534��6'   	 � Offset$		 0.0Q�67   � 5      $ #56776c��6'   $	 1Q�67   5      5      �� 5       $��Center=�6   .+�5!      �� $:��4C:\Users\Dzova\Desktop\Snek\Snek\Images\Snek_PNG.png��6   $��80��6V   �� 5"      $��
Snek Login��6   $��Light"�5#      $��	helvetica)�5$      $��22(�5%      
�������$��Center=�5'      5(      �� 5,      $��1��6   .+�5-      �� 
 �� Orientation$
 
Horizontal=�6   .+�5.      �� $��	Helvetica)�6   $��Light"�5/      $��Username��50      $��20(�51      $��Center=�52      
�������
������ $��0q�55      $	��235��56      $
��Left=�57       J� Opacity$	 0.5Q�58      $��25��59      $��63,0,0,0q�5:      .  (MahApps.Metro.IconPacks.PackIconMaterial  5;         Kind$ Account=�61   $��Center=�5<   1   $��Center=�5=   1   
�������5>   1   5?      �� 5@      $	��250��6   $��2��5A      
�������$	 0.5Q�5C      �� 5G      $
 
Horizontal=�6   $��0,20,0,0q�66   .+�5H      G� $��	Helvetica)�6"   $��Light"�5I       G� Password$ Password��5J      $��20(�5K      $��Center=�5L      
�������
������ $��0q�5O      $	��235��5P      $
��Left=�5Q      $	 0.5Q�5R      $��25��5S      $��63,0,0,0q�5T        5U      $ FormTextboxPassword=�61   $��Center=�5V   1   $��Center=�5W   1   
�������5X   1   5Y      �� 5Z      $	��250��6   $��2��5[      
�������$	 0.5Q�5]      �� 5`      $
 
Horizontal=�6   $��0,50,0,0q�66   .+�5a      �� $	��100��6   $��40��6)   $��LOGIN��65   $��	60,0,60,0q�6E   �� 5b      -   5        $	��100��5b      $��40��6)   $��REGISTER��65   6H   5c      5e      5g      5h      5i      