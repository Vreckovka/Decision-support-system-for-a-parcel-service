   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Bakalarka.PagesBakalarka.Pages  5      &     Bakalarka.Pages.ZobrazTovaryPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Bakalarka.Pages     5        N� Title$  ZobrazTovaryPage��5	       � 	Resources 5       �� 
TargetType   ScrollBarStyle �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6'   5      .��5      � $
��auto��6   $
��Left=�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ vsetkyTovaryGrid��5         AutoGenerateColumns .    DataGridStyle#��[ 6a      
IsReadOnly .    CanUserResizeColumns .    CanUserResizeRows .  	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 5   �   
   MinColumnWidth$
 50Q�6�   ��5   -   �� ��5      �� *Vyska+��6,   �� *Sirka+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width$
 auto 6&      Header$ Číslo tovaru��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *	TOVARID+6g     5      $
 auto 6&   $* $Plánovaný dátum prijatia na sklad��63    6^   �� *PLANOVANYDATUM+ �� StringFormat$ 
dd/MM/yyyy��6�     5      $ Dátum prijatia na sklad��6&    6G   �� *DATUMPRIJATIANASKLAD+$ 
dd/MM/yyyy��6�     5      $
 auto 6&   $ Dodávateľ��63    6F   �� *NAZOVDODAVATELA+6l     5      $
 auto 6&   $ 	Príjemca��63    6E   �� *MENOPRIJEMCU+6h     5      $ Dĺžka��6&    65   �� *DLZKA+$
 0.00��6d     5      $ Šírka��6&    65   �� *SIRKA+$
 0.00��6d     5      $ Výška��6&    65   �� *VYSKA+$
 0.00��6d     5      $ 	Hmotnosť��6&    68   �� *
HMOTNOST+$
 0.00��  5      $
 auto 6&   $ Dodacia Adresa��63    6K   �� *ADRESAPRIJEMCU+  5      $ Vozidlo��6&    67   �� *	VOZIDLOID+6W     5      $ Dátum doručenia��6&    6?   �� *DATUMDORUCENIA+$ 
dd/MM/yyyy��6~     5"      $ Prvá trieda��6&    6;   �� *
PRVATRIEDA+   	CellStyle 5#      �� 5$      *  $System.Windows.Controls.DataGridCell"  6    .�5%      ��  �� Property � �� �� Value �	#66FF00006;    �� Triggers 5&      ^� 5'   "    ^� 
Conditions 5(   &   �� 5)   *    �� Binding 64   ��  �� Path$ 
PRVATRIEDA� �� Value ÁNO6X   6f   .0�5+   &   ��  � �� �	#660080006C   5,   #   5.      50        52      $ Prijatý��6&    67   �� *	PRIJATY+ 53      �� 54      "  6    .�55      ��  � �� �	#66FF00006;    56      ^� 57   "    58   &   �� 59   *    64   �� $ PRIJATY� ÁNO6U   6c   .0�5;   &   ��  � �� �	#660080006C   5<   #   5>      5@        5B      $ 
Doručený��6&    68   �� *
DORUCENY+ 5C      �� 5D      "  6    .�5E      ��  � �� �	#66FF00006;    5F      ^� 5G   "    5H   &   �� 5I   *    64   �� $ DORUCENY� ÁNO6V   6d   .0�5K   &   ��  � �� �	#660080006C   5L   #   5N      5P      4  .System.Windows.Controls.DataGridTemplateColumn  5S         CellTemplate 5T      �� 5U      .R�5V      �� -   5        $��X��5V   @     DeleteButtonStyle#��[ 6L   5W      5Y      5\      5]      5^      