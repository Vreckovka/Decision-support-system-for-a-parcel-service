   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Bakalarka	Bakalarka  5      '    !Bakalarka.Pages.ZobrazVozidlaPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Bakalarka     5        N� Title$  ZobrazVozidlaPage��5	       � 	Resources 5       �� 
TargetType   ScrollBarStyle �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6'   5      .��5      � $
��auto��6   $
��Left=�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ vsetkyVozidlaGrid��5         AutoGenerateColumns .    DataGridStyle#��[ 5         
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6L      MinColumnWidth$	 100Q�6\   ��5   .   �� 	   	CellStyle	 5      �� 5      *  $System.Windows.Controls.DataGridCell"  6   .�5      -   5        5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 SPŽ��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *	VOZIDLOID+6R     5      $ Značka��6%    65   �� *ZNACKA+6R     5      $	 Typ��6%    62   �� *TYP+6L     5      $ Najazdené kilometre��6%    6B   �� *NAJAZDENEKM+6d     5       $ Dĺžka kufru (m)��6%    6>   �� *
DLZKAKUFRU+6_     5!      $ Šírka kufru (m)��6%    6>   �� *
SIRKAKUFRU+6_     5"      $ Výška kufru (m)��6%    6>   �� *
VYSKAKUFRU+6_     5#      $ Nosnosť (kg)��6%    6;   �� *	NOSNOST+6Y     5$      $ Dátum evidencie��6%    6>   �� *DATUMEVIDENCIE+ �� StringFormat$ 
dd/MM/yyyy��6}     5%      $ 
Dátum Stk��6%    68   �� *
DATUMSTK+$ 
dd/MM/yyyy��6q     5&      $ Dátum emisnej kontroly��6%    6E   �� *DATUMEMISNEJ+$ 
dd/MM/yyyy��6�     5'      $ Dátum vyradenia��6%    6>   �� *DATUMVYRADENIA+$ 
dd/MM/yyyy��6}     5(      $ Aktívne��6%    66   �� *	AKTIVNE+   	CellStyle 5*      �� 5+      "  6    .�5,      ��  �� Property � �� �� Value �	#66FF00006;    �� Triggers 5-      ^� 5.   "    ^� 
Conditions 5/   &   �� 50   *    �� Binding 64   ��  �� Path$ AKTIVNE� �� Value ÁNO6U   6c   .0�52   &   ��  � �� �	#662078206C   53   #   55      57      4  .System.Windows.Controls.DataGridTemplateColumn  59         Width$
 auto 6)      CellTemplate 5:      �� 5;      .R�5<      �� -   5        $��X��5<   @     DeleteButtonStyle#��[ 6L   5=      5?      5B      5C      5D      