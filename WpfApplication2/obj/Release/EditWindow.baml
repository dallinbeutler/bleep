   M S B A M L   `   `   `  ���� K  GWpfApplication2, Version=16.5.1.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem      WpfApplication2.EditWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication2     6sys&clr-namespace:System;assembly=mscorlib     -     � Title$  Novacado Editor Window��$��680.308��$	��300��$	��300�� � Left$
 1000�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$  ApplicationCommands.Delete��  -   $ ApplicationCommands.Cut��.��� .+�� -    �Name$ 	greenGrid��$��10,0,10,423q����	#FFA7FF8D$	��183��$��Bottom=�.+��� -    ��Name$ butMarkStart��$��
mark start��$��Center=�$	��Top=�$	��266��$��31��$��0,10,0,0q��� -   $ butSound��$��sound��$��Center=�$��10,99,202,27q�$��Center=�$��60��$��60��$��4q��� -   $ butSkip��$
��skip��$��Center=�$��105,99,107,27q�$��Center=�$��60��$��60��$��4q��� -   $ butVideo��$��video��$��Center=�$��206,99,10,27q�$��Center=�$��56��$��60��$��4q��� -	    ��Name$ label��$��seconds��$
��Left=�$��196,0,0,113q�$��Bottom=��� -
   $ totalTimeLabel��$��0��$
��Left=�$��164,0,0,113q�$��Bottom=� J� RenderTransformOrigin$ -7.521,-3.282&��� -    ��Name$ comboBox��$
��Left=�$��	10,46,0,0q�$	��Top=�$	��120��	 �� SelectedIndex$	 0������ 
 �� Source
 0   *WpfApplication2.EnumBindingSourceExtension  *M� *local:CensorType++�� -   $ label2��$+��%Make edit up to current time of type:��$��Center=�$��0,75,0,0q�$	��Top=�� $��10,0,10,606q����	#FFFFFF92.+��� -   $ label1��$��current time:��$
��Left=�$��4,7,0,0q�$	��Top=��� -    ��Name$ 	time_hour��$
��Left=�$��23��$��	81,10,0,0q� �� TextWrapping$
 Wrap=�$��00��$	��Top=�$��21���� -   $ time_min��$
��Left=�$��23��$��
102,10,0,0q�$
 Wrap=�$��00��$	��Top=�$��21���� -   $ time_sec��$
��Left=�$��23��$��
123,10,0,0q�$
 Wrap=�$��00��$	��Top=�$��21���� -   $ time_ms��$
��Left=�$��23��$��
144,10,0,0q�$
 Wrap=�$��00��$	��Top=�$��31���� -   $ nudgeforward��$��>>��$
��Left=�$��
231,10,0,0q�$	��Top=�$��36��$��23���� -   $ 	nudgeback��$��<<��$
��Left=�$��
190,10,0,0q�$	��Top=�$��36��$��23���� -    ��Name$ listView��$��10,231,10,76q� �� ShowOnDisabled .  � ContextMenu �� .@�m� -    m�Name$ contextDelete�� m� Command$  ApplicationCommands.Delete��m� -   $ contextDisable��$ ApplicationCommands.Cut��$��Disable�� �� View �� .P��� �� -   $ 
toggleEdit��$��Toggle active��$
��Left=�$��
13,598,0,0q�$	��Top=�$��93���� -   $ delete��$��delete��$
��Left=�$��153,598,0,0q�$	��Top=�$��93��