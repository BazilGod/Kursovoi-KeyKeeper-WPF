   M S B A M L   `   `   `  ����D  @KeyKeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:KeyKeeper	KeyKeeper  5   	   !    KeyKeeper.AccountListWindow   5   	   DmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:KeyKeeper     5   	     � Title$  AccountListWindow��5	   	   $��407.756��6#   $��665.706��64   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� -   5        $��NoAccountsTextField��5      $��Center=�6/   $��16(�6L   $��	Agency FB)�6Z   $��Center=�6q   No saved accounts6�   �� 5   
   -   5        $��accountListView��5   '   $y�Hidden=�6   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 �����64   �� 5       � ��$ 0,0,0,1q�68   5      ��5      �� 5      .R�5      � $��5q�6    $��30��6+   .+�5      �� $��accountTitle��65   $��0,0,0,0q�6$   
���   �$��	Agency FB)�6s   $��16(�6�   $	��150��6�   $��25��6�   ��6I   �� *title+6�   �� 5      -   5        ���#e04a32
�������$��0q�5   b   $��	Agency FB)�6v   $��16(�6�   $��60��6�   $��25��6�   .��6�   Edit6�   �� 5      -   5        ���#e04a32
�������$��0q�5   d   $��	Agency FB)�6x   $��16(�6�   $��60��6�   $��25��6�   $��5 0 0 0q�6�   .��6�   Delete6�   5       5!      5#      �� 5$   
   -   5        $��1��5$   0   $��18(�6=   ���#e04a32
�������$��0q�6s   .��6�   +6�   5%      5&      