   M S B A M L   `   `   `  ����?  ;Snek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnekSnek  5   	   +    %Snek.Graph_Creation.Create_Graph_Type   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Snek     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$
 Snek��5
   	   $	��500��6   $	��920��6#    � Icon$ \Images\favicon.ico��6/    � AllowsTransparency$
 True��5   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      �� ���#252526 �� CornerRadius$ 10��6"   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5      �� $��Center=�6   $
��Left=�64   .+�5      �� $��/Images/Snek_PNG.png��6   $��80��66   5      �� 5      $��Center=�6   $��Right=�64   .+�5      �� $��Snek Studio��6   $��	helvetica)�5      $��23(�5      
�������$��Center=�5!      5"      A� 5#      -   5        ���#ec4646$��1��5#   %   $��15��65   $��15��6A   $��
698,7,7,53q�6L   $��Right=�6`   $��Center=�6|   6�   A� 5$      -   5        ���#ffe268$��1��5$   %   $��15��65   $��15��6A   $��0,7,38,0q�6L   $��Right=�6^   $	��Top=�6z   6�   �� 5&      $��Graphentypen auswählen��6   $��	helvetica)�5'      $��36(�5(      
�������$��Center=�5*      $��Center=�5+      $��1��5,      �� 5/      $��1��6   $��1��50      $��
20,8,14,10q�51      .+�53      �� -   5        $	��lst��53     $	��346��6   $	��607��6'   ���#252526$��Visible=�6H   $��Disabled=�6{   ���	#FF252526	 �� SelectionMode$	 Single=�6�   .@�57      �� $	��613��6"   59      �� 5:      .��5;      �� $��Line Series��6#   $��85��5<   !   
�������$��14(�5>   !      ButtonVS#��[  5?   !   $	��586��6C   5A      �� 5B      .��5C      �� $��Vertical Line Series��6#   $��85��5D   !   
�������$��14(�5F   !   #��[  5G   !   $	��586��6C   $��0,10,0,0q�6O   5H   $   5I      �� 5J      .��5K      �� $��Column Series��6#   $��85��5L   !   
�������$��14(�5N   !   #��[  5O   !   $	��586��6C   $��0,10,0,0q�6O   5P   $   5Q      �� 5R      .��5S      �� $��
Row Series��6#   $��85��5T   !   
�������$��14(�5V   !   #��[  5W   !   $	��586��6C   $��0,10,0,0q�6O   5X   $   5Y      �� 5\      .��5]      �� $��	Pie Chart��6#   $��85��5^   !   
�������$��14(�5`   !   #��[  5a   !   $	��586��6C   $��0,10,0,0q�6O   5b   $   5c      �� 5d      .��5e      �� $��Doughnut��6#   $��85��5f   !   
�������$��14(�5h   !   #��[  5i   !   $	��586��6C   $��0,10,0,0q�6O   5j   $   5k      5o      �� 5p      -   5        $��Buttond��5p   -   $��	Erstellen��6   
 �� Left$	
 586��6=   
 �� Top$	 367��6O   $��40��6`   $	��100��6l   ${�False��6�   5q      5r      5t      5u      