   M S B A M L   `   `   `  ����K  GWpfApplication2, Version=16.5.1.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   
        WpfApplication2.EditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   
   -   5          � Title$  Novacado Editor Window��5	   	   $��680.308��6(   $	��300��69   $	��300��6E    � Left$
 1000��6T    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$  ApplicationCommands.Delete��5   	   5   	     5   
   -   5        $ ApplicationCommands.Cut��5   	   5   	   .��5      � .+�5   
   � -   5         �Name$ 	greenGrid��5      $��10,0,10,423q�6"   ���	#FFA7FF8D$	��183��6N   $��Bottom=�6[   .+�5      �� -   5         ��Name$ butMarkStart��5      $��
mark start��6+   $��Center=�6@   $	��Top=�6^   $	��266��6v   $��31��6�   $��0,10,0,0q�6�   6�   �� 5      -   5        $ butSound��5      $��sound��6'   $��Center=�67   $��10,99,202,27q�6T   $��Center=�6j   $��60��6�   $��60��6�   $��4q�6�   �� 5      -   5        $ butSkip��5      $
��skip��6&   $��Center=�65   $��105,99,107,27q�6R   $��Center=�6i   $��60��6�   $��60��6�   $��4q�6�   �� 5      -   5        $ butVideo��5      $��video��6'   $��Center=�67   $��206,99,10,27q�6T   $��Center=�6j   $��56��6�   $��60��6�   $��4q�6�   �� 5      -	   5         ��Name$ label��5      $��seconds��6#   $
��Left=�65   $��196,0,0,113q�6P   $��Bottom=�6e   �� 5      -
   5        $ totalTimeLabel��5      $��0��6,   $
��Left=�68   $��164,0,0,113q�6S   $��Bottom=�6h    J� RenderTransformOrigin$ -7.521,-3.282&�6�   �� 5       -   5         ��Name$ comboBox��5       $
��Left=�6)   $��	10,46,0,0q�6D   $	��Top=�6W   $	��120��6o   	 �� SelectedIndex$	 0��6�   ��6{   �� 
 �� Source
 0   *WpfApplication2.EnumBindingSourceExtension  *M� *local:CensorType++6�   �� 5!      -   5        $ label2��5!      $+��%Make edit up to current time of type:��6$   $��Center=�6T   $��0,75,0,0q�6q   $	��Top=�6�   5"      � 5#   
   $��10,0,10,606q�6   ���	#FFFFFF92.+�5$      �� -   5        $ label1��5$      $��current time:��6$   $
��Left=�6<   $��4,7,0,0q�6W   $	��Top=�6h   �� 5&      -   5         ��Name$ 	time_hour��5&      $
��Left=�6)   $��23��6D   $��	81,10,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $��00��6w   $	��Top=�6�   $��21��6�   6�   �� 5'      -   5        $ time_min��5'      $
��Left=�6(   $��23��6C   $��
102,10,0,0q�6O   $
 Wrap=�6c   $��00��6w   $	��Top=�6�   $��21��6�   6�   �� 5(      -   5        $ time_sec��5(      $
��Left=�6(   $��23��6C   $��
123,10,0,0q�6O   $
 Wrap=�6c   $��00��6w   $	��Top=�6�   $��21��6�   6�   �� 5)      -   5        $ time_ms��5)      $
��Left=�6'   $��23��6B   $��
144,10,0,0q�6N   $
 Wrap=�6b   $��00��6v   $	��Top=�6�   $��31��6�   6�   �� 5*      -   5        $ nudgeforward��5*      $��>>��6+   $
��Left=�6>   $��
231,10,0,0q�6Y   $	��Top=�6m   $��36��6�   $��23��6�   6�   �� 5+      -   5        $ 	nudgeback��5+      $��<<��6(   $
��Left=�6;   $��
190,10,0,0q�6V   $	��Top=�6j   $��36��6�   $��23��6�   6�   5.      �� 5/   
   -   5         ��Name$ listView��5/      $��10,231,10,76q�6%    �� ShowOnDisabled .  � ContextMenu 50      �� 53      .@�54      m� -   5         m�Name$ contextDelete��54       m� Command$  ApplicationCommands.Delete��66   55      m� 56      -   5        $ contextDisable��56       $ ApplicationCommands.Cut��68   $��Disable��6Z   57      58       �� View 5:      �� 5;      .P�5<      �� 5=      5?      �� 5@   
   -   5        $ 
toggleEdit��5@      $��Toggle active��6%   $
��Left=�6=   $��
13,598,0,0q�6X   $	��Top=�6l   $��93��6�   6�   �� 5A   
   -   5        $ delete��5A      $��delete��6!   $
��Left=�62   $��153,598,0,0q�6M   $	��Top=�6b   $��93��6z   6�   5F      5G      