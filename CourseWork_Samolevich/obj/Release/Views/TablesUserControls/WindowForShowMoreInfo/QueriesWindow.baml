   M S B A M L   `   `   `  ���� P  LCourseWork_Samolevich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Rclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfoDCourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo  X    RCourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo.QueriesWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     dlocalRclr-namespace:CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Запросы��$	��540��$	��840�����#9e66cc.���  � RowDefinitions �� $
��200* ��� $
��240* ��� $
��150* � � ColumnDefinitions �� $
��150* ��� $
��300* �.+��� $��0��$��0��$��Выбор запроса��$��10q����#7000be
����+��$	��0.8q�.����  �� SelectionMode$ Single=�$��	Helvetica)�$��14(�
����������� *QueriesCollection.Keys+ �� SelectedItem �� *SelectedQuery+�� $��0��$��1��$'��!Параметры запроса��$��10q����#7000be
����+��$	��0.8q�.���� $��0q����� *CurrentParamsUC+9� $��0��$��2��$��2��$��Stretch=�$��10 10 150 10q����#7000be
�������$
��Bold"�$��	Helvetica)� 9� 
IsExpanded . ���� *SelectedQuery+.����  �� Orientation$ Vertical=�   MaterialDesignBody#���   $��10 0 0 0q�.+���  J� Opacity$	 .68Q�
�������$��Medium"�$��16(�$��	Helvetica)�$
��Wrap=����� *SelectedQueryDescription+�� $��0��$��2��$��1��$ Vertical=�.+��� $��0��$��30��  brdHeaderTableStyle#��[ ._��� $)��#Результаты запроса��$��Center=�$	��Top=�$��0 4 0 0q�$��16(�$
��Bold"�
�������&   System.Windows.Controls.DataGrid  $��2��$��1��   AutoGenerateColumns . 	   
IsReadOnly	 . $��
10 0 10 10q�$	��320������ *ResultRequest+
 �� UpdateSourceTrigger$
 PropertyChanged=��� $ Vertical=�$��1��$��2��$	��140��$��Right=�$��Center=�$��0,10.2,4.6,10.4q�$	��109��.+��� $��Выполнить�� $  MaterialDesignRaisedAccentButton#��[ $��	Helvetica)�$��13(�$	��120��$��35��$��	0 10 0 10q�+  %MaterialDesignThemes.Wpf.RippleAssist   Feedback �	#DD000000 � ToolTip$% Выполнить запрос������ *ExecuteRequest+�� $��
Выйти��#��[ $��	Helvetica)�$��13(�$	��120��$��35��$��	0 10 0 10q� �	#DD000000$% Завершить работу������ *CloseQueriesWindow+