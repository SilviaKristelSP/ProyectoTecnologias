   M S B A M L   `   `   `  ����D  @ClienteMD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ClienteMD.VistasClienteMD.Vistas  5   	       ClienteMD.Vistas.Perfil   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ClienteMD.Vistas     5   	     � WindowStyle$
  None=�5   	   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   $	��450��5   	   $	��800��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� -   5        ���#1B2430 �� CornerRadius$ 20��5   "   ._�5   
   � 
������  � RowDefinitions 5      �� 5      $��70 �6    6.   �� 5      6"   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $ ��/Imagenes/lineaRelleno.png��6   $	��150��6<   $
��Left=�6H   $��25,5,0,0q�6c   �� 5      $ ��/Imagenes/lineaRelleno.png��6   $	��150��6<   $
��Left=�6H   $��0,5,0,0q�6c   �� 5      $��	20 0 20 0q�6   $��Fuentes/#Roboto)�6/   $��40(�6L   $
��Bold"�6Z    �� TextAlignment$ Center=�6l   ���	#FFD6D5A8$��Center=�6�   Perfil6�   �� 5      $ ��/Imagenes/lineaRelleno.png��6   $	��150��6<   $
��Left=�6H   $��0,5,0,0q�6c   �� 5      $ ��/Imagenes/lineaRelleno.png��6   $	��150��6<   $
��Left=�6H   $��0,5,0,0q�6c   5      � 5      $��1��6    � ColumnDefinitions 5      �� 5      6)   �� 5      6)   .+�5       �� $��0��6   $ Vertical=�6-   .+�5!      �� $��	15 10 0 0q�6    $��Fuentes/#Roboto)�63   $��20(�6P   $
��Bold"�6^   $
 Left=�6p   ���	#FFD6D5A8$��Center=�6�   Datos personales6�   �� 5"      $ 
Horizontal=�6!   .+�5#      �� $��	15 10 0 0q�6$   $��Fuentes/#Roboto)�67   $��15(�6T   $��Medium"�6b   $
 Left=�6v   ���	#FFD6D5A8$��Center=�6�   Nombre completo:6�   �� 5$      -   5        	 ��Name$	 tbNombreCompleto��5$   $   $��5 10 0 0q�6>   $��Fuentes/#Roboto)�6P   $��14(�6m   $��Normal"�6{   $
 Left=�6�   ���	#FFD6D5A8$��Center=�6�   $
��Wrap=�6�   Ejemplo nombre6�   5%      �� 5&      $��0 40 0 0q�6!   $ 
Horizontal=�63   .+�5'      �� $��	15 10 0 0q�6$   $��Fuentes/#Roboto)�67   $��15(�6T   $��Medium"�6b   $
 Left=�6v   ���	#FFD6D5A8$��Center=�6�   Correo electronico:6�   �� 5(      -   5        $	 tbCorreo��5(   $   $��5 10 0 0q�66   $��Fuentes/#Roboto)�6H   $��14(�6e   $��Normal"�6s   $
 Left=�6�   ���	#FFD6D5A8$��Center=�6�   $
��Wrap=�6�   Ejemplo correo6�   5)      �� 5*      $��0 40 0 0q�6!   $ 
Horizontal=�63   .+�5+      �� $��	15 10 0 0q�6$   $��Fuentes/#Roboto)�67   $��15(�6T   $��Medium"�6b   $
 Left=�6v   ���	#FFD6D5A8$��Center=�6�   	Telefono:6�   �� 5,      -   5        $	 
tbTelefono��5,   $   $��5 10 0 0q�68   $��Fuentes/#Roboto)�6J   $��14(�6g   $��Normal"�6u   $
 Left=�6�   ���	#FFD6D5A8$��Center=�6�   $
��Wrap=�6�   Ejemplo telefono6�   5-      �� 5.      $��0 40 0 0q�6!   $ 
Horizontal=�63   .+�5/      �� $��	15 10 0 0q�6$   $��Fuentes/#Roboto)�67   $��15(�6T   $��Medium"�6b   $
 Left=�6v   ���	#FFD6D5A8$��Center=�6�   Fecha de nacimiento:6�   �� 50      -   5        $	 tbFechaNacimiento��50   $   $��5 10 0 0q�6?   $��Fuentes/#Roboto)�6Q   $��14(�6n   $��Normal"�6|   $
 Left=�6�   ���	#FFD6D5A8$��Center=�6�   $
��Wrap=�6�   Ejemplo fecha6�   51      �� 52      $��0 40 0 0q�6!   $ 
Horizontal=�63   .+�53      �� -   5        $��Regresar��53   !   ���#D6D5A8$��14(�6I   $��Medium"�6W   $��	15 20 0 0q�6�   ��54      �� 55   "   
 �� 
TargetType"
 ��6(   .�56   &   ��  �� Property � �� �� Value$ Fuentes/#Roboto)�6O   6i   �� 57   &    � �� �#8167976U   �� 58   &    �@�Cursor$
 Hand��6?   6N    �� Triggers 59   &   P� 5:   *    P� Property �@J�IsMouseOver P� Value . . �5;   .   ��  � �� �#51557E6]   5<   +   5>   #   ��5@      �� 5A   "    �� 
TargetType" ��62   .R�5B   &   �� $	��100��6-   $��25��69   $ 12��6E   #��z��6W   ._�5C   *   �� $��Center=�6;   $��Center=�6V   6u   5D   '   5E   #   5G      �� 5H      -   5        $��Editar Perfil��5H   !   ���#D6D5A8$��14(�6N   $��Medium"�6\   $��
175 20 0 0q�6�   ��5I      �� 5J   "   "
 ��6(   .�5K   &   ��  � ��$ Fuentes/#Roboto)�6O   6i   �� 5L   &    � �� �#8167976U   �� 5M   &    �@�Cursor$
 Hand��6?   6N    5N   &   P� 5O   *    �@J�IsMouseOver . . �5P   .   ��  � �� �#51557E6]   5Q   +   5S   #   ��5U      �� 5V   "   " ��62   .R�5W   &   �� $	��100��6-   $��25��69   $ 12��6E   #��z��6W   ._�5X   *   �� $��Center=�6;   $��Center=�6V   6u   5Y   '   5Z   #   5\      5]      5^      � 5_      $��1��6   .+�5`      �� $ Vertical=�6!   .+�5a      �� $ 
Horizontal=�6%   .+�5b      �� $��
110 10 0 0q�6(   $��Fuentes/#Roboto)�6<   $��15(�6Y   $��Medium"�6g   $ Center=�6{   ���	#FFD6D5A8$��Center=�6�   Puntaje global:6�   �� 5c      -   5        $	 tbPuntajeGlobal��5c   (   $��5 10 0 0q�6A   $��Fuentes/#Roboto)�6S   $��14(�6p   $��Normal"�6~   $ Center=�6�   ���	#FFD6D5A8$��Center=�6�   $
��Wrap=�6�   Ejemplo puntaje6   5d      �� 5e      $��0 10 0 0q�6$   $��Fuentes/#Roboto)�66   $��15(�6S   $��Medium"�6a   $ Center=�6u   ���	#FFD6D5A8$��Center=�6�   Partidas ganadas:6�   � 5f      $��15q�6   .+�5g      �� $ 10��6%   $��7q�67   ���#51557E._�5h   "   &   System.Windows.Controls.DataGrid  -	   5          Name$ dgPartidasGanadas��5h   +      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6t   $	��188��6�   $	��Top=�6�      Columns 5i   &   0  *System.Windows.Controls.DataGridTextColumn  5j   *   ,  &System.Windows.Controls.DataGridColumn   Header$ Jugador vencido��6=      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6`   �� *NombreRetador+6�     5k   *   $ Fecha��6=   $ * 6L    6V   �� *Fecha+6r   5m   #   5n      5o      5p      5q      5r      5s      5t      5u      