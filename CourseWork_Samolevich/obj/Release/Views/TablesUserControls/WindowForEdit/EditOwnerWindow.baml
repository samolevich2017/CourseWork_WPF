   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit<CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit  R    LCourseWork_Samolevich.Views.TablesUserControls.WindowForEdit.EditOwnerWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     \localJclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$5  /Редактирование владельца�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�$	��510��$	��322��.��� ���#d6d3db J� Opacity$	 0.9Q�.+���  �� Orientation$ Vertical=�.+��� $��Center=�$��Center=�$"��Редактирование��$��	Helvetica)�$��24(�$��Medium"�$��	0 10 0 20q�
���   ��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Фамилия владельца��   
HelperText$' !Фамилия владельца��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *SurnameOwner+ �� ValidatesOnExceptions .  �� NotifyOnValidationError . 	 �� UpdateSourceTrigger$	 PropertyChanged=��� $ Имя владельца��$ Имя владельца��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *	NameOwner+ .  . $	 PropertyChanged=��� $) #Отчество владельца��$) #Отчество владельца��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *PatronymicOwner+ .  . $	 PropertyChanged=��� $ Прописка��$) #Прописка владельца��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *RegistrationOwner+ .  . $	 PropertyChanged=�(  "System.Windows.Controls.DatePicker  $! Дата обращения��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)�
   SelectedDate
 �� *DateOfApplication_Owner+ .  . $	 PropertyChanged=�  {�.  $Q KДата рождения (редактирование запрещено)��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)�
 �� *SelectedOwner.DateOfBirthday+ .  . $	 PropertyChanged=��� $ 
Horizontal=�$��25q�$��Center=�.+��� $��Сохранить��$��14(�$��	Helvetica)�
���   �$
��Bold"�
����������� *EditOwnerInTable+�� $��Отменить��$��14(�$��	Helvetica)�
���   �$
��Bold"�
�������$��25 0 0 0q����� *CloseWindowEditOwner+