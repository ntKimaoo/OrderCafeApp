   M S B A M L   `   `   `  ����E  AProjectPrn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectPrn
ProjectPrn  5   	       ProjectPrn.w_dashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectPrn     5   	     � Title$  w_dashboard��5   	   $	��450��6   $	��800��6*    � 
ResizeMode$ CanMinimize=�66    � WindowStartupLocation$ CenterScreen=�6O   .��5	      � 
����� � � ColumnDefinitions 5
   
   �� 5      $��1 �6   6+   �� 5      $��0 �6   6+   �� 5      $��3 �6   6+    � RowDefinitions 5   
   �� 5      $��1 �6   6)   �� 5      $��1 �6   6)   �� 5      $��1 �6   6)   .+�5   
   �� $��	DASHBOARD��6   $
��70px(�6$   $��128,8,-589,-113q�64   $��2��6M   $��2��6]   �� 5   
   $��images/order.png��6   $��-10,167,-136,-289q�6*   $��2��6E   $��3��6R   �� 5   
   -   5        $��btnOrderMana��5      $��36(�6%   $��129,166,-404,-285q�63   $��2��6N   $��2��6[   .��6�   Quản lí hóa đơn6�   �� 5   
   $��images/user.png��6   $��414,300,-553,-419q�6)   $��2��6D   $��2��6Q   �� 5   
   -   5        $��btnStaffMana��5      $��36(�6%   $��549,299,-793,-418q�63   $��2��6N   $��2��6[   .��6�   Quản lí staff6�   �� 5   
   $��/images/product.png��6   $��3��6-   $��-6,303,-132,-422q�6A   $��2��6[   �� 5   
   -   5        $��btnItemMana��5      $��36(�6$   $��128,302,-403,-421q�62   $��2��6M   $��Quản lí sản phẩm��6Z   $��2��6u   6�   �� 5   
   $��/images/table.png��6   $��412,162,-548,-284q�6+   $��2��6F   $��2��6S   �� 5   
   -   5        $��
btnBanMana��5      $��36(�6#   $��548,162,-792,-281q�61   $��2��6L   $��Quản lí bàn��6Y   $��2��6o   6   �� 5   
   -   5        $��	btnLogout��5      $��36(�6"   $��606,-1,-794,-49q�60   $��Log out��6I   $��2��6[   $��3��6�   5      5       