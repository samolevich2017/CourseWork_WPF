   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit<CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit  P    JCourseWork_Samolevich.Views.TablesUserControls.WindowForEdit.EditCarWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     \localJclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$+  %Редактирование авто�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�$	��310��$	��322��.��� ���#d6d3db J� Opacity$	 0.9Q�.+���  �� Orientation$ Vertical=�.+��� $��Center=�$��Center=�$"��Редактирование��$��	Helvetica)�$��24(�$��Medium"�$��	0 10 0 20q�
���   ��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Цвет авто��   
HelperText$ Цвет авто��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *Color+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError . 	 �� ValidatesOnExceptions	 . �� $! Гос. номер авто��$! Гос. номер авто��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *GovernmentNumber+$ PropertyChanged=� . 	 . �� $ 
Horizontal=�.+��� $��14(�$��	Helvetica)�
���   �$��Medium"�$��
30 10 26 0q�$��Center=����� 
 �� StringFormat$ 
 ID владельца: {0}�� �� Path$ SelectedCar.idOwner��� $��12(�$��26��$��26��$��	Helvetica)�
���   �$��Medium"�
�������$��Center=�+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��$��0q�$��10 0 0 0q� � ToolTip$- 'Просмотреть\Изменить������ *ShowWindowEditOwner+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountQuestionMark=�$��15��$��15��$��Center=�$��Center=�$��2 0 0 0q��� $ 
Horizontal=�$��25q�$��Center=�.+��� $��Сохранить��$��14(�$��	Helvetica)�
���   �$
��Bold"�
����������� *EditCarInTable+�� $��Отменить��$��14(�$��	Helvetica)�
���   �$
��Bold"�
�������$��25 0 0 0q����� *CloseEditCarWindow+