   M S B A M L   `   `   `  ����  ProyectoBriss    ProyectoBriss.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  My App��5   	   $	��450��6   $
��1200��6%   .��5      �  J� OpacityMask �	#FFED77DE � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6   $��Right=�6"    �� Orientation$ 
Horizontal=�6>   .+�5      �� -   5         ��Name$ 
BtnAgregar��5      $��Agregar��6)   $��5q�6;   ���	#FFA0E4D96_   �� 5      -   5        $ BtnActualizar��5      $��
Actualizar��6,   $��5q�6A   ���	#FF87C5DA6h   �� 5      -   5        $ BtnEliminar��5      $��Eliminar��6*   $��5q�6=   ���	#FF6EDCCA6b   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��5q�6;   .+�5      �� -   5         ��Name$ TxtID��5   I   $	��ID:��6   $��Center=�6#   $��5q�6>   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FF6FE677��6'   � 5      $ 	#FF61ED84��6'   	 � Offset$	 1Q�69   5       5      �� 5      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5      � $ Black��6'   � 5      $ White��6'   $	 1Q�65   5      5       �� 5!      -   5        
 ��Name$
 
TxtIDValue��5!   -   $	��200��6   $��5q�6"    �	#FFE993F3���	#FFADF3A36Y   �� 5"      $��Nombre:��6   $��Center=�6'   $��5q�6B   ���	#FF6FE6776M   �� 5#      -   5        $
 	TxtNombre��5#   -   $	��200��6   $��5q�6"   ���	#FFBAF7B86@   �� 5$      $��Edad:��6   $��Center=�6%   $��5q�6@   
���   ����	#FF96D8976^   �� 5%      -   5        $
 TxtEdad��5%   -   $	��200��6   $��5q�6"   ���	#FF86ECB16>   �� 5&      $��
Teléfono:��6   $��Center=�6)   $��5q�6D   ���	#FF87ED886O   �� 5'      -   5        $
 TxtTelefono��5'   -   $	��200��6   $��5q�6"   ���	#FF86ECB16B   �� 5(      $��	Consulta:��6   $��Center=�6)   $��5q�6D   ���	#FFA6F3856O   �� 5)      -	   5        $
 TxtConsulta��5)   -   $	��200��6   $��5q�6"   ���	#FFB1F1D56B   5*      &   System.Windows.Controls.DataGrid  5,   
   -
   5          Name$ PersonasDataGrid��5,   G   $��2��6   $��5q�6       AutoGenerateColumns .     SelectionMode$ Single=�6a      SelectionUnit$ FullRow=�6x      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+  5/      $ Nombre��6%    65   �� *Nombre+  50      $
 Edad��6%    63   �� *Edad+  51      $ 	Teléfono��6%    67   �� *
Telefono+  52      $ Consulta��6%    67   �� *
Consulta+54      55      56      