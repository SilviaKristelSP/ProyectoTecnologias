   M S B A M L   `   `   `  ����D  @ClienteMD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ClienteMD.VistasClienteMD.Vistas  5   	   &     ClienteMD.Vistas.CreacionPartida   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ClienteMD.Vistas     5   	     � WindowStyle$
  None=�5   !   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��300��5   	   $	��500��6   .��5      �� -   5        ���#1B2430 �� CornerRadius$ 20��5   "   ���#51557E$��5q�6J   ._�5   
   � 
������  � RowDefinitions 5      �� 5      $��50 �6    6.   �� 5      6"   �� 5      $��50 �6    6.   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��62   .+�5      �� $��40 5 0 0q�6   $��/Imagenes/cartel.png��6*   �� 5      $��0 5 0 0q�6   $��Fuentes/#Roboto)�6-   $��50(�6J   $
��Bold"�6X    �� TextAlignment$ Center=�6j   ���	#FFD6D5A8$��Center=�6�   $��Center=�6�   Crear partida6�   �� 5      $��0 5 0 0q�6   $��/Imagenes/ojos.png��6)   5      �� 5      $��1��6   $ Vertical=�6&   .+�5      �� $��0 50 0 0q�6   $��Center=�6/   $ 
Horizontal=�6L   .+�5      �� $��0 0 0 0q�6    $��Fuentes/#Roboto)�61   $��15(�6N   $��Medium"�6\   $ Center=�6p   ���	#FFD6D5A8$��Center=�6�   $��Center=�6�   
Categoria:6�   �� 5      -   5         ��Name$ 	Categoria��5   1   $��10 0 0 0q�6   $	��150��6D   $��23��6P   	 �� DisplayMemberPath$	 NombreCategoria��6�   ��6�   �� 
 �� Path$
 
categorias�6�   5      �� 5      $��0 50 0 0q�6   $��Center=�6/   $ 
Horizontal=�6L   .+�5      �� $��0 0 0 0q�6    $��Fuentes/#Roboto)�61   $��15(�6N   $��Medium"�6\   $ Center=�6p   ���	#FFD6D5A8$��Center=�6�   $��Center=�6�   
Palabra:6�   �� 5       -   5        $ Palabra��5    1   $��10 0 0 0q�6   $	��150��6B   $��23��6N   $	 PalabraSecreta��6�   ��6Z   �� $
 palabras�6�   5!      5"      �� 5#      $ 
Horizontal=�6   $��2��62   .+�5$      �� -   5        $��10 0 0 0q�5$      $
��Left=�6+   $��Center=�6F   $��Regresar��6a   ���#D6D5A8$��14(�6�   $��Medium"�6�   ��5%      �� 5&       �� 
TargetType" ��6    .�5'      ��  �� Property � �� �� Value$ Fuentes/#Roboto)�6G   6a   �� 5(       � �� �#8167976M   �� 5)       �@�Cursor$
 Hand��67   6F    �� Triggers 5*      P� 5+   "    P� Property �@J�IsMouseOver P� Value . . �5,   &   ��  � �� �#51557E6U   5-   #   5/      ��51      �� 52       �� 
TargetType" ��6*   .R�53      �� $	��100��6%   $��25��61   $ 12��6=   #��z��6O   ._�54   "   �� $��Center=�63   $��Center=�6N   6m   55      56      58      �� 59      -   5        $��	260 0 0 0q�59      $��Right=�6,   $��Center=�6H   $��Crear partida��6c   ���#D6D5A8$��14(�6�   $��Medium"�6�   ��5:      �� 5;      " ��6    .�5<      ��  � ��$ Fuentes/#Roboto)�6G   6a   �� 5=       � �� �#8167976M   �� 5>       �@�Cursor$
 Hand��67   6F    5?      P� 5@   "    �@J�IsMouseOver . . �5A   &   ��  � �� �#51557E6U   5B   #   5D      ��5F      �� 5G      " ��6*   .R�5H      �� $	��100��6%   $��25��61   $ 12��6=   #��z��6O   ._�5I   "   �� $��Center=�63   $��Center=�6N   6m   5J      5K      5M      5N      5O      5Q      5R      