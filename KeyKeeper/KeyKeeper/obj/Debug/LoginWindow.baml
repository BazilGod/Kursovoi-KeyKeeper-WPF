   M S B A M L   `   `   `  ����D  @KeyKeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:KeyKeeper	KeyKeeper  5   	       KeyKeeper.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:KeyKeeper     5   	     � Title$  LoginWindow��5	   	   $	��628��6   $	��628��6*    � 
ResizeMode$ NoResize=�5
   	   ��5      �� 5   
    �� ImageSource$ Resources/Fon.jpg��6    j� Stretch$ UniformToFill=�65    j� TileMode$
 None=�6M   .��5      �� .+�5   
   � $��Center=�6   $��181,430,112,0q�6,   $	��191��6C   $	��327��6P    � 	Resources 5       �� 
TargetType �� Property �� Value��%R   '��       �� 5      " ��6   .�5      ��  � ��$ 16(�61   5      5      	 � RowDefinitions	 5      �� 5      $��30 �6    �� 5      $��30 �6    �� 5      $��30 �6    
 � ColumnDefinitions
 5      �� 5      $	��141 �6#   �� 5      $	��155 �6#   .+�5      �� 
�������$��Right=�6+    �� Padding$ 0 0 10 0q�6G   $��	Agency FB)�6Z   $��16(�6q   $��0,6,0,25q�6   $��2��6�   $��92��6�   �� 6�   $�
User Name:��6�   6�   �� 5       -   5         ��Name$ usernameTextBox��5       $��0q�6/   $��5 3 5 0q�6C   $��
10,6,-16,0q�6U   $��1��6i   �� 5!      $��1��6   
�������$��Right=�68   $ 0 0 10 0q�6T   $��	Agency FB)�6g   $��16(�6~   $��0,0,10,0q�6�    J� RenderTransformOrigin$ 0.295,-0.764&�6�   $��80��6�   �� 6�   $�	Password:��6�   6�   G� 5"      -   5         G�Name$ passwordBox��5"      $��1��6/   $��0q�6<   $��5 3 5 0q�6P   $��
10,8,-16,0q�6b   $��1��6v   �� 5#      -   5        $��2��5#   ,   ���#e04a32
�������$��0q�6a   $��	Agency FB)�6u   $��16(�6�   $��8,19,-26,-24q�6�   $��Login��6�   $��1��6�   �� 5$      -   5        ���#e04a32
�������$��0q�5$   W   $��	Agency FB)�6k   $��16(�6�   $��0,19,21,-20q�6�   $��Register��6�   $��Right=�6�   $	��111��6�   $��2��6�   5%      5)      5*      