   M S B A M L   `   `   `  ����D  @Bakalarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Bakalarka.WindowsBakalarka.Windows  5   	   .    (Bakalarka.Windows.PridajDodavatelaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Bakalarka.Windows     5   	   -   5          � Title$  PridajDodavatela��5   	   $	��450��6"   $	��300��6/      WindowStyle#���   6;    � WindowStyle$
 None=�6a    � AllowsTransparency . 
�������'  !System.Windows.Shell.WindowChrome   WindowChrome 5	        5
   
      ResizeBorderThickness$ 0q�6      CaptionHeight$ 40Q�61    � 	Resources 5       �� 
TargetType  TextBoxStyle �� BasedOn��%0   '��       7  �� 5   
   " ��6   8   6%   5      .��5      � .+�5   
   � .+�5      �� $��Stretch=�6   $
��Auto��67   $��5q�6D    5      	 �� 	Resources
 �� Property �� Value��%�   '��       �� 5      " ��6   	 5      ���� 5      '��       " ��6$   .�5   "   �� 
 � ��$ 5q�6;   6G   �� 5   "   
 � ��$ Center=�6H   6Y   5      5      5      5      .+�5      �� $��Meno/Názov��6   60   �� 5       -   5         ��Name$
 meno��5       6*   �� 5"      $
��IČO��6   6)   �� 5#      -   5        $	 ico��5#      6)   � 5&      .+�5'      �� $��Stretch=�6!   $
��Auto��6?   $��5q�6L     StackPanelStyle#���  6W   .+�5(      �� $��Adresa��6$   $��20(�62   6C   �� 5)      $��Mesto��6$   63   �� 5*      -   5        $ mesto��5*   "   63   �� 5,      $��Ulica��6$   63   �� 5-      -   5        $ ulica��5-   "   63   �� 5/      $��Čislo domu��6$   68   �� 50      -   5        $ 	cisloDomu��50   "   67   51      52      �� 54      -   5         ��Name$ ButtPridajDodavatela��54      $��Pridaj dodávateľa��67   $��10,20,10,10q�6S     ButtonStyle#���  6�   6�   56      57      58      59      