   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CourseWork_Samolevich.ViewsCourseWork_Samolevich.Views  4    .CourseWork_Samolevich.Views.CheckoutScreenPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5local)clr-namespace:CourseWork_Samolevich.Views    N� Title$  CheckoutScreenPage��.��� .+��� $��50 0 0 0q�$	��520��$	��480�����#314160 J� Opacity$	 0.9Q�
�������$��1q� �� CornerRadius$ 25��._��  � ColumnDefinitions �� $	��260 ��� $	��260 � � RowDefinitions �� $��55 ��� $
��356* ��� $	��55* �.+��� $��0��$��2��$��Center=�$��Center=�$'��!Оформление заказа��$��	Helvetica)�$��24(�$��Medium"�$��	0 11 0 10q�
��������� -    ��Name$ formDataClientBorder��$��10q�$��1��$��0��
����+��$	��0.8q�$ 20�����#2d2a42._��  �� $��45 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��50 �.+��� -    ��Name$ 	txbClient��$��0��$��0 5 0 0q�$!��Данные клиента��$��18(�$��Light"�$��Center=�$��Center=�
�������$��	Helvetica)��� -    ��Name$ SurnameTextBox��$��1��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фaмилия��	   
HelperText$2	 ,Введите фамилию (Иванов)��$	��200��$��25��$��0 5 0 25q�
����������� *SurnameNewClient+
 �� UpdateSourceTrigger$
 PropertyChanged=��� -   $ NameTextBox��$��2��$ Имя��$&	  Введите имя (Иван)��$	��200��$��25��$��0 5 0 25q�
����������� *NameNewClient+$
 PropertyChanged=��� -   $ PatronymicTextBox��$��3��$ Отчество��$8	 2Введите отчество (Иванович)��$	��200��$��25��$��0 5 0 25q�
����������� *PatronymicNewClient+$
 PropertyChanged=��� -   $ RegistrationTextBox��$��4��$ Прописка��$5	 /Введите данные о прописке��$	��200��$��25��$��0 5 0 25q�
������� � ToolTip$_ Y(пример) г. Сорочинск, ул. Волоколамский пер, дом 67������ *RegistrationNewClient+$
 PropertyChanged=�(  "System.Windows.Controls.DatePicker  -   $��dpDateOfBirthday��$��5��$��0 0 80 0q�$	��120��$ Дата рождения��$	 Дата рождения�����#5f6ef5$��	Helvetica)�   SelectedDate �� *DateOfBirthday_NewClient+$
 PropertyChanged=��� -    ��Name$ 	chIsOwner��$��5��$��
150 10 0 0q�$��Владелец��$8 2Являетесь ли вы владельцем?��
�������$��	Helvetica)� d� 	IsChecked �� *NewClient_isOwner+$
 PropertyChanged=��� -	   $ formDataOwnerBorder��$��10 10 15 10q�$��1��$��1��
����+��$	��0.8q�$ 20�����#2d2a42 �� *ToolTipForOwnerFieldset+$
 PropertyChanged=�._�� {��� *EnableOwnerFieldset+$
 PropertyChanged=� �� $��45 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��50 �.+��� -
   $ txbOwner��$��0��$��0 5 0 0q�$%��Данные владельца��$��18(�$��Light"�$��Center=�$��Center=�
�������$��	Helvetica)��� -   $ SurnameTextBoxOwn��$��1��$ Фaмилия��$2	 ,Введите фамилию (Иванов)��$	��200��$��25��$��0 5 0 25q�
����������� *SurnameNewOwner+$
 PropertyChanged=��� -   $ NameTextBoxOwn��$��2��$ Имя��$&	  Введите имя (Иван)��$	��200��$��25��$��0 5 0 25q�
����������� *NameNewOwner+$
 PropertyChanged=��� -   $ PatronymicTextBoxOwn��$��3��$ Отчество��$8	 2Введите отчество (Иванович)��$	��200��$��25��$��0 5 0 25q�
����������� *PatronymicNewOwner+$
 PropertyChanged=��� -   $ RegistrationTextBoxOwn��$��4��$ Прописка��$5	 /Введите данные о прописке��$	��200��$��25��$��0 5 0 25q�
�������$_ Y(пример) г. Сорочинск, ул. Волоколамский пер, дом 67������ *RegistrationNewOwner+$
 PropertyChanged=�  -   $��dpDateOfBirthdayOwn��$��5��$��0 0 80 0q�$	��120��$ Дата рождения��$	 Дата рождения�����#5f6ef5$��	Helvetica)� �� *DateOfBirthday_NewOwner+$
 PropertyChanged=��� -    ��Name$ 	btnCancel��$��0��$��2��$	��160��$��45��$��Center=�$��Center=�+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��$��	Helvetica)�$��15(����� *OpenMainScreen+.��� $��Center=� �� $	��30* ��� $��70 �.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��0��   Kind$ ArrowLeftThick=�$��24(�$��0 0 40 0q��� $��Отмена��$��35 0 0 0q�$��2���� -   $ btnNext��$��1��$��2��$	��160��$��45��$��Center=�$��Center=�$ 25��$��	Helvetica)�$��15(����� *OpenCheckoutCarScreen+.��� $��Center=� �� $��70 ��� $	��30* �.+�  $��1��$ ArrowRightThick=�$��24(�$��40 0 0 0q��� $��0��$��
Далее��$��43 0 0 0q�$��2��