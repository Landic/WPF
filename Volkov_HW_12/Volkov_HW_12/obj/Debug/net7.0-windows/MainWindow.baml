   M S B A M L   `   `   `  ����G  CVolkov_HW_12, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Volkov_HW_12Volkov_HW_12  5   	       Volkov_HW_12.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Volkov_HW_12     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6,   $	��450��6;   $	��800��6H    � 	Resources 5	         Volkov_HW_12.ViewModel   ColorViewModel��%   &	          5
   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      $
��0.8* �6#   �� 5      $��0.325* �6#   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5      �� 5      $��0.11* �6    �� 5      $
��0.3* �6    �� 5      $
��0.3* �6    �� 5      $
��0.3* �6    �� 5      $
��0.3* �6    �� 5      .+�5      o� -   5        $
��menu��5      $��7��6   .@�5      m� $��Добавить��6:    m� Command 6   �� *
AddCommand+6:   m� 5       $��Удалить��6=    6   �� *RemoveCommand+6=   5!      �� 5"      $��Альфа:��6N   $��1��6_    d� 	IsChecked 6   �� *CurrentColor.Check1+ �� Mode$ TwoWay=�6_   �� 5#      $��Красный:��6N   $��2��6a    6   �� *CurrentColor.Check2+$ TwoWay=�6a   �� 5$      $��Зелёный:��6N   $��3��6a    6   �� *CurrentColor.Check3+$ TwoWay=�6a   �� 5%      $��Сниий:��6N   $��4��6_    6   �� *CurrentColor.Check4+$ TwoWay=�6_   �� 5&      $��1��6;   $��1��6H   ��6   �� *CurrentColor.Alpha+6H   �� 5'      $��2��69   $��1��6F   ��6   �� *CurrentColor.Red+6F   �� 5(      $��3��6;   $��1��6H   ��6   �� *CurrentColor.Green+6H   �� 5)      $��4��6:   $��1��6G   ��6   �� *CurrentColor.Blue+6G   �� 5*       � Maximum$	 255Q�6L   	 � Minimum$	 0Q�6Z   $��1��6�   $��2��6�   $��4��6�   {�6   �� *CurrentColor.Check1+$ TwoWay=�
 � Value
 6f   �� *CurrentColor.Alpha+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5+      $	 255Q�6L   $	 0Q�6Z   $��2��6�   $��2��6�   $��4��6�   {�6   �� *CurrentColor.Check2+$ TwoWay=�
 6f   �� *CurrentColor.Red+$ TwoWay=�$ PropertyChanged=�6�   �� 5,      $	 255Q�6L   $	 0Q�6Z   $��3��6�   $��2��6�   $��4��6�   {�6   �� *CurrentColor.Check3+$ TwoWay=�
 6f   �� *CurrentColor.Green+$ TwoWay=�$ PropertyChanged=�6�   �� 5-      $	 255Q�6L   $	 0Q�6Z   $��4��6�   $��2��6�   $��4��6�   {�6   �� *CurrentColor.Check4+$ TwoWay=�
 6f   �� *CurrentColor.Blue+$ TwoWay=�$ PropertyChanged=�6�   �� 5.       �� CornerRadius$ 5��6   $��3q�6&   $��1��61   $��7��6>   $��4��6N   ��6_   �� *CurrentColor.Name+$ TwoWay=�$ PropertyChanged=�._�5/      �� 50      �� 51      $��6��6   $��7��6(   $
��Auto=�6<   .��52      ��  �� SelectedIndex 6   �� *index+��6:   �� *
color_list+��53      �� 54       �� 
TargetType" ��6    .�55      ��  �� Property � �� �� Value 56   "   �� 57   &    �� 
TargetType" ��66   .R�58   *   ��  ��Name$ border��61   $��2q�6A   $ 5��6U   ._�59   .   �� 5:   +    �� Triggers 5;   *   P� 5<   .    P� Property �@��
IsSelected P� Value$
 True��6L   . �5=   2   ��  �� 
TargetName$ border��69    � ��
 �   �6d   5>   /   5@   '   5B      5C      ��5E      �� 5F      .R�5G      �  5H   "   �� 5I   &   $
��auto �67   �� 5J   &   $��* �67   .+�5L   "   �� $��0��6(   $
��20,0q�68   ��6F   �� *Name+�� 5M   "   $��1��6,   $��Center=�6<   $��Stretch=�6W   ��6u   �� *Name+5N      5O      5Q      5R      5S      5T      