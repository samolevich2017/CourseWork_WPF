using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CourseWork_Samolevich.Services.Interfaces {
    // Интерфейс для открытия новых окон
    public interface IWindowShow {

        void ShowInfoMessage(string message); // показать сообщение 
        void ShowErrorMessage(string message); // показать ошибку
        MessageBoxResult ShowConfirmationMessage(string message); // показать диалог подтверждения действия
        void ShowSelectDefectsWindow(); // открыть диалоговое окно для выбора неисправностей
        void ShowAddDefectWindow(); // открыть диалоговое окно для добавления неисправности в диспетчерской
        void CloseAddDefectWindow(); // закрыть диалоговое окно для добавления неисправности в диспетчерской
        void ShowAddServicesWindow(); // открыть диалоговое окно для добавления услуг в диспетчерской
        void CloseAddServicesWindow(); // закрыть диалоговое окно для добавления услуг в диспетчерской
        void ShowAddEmployeeWindow(); //  открыть диалоговое окно для добавления сотрудника в диспетчерской
        void CloseAddEmployeeWindow(); // закрыть диалоговое окно для добавления сотрудника в диспетчерской
        void ShowEditClientWindow(); // открыть диалоговое окно для редактирования записи о клиенте в диспетчерской
        void CloseEditClientWindow(); // открыть диалоговое окно для редактирования записи о клиенте в диспетчерской
        void ShowEditOwnerWindow(); // открыть диалоговое окно для редактирования записи о владельце в диспетчерской
        void CloseEditOwnerWindow(); // закрыть диалоговое окно для редактирования записи о владельце в диспетчерской
        void ShowEditCarWindow(); // открыть диалоговое окно для редактирования записи об авто в диспетчерской
        void CloseEditCarWindow(); // закрыть диалоговое окно для редактирования записи об авто в диспетчерской
        void ShowEditServicesWindow(); // открыть диалоговое окно для редактирования записи об услуге в диспетчерской
        void CloseEditServicesWindow(); // закрыть диалоговое окно для редактирования записи об услуге в диспетчерской
        void ShowEditEmployeeWindow(); // открыть диалоговое окно для редактирования записи о работнике в диспетчерской
        void CloseEditEmployeeWindow(); // закрыть диалоговое окно для редактирования записи об работнике в диспетчерской
        void ShowListCarSC_Window(); // открыть диалоговое окно для просмотра перечня авто, которые клиент сдавал в ремонт
        void CloseListCarSC_Window(); // закрыть диалоговое окно для просмотра перечня авто, которые клиент сдавал в ремонт
        void ShowListOrdersSC_Window(); // открыть диалоговое окно для просмотра перечня заказов, которые клиент оформлял
        void CloseListOrdersSC_Window(); // закрыть окно для просмотра перечня заказов, которые клиент оформлял
        void ShowListDefectsSC_Window(); // открыть диалоговое окно для просмотра перечня неисправностей выбранного авто
        void CloseListDefectsSC_Window(); // закрыть диалоговое окно для просмотра перечня неисправностей выбранного авто
        void ShowInfoAboutClientSelectedCar(); // открыть диалоговое окно для просмотра информации о клиенте выбранного авто
        void CloseInfoAboutClientSelectedCar(); // закрыть диалоговое окно для просмотра информации о клиенте выбранного авто
        void ShowInfoAboutOwnerSelectedCar(); // открыть диалоговое окно для просмотра информации о владельце выбранного авто
        void CloseInfoAboutOwnerSelectedCar(); // закрыть диалоговое окно для просмотра информации о владельце выбранного авто
        void ShowQueriesWindow(); // открыть диалоговое окно для работы с запросами
        void CloseQueriesWindow(); // закрыть диалоговое окно для работы с запросами
    } // IWindowShow 
}
