   M S B A M L   `   `   `  ����W  SBasketballRecreationalLeague, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:BasketballRecreationalLeague.Views"BasketballRecreationalLeague.Views  5   	   3    -BasketballRecreationalLeague.Views.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:BasketballRecreationalLeague.Views     5   	     � Title$  
MainWindow��5   	   $
��1080��6   $
��1920��6*    � WindowState$ 	Maximized=�5	   	   .��5
      � -   5         �Name$ MainWindowGrid��5
       � 	Resources 5   
    �� 
TargetType �� Property   OwnerFontFamily �� Value��%R   'x�       7   �� 5      " x�6   .�5      ��  � ��8   6/   5      5       � RowDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   �� 5      $	��250 �6   .+�5   
    � -   5        	  �Name$	 	mainFrame��5      
  � NavigationUIVisibility$
 Hidden=�6#   $��3��6C   $��2��6W   �� 5   
   $��0 0 0 1q�6   
���   �$��3��6?   �� 5   
   -   5        
������ $��0q�5   *   .��5      �� $%��../Resources/Images/BL-logo.png��6   5      �� 5   
   -   5        $��2��5      
������ $��0q�6:   $��0q�6N   ��5       �� 5!       �� 
TargetType" ��6"   .R�5"      ��  �� Orientation$ Vertical=�6!   $��Center=�68   $��Center=�6U   .+�5#      �� $"��../Resources/Images/user.png��6    $��60��6F   �� 5$      $��Center=�6k   $��0,5,0,0q�6�   ��6$   �� *UserDTO.Username+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5%      5&      5(      � 5+   
   $��1��6    5,      �� 5-      $
��4.5* �6#   �� 5.      $��* �6#   �� 5/      $��* �6#   �� 50      $��* �6#   �� 51      $��* �6#   �� 52      $��* �6#   .+�54      �� -   5        $��1��54      $��	Home Page��6%   69   �� 55      -   5        $��2��55      $��Schedule��6%   68   �� 56      -   5        $��3��56      $��Leagues��6%   67   �� 57      -   5        $��4��57      $��Teams��6%   65   �� 58      -	   5        $��5��58      $��Hall of Fame��6%   6<   59      5C      5D      