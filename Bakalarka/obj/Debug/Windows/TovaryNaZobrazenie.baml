   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Bakalarka.WindowsBakalarka.Windows  5   	   *    $Bakalarka.Windows.TovaryNaZobrazenie   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Bakalarka.Windows     5   	   -   5          � Title$  TovaryVObjednavke��5   	   $	��350��6#   $
��1000��63   $	��350��6C   $
��1000��6P      WindowStyle#���   6^    � AllowsTransparency .  � WindowStyle$
 None=�5	   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      ResizeBorderThickness$ 15q�6      CaptionHeight$ 40Q�62    � 	Resources 5       �� 
TargetType  ScrollBarStyle �� BasedOn��%0   '��       7  �� 5   
   " ��6   8   6'   5      .��5      � .+�5   
   � $
��auto��6   $
��Left=�6   .+�5      �� .+�5      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 vsetkyTovaryGrid��5      
   AutoGenerateColumns
 .    DataGridStyle#��[ 6i      
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5         MinColumnWidth$ 50Q�6,   $
��1000��6@   ��5   5   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width$
 auto 6.      Header$ Číslo tovaru��6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *	TOVARID+6o     5      $
 auto 6.   $* $Plánovaný dátum prijatia na sklad��6;    6f   �� *PLANOVANYDATUM+ �� StringFormat$ 
dd/MM/yyyy��6�     5      $ Dátum prijatia na sklad��6.    6O   �� *DATUMPRIJATIANASKLAD+$ 
dd/MM/yyyy��6�     5      $
 auto 6.   $ Dodávateľ��6;    6N   �� *NAZOVDODAVATELA+6t     5      $
 auto 6.   $ 	Príjemca��6;    6M   �� *MENOPRIJEMCU+6p     5!      $ Dĺžka��6.    6=   �� *DLZKA+$
 0.00��6l     5"      $ Šírka��6.    6=   �� *SIRKA+$
 0.00��6l     5#      $ Výška��6.    6=   �� *VYSKA+$
 0.00��6l     5$      $ 	Hmotnosť��6.    6@   �� *
HMOTNOST+$
 0.00��  5%      $
 auto 6.   $ Dodacia Adresa��6;    6S   �� *ADRESAPRIJEMCU+  5&      $ Vozidlo��6.    6?   �� *	VOZIDLOID+6_     5'      $ Dátum doručenia��6.    6G   �� *DATUMDORUCENIA+$ 
dd/MM/yyyy��6�     5*      $ Prvá trieda��6.    6C   �� *
PRVATRIEDA+   	CellStyle 5+      �� 5,   "   *  $System.Windows.Controls.DataGridCell"  6(   .�5-   &   ��  �� Property � �� �� Value �	#66FF00006C    �� Triggers 5.   &   ^� 5/   *    ^� 
Conditions 50   .   �� 51   2    �� Binding 6<   ��  �� Path$ 
PRVATRIEDA� �� Value ÁNO6`   6n   .0�53   .   ��  � �� �	#660080006K   54   +   56   #   58        5<      $ Prijatý��6.    6?   �� *	PRIJATY+ 5=      �� 5>   "   "  6(   .�5?   &   ��  � �� �	#66FF00006C    5@   &   ^� 5A   *    5B   .   �� 5C   2    6<   �� $ PRIJATY� ÁNO6]   6k   .0�5E   .   ��  � �� �	#660080006K   5F   +   5H   #   5J        5L      $ 
Doručený��6.    6@   �� *
DORUCENY+ 5M      �� 5N   "   "  6(   .�5O   &   ��  � �� �	#66FF00006C    5P   &   ^� 5Q   *    5R   .   �� 5S   2    6<   �� $ DORUCENY� ÁNO6^   6l   .0�5U   .   ��  � �� �	#660080006K   5V   +   5X   #   5Z      4  .System.Windows.Controls.DataGridTemplateColumn  5\       5]      �� 5^   "   $��Prijať��6,   5`   #      CellTemplate 5c      �� 5d   "   .R�5e   &   �� -   5        ��5f   *   �� 5g   .   " ��64    5h   2   ^� 5j   6    5k   :   �� 5l   >    6H   �� $ PRIJATY� ÁNO6i   .0�5n   :   ��  � y�$ Hidden=�6W   5o   7   5q   /   5s   '   5t   #   5v      5y      �� 5{      -   5         ��Name$ ButtPotvrdPrijatie��5{      $��25q�66     ButtonStyle#��[ 6B   $��Prijať tovary na sklad��5|      $	��220��6:   $��30��6F   6R   5~      5      5�      5�      