   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Rclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfoDCourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo  e    _CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo.InfoAboutClientSelectedCar   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     dlocalRclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$,  &Информация о клиенте�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�$	��530��$	��322��.��� ���#d6d3db J� Opacity$	 0.9Q�.+���  �� Orientation$ Vertical=�.+��� $��Center=�$��Center=�$��О клиенте��$��	Helvetica)�$��24(�$��Medium"�$��	0 10 0 20q�
���   ��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Фамилия клиента��   
HelperText$ Фамилия��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *SelectedClient.SurnameClient+ �� ValidatesOnExceptions .  �� NotifyOnValidationError . 	 �� UpdateSourceTrigger$	 PropertyChanged=��� $ Имя клиента��$ Имя��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *SelectedClient.NameClient+ .  . $	 PropertyChanged=��� $% Отчество клиента��$ Отчество��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *!SelectedClient.PatronymicClient+ .  . $	 PropertyChanged=��� $ Прописка��$% Прописка клиента��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)����� *SelectedClient.Registration+ .  . $	 PropertyChanged=��� $ 
Horizontal=�.+��� $��14(�$��	Helvetica)�
���   �$��Medium"�$��
30 10 26 0q����� 
 �� StringFormat$"
 ID автомобиля: {0}�� �� Path$ SelectedClient.idCar��� -    ��Name$ 	chIsOwner��$��5��$��5 10 0 0q�$��2��$��Владелец�� � ToolTip$1 +Является ли владельцем?��
���   �$��14(�$��Medium"�$��	Helvetica)�$��Right=� d� 	IsChecked �� *SelectedClient.isOwner+(  "System.Windows.Controls.DatePicker  $! Дата обращения��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)�   SelectedDate �� *" SelectedClient.DateOfApplication+ .  . $	 PropertyChanged=�  {�.  $ Дата рождения��$��25��$��
30 5 31 25q�
���   �$��	Helvetica)� �� *SelectedClient.DateOfBirthday+ .  . $	 PropertyChanged=��� $
��Ок��$��14(�$��	Helvetica)�
���   �$
��Bold"�$	��100��$��Center=�$��Bottom=�
�������$��0 30 0 0q����� *CloseInfoAboutClientCar+