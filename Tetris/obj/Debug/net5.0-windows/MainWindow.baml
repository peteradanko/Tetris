   M S B A M L   `   `   `  ����A  =Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TetrisTetris  5   	       Tetris.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Tetris     5   	   -   5          � Title$  Tetris��5   	   $	��600��6   $	��800��6%   $	��600��5	   	   $	��600��6   
�������$��28(�6;   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   ��5   
   �� 5       �� ImageSource$ Images/BackGround.png��6   .+�5   
   (� $��1��6   $��1��6   $��0,0,0,20q�6/   .��5      �� -   5         ��Name$ 
GameCanvas��5      ���#101010$	��250��5      $	��500��5      $
}�True��5       5!      5"      �� 5$   
   -   5         ��Name$ 	ScoreText��5$      $��0��5%      $��1��5&      $��Score: ��5'      $
��0,10q�5(       �� TextAlignment$ Center=�5)      �� 5+   
   $��1��6   $��0��5,      $��Center=�5-      $��Right=�5.      .+�5/      �� $
��Hold��6   $ Center=�6$   
���   �6;   �� 50      -   5         ��Name$ 	HoldImage��50      $��20q�51      $	��125��52      53      �� 55   
   $��1��6   $��2��56      $��Center=�57      $
��Left=�58      .+�59      �� $
��Next��6   $ Center=�6$   
���   �6;   �� 5:      -   5        $ 	NextImage��5:      $��20q�5;      $	��125��5<      5=      � 5?   
   -   5         �Name$ GameOverMenu��5?      ���	#CC000000$��2��5A      $��3��5B      $y�Hidden=�5C      .+�5D      �� $��Center=�6   $��Center=�66   .+�5E      �� $��GameOver��6   $��Center=�6,   $��Center=�6I   �� 5F      -   5        $ 
FinalScore��5F      $��Score: ��60   $ Center=�6?   � 5G      $	��100��6   �� 5H      -   5        $��
Play Again��5H      
����ح�$��0,20,0,0q�5J      $��5q�5K      5L      5M      6   5N      5O      