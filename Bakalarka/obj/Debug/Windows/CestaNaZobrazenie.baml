   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Bakalarka.WindowsBakalarka.Windows  5   	   )    #Bakalarka.Windows.CestaNaZobrazenie   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Bakalarka.Windows     5   	   -   5          � Title$  CestaNaZobrazenie��5   	   $	��450��6#   $	��800��60      WindowStyle#���   6=    � AllowsTransparency .  � WindowStyle$
 None=�6~    � Topmost . '  !System.Windows.Shell.WindowChrome   WindowChrome 5
        5   
      ResizeBorderThickness$ 0q�6      CaptionHeight$ 40Q�61    � 	Resources 5       �� 
TargetType  ScrollBarStyle	 �� BasedOn��%0   '��       7  �� 5   
   " ��6   8	   6'   5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $
��auto �6#   62   �� 5      $��* �6#   6/   .+�5      �� $��0��64   $��1��6A   $��5q�6Q   $��20(�6\   ��6   �� *
NazovCesty+6\   5       �� 5!   
   
�������$��1��6,   $��10q�69   $��0q�6j   
������ ��6E   �� *ZoznamAdries+��5"      �� 5#      .R�5$      ��  �� Orientation$ 
Horizontal=�6!   .+�5%      �� ��6$   �� 5&      5'      5)      5*      5+      