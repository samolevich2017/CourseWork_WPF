   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseWork_SamolevichCourseWork_Samolevich  &     CourseWork_Samolevich.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  /local#clr-namespace:CourseWork_Samolevich  -     �Name$  WindM�� � Title$3 -Станция техобслуживания�� � WindowStyle$ ThreeDBorderWindow=�$	��640��$
��1068�� � 
ResizeMode$ CanMinimize=� � Icon$ icons/iconBrand.ico��   WindowStyle#���    � DataContext 0   *CourseWork_Samolevich.ApplicationViewModel   � Triggers :�  :� RoutedEvent$ ButtonBase.Click�� :� 
SourceName$ buttonOpenMenu��.[���   MenuOpen#��[ :� $ ButtonBase.Click��$ buttonCloseMenu��.[���   	MenuClose#��[ :� $ Window.Loaded��$ WindM��.[���   
OpenWindow#��[ .��� 	 � ColumnDefinitions	 �� $
��auto ��� $��* �.+� � $��1��
  � NavigationUIVisibility$
 Hidden=����� *CurrentPage+� -    �Name$ SlideMenuGrid��$��0��$��2��$��60��$	��185��$
��Left=�
���   �.+��� .+�� -   $ gridBtnMenu��$	��150��
���   �.+��� -    ��Name$ buttonCloseMenu��$��60��$��60��$	��Top=�$��Right=�$y�	Collapsed=���Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  
�������   Kind$ 	ArrowLeft=�$��30��$��30���� -   $ buttonOpenMenu��$��60��$��60��$	��Top=�$
��Left=���Z� ��Z� .��  
�������$
 Menu=�$��30��$��30���� $��Disabled=�$��0 50 0 0q�.+��� -   $ btnMainScreen��$��60�� � Cursor$
 Hand��
������ $��0q����� *OpenMainScreen+.��� 	 �� $��50 ��� $	��130 �.+�  $��0��$
 Home=�$��25��$��25��$��4 0 20 0q�$
��Left=� ^� ToolTip _� -    _�Name$ toolTipMenu��$��Главный экран�� _� 	Placement$ RelativePoint=� _� HorizontalOffset$ 40�� _� VerticalOffset$ -4���� $��1��$��Главная��$��Center=�$��16(��� $��60��$
 Hand��
������ $��0q����� *OpenAuthorizationScreen+.��� 	 �� $��50 ��� $	��130 �.+�  $��0��$ 
Assessment=�$��25��$��25��$��4 0 20 0q�$
��Left=� _� $ ��Диспетчерская��$ RelativePoint=�$ 40��$ -4���� $��1��$��Управление��$��Center=�$��16(��� -    ��Name$ spListOrder�� �� Orientation$ Vertical=�$��59��$��59��$	��180�� :� $ 
MouseEnter��.[��� .���� .��W�  �� TargetProperty$ Height� �� 
TargetName$ spListOrder�� g� Duration$ 0:0:0.3D� W� From ��  �� ElementName$ spListOrder�� �� Path$ ActualHeight�	 W� To �� $ spListOrder��$ 	MaxHeight�:� $ 
MouseLeave��.[��� .���� .��W� $ Height�$ spListOrder��$ 0:0:0.15D� �� $ spListOrder��$ ActualHeight� �� $ spListOrder��$ 	MinHeight�.+��� -	   $ btnOrder��$��60��$
 Hand��
������ $��0q�.��� 	 �� $��50 ��� $	��130 �.+�  $��0��$ 
Assignment=�$��25��$��25��$��4 0 20 0q�$
��Left=� _� $��
Заказ��$ RelativePoint=�$ 40��$ -4���� $��1��$��
Заказ��$��Center=�$��16(��� $��60��$
 Hand�����#383838$��0q�
������ ���� *OpenCheckoutScreen+.��� 	 �� $��50 ��� $	��130 �.+�  $��0��$ AssignmentReturnedOutline=�$��25��$��25��$��4 0 20 0q�$
��Left=� _� $��Отдать авто��$ RelativePoint=�$ 40��$ -4���� $��1��$��Оформить��$��Center=�$��16(��� $��60��$
 Hand�����#383838$��0q�
������ ���� *OpenPickUpOrderScreen+.��� 	 �� $��50 ��� $	��130 �.+�  $��0��$ AssignmentTurnedIn=�$��25��$��25��$��4 0 20 0q�$
��Left=� _� $��Забрать авто��$ RelativePoint=�$ 40��$ -4���� $��1��$��Забрать��$��Center=�$��16(��� $��60��$
 Hand��
������ $��0q�.��� 	 �� $��50 ��� $	��125 �.+�  $��0��$
 Help=�$��25��$��25��$��4 0 15 0q�$
��Left=� _� $��О программе��$ RelativePoint=�$ 40��$ -4���� $��1��$��О программе��$��Center=�$��16(��� -
   $ btnExit��$��60��$
 Hand��
������ $��0q�.��� 	 �� $��50 ��� $	��130 �.+�  $��0��$ Logout=�$��25��$��25��$��4 0 20 0q�$
��Left=� _� $%��Завершить работу��$ RelativePoint=�$ 40��$ -4���� $��1��$��
Выход��$��Center=�$��16(�