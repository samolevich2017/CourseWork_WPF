   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseWork_SamolevichCourseWork_Samolevich  7    1CourseWork_Samolevich.Views.CheckoutCarScreenPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:CourseWork_Samolevich     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  CheckoutCarScreenPage�� � DataContext 0   *CourseWork_Samolevich.ApplicationViewModel  .��� .+��� $��50 0 0 0q�$	��520��$	��480�����#314160 J� Opacity$	 0.9Q�
�������$��1q� �� CornerRadius$ 25��._��  � ColumnDefinitions �� $	��260 ��� $	��260 � � RowDefinitions �� $��55 ��� $
��306* ��� $
��auto ��� $	��50* �.+��� $��0��$��2��$��Center=�$��Center=�$'��!Оформление заказа��$��	Helvetica)�$��24(�$��Medium"�$��	0 11 0 10q�
��������� -    ��Name$ formDataCarBorder��$��10q�$��1��$��0��
����+��$	��0.8q�$ 20�����#2d2a42._��  �� $��45 ��� $��60 ��� $��60 ��� $��60 ��� $��60 �.+��� -    ��Name$ txbCar��$��0��$��0 5 0 0q�$%��Данные атомобиля��$��18(�$��Light"�$��Center=�$��Center=�
�������$��	Helvetica)��� -    ��Name$ CarMakeTextBox��$��1��)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 
Марка��
   
HelperText$2
 ,Введите марку авто (Hyundai)��$	��200��$��25��$��0 5 0 25q�
����������� *CarMake_NewCar+ �� UpdateSourceTrigger$ PropertyChanged=��� -   $ ColorTextBox��$��2��$	 Цвет��$5
 /Введите цвет авто (Чёрный)��$	��200��$��25��$��0 5 0 25q�
����������� *Color_NewCar+$ PropertyChanged=��� -   $ YearOfManufactureTextBox��$��3��$	 Год выпуска��$:
 4Введите год выпуска авто (2015)��$	��200��$��25��$��0 5 0 25q�
����������� *YearOfM_NewCar+$ PropertyChanged=��� -   $ GovermntNumberTextBox��$��4��$	 Гос. номер��$;
 5Введите гос. номер авто (AH2323KU)��$	��200��$��25��$��0 5 0 25q�
����������� *GovernmNum_NewCar+$ PropertyChanged=��� -   $ formDataCarDefectBorder��$��10q�$��1��$��1��
����+��$	��0.8q�$ 20�����#2d2a42._��  �� $��45 ��� $	��60* ��� $��60 �.+��� -   $ 	txbDefect��$��0��$��0 5 0 0q�$ ��Неисправности��$��18(�$��Light"�$��Center=�$��Center=�
�������$��	Helvetica)��� -	    ��Name$ 	lvDefects�� �� DisplayMemberPath$ TitleDefect��
�������$��Disabled=�1  +MaterialDesignThemes.Wpf.ScrollViewerAssist   ShowSeparators .  $��1��$	��250�� �� SelectedItem �� *SelectedDefect+���� *DefectsCollection+$ PropertyChanged=�%  MaterialDesignThemes.Wpf.Badged  $��2��
������ $��0q�$��Center=�$��-5q�$��0 15 0 0q� � ToolTip$. (Кол-во неисправностей��  ControlzEx.BadgedEx   Badge �� *DefectsNewCar.Count+$ PropertyChanged=�.���� $��2�� /  +MaterialDesignFloatingActionMiniLightButton#��[  $ Добавить�����#7537b8$��0q�
������ ���� *" AddDefectToDefsCollectionThisCar+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�$��24��$��24���� $��10q�$��2��$��0��$��2��
����+��$	��0.8q�$ 20�����#2d2a42._��  �� $
��200* ��� $
��200* � �� $��35 �.+��� $��0��$��0��$+��%Общая сумма заказа : ��$��18 0 0 0q�$��16(�$��Medium"�$��Center=�
�������$��	Helvetica)��� $��1��$��0��$��0 0 18 0q�$��16(�$��Medium"�$��Center=�$��Right=�
�������$��	Helvetica)�����  �� StringFormat$ ­{0}₽�� �� Path$ TotalPriceSumOrder��� -
    ��Name$ 	btnCancel��$��0��$��3��$	��185��$��40��$��Center=�$��Center=�+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��$��	Helvetica)�$��15(����� *OpenMainScreen+.��� $��Center=� �� $��30 ��� $	��95* �.+�  $��0��$ Block=�$��24(�$��	-13 0 0 0q�$��23���� $��1��$!��Отменить заказ��$��2��$��	-15 0 0 0q��� -   $ btnNext��$��1��$��3��$	��185��$��40��$��Center=�$��Center=�$ 25��$��	Helvetica)�$��15(����� *ConfirmTheOrder+.��� $��Center=� �� $��95 ��� $	��30* �.+�  $��1��$ Approval=�$��24(�$��40 0 0 0q��� $��0��$'��!Подтвердить заказ��$��0 0 0 0q�$��2��