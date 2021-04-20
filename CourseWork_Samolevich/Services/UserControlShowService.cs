using CourseWork_Samolevich.Services.Interfaces;
using CourseWork_Samolevich.Views.TablesUserControls;
using CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo.UC_ParametrsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CourseWork_Samolevich.Services {
    // Класс-сервис реализующий методы для работы с UserControl's
    class UserControlShowService : IUserControlShow{

        // Показать UserControl представляющий таблицу "Клиенты"
        UserControl _showClientTable;
        public UserControl ShowClientTable() {
            _showClientTable = new UC_ClientTable();
            return _showClientTable;
        } // ShowClientTable

        // Показать UserControl представляющий таблицу "Автомобили"
        UserControl _showCarsTable;
        public UserControl ShowCarsTable() {
            _showCarsTable = new UC_CarsTable();
            return _showCarsTable;
        } // ShowCarsTable

        // Показать UserControl представляющий таблицу "Владельцы авто"
        UserControl _showOwnersTable;
        public UserControl ShowOwnersTable() {
            _showOwnersTable = new UC_OwnersTable();
            return _showOwnersTable;
        } // ShowOwnersTable

        // Показать UserControl представляющий таблицу "Неисправности"
        UserControl _showDefectsTable;
        public UserControl ShowDefectsTable() {
            _showDefectsTable = new UC_DefectsTable();
            return _showDefectsTable;
        } // ShowDefectsTable

        // Показать UserControl представляющий таблицу "Услуги"
        UserControl _showServicesTable;
        public UserControl ShowServicesTable() {
            _showServicesTable = new UC_ServicesTable();
            return _showServicesTable;
        } // ShowServicesTable

        // Показать UserControl представляющий таблицу "Специальности"
        UserControl _showSpecialtyTable;
        public UserControl ShowSpecialtyTable() {
            _showSpecialtyTable = new UC_SpecialtyTable();
            return _showSpecialtyTable;
        } // ShowSpecialtyTable

        // Показать UserControl представляющий таблицу "Сотрудники"
        UserControl _showEmployeeTable;
        public UserControl ShowEmployeeTable() {
            _showEmployeeTable = new UC_EmployeeTable();
            return _showEmployeeTable;
        } // ShowEmployeeTable

        // Показать UserControl представляющий таблицу "Заказы"
        UserControl _showOrdersTable;
        public UserControl ShowOrdersTable() {
            _showOrdersTable = new UC_OrdersTable();
            return _showOrdersTable;
        } // ShowOrdersTable

        // Показать UserControl с полями для ввода параметров к запросу №1
        UserControl _showParamsToQuery1;
        public UserControl ShowParamsToQuery1() {
            _showParamsToQuery1 = new UC_Query_1();
            return _showParamsToQuery1;
        } // ShowParamsToQuery1

        // Показать UserControl с полями для ввода параметров к запросу №2 и №3
        UserControl _showParamsToQuery2;
        public UserControl ShowParamsToQuery2() {
            _showParamsToQuery2 = new UC_Query_2();
            return _showParamsToQuery2;
        } // ShowParamsToQuery2

        // Показать UserControl с полями для ввода параметров к запросу №4
        UserControl _showParamsToQuery4;
        public UserControl ShowParamsToQuery4() {
            _showParamsToQuery4 = new UC_Query_4();
            return _showParamsToQuery4;
        } // ShowParamsToQuery4

        // Показать UserControl с полями для ввода параметров к запросу №5
        UserControl _showParamsToQuery5;
        public UserControl ShowParamsToQuery5() {
            _showParamsToQuery5 = new UC_Query_5();
            return _showParamsToQuery5;
        } // ShowParamsToQuery5

        // Показать UserControl с полями для ввода параметров к запросу №6
        UserControl _showParamsToQuery6;
        public UserControl ShowParamsToQuery6() {
            _showParamsToQuery6 = new UC_Query_6();
            return _showParamsToQuery6;
        } // ShowParamsToQuery5

    } // UserControlShowService
} 
