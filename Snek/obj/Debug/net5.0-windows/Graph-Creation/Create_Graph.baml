   M S B A M L   `   `   `  ����?  ;Snek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnekSnek  5   	   M+clr-namespace:Snek.Graph_Creation.ViewModelSnek.Graph_Creation.ViewModel  5   	   &     Snek.Graph_Creation.Create_Graph   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Snek     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   >
viewModels+clr-namespace:Snek.Graph_Creation.ViewModel   5   	   -   5          � WindowStartupLocation$  CenterScreen=�5
   	    � Title$
 Snek��5   	   $	��600��6   $	��920��6#    � Icon$ \Images\favicon.ico��6/    � AllowsTransparency$
 True��5   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � DataContext 5      :  4Snek.Graph_Creation.ViewModel.Create_Graph_ViewModel  5   
   .��5      �� ���#252526 �� CornerRadius$ 10��6"   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      	 � RowDefinitions	 5      �� 5      $��75 �6    �� 5      .+�5      �� $��Center=�6   $
��Left=�64   .+�5      �� $��/Images/Snek_PNG.png��6   $��80��66   5      �� 5       $��Center=�6   $��Right=�64   .+�5!      �� $��Snek Studio��6   $��	helvetica)�5"      $��23(�5#      
�������$��Center=�5%      5&      A� 5'      -   5        ���#ec4646$��1��5'   %   $��15��65   $��15��6A   $��
698,7,7,53q�6L   $��Right=�6`   $��Center=�6|   6�   A� 5(      -   5        ���#ffe268$��1��5(   %   $��15��65   $��15��6A   $��0,7,38,0q�6L   $��Right=�6^   $	��Top=�6z   6�   �� 5)      $��1��6   .+�5*      	� $
��Home��6!   $��50��5+   !   
�������$��14(�5-   !      MenuButtonTheme#��[  5.   !   
 d� 	IsChecked$

 TrueY�5/   !   ��50   !   �� *HomeViewCommand+51   $   	� 52      $��	Über uns��6!   $��50��53   !   
�������$��14(�55   !   #��[  56   !   ��57   !   �� *UeberUnsCommand+58   $   	� 5:      $��Pos-Kriterien��6!   $��50��5;   !   
�������$��14(�5=   !   #��[  5>   !   ��5?   !   �� *
PosCommand+5@   $   5A      �� 5B      $	��250��6   $��40��5C      $��Center=�5D      $
��Left=�5E      $��5q�5F      $��1��5G        ModernTextbox#��[ 5H      .��6?   5J      �� 5K      $��1��6   $��1��6*   $��10,0,0,0q�6:   ��6L   �� *CurrentView+6n   5M      5O      5P      