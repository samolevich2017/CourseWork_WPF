   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Iclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForAdd;CourseWork_Samolevich.Views.TablesUserControls.WindowForAdd  V    PCourseWork_Samolevich.Views.TablesUserControls.WindowForAdd.AddToServicessWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  UlocalIclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForAdd    � Title$  Добавление�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�$	��420��$	��322��.��� ���#d6d3db J� Opacity$	 0.9Q�.+���  �� Orientation$ Vertical=�.+��� $��Center=�$��Center=�$��Добавление��$��	Helvetica)�$��24(�$��Medium"�$��	0 10 0 20q�
���   ��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$+ %Наименование услуги��   
HelperText$: 4Введите наименование услуги��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *	TitleServ+ �� ValidatesOnExceptions .  �� NotifyOnValidationError . 	 �� UpdateSourceTrigger$	 PropertyChanged=��� $ Время работы��$, &Введите время работы��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *	WorkHours+ .  . $	 PropertyChanged=��� $ Цена услуги��$L FВведите цену за предоставление услуги��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *PriceS+ .  . $	 PropertyChanged=��� $+ %Выбор специальности��$] WВыберите специальность предоставляющую услугу��
���   �$��	Helvetica)�$��	30 0 31 0q����� *SpecialtiesCollection+
 �� SelectedItem
 �� *SelectedSpecialty+�� $��14(�$��	Helvetica)�
���   �$��Medium"�$��
30 30 86 0q�����  �� StringFormat$( "ID специальности: {0}�� �� Path$# SelectedSpecialty.idSpecialty��� $ 
Horizontal=�$��25q�$��Center=�.+��� -    ��Name$ btnAdd��$��Добавить��$��14(�$��	Helvetica)�
���   �$
��Bold"�
����������� *AddServiceIntoTable+�� -   $ 	btnCancel��$��Отменить��$��14(�$��	Helvetica)�
���   �$
��Bold"�
�������$��25 0 0 0q����� *CloseWindowAddServices+