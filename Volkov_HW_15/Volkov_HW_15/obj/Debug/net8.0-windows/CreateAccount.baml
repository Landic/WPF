   M S B A M L   `   `   `  ����G  CVolkov_HW_15, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Volkov_HW_15Volkov_HW_15  5   	        Volkov_HW_15.CreateAccount   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Volkov_HW_15     5   	     � Title$  CreateAccount��5   	   $	��230��6   $	��300��6/   $	��230��6>   $	��300��6K   
���iii� � Icon$ galleryIco.png��6l    � 	Resources 5	      (   "Volkov_HW_15.RegistrationViewModel   registrationviewmodel  ButtTemplate �� 
TargetType �� CornerRadius �� StrokeDashArray �� Triggers P� Property P� Value	 �� 
TargetName
 �� Property �� Value  TextBoxTemplate ��Name �� RelativeSource �� Path��%W  &	        &	      &	 0      5
   
   6&   �� 5   
   " ��6/   .R�5      �� $��Border��6Y   
�������$ 5��62   
�������$��5q�6g   ._�5      � .+�5      �� $y�Hidden=�6    
���   �$��1��6C   $	 1 2R�6W   �� 5      $
��True��6'   #��z��6B   $��Center=�6e   $��Center=�6�   5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      �� $	 Border��6   
 � ��
 �����6V   5      P� 5       � {�$ False��60   . �5      �� $	 Border��6   
 � ��
 �����6G   5      5      �� 5   
   " ��62   .R�5      �� $ Border��6   
�������$ 6��67   $��1q�6H   
�������$��5q�6t   ._�5      � .+�5      �� $y�Hidden=�6    
���   �$��1��6C   $	 1 2R�6W   �� 5      .��5       �� 
������ 
�������$��0q�6�   $��Center=�6�   ��6"   ��  �� *TemplatedParent+$
 Text�6�   5!      5"      5#       5$      P� 5%       �@J�IsMouseOver$
 True��61   . �5&      �� $	 Border��6   
 � ��
 �iii�6Y   5'      5)      5*      .��5+      �  � DataContext# [  6    � ColumnDefinitions 5,   
   �� 5-      $
��0.4* �6   �� 5.       � RowDefinitions 50   
   �� 51      $
��0.3* �6   �� 52      $
��0.3* �6   �� 53      $
��0.3* �6   �� 54      $
��0.3* �6   �� 55      $
��0.3* �6   .+�57   
   �� $��Регистрация��6   $��2��6&   
�������$��Center=�6N   $��Center=�6k   �� 58   
   $��1��6   $��
Логин��6   
�������$��Center=�6@   $��Center=�6]   �� 59   
   $��1��6)   $��1��66   #��[ 6F   ��6   �� *Login+6F   �� 5:   
   $��2��6   $��Пароль��6   
�������$��Center=�6A   $��Center=�6^   �� 5;   
   $��2��6,   $��1��69   #��[ 6I   ��6   �� *
Password+6I   �� 5<   
   $��3��6   $��Повторите��6   
�������$��Center=�6D   $��Center=�6a   �� 5=   
   $��3��62   $��1��6?   #��[ 6O   ��6   �� *RepeatPassword+6O   � 5>   
   $��4��6   $��2��6    5?      �� 5@      �� 5A      .+�5C      �� $"��Авторизоваться��6   #��[ 6M   ��6.   �� *
OpenSignIn+6M   �� 5D      $*��$Зарегестрироваться��6   $��1��6Z   #��[ 6j   ��62   �� *RegistrationCommand+6j   5E      5F      5G      