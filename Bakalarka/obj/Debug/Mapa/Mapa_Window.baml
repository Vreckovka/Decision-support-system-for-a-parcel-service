   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Bakalarka.MapaBakalarka.Mapa  5   	        Bakalarka.Mapa.Mapa_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Bakalarka.Mapa     5   	   -   5          � Title$
  Mapa��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStyle$
 None=�5	   	    � AllowsTransparency .     WindowMapaStyle#���   67   $��0q�6a    � 
ResizeMode$ NoResize=�5
   	   $��0q�6    � WindowStartupLocation$ CenterScreen=�6+   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      ResizeBorderThickness$ 10q�6      CaptionHeight$ 40Q�62   .��5      � 	 � RowDefinitions	 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
    � -   5        
  �Name$
 HlavnyFrame��5      $��0��6%     � NavigationUIVisibility$ Hidden=�62   $	��500��6�   $
��1300��6�   ��6R   �� *Sirka+��6j   �� *Vyska+6�   �� 5   
   -   5         ��Name$ ListBoxTrasy��5      $��1��6(   
�������$��20q�6N   $	��100��6Z   ���	#FF384B61$��1q�6   
������ ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� -   5        ��5   $   �� *
NazovCesty+6@   5      5      5      5       5!      