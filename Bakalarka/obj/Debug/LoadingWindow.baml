   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Bakalarka	Bakalarka  5   	   P LLoadingIndicators.WPF, Version=0.0.1.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingIndicators.WPF;assembly=LoadingIndicators.WPFLoadingIndicators.WPF 5   	       Bakalarka.LoadingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Bakalarka     5   	   RWPFBclr-namespace:LoadingIndicators.WPF;assembly=LoadingIndicators.WPF     5   	     � Title$  LoadingWindow��5	   	   $	��350��6   $	��700��6,    � WindowStyle$
 None=�68   ���#121a21 � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType	 �� Padding
 ��Name �� 
StartPoint �� EndPoint � Color � Offset J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity � RowDefinitions��%�  '�       �� 5   
   " �6   .�5      ��  � �� 5      �� 5      " �6&   .R�5      �� $	 	0,0,10,10q�6"   ._�5      � .+�5   "   �� $
 	Container��6*   ��5   &   �� 5   *   $	 0,0&�6>   $	 0,2&�6O   .��5   .   � $ 	#FF0B1115��6;   $	 0.0Q�6M   � 5   .   $ 	#FF061219��6;   $
 0.35Q�6M   5   +    5   &     5   *   $ 10Q�6;   $
 0.25Q�6L   6]   5   #   � 5!   "    5"   &   �� 5#   *   $
��auto �68   6H   �� 5$   *   $
��auto �68   6H   �� 5%   *   $��* �68   6E   .+�5'   &   �� $��2��6-   ._�5(   *   �� #��z��6;   6a   5)   '   5*   #   5+      5,      5-      5/      50      51      '  !System.Windows.Shell.WindowChrome   WindowChrome 54        55   
      ResizeBorderThickness$ 15q�6      CaptionHeight$ 40Q�62   .��58      �� ��59   
   �� 5:      $	 0,0&�6"   $	 0,2&�63   .��5;      � $ 	#FF0B1115��6   $	 0.0Q�61   � 5<      $ 	#FF061219��6   $
 0.35Q�61   � 5=      $ 	#FF0E1D29��6   $	 0.8Q�61   5>      ._�5@   
   �  5A      �� 5B      $
��auto �6    �� 5C      $��* �6    .+�5F      ,  &LoadingIndicators.WPF.LoadingIndicator     
SpeedRatio$	 0.8Q�6#   $��0��64   $	��200��6A   $	��200��6M       LoadingIndicatorRingStyleKey#���   6[   $	��Top=�6�   $��0,45,0,0q�6�   ��5G      �� 5H      $	 0,0&�6*   $	 0,1&�6;   .��5I      � $ 	#FF98F2FB��6'   $	 0.0Q�69   � 5J      $ 	#FF8DF1FB��6'   $
 0.25Q�69   � 5K      $ 	#FF63FFF8��6'   $	 0.3Q�69   5L       5N        5O      $ 0Q�6'   $	 0.8Q�67      Color$ 	#9975FFFF��6E      
BlurRadius$ 10Q�6W   6i   5Q      �� 5S      $��1��6   ��5T      �� 5U      $	 0,0&�6*   $
 0,45&�6;   .��5V      � $ 	#FF06121B��6'   $	 0.0Q�69   � 5W      $ 	#FF01060A��6'   $	 0.3Q�69   5X      ._�5[      �� -   5         ��Name$ 
TextStatus��5[   J     ModreGradient#���  6   $��18(�6^   $��Center=�6}   $��Center=�6�   $��0q�6�   ��6l   �� 5]      5^      5_      5`      5a      