   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit<CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit  U    OCourseWork_Samolevich.Views.TablesUserControls.WindowForEdit.EditEmployeeWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     \localJclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$7  1Редактирование сотрудника�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�$	��530��$	��322��.��� ���#d6d3db J� Opacity$	 0.9Q�.+���  �� Orientation$ Vertical=�.+��� $��Center=�$��Center=�$"��Редактирование��$��	Helvetica)�$��24(�$��Medium"�$��	0 10 0 20q�
���   ��� {�.  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$) #Фамилия сотрудника��   
HelperText$[ UФамилия сотрудника (редактирование запрещено)��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *	Surname+ �� ValidatesOnExceptions .  �� NotifyOnValidationError . 	 �� UpdateSourceTrigger$	 PropertyChanged=��� {�.  $! Имя сотрудника��$S MИмя сотрудника (редактирование запрещено)��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *Name+ .  . $	 PropertyChanged=��� {�.  $+ %Отчество сотрудника��$] WОтчество сотрудника (редактирование запрещено)��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *
Patronymic+ .  . $	 PropertyChanged=��� $@ :Выбор специальности сотрудника��$F @Выберите специальность сотрудника��
���   �$��	Helvetica)�$��	30 0 31 0q����� *SpecialtiesCollection+
 �� SelectedItem
 �� *SelectedSpecialty+�� $��14(�$��	Helvetica)�
���   �$��Medium"�$��
30 30 86 0q�����  �� StringFormat$( "ID специальности: {0}�� �� Path$# SelectedSpecialty.idSpecialty��� $' !Разряд сотрудника��$6 0Введите разряд сотрудника��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *Rank+ .  . $	 PropertyChanged=��� $# Стаж сотрудника��$2 ,Введите стаж сотрудника��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *Exp+ .  . $	 PropertyChanged=��� $��14(�$��	Helvetica)�
���   �$��Medium"�$��	30 0 86 0q����� $ Уволен: {0}��$ DissmisedEmp��� $ 
Horizontal=�$��25q�$��Center=�.+��� $��Сохранить��$��14(�$��	Helvetica)�
���   �$
��Bold"�
����������� *EditEmployeeIntoTable+�� $��Отменить��$��14(�$��	Helvetica)�
���   �$
��Bold"�
�������$��25 0 0 0q����� *CloseEditEmployeeWindow+