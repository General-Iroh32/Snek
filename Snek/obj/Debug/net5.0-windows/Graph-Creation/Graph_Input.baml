   M S B A M L   `   `   `  ����?  ;Snek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnekSnek  5   	   %    Snek.Graph_Creation.Graph_Input   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Snek     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$
 Snek��5
   	   $	��500��6   $	��920��6#    � Icon$ \Images\favicon.ico��6/    � AllowsTransparency$
 True��5   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      �� ���#252526 �� CornerRadius$ 10��6"   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5      �� $��Center=�6   $
��Left=�64   .+�5      �� $��/Images/Snek_PNG.png��6   $��80��66   5      �� 5      $��Center=�6   $��Right=�64   .+�5      �� $��Snek Studio��6   $��	helvetica)�5      $��23(�5      
�������$��Center=�5!      5"      A� 5#      -   5        ���#ec4646$��1��5#   %   $��15��65   $��15��6A   $��
698,7,7,53q�6L   $��Right=�6`   $��Center=�6|   6�   A� 5$      -   5        ���#ffe268$��1��5$   %   $��15��65   $��15��6A   $��0,7,38,0q�6L   $��Right=�6^   $	��Top=�6z   6�   �� 5&      $��	helvetica)�5'      $��36(�5(      
�������$��Center=�5*      $��Center=�5+      $��1��5,      �� 5-      	 � Language$	 de-at�6   $�Graph Input��6/   6E   �� 5/      $��1��6   $��1��50      $��
20,8,14,10q�51      .+�53      �� $��	helvetica)�54      $��28(�55      
�������$��1��57      
 �� Left$
 27��6,   
 �� Top$ 26��6=   $��34��6M   $��64��6Y   �� 58      $	 de-at�6   $�Input��6/   6?   �� 5=      -   5        $��Buttone��5=   -   $��	Erstellen��6   $	
 586��6=   $	 367��6O   $��40��6`   $	��100��6l   6x   �� 5>      -   5        $��Buttonb��5>   +   $��Go back��6   $	
 586��6;   $	 313��6M   $��40��6^   $	��100��6j   6v   �� 5?      -   5        $	��TB1��5?   #   $��0��6    �� TextWrapping$
 Wrap=�6.   $	��118��6B   $��30��6N   $ 60��6Z   $��20(�6j   �� 5@      $��	helvetica)�5A      $��28(�5B      
�������$	
 172��5D      $ 26��6'   $��34��67   $��65��6C   �� 5E      $	 de-at�6   $�Input��6/   6?   �� 5F      -   5        $	��TB2��5F   #   $��0��6   $
 Wrap=�6.   $	��119��6B   $��30��6N   $ 60��6Z   $	
 145��6j   $��20(�6|   �� 5G      $��	helvetica)�5H      $��28(�5I      
�������$	
 328��5K      $ 26��6'   $��34��67   $��64��6C   �� 5L      $	 de-at�6   $�Input��6/   6?   �� 5M      -   5        $	��TB3��5M   $   $��0��6   $
 Wrap=�6/   $	��118��6C   $��30��6O   $ 60��6[   $	
 301��6k   $��20(�6}   �� 5N      $��	helvetica)�5O      $��28(�5P      
�������$	
 328��5R      $	 102��6'   $��34��68   $��64��6D   �� 5S      $	 de-at�6   $�Input��6/   6?   �� 5T      -	   5        $	��TB7��5T   #   $��0��6   $
 Wrap=�6.   $	��118��6B   $��30��6N   $	 137��6Z   $	
 301��6k   $��20(�6}   �� 5U      $��	helvetica)�5V      $��28(�5W      
�������$	
 172��5Y      $	 102��6'   $��34��68   $��65��6D   �� 5Z      $	 de-at�6   $�Input��6/   6?   �� 5[      -
   5        $	��TB6��5[   #   $��0��6   $
 Wrap=�6.   $	��119��6B   $��30��6N   $	 137��6Z   $	
 145��6k   $��20(�6}   �� 5\      $��	helvetica)�5]      $��28(�5^      
�������$
 27��5`      $	 102��6&   $��34��67   $��64��6C   �� 5a      $	 de-at�6   $�Input��6/   6?   �� 5b      -   5        $	��TB5��5b   $   $��0��6   $
 Wrap=�6/   $	��118��6C   $��30��6O   $	 137��6[   $��20(�6l   �� 5c      $��	helvetica)�5d      $��28(�5e      
�������$
 27��5g      $	 187��6&   $��34��67   $��64��6C   �� 5h      $	 de-at�6   $�Input��6/   6?   �� 5i      -   5        $	��TB9��5i   #   $��0��6   $
 Wrap=�6.   $	��118��6B   $��30��6N   $	 221��6Z   $��20(�6l   .��6z   5k      �� 5l      $��	helvetica)�5m      $��28(�5n      
�������$	
 172��5p      $	 186��6'   $��35��68   $��65��6D   �� 5q      $	 de-at�6   $�Input��6/   6?   �� 5r      -   5        $
��TB10��5r   #   $��0��6   $
 Wrap=�6/   $	��119��6C   $��30��6O   $	 220��6[   $	
 145��6l   $��20(�6~   �� 5s      $��	helvetica)�5t      $��28(�5u      
�������$	
 328��5w      $	 186��6'   $��35��68   $��64��6D   �� 5x      $	 de-at�6   $�Input��6/   6?   �� 5y      -   5        $
��TB11��5y   #   $��0��6   $
 Wrap=�6/   $	��118��6C   $��30��6O   $	 220��6[   $	
 301��6l   $��20(�6~   �� 5z      $��	helvetica)�5{      $��28(�5|      
�������$	
 172��5~      $ 26��6'   $��34��67   $��65��6C   �� 5      $	 de-at�6   $�Input��6/   6?   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 328��5�      $ 26��6'   $��34��67   $��64��6C   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 328��5�      $	 102��6'   $��34��68   $��64��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 172��5�      $	 102��6'   $��34��68   $��65��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 172��5�      $	 186��6'   $��35��68   $��65��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 328��5�      $	 186��6'   $��35��68   $��64��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 484��5�      $ 26��6'   $��34��67   $��64��6C   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      -   5         ��Name$	 TB4��5�   $   $��0��6   $
 Wrap=�61   $	��118��6E   $��30��6Q   $ 60��6]   $	
 457��6m   $��20(�6   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 484��5�      $	 102��6'   $��34��68   $��64��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      -   5        $	 TB8��5�   #   $��0��6   $
 Wrap=�60   $	��118��6D   $��30��6P   $	 137��6\   $	
 457��6m   $��20(�6   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 484��5�      $	 186��6'   $��35��68   $��64��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      -   5        $
 TB12��5�   #   $��0��6   $
 Wrap=�61   $	��118��6E   $��30��6Q   $	 220��6]   $	
 457��6n   $��20(�6�   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$
 27��5�      $	 270��6&   $��34��67   $��64��6C   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      -   5        $
 TB13��5�   #   $��0��6   $
 Wrap=�61   $	��118��6E   $��30��6Q   $	 304��6]   $��20(�6o   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 172��5�      $	 269��6'   $��35��68   $��65��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      -   5        $
 TB14��5�   #   $��0��6   $
 Wrap=�61   $	��119��6E   $��30��6Q   $	 303��6]   $	
 145��6n   $��20(�6�   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 328��5�      $	 269��6'   $��35��68   $��64��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      -   5        $
 TB15��5�   #   $��0��6   $
 Wrap=�61   $	��118��6E   $��30��6Q   $	 303��6]   $	
 301��6n   $��20(�6�   �� 5�      $��	helvetica)�5�      $��28(�5�      
�������$	
 484��5�      $	 269��6'   $��35��68   $��64��6D   �� 5�      $	 de-at�6   $�Input��6/   6?   �� 5�      -   5        $
 TB16��5�   #   $��0��6   $
 Wrap=�61   $	��118��6E   $��30��6Q   $	 303��6]   $	
 457��6n   $��20(�6�   5�      5�      5�      5�      