   M S B A M L   `   `   `  ����?  ;Snek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Snek.Graph_Creation.ViewModelSnek.Graph_Creation.ViewModel  5      C&clr-namespace:Snek.Graph_Creation.ViewSnek.Graph_Creation.View  5      O,clr-namespace:Snek.Graph_Creation.ConvertersSnek.Graph_Creation.Converters  6C   &     Snek.Graph_Creation.View.PosView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      B
viewModels+clr-namespace:Snek.Graph_Creation.ViewModel     5      8local&clr-namespace:Snek.Graph_Creation.View     5      C
Converters,clr-namespace:Snek.Graph_Creation.Converters     6C     � DataContext  5
      0   *Snek.Graph_Creation.ViewModel.PosViewModel  5   
    � 	Resources 5      4  .Snek.Graph_Creation.Converters.ZeitenConverter   	converter��%   &	          5   
   69   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��200* �6   �� 5      $	��40* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   .+�5$   
   �� -   5         ��Name$ lstMitwirkende��5$      $��0��6*   $��0��6:   ��6G   ��  �� Path$ AllMitwirkende� �� SelectedItem 6s   �� $ SelectedMitwirkende���5%      �� 5&      .R�5'      ��  �� Orientation$ 
Horizontal=�6!   .+�5(      �� $��5q�6%   $ 
Horizontal=�60   .+�5)      �� $��5,0,0,0q�6(   $��12(�6W   ��69   �� $ Vorname�6g   �� 5*      $��5,0,0,0q�6(   $��12(�6X   ��69   �� $ Nachname�6h   5+      5,      5-      5/      �� 51   
   -   5        $ lstArbeiten��51      $��1��6'   ��67   �� $ ArbeitenByMitwirkende� 6j   �� $ SelectedArbeiten���52      �� 53      .R�54      �� $ 
Horizontal=�6!   .+�55      �� $��5q�6%   $ 
Horizontal=�60   .+�56      �� $��5,0,0,0q�6(   $��12(�6S   ��69   �� $	 Art�6c   57      58      59      5;      �� 5=   
   -   5        $ 	lstZeiten��5=      $��2��6%   ��65   �� $ ZeitenByArbeiten���5>      �� 5?      .R�5@      �� $ 
Horizontal=�6!   .+�5A      �� $��5q�6%   $ 
Horizontal=�60   .+�5B      �� $��5,0,0,0q�6(   $��12(�6W   ��69   �� $ Stunden�6g   �� 5C      $��5,0,0,0q�6(   $��12(�6W   ��69   �� $ Minuten�6g   �� 5D      $��5,0,0,0q�6(   $��12(�6X   ��69   �� $ Sekunden�6h   5E      5F      5G      5I      �� 5J   
   $��2��6   $��Center=�6$   $��Center=�6A   $��1��6\   $��20(�6�   
���������6i   ��  �� ElementName$ 	lstZeiten��$ ItemsSource�	 �� 	Converter#	 [  5K      5M      5N      