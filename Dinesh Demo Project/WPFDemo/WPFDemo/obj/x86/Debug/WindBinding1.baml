   M S B A M L   `   `   `  ����B  >WPFDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPFDemoWPFDemo  5   	       WPFDemo.WindBinding1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   'localclr-namespace:WPFDemo     5   	     � Title$  ConverterSample��5   	   $	��140��6!   $	��250��6.    � 	Resources 5      %   WPFDemo.YesNoToBooleanConverter   YesNoToBooleanConverter��%   &	          5   
   6(   5      .��5
      �� $��10q�6   .+�5   
   �� -   5        $��txtValue��5      � 5   
   $
��0,10q�6   .+�5      �� $��Current value is: ��6   �� 5      ��6   ��  �� ElementName$ txtValue�� �� Path$
 Text� �� 	Converter# [  6   5      �� 5   
   $	��Yes��6}    d� 	IsChecked 6   �� $ txtValue��$
 Text�# [  6}   5      5      