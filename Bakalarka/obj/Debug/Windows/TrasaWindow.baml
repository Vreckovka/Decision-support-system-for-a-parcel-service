   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Bakalarka.WindowsBakalarka.Windows  5   	   #    Bakalarka.Windows.TrasaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Bakalarka.Windows     5   	   -   5          � Title$  TrasaWindow��5   	   $
��1020��6   $	��420��6*      WindowStyle#���   67    � WindowStyle$
 None=�6]    � 
ResizeMode$ 	CanResize=�6p    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5	   $   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      ResizeBorderThickness$ 15q�6      CaptionHeight$ 40Q�62    � 	Resources 5      	 �� 
TargetType  ScrollBarStyle
 �� BasedOn:  4System.Windows.Controls.Primitives.DatePickerTextBox  DatePickerTextBoxStyle��%`   '��       7  '  "     7  �� 5   
   "	 ��6   8
   6'   �� 5   
   "	  6   8
   6/   5      .��5      � .+�5   
   � $
��auto��6   $
��Left=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ StackPanelVozidla��5      $	��160��69   ���	#0553AFFF.+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$! DateTimePicker_VybratyDatum��5   !     DatePickerStyle#���  6F   
�������$��	0,10,0,10q�6�   �� 5      -   5         ��Name$ ButtPotvrdDatum��5      $��Vybrať dátum��66     ButtonStyle#���  6M   6s   �� 5      .+�5      �� ���	#7F89CEFD$��0,2,0,0q�69   ._�5      �� $��Vozidla��6(   $��Center=�67   $	��Top=�6T   $��20(�6l   $��0,0,0,20q�6z   5      �� 5      -   5         ��Name$ 	ZoznamAut��5   "   
�������$��0q�6e   
������ ��65   �� ��5       �� 5!   "   .R�5"   &   �� $ 
Horizontal=�61   .+�5#   *   �� ��64   �� *	VOZIDLOID+5$   '   5%   #   5'      5(      5)      �� 5+      -   5        $ StackPanelTovary��5+      .+�5,      &   System.Windows.Controls.DataGrid  -   5          Name$ vsetkyTovaryGrid��5,         AutoGenerateColumns .    DataGridStyle#��[ 6m      
IsReadOnly .    CanUserResizeColumns .    CanUserResizeRows .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5-   g      MinColumnWidth$ 50Q�5.      ��5,   9   ��    Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Poradie v trase��62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *PORADIEVTRASE+  52      $ Číslo tovaru��62    6H   �� *	TOVARID+  53      $* $Plánovaný dátum prijatia na sklad��62    6]   �� *PLANOVANYDATUM+ �� StringFormat$ 
dd/MM/yyyy��6�     54      $ Dátum prijatia na sklad��62    6S   �� *DATUMPRIJATIANASKLAD+$ 
dd/MM/yyyy��6�     55      $ Dodávateľ��63    6F   �� *NAZOVDODAVATELA+6l     56      $ 	Príjemca��63    6E   �� *MENOPRIJEMCU+6h     58      $ Dĺžka��62    6A   �� *DLZKA+$
 0.00��6p     59      $ Šírka��62    6A   �� *SIRKA+$
 0.00��6p     5:      $ Výška��62    6A   �� *VYSKA+$
 0.00��6p     5;      $ 	Hmotnosť��62    6D   �� *
HMOTNOST+$
 0.00��  5<      $ Dodacia Adresa��62    6J   �� *ADRESAPRIJEMCU+  5=      $ Vozidlo��62    6C   �� *	VOZIDLOID+6c     5>      $ Dátum doručenia��62    6K   �� *DATUMDORUCENIA+$ 
dd/MM/yyyy��6�     5A      $ Prvá trieda��62    6G   �� *
PRVATRIEDA+   	CellStyle 5B   "   �� 5C   &   *	  $System.Windows.Controls.DataGridCell"	 	 6,   .�5D   *   ��  �� Property � �� �� Value �	#66FF00006G    �� Triggers 5E   *   ^� 5F   .    ^� 
Conditions 5G   2   �� 5H   6     �� Binding  6@   �� ! �� Path$! 
PRVATRIEDA�" �� Value" ÁNO6d   6r   .0�5J   2   ��  � �� �	#660080006O   5K   /   5M   '   5O        5S      $ Prijatý��62    6C   �� *	PRIJATY+ 5T   "   �� 5U   &   "	 	 6,   .�5V   *   ��  � �� �	#66FF00006G    5W   *   ^� 5X   .    5Y   2   �� 5Z   6     6@   �� $! PRIJATY�" ÁNO6a   6o   .0�5\   2   ��  � �� �	#660080006O   5]   /   5_   '   5a        5c      $ 
Doručený��62    6D   �� *
DORUCENY+ 5d   "   �� 5e   &   "	 	 6,   .�5f   *   ��  � �� �	#66FF00006G    5g   *   ^� 5h   .    5i   2   �� 5j   6     6@   �� $! DORUCENY�" ÁNO6b   6p   .0�5l   2   ��  � �� �	#660080006O   5m   /   5o   '   5q      4
  .System.Windows.Controls.DataGridTemplateColumn
  5s       5t   "   �� 5u   &   $��Prijať��60   # 
  CellTemplate# 5x   "   �� 5y   &   .R�5z   *   �� -   5        ��5{   .   �� 5|   2   "	 ��68   .�5}   6   ��  � y�$ Visible=�6S    5~   6   ^� 5   :    5�   >   �� 5�   B     6L   �� $! DORUCENY�" ÁNO6n   6|   .0�5�   >   ��  � y�$ Hidden=�6[   5�   ;   5�   3   5�   +   5�   '   5�      5�      �� 5�      -	   5        $��25q�5�      #��[ 6*   $!��Potvrdiť doručené tovary��6O   $	��220��6r   $��30��6~   6�   5�      5�      5�      5�      5�      