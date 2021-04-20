using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CourseWork_Samolevich.Services.Interfaces {
    // Интерфейс для работы с UserControl's
    public interface IUserControlShow {

        UserControl ShowClientTable(); // показать таблицу - Клиенты
        UserControl ShowCarsTable(); // показать таблицу - Автомобили
        UserControl ShowOwnersTable(); // показать таблицу - Владельцы авто
        UserControl ShowDefectsTable(); // показать таблицу - Неисправности
        UserControl ShowServicesTable(); // показать таблицу - Услуги
        UserControl ShowSpecialtyTable(); // показать таблицу - Специальности
        UserControl ShowEmployeeTable(); // показать таблицу - Сотрудники
        UserControl ShowOrdersTable(); // показать таблицу - Заказы
        UserControl ShowParamsToQuery1(); // параметры к запросу №1
        UserControl ShowParamsToQuery2(); // параметры к запросу №2
        UserControl ShowParamsToQuery4(); // параметры к запросу №4
        UserControl ShowParamsToQuery5(); // параметры к запросу №5
        UserControl ShowParamsToQuery6(); // параметры к запросу №6
    } // IUserControlShow 
}
