   M S B A M L   `   `   `  ����I  EVolkov_HW_11_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Volkov_HW_11_1Volkov_HW_11_1  5   	       Volkov_HW_11_1.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Volkov_HW_11_1     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��600��6,   $	��350��6;   $	��600��6H   
���iii� � 	Resources 5	      (   "Volkov_HW_11_1.MainWindowViewModel 
  person  ButtTemplate �� 
TargetType �� CornerRadius �� StrokeDashArray �� Triggers P� Property P� Value �� 
TargetName	 �� Property
 �� Value  TextBoxTemplate ��Name �� RelativeSource �� Path  ListBoxStyle��%w  &	        &	      &	 0    &	 9      5
   
   6$   �� 5   
   " ��6/   .R�5      �� $��Border��6Y   
�������$ 5��62   
�������$��5q�6g   ._�5      � .+�5      �� $y�Hidden=�6    
���   �$��1��6C   $	 1 2R�6W   �� 5      $
��True��6'   #��z��6B   $��Center=�6e   $��Center=�6�   5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      �� $ Border��6   	 � ��

 �����6V   5      P� 5       � {�$ False��60   . �5      �� $ Border��6   	 � ��

 �����6G   5      5      �� 5   
   " ��62   .R�5      �� $ Border��6   
�������$ 6��67   $��1q�6H   
�������$��5q�6t   ._�5      � .+�5      �� $y�Hidden=�6    
���   �$��1��6C   $	 1 2R�6W   �� 5      .��5       �� 
������ 
�������$��0q�6�   $��Center=�6�   ��6"   ��  �� *TemplatedParent+$
 Text�6�   5!      5"      5#       5$      P� 5%       �@J�IsMouseOver$
 True��61   . �5&      �� $ Border��6   	 � ��

 �iii�6Y   5'      5)      �� 5*   
   " ��6/   .R�5+      �� $ Border��6   
�������$ 6��67   $��1q�6H   
�������$��5q�6t   ._�5,      � .+�5-      �� $y�Hidden=�6    
���   �$��1��6C   $	 1 2R�6W   �� 5.      .��5/      �� 50      51      52      53      54      .��55      �  � DataContext# [  6    � ColumnDefinitions 56   
   �� 57      �� 58      $
��0.5* �6   .+�5:   
   �� -   5         ��Name$ Listbox1��5:      #��[ 6D   $��Disabled=�6m   ��6$   �� *	Persons+ �� SelectedItem 6�   �� *SelectedPerson+ �� Mode$ TwoWay=���5;      �� 5<       �� 
TargetType" ��6   .�5=      �� 	 � ��$
 Stretch=�6C   5>      ��5@      �� 5A      .R�5B      �� 
���iii�$��1q�63   $��5q�6G   $ 5��6R   ._�5C      �� .+�5D      �� $��15(�6B   
���������6(   �� *
FullName+6P   �� 5E      $��15(�6A   
���������6(   �� *	Address+6O   �� 5F      $��15(�6?   
���������6(   �� *Phone+6M   5G      5H      5I      ��5K      �� 5L      .R�5M      �� 5N      5P      � 5Q   
   $��1��6    � RowDefinitions 5R      �� 5S      �� 5T      �� 5U      �� 5V      �� 5W      �� 5X      �� 5Y      �� 5Z      .+�5\      �� #��[ 6`   ��6   �� *InformationFullName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5]      $��1��6   #��[ 6l   ��6#   �� *InformationAddress+$ PropertyChanged=�6�   �� 5^      $��2��6   #��[ 6j   ��6#   �� *InformationPhone+$ PropertyChanged=�6�   �� 5_      $��3��6   #��[ 6A   ��6"   �� *
AddCommand+.��6j   Добавить6t   �� 5`      $��4��6   #��[ 6B   ��6"   �� *EditCommand+.��6k   Редактировать6z   �� 5a      $��5��6   #��[ 6D   ��6"   �� *DeleteCommand+.��6m   Удалить6v   �� 5b      $��6��6   #��[ 6F   ��6"   �� *SaveJsonCommand+.��6o   Сохранить6z   �� 5c      $��7��6   #��[ 6F   ��6"   �� *LoadJsonCommand+.��6o   Загрузить6z   5d      5e      5f      