   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseWork_SamolevichCourseWork_Samolevich  5    /CourseWork_Samolevich.Views.SelectDefectsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  /local#clr-namespace:CourseWork_Samolevich    � Title$-  'Выбор неисправностей�� � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ NoResize=�$	��450��$	��920�� � WindowStartupLocation$ CenterOwner=� � DataContext 0   *CourseWork_Samolevich.ApplicationViewModel  .��� ��
� .���  � Color$ 	#FF8131B7�� � Offset$ 0Q�� $ 	#FF491C68��$ 1Q� � RowDefinitions �� $��45 ��� $	��250 ��� $	��50* � � ColumnDefinitions �� $	��250 ��� $	��300 ��� $
��300* �.+��� -   	 ��Name$	 spHeaderPage��$��0��$��3��   spHeaderStyle#���   .+��� $-��'Выбор неисправностей��$��Center=�
 � ToolTip$[
 UВы находитесь на экране выбора неисправностей��$��0 5 0 0q�$��Center=�$��22(�$
��Bold"�
��������� $��1��$	��240��$��0��
���   �$��1q� �� CornerRadius$ 15��$��5 10 5 0q�._���  �� Orientation$ Vertical=�.+��� $��Фильтр��$��Center=�$J
 DЗдесь вы можете настроить фильтрацию��$��0 5 0 0q�$��Center=�$��16(�$
��Bold"�
������ 
��������� $ 
Horizontal=�.+��� $��Категория :��$��	20 10 5 0q�$��Center=�$��14(�$��	Helvetica)�
��������� $��10 5 0 8q�$
��Left=�$��	Helvetica)�-  'MaterialDesignThemes.Wpf.ComboBoxAssist   ClassicMode ��  �� ElementName$ ClassicModeCheckBox�� �� Path$ 	IsChecked�.@���  �� 
IsSelected . .��Двигатель�� .��Ходовая�� .��Электроника�� .��Подвеска��  + 'MaterialDesignFloatingActionLightButton#��[ $
 Применить��$��
0 100 0 15q�.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Approval=�$��24��$��24��&   System.Windows.Controls.DataGrid  $��1��$��1��$	��280��
������ $��0 8 0 0q�   CanUserSortColumns .    CanUserAddRows .  -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 4 2 2 2q�   ColumnHeaderPadding$ 4 2 2 2q����� *	Clients+   Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn   - )MaterialDesignDataGridCheckBoxColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  4 0MaterialDesignDataGridCheckBoxColumnEditingStyle   EditingElementStyle# [    Binding �� *
IsSelected+,  &System.Windows.Controls.DataGridColumn   Header �� 
������  �� Padding$ 6 0 6 0q�$��Center=�._��� $��Center=� ��  �� RelativeSource ��  �� AncestorType"  $ DataContext� d� 	IsChecked �� *IsAllItems3Selected+0	  *System.Windows.Controls.DataGridTextColumn	  $ ID��   Width5
  /System.Windows.Controls.DataGridLengthConverter$ 60
     CanUserResize  .  ! 	  FontSize$! 14Q�"   
IsReadOnly" . # 	  
Foreground
# ����� �� *
idClient+	  $  Неисправность��  . $! 14Q�" . 
# ����� �� *
NameClient+  $��1��$��2��$	��325��
������ $��0 10 0 0q� .  .  $ 4 2 2 2q�$ 4 2 2 2q����� *	TestCol+ 	  $ ID��$ 60
   .  $! 14Q�" . 
# �����	  $ Услуга��$	 200
   . $! 14Q�" . 
# �����	  $ Цена��  . $! 14Q�" . 
# ������� $��2��$��0��$��2��
���   �$��1q�$ 20��$��5q�._��  �� $
��180* ��� $
��180* ��� $	��180 � �� $��30 ��� $��25 ��� $��25 ��� $��25 �.+��� $ 
Horizontal=�$��0��$��0��$��3��$��Center=�$��Center=�.+��� $8��2Анализ формируемого заказа��$��Center=�$J
 DЗдесь вы можете настроить фильтрацию��$��Center=�$��16(�$
��Bold"�
��������� $/��)Всего неисправностей :��$��0��$��2��$��1��$��16(�
�������$��	Helvetica)�$��20 0 0 0q�$��Center=��� $��X шт.��$��1��$��1��$��16(�
�������$��	Helvetica)�$��Right=�$��Center=��� $/��)Задействованно услуг :��$��0��$��2��$��2��$��16(�
�������$��	Helvetica)�$��20 0 0 0q�$��Center=��� $��X шт.��$��1��$��2��$��16(�
�������$��	Helvetica)�$��Right=�$��Center=��� $*��$Общая сумма заказа :��$��0��$��2��$��3��$��16(�
�������$��	Helvetica)�$��20 0 0 0q�$��Center=��� $��XXX руб.��$��1��$��3��$��16(�
�������$��	Helvetica)�$��Right=�$��Center=��� -   $ ��Name$$ btnSeenSelectedDefects��$��2��$��1��$��22��$	��110��.��� $��Center=� �� $��30 ��� $	��80* �.+�  $��1��$	 Eye=�$��9(�$��	45 0 -9 0q�$��13��$��17���� $��0��$��Просмотреть��$��2��$��0 0 10 0q�$��11(��� -   $$ btnSeenSelectedService��$��2��$��2��$��22��$	��110��.��� $��Center=� �� $��30 ��� $	��80* �.+�  $��1��$	 Eye=�$��9(�$��	45 0 -9 0q�$��13��$��17���� $��0��$��Просмотреть��$��2��$��0 0 10 0q�$��11(��� -   $$ 	btnCancel��$��2��$��2��$	��130��$��Отменить��+  %MaterialDesignThemes.Wpf.ButtonAssist%   CornerRadius$% 20��$��	Helvetica)�$��15(�$��Bottom=�$��Right=�$��10 10 200 10q��� -   $$ 	btnAccess��$��2��$��2��$	��130��$��Подтвердить��$% 20��$��	Helvetica)�$��15(�$��Bottom=�$��Right=�$��10 10 35 10q�