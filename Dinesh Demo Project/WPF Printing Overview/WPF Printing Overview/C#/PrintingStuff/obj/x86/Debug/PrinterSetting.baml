   M S B A M L   `   `   `  ����  PrintingStuff"    PrintingStuff.PrinterSetting   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  PrinterSetting��5   	   $	��300��6    $	��300��6-   .��5      � $��4q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Available Printers��6!   $��14(�6;   �� 5   
   -   5         ��Name$ _PrinterList��5       �� DisplayMemberPath$
 Name��6(   $��1��5   (   ��5      ��  �� ElementName$
 This�� �� Path$ Printers��� 5   
   $/��)Available Page Sizes for Selected Printer��6   $��14(�6E   $��2��5      $��0 5 0 0q�6   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0 5 0 0q�6.   $��4��6?   .+�5      	� -   5         	�Name$ _PortraitRadio��5   -   $��Portrait��6   $��0 0 10 0q�6E    d� 	IsChecked$
 TrueY�5   .   	� 5      $��	Landscape��6   5      �� 5   
   -   5        $��5��5      $��Right=�6   $��Print Test Page��6:   5      5      5      