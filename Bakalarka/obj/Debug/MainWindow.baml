   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Bakalarka	Bakalarka  5   	       Bakalarka.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Bakalarka     5   	   -   5          �Name$  
HlavneOkno��5       � Title$ 
HlavneOkno��6	   $
��1000��60   $	��520��6@   $	��320��6Q   $
��1000��6^      WindowStyle#���   6�    � WindowStyle$
 None=�6�    � 
ResizeMode$ 	CanResize=�6�    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5	   k    � 	Resources 5
       �� 
TargetType  ScrollBarStyle �� BasedOn  MenuItemControlTemplate1	 �� 
TargetType
 ��Name J� SnapsToDevicePixels � ColumnDefinitions ��Name m� Icon F�Name �� HeaderStringFormat �� ContentStringFormat �Name � AllowsTransparency �� RelativeSource �� Padding ��Name �� 
ResourceId �� TypeInTargetAssembly �� ClearTypeHint ��Name �� ElementName ��Name-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation � IsSharedSizeScope   TabNavigation  �� Triggers! P� Property" P� Value# �� 
TargetName$ �� Property% �� Value& P� 
SourceName  MenuItemControlTemplate2' �� Stretch��%�  '��       7  &	 "     &	 }
    �� 5   
   " ��6   8   6'   �� 5   
   "	 m�6;   .R�5      �� $
 templateRoot��6   #��z��6+   #��z��6W   #��z��6�    . ._�5      � $��Center=�6    5      �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   .+�5      �� $
 Icon��6'   #��z 65   $
��Icon��6V   $��Center=�6k   $��16��6�   $��3q�6�   # z 6�   $��Center=�6�   $��16��6�   F� 5      $ 
GlyphPanel��6   T������� �O �`�G �ڊ � �D �ڊ �    �XO � � �g5 ���A  ] ������� @    р�� �O #��z��6t   $��LeftToRight=�6�   $��3q�6�   $y�	Collapsed=�6�   $��Center=�6�   �� 5      #��z��6'   #��z��6Z   $��1��6}   # z 6�   $��Header��6�   #��z��6�   ��. # z 6  � 5      $ 
PART_Popup��6    . |�.  #��� -�6�   $��Bottom=�6  ��6\   �� *IsSubmenuOpen+ �� *TemplatedParent+.��5      �� $
 SubMenuBorder��6!   ���	#FF729FB4$��1q�6Q   ���	#D80D1721$ 2q�6|   ._�5      �� $ SubMenuScrollViewer��6,   ��6I   C� *�� $ MenuScrollViewer��" �+.��5   "   � $ Enabled=�6'   .+�5   &   �� $
��Left=�6-   $��0��6H   $	��Top=�6S   $��0��6k   .+�5   *   �� $ 
OpaqueRect��64   ��6H   �� *
Background+$ SubMenuBorder����6   �� *ActualHeight+$ SubMenuBorder����6�   �� *ActualWidth+$ SubMenuBorder��5   '   �� 5   &   ���	#FFD7D7D7$
��Left=�6A   $��29,2,0,2q�6\   $��1��6n   �� 5   &   $ ItemsPresenter��65   $ Cycle=�6M    . # z 6�   $ Cycle=�6�   5    #   5!      5"      5#      5$      5%        5&      P� 5'      "! �@m�IsSuspendingPopupAnimation" . . �5(      �� $# 
PART_Popup��67   $ � ��$
% None=�6O   5)      P� 5*      " 6*   Z� ! �@m�Icon. �5+      �� $
# Icon��63   $ � y�$% 	Collapsed=�6E   5,      P� 5-      ! �@m�	IsChecked" . . �5.      �� $# 
GlyphPanel��63   $ � y�$% Visible=�6K   �� 5/      $
# Icon��63   $ � y�$% 	Collapsed=�6E   50      P� 51      ! �@m�IsHighlighted" . . �52      �� $# templateRoot��63   $ � ��% �	#3D26A0DA6M   �� 53      $# templateRoot��64   $ � ��% �	#FF26A0DA6N   54      P� 55      ! � {�" .  . �56      �� $# templateRoot��6?   $ � ��% �	#FF56FFF06Y   �� 57      $# 
GlyphPanel��6-   $ � ��% �	#FF7070706E   58      P� 59      $& SubMenuScrollViewer��66   ! � ��" .  . �5:      �� $# 
OpaqueRect��63   % 6K   �� *VerticalOffset+$ SubMenuScrollViewer��$ �@��Top�� 5;      $# 
OpaqueRect��64   % 6L   �� *HorizontalOffset+$ SubMenuScrollViewer��$ �@��Left5<      5>      �� 5@   
   "	 m�6;   .R�5A      �� $
 templateRoot��6   ._�5B      � $��Center=�6    5C      �� 5D      $
��auto �6+   �� 5E      $
��auto �6+   .+�5H      F� $��1��6   $��10��6+   $��10��66   $
' Fill=�6B   ���	#CCA6B2B8������VQ ��р=P����@*NP��� �W
i�x�e	i� }
P�Ѡ�
��u���
0�w�PC�
`����h	� �р[
� ���VQx���xz���v��VQ ��6b   �� 5J      $��0��6'   #��z��67   #��z��6j   # z 6�   $��Header��6�   ��. # z 6�   $��	35,2,50,2q�67  � 5L      $ 
PART_Popup��6    . |�.  #��� -�6�   $��Right=�6  ��6\   �� *IsSubmenuOpen+ �� *TemplatedParent+.��5M      �� $
 SubMenuBorder��6!   ���	#FF729FB4$��1q�6P   ���	#D80D1721$ 2q�6{   ._�5N      �� $ SubMenuScrollViewer��6+   ��6H   C� *�� $ MenuScrollViewer��" �+.��5O   "   � $ Enabled=�6'   .+�5P   &   �� $
��Left=�6-   $��0��6H   $	��Top=�6S   $��0��6k   .+�5Q   *   �� $ 
OpaqueRect��64   ��6H   �� *
Background+$ SubMenuBorder����6   �� *ActualHeight+$ SubMenuBorder����6�   �� *ActualWidth+$ SubMenuBorder��5R   '   �� 5S   &   ���	#FFD7D7D7$
��Left=�6A   $��29,2,0,2q�6\   $��1��6n   �� 5T   &   $ ItemsPresenter��65   $ Cycle=�6M    . # z 6�   $ Cycle=�6�   5U   #   5V      5W      5X      5Y      5Z        5[      P� 5\      "! �@m�IsSuspendingPopupAnimation" . . �5]      �� $# 
PART_Popup��67   $ � ��$
% None=�6O   5^      P� 5`      ! �@m�IsHighlighted" . . �5a      �� $# templateRoot��63   $ � ��% �	#3D26A0DA6M   �� 5b      $# templateRoot��64   $ � ��% �	#FF26A0DA6N   �� 5c      $# templateRoot��68   $ � ��$% 1q�6R   6^   �� 5d      $# templateRoot��6/   $ � ��$% -1,-1,-1,-1q�6I   6_   5e      P� 5f      ! � {�" .  . �5g      �� $# templateRoot��6?   $ � ��% �	#FF56FFF06Y   5h      P� 5i      $& SubMenuScrollViewer��66   ! � ��" .  . �5j      �� $# 
OpaqueRect��63   % 6K   �� *VerticalOffset+$ SubMenuScrollViewer��$ �@��Top�� 5k      $# 
OpaqueRect��64   % 6L   �� *HorizontalOffset+$ SubMenuScrollViewer��$ �@��Left5l      5n      5r      '  !System.Windows.Shell.WindowChrome(   WindowChrome( 5t        5u   
   )   ResizeBorderThickness$) 15q�6   *   CaptionHeight$* 40Q�62   .��5x      � .+�5y   
   �� .+�5z      � $��5q�6     
tmavaModra#��[ 6    5{      �� 5|      $��* �6'   �� 5}      $
��auto �6'   .+�5�      o� $��0��6   $	��Top=�6)   $
��Left=�6A   $
��auto��6\   
�������$��2q�6�   ��6i   Z� .@�5�      m� $��Vozidlá��6   
�������#���  6C   .@�5�      m� $��Zobraz Vozidlá��6#   #���  6Q   ��6;   Z� .@�5�      m� -   5        + m�Name$+ ButtZobrazVsetkyVozidla��5�   '   $��Všetky vozidlá��6H   6�   m� 5�      -   5        $ + ButtZobrazNeAktivneVozidla��5�   '   $��Neaktívne vozidlá��6K   6�   m� 5�      -   5        $+ ButtZobrazAktivneVozidla��5�   '   $��Aktívne vozidlá��6I   6�   5�      m� 5�      -   5        $+ ButtPridajVozidlo��5�   #   $��Pridaj Vozidlo��6>   6x   5�      m� 5�      $��Tovary��6   
�������#���  6C   .@�5�      m� $��Zobraz Tovary��6#   #���  6P   ��6:   Z� .@�5�      m� -   5        $+ ButtZobrazVsetkyTovary��5�   '   $��Všetky tovary��6G   6�   m� 5�      -   5        $#+ ButtZobrazPrichadzajuceTovary��5�   '   $��Prichadzajúce tovary��6N   6�   m� 5�      -   5        $+ ButtZobrazTovaryNaSklade��5�   '   $��Tovary na sklade��6I   6�   m� 5�      -	   5        $+ ButtZobrazDoruceneTovary��5�   '   $��Doručené tovary��6I   6�   5�      5�      m� 5�      $��Objednávky��6   
�������#���  6F   .@�5�      m� $��Zobraz objednávky��6#   #���  6T   ��6>   Z� .@�5�      m� -
   5        $+ ButtZobraVsetky��5�   '   $��Všetky objednávky��6@   6|   m� 5�      -   5        $'+ !ButtZobrazPrichadzajuceObjednavky��5�   '   $ ��Prichadzajúce objednávky��6R   6�   m� 5�      -   5        $+ ButtZobrazVybavene��5�   '   $��Vybavené objednávky��6C   6`   m� 5�      -   5        $!+ ButtZobrazCiastocneVybavene��5�   '   $'��!Čiastočne vybavené objednávky��6L   6s   m� 5�      -   5        $+ ButtZobrazNevybavene��5�   '   $��Nevybavené objednávky��6E   6d   5�      m� 5�      -   5        $+ ButtPridajObjednavku��5�   #   $��Pridaj objednávku��6A   6�   5�      m� 5�      $��Dodávatelia��6   
�������#���  6G   .@�5�      m� -   5        $+ ButtZobrazDodavatelov��5�   #   $��Zobraz dodávateľov��6B   6�   m� 5�      -   5        $+ ButtPridajDodavatela��5�   #   $��Pridaj dodávateľa��6A   6�   5�      m� 5�      -   5        $
+ Mapa��5�      $
��Mapa��6-   
�������#���  6O   .@�5�      m� -   5        $+ ButtZobrazMapu��5�   #   $��Zobraz Mapu��6;   6P   m� 5�      -   5        $��Trasa��5�   #   #���  6e   ��6O   Z� .@�5�      m� -   5        $+ ButtVygenerujTrasu��5�   '   $��Vygeneruj novú trasu��6C   6a   m� 5�      -   5        $+ ButtZobrazTrasu��5�   '   $��Zobraz trasy��6@   6V   5�      5�      5�      �� 5�      $��1��6   $��Bottom=�6,   $
��auto��6c   $��0,2,5,0q�6p   ��6D   �� *Databaza.Stav+��5�      �� 5�      " ��6    .�5�      �� $ � ��% �	#FFE24D4D6;   , �� Triggers, 5�      ^� 5�   "   - ^� 
Conditions- 5�   &   �� 5�   *   . �� Binding. 64   ��  �� *Self+/ �� Path$
/ Text�0 �� Value0 
Pripojený6x   6�   .0�5�   &   �� $ � ��% �	#FF29BB296C   5�   #   5�      5�      5�      �� 5�      1 �� Orientation$1 
Horizontal=�6   ��62   �� *Vyska+.+�5�      � 
������ $��5,0,0,0q�60   .+�5�      �� ��6   �� *
tmavaModra+2 J� Effect2 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�      3   
BlurRadius$3 5Q�6/   4   Opacity$	4 0.5Q�6>   5   ShadowDepth$5 1Q�6L   5�      � 5�      $��5q�6    5�      �� 5�      $��* �6/   6 � RowDefinitions6 5�      �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   .+�5�      �� $��0��6%   $%��Dnes prichadzajúce objednávky��62   $��15(�6W   $��Center=�6e   
�������$��5q�6�   6�   &   System.Windows.Controls.DataGrid  5�      -   5        7  Name$%7 DnesPrichadzajuceObjednavkyGrid��5�   �   $��1��6#   8   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	8 245 60   $��0��6C   $
��Left=�6S   $��Center=�6n   9   AutoGenerateColumns9 .    DataGridStyle#��[ 5�   d   :   
IsReadOnly: . ;   CanUserResizeColumns; .  <   CanUserResizeRows< .  ��6#   �� *DataTablePom+��5�   6   �� =   	CellStyle= 5�      �� 5�   "   *  $System.Windows.Controls.DataGridCell"  6(   .�5�   &   -   5        5�   #   >   Columns> 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn?   Header$? Číslo objednávky��66   1	  +System.Windows.Controls.DataGridBoundColumn@ 	  Binding@ 6P   �� *OBJEDNAVKAID+A   	CellStyleA 5�   &   �� 5�   *   "  60   .�5�   .   �� $ � ��% �	#CC9C27276K   -   5        , 5�   .   ^� 5�   2   - 5�   6   �� 5�   :   . 6D   �� $/ VYBAVENA�0 C6f   6r   .0�5�   6   �� $ � ��% �	#CC9E9E006S   5�   3   ^� 5�   2   - 5�   6   �� 5�   :   . 6D   �� $/ VYBAVENA�0 V6f   6r   .0�5�   6   �� $ � ��% �	#880078006S   5�   3   5�   +   5�   #   5�      5�      5�      � 5�      $��5,0,10,0q�6   .+�5�      �� $
��auto��6   #��[ 6+   2 5�        5�      $3 5Q�6/   $	4 0.5Q�6>   $5 1Q�6L   5�       � 5�      -   5        B  �Name$B HlavnyFrame��5�      C  � NavigationUIVisibility$C Hidden=�62   ��6R   �� *Sirka+��6j   �� *Vyska+5�      5�      5�      5�      5�      