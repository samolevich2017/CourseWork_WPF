using CourseWork_Samolevich.Services.Interfaces;
using CourseWork_Samolevich.Views;
using CourseWork_Samolevich.Views.TablesUserControls;
using CourseWork_Samolevich.Views.TablesUserControls.WindowForAdd;
using CourseWork_Samolevich.Views.TablesUserControls.WindowForEdit;
using CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork_Samolevich.Services {

    // Класс-сервис, реализующий методы для работы с окнами
    class WindowShowService: IWindowShow {

        // Показать диалог с сообщением
        public void ShowInfoMessage(string message) =>
            MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

        // Показать диалог с ошибкой
        public void ShowErrorMessage(string message) =>
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        // Показать диалог с подтверждением действия 
        public MessageBoxResult ShowConfirmationMessage(string message) => 
            MessageBox.Show(message, "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);


        // Открыть диалоговое окно для выбора неисправностей
        Window _selectDefectsWindow;
        public void ShowSelectDefectsWindow() {
            _selectDefectsWindow = new SelectDefectsWindow();
            _selectDefectsWindow.ShowDialog();
        } // ShowSelectDefectsWindow

        // Открыть диалоговое окно для добавления неисправности в диспетчерскую
        Window _addDefectWindow;
        public void ShowAddDefectWindow() {
            _addDefectWindow = new AddToDefectWindow();
            _addDefectWindow.ShowDialog();
        } // ShowAddDefectWindow

        // Закрыть диалоговое окно для добавления неисправности в диспетчерскую
        public void CloseAddDefectWindow() =>
            _addDefectWindow.Close();

        // Открыть диалоговое окно для добавления услуги в диспетчерскую
        Window _addServicesWindow;
        public void ShowAddServicesWindow() {
            _addServicesWindow = new AddToServicessWindow();
            _addServicesWindow.ShowDialog();
        } // ShowAddServicesWindow

        // Закрыть диалоговое окно для добавления услуги в диспетчерскую
        public void CloseAddServicesWindow() =>
            _addServicesWindow.Close();

        // Открыть диалоговое окно для добавления сотрудника в диспетчерскую
        Window _addEmployeeWindow;
        public void ShowAddEmployeeWindow() {
            _addEmployeeWindow = new AddToEmployeeWindow();
            _addEmployeeWindow.ShowDialog();
        } // ShowAddEmployeeWindow

        // Закрыть диалоговое окно для добавления сотрудника в диспетчерскую
        public void CloseAddEmployeeWindow() =>
            _addEmployeeWindow.Close();

        // Открыть диалоговое окно для редактирования записи о клиенте
        Window _editClientWindow;
        public void ShowEditClientWindow() {
            _editClientWindow = new EditClientWindow();
            _editClientWindow.ShowDialog();
        } // ShowEditClientWindow

        // Закрыть диалоговое окно для редактирования записи о клиенте
        public void CloseEditClientWindow() =>
            _editClientWindow.Close();

        // Открыть диалоговое окно для редактирования записи о владельце
        Window _editOwnerWindow;
        public void ShowEditOwnerWindow() {
            _editOwnerWindow = new EditOwnerWindow();
            _editOwnerWindow.ShowDialog();
        } // ShowEditOwnerWindow

        // Закрыть диалоговое окно для редактирования записи о владельце
        public void CloseEditOwnerWindow() =>
            _editOwnerWindow.Close();

        // Открыть диалоговое окно для редактрования записи об авто
        Window _editCarWindow;
        public void ShowEditCarWindow() {
            _editCarWindow = new EditCarWindow();
            _editCarWindow.ShowDialog();
        } // ShowEditCarWindow

        // Закрыть диалоговое окно для редактрования записи об авто
        public void CloseEditCarWindow() =>
            _editCarWindow.Close();

        // Открыть диалоговое окно для редактирования записи об услуге
        Window _editServicesWindow;
        public void ShowEditServicesWindow() {
            _editServicesWindow = new EditServicesWindow();
            _editServicesWindow.ShowDialog();
        } // ShowEditServicesWindow

        // Закрыть диалоговое окно для редактирования записи об услуге
        public void CloseEditServicesWindow() =>
            _editServicesWindow.Close();

        // Открыть диалоговое окно для редактиования записи о сотруднике
        Window _editEmployeeWindow;
        public void ShowEditEmployeeWindow() {
            _editEmployeeWindow = new EditEmployeeWindow();
            _editEmployeeWindow.ShowDialog();
        } // ShowEditEmployeeWindow

        // Закрыть диалоговое окно для редактиования записи о сотруднике
        public void CloseEditEmployeeWindow() =>
            _editEmployeeWindow.Close();

        // Открыть диалоговое окно для просмотра перечня авто, которые клиент сдавал в ремонт
        Window _showListCarSC_Window;
        public void ShowListCarSC_Window() {
            _showListCarSC_Window = new ListCarSelectedClient();
            _showListCarSC_Window.ShowDialog();
        } // ListCarSelectedClientWindow

        // Закрыть диалоговое окно для просмотра перечня авто, которые клиент сдавал в ремонт
        public void CloseListCarSC_Window() =>
            _showListCarSC_Window.Close();

        // Открыть диалоговое окно для просмотра перечня заказов, которые клиент оформлял
        Window _showListOrdersSC_Window;
        public void ShowListOrdersSC_Window() {
            _showListOrdersSC_Window = new ListOrdersSelectedClient();
            _showListOrdersSC_Window.ShowDialog();
        } // ShowListOrdersSC_Window

        // Закрыть окно для просмотра перечня заказов, которые клиент оформлял
        public void CloseListOrdersSC_Window() =>
            _showListOrdersSC_Window.Close();

        // Открыть диалоговое окно для просмотра перечня неисправностей выбранного авто
        Window _showListDefectsSC_Window;
        public void ShowListDefectsSC_Window() {
            _showListDefectsSC_Window = new ListDefectsSelectedCar();
            _showListDefectsSC_Window.ShowDialog();
        } // ShowListDefectsSC_Window

        // Закрыть диалоговое окно для просмотра перечня неисправностей выбранного авто
        public void CloseListDefectsSC_Window() =>
            _showListDefectsSC_Window.Close();

        // Открыть диалоговое окно для просмотра информации о клиенте выбранного авто
        Window _showInfoAboutClientSelectedCar;
        public void ShowInfoAboutClientSelectedCar() {
            _showInfoAboutClientSelectedCar = new InfoAboutClientSelectedCar();
            _showInfoAboutClientSelectedCar.ShowDialog();
        } // ShowInfoAboutClientSelectedCar

        // Закрыть диалоговое окно для просмотра информации о клиенте выбранного авто
        public void CloseInfoAboutClientSelectedCar() =>
            _showInfoAboutClientSelectedCar.Close();

        // Открыть диалоговое окно для просмотра информации о владельце выбранного авто
        Window _showInfoAboutOwnerSelectedCar;
        public void ShowInfoAboutOwnerSelectedCar() {
            _showInfoAboutOwnerSelectedCar = new InfoAboutOwnerSelectedCar();
            _showInfoAboutOwnerSelectedCar.ShowDialog();
        } // ShowInfoAboutClientSelectedCar

        // Закрыть диалоговое окно для просмотра информации о клиенте выбранного авто
        public void CloseInfoAboutOwnerSelectedCar() =>
            _showInfoAboutOwnerSelectedCar.Close();

        // Открыть диалоговое окно для работы с запросами
        Window _showQueriesWindow;
        public void ShowQueriesWindow() {
            _showQueriesWindow = new QueriesWindow();
            _showQueriesWindow.ShowDialog();
        } // ShowQueriesWindow

        // Закрыть диалоговое окно для работы с запросами
        public void CloseQueriesWindow() =>
            _showQueriesWindow.Close();


    } // WindowShowService
}
