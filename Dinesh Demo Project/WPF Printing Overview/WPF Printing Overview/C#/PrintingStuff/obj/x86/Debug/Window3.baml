   M S B A M L   `   `   `  ����  PrintingStuff    PrintingStuff.Window3   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Make XPS document and Print��5   	   $	��500��6-   $	��500��6:    � WindowStartupLocation$ CenterScreen=�6F   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $-��'4. Make, save and print an XPS document��6   $��16(�6C   $
��Bold"�6Q   $��5q�6c   � 5   
   -   5         �Name$ myGrid��5      $��1��6   .+�5      �� -   5         ��Name$ myInkCanvasBorder��5      
���   �$��2q�6D   ._�5      �� 5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   .+�5      �� $
��Wrap=�6   $+��%This is an InkCanvas, draw a picture.��6,   $	��Top=�6Y   $��0,0,10,0q�6q   �� 5      -   5        $��	XPS Print��5      $	��100��6)   $��5q�6H   �� 5      -   5        $
��Next��5      $	��100��6$   $��5q�6F   5      5      5      