   M S B A M L   `   `   `  ���� T  PMeta.Vlc.Wpf, Version=16.5.1.0, Culture=neutral, PublicKeyToken=721a8c5379fa4056A0clr-namespace:Meta.Vlc.Wpf;assembly=Meta.Vlc.WpfMeta.Vlc.Wpf  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  WpfApplication2$   Meta.Vlc.Wpf.Sample.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @wpf0clr-namespace:Meta.Vlc.Wpf;assembly=Meta.Vlc.Wpf     9system&clr-namespace:System;assembly=mscorlib     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  Novacado Video Player��$��636.867��$��424.209�� � 	Resources  �� 
TargetType �� Property �� Value��%.   '��       �� " ��.���  � ��$	 5,2q�.��� -    �Name$ LayoutParent�� ��    Key
VlcOptions   �� Type" ��.s���-I����--dummy-quiet����--ignore-config����--no-video-title����--no-sub-autodetect-file��.+�   Meta.Vlc.Wpf.VlcPlayer  -     Name$ Player��  
VlcOptions   	VlcOption# [ 	   
LibVlcPath$	 ..\..\libvlc��
   EndBehavior$
 Nothing=�$��10,20,10,62q�� -   $ allControls��.+�]� $
��Left=�$	��Top=�.+�o� $	��Top=�.@�m� $��_File��.@�m� -   $��
_Open File��m� -   $��	_Open DVD��m� -   $��
_Open Link��m� $��_Edits��.@�m� -   $��_Toggle Editor ��m� -	   $��_Search Online for Edits��m� -
   $��_Open / Add Edits��m� -   $��_Save Edit File��m� -   $��_Clear All Edits��m� $��	_Settings��.@�m� $��_Aspect Ratio��.@�m� -    m�Name$ RatioDefault��$��Default��m� -   $ 	Ratio4by3��$	��4:3��m� -   $ 
Ratio16by9��$
��16:9��m� -   $ pbSpeed��$��_PlayBack Speed��.@�m� -   $ 
speed_0_75��$��x 0.75��m� -   $ 	speed_1_0��$��x 1.0��m� -   $ 
speed_1_25��$��x 1.25��m� -   $ 	speed_1_5��$��x 1.5��m� -   $ 	speed_2_0��$��x 2.0���� � -    �Name$ ProgressBar�� J� Opacity$	 0.8Q�$��Bottom=�$��10�� � Maximum$ 1Q� � SmallChange$ 0.00001Q�$��0,0,0,40q� � Value �� *
Position+ �� ElementName$ Player������  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FFB2B2B2�� � Offset$ 0Q�� $ 	#FF303030��$ 1Q�� -   $ lowerControls�����	#FF858282$��Center=�$	��629��$��40��$��Bottom=�.+�� ���	#FFDDDDDD$��	0,0,409,0q�$��Right=�$	��220�� � ColumnDefinitions �� $
��Auto �$��51���� $
��129* ��� $	��40* �.+��� $��Volume:��$��Center=�$��16��$��4,7,3,7q�$��Center=�$��44���� $��1��$��Center=�$	 250Q�$��2,0,0,7q�$��23�� �� Ticks$ 	0,100,249R� �� TickPlacement$ BottomRight=� �� *Volume+$ Player����  �� TextAlignment$ Right=�$��40��$��Right=�$��1��$��0q�$��2������ *Volume+$ Player�� �� UpdateSourceTrigger$ PropertyChanged=��� -   $��Center=����	#FFD1D1D1
���   �
���   �$��40��$��0q�$��Center=�.���� -    ��Name$ image��$��0,0,0,0q�$��play.png���� -   $
��Stop��$��Center=�$��Center=�$��225,6,366,4q�$��38��$��30���� -   $	��[ ]��$��Bottom=�$��Right=�$��Symbol)�$��38��$��0q��� -    ��Name$ Editor��$��Right=�$��0,0,74,0q�$��Bottom=�$��39��$��21��$��Edits���� -   $ ClosedCaptioning��$��Right=�$��0,0,38,0q�$��Bottom=�$��36��$��CC��$��21���� $	 0.8Q�.+�� $��30��$��0q� �� �� 