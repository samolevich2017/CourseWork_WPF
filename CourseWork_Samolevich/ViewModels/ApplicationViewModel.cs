using CourseWork_Samolevich.EF;
using CourseWork_Samolevich.Services.Interfaces;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CourseWork_Samolevich {

    // Модель представления
    public class ApplicationViewModel : DependencyObject, INotifyPropertyChanged {

        ServiceStationEntities context; // контекст данных (БД)

        IPageShow _ipage; // для работы со страницами
        IWindowShow _iwind; // для работы с окнами
        IUserControlShow _iuc; // для работы с UserControl's

        // контент строки подключения
        private string _statusBarContent;
        public string StatusBarContent {
            get => _statusBarContent;
            set {
                _statusBarContent = value;
                OnPropertyChanged("StatusBarContent");
            } // set
        } // StatusBarContent

        // Текущая страница в окне 
        // В зависимости от выбранного раздела меню, отображается нужная View
        private Page _currentPage;
        public Page CurrentPage {
            get => _currentPage;
            set {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            } // set
        } // CurrentPage

        // Текущий UserControl-таблица в окне управления
        private UserControl _currentUserControl;
        public UserControl CurrentUserControl {
            get => _currentUserControl;
            set {
                _currentUserControl = value;
                
                StatusBarContent = "Готов";

                // если отображается таблица сотрудников, то показывать 
                // в строке состояния общее кол-во сотрудников и кол-во свободных
                if (value.Name == "UC_Employees") {
                    int countAllEmployee = EmployeesCollection.Count;
                    int countFreeEmployee = EmployeesCollection.Select(o => o).Where(u => u.StatusWorking == false && u.StateDiss == true).ToList().Count;
                    int countNotDissEmployee = EmployeesCollection.Select(o => o).Where(u => u.StateDiss == true).ToList().Count;
                    StatusBarContent = $"Всего сотрудников: {countAllEmployee} | В штате: {countNotDissEmployee} | Свободных: {countFreeEmployee}";
                }
                // иначе, если отображается таблица автомобилей, то показывать
                // в строке состояния общее кол-во авто и кол-во авто находящихся в ремонте
                else if(value.Name == "UC_Cars") {
                   
                    // кол-во всех авто
                    int countAllCars = CarsCollection.Count;

                    // получили все незавершенные заказы
                    List<Orders> ordersNotFinished = OrdersCollection.Select(o => o).Where(u => u.Stat != true).ToList();

                    // получили всех клиентов, заказы которых, не выполнены
                    List<Clients> clientsWhoNotFinishedOrder = new List<Clients>();
                    foreach(var item in ordersNotFinished) 
                        clientsWhoNotFinishedOrder.Add(ClientsCollection.Select(o => o).Where(u => u.idClient == item.idClient).ToList().First());

                    // получили все авто, которые еще в ремонте
                    List<Cars> cars = new List<Cars>();
                    foreach(var item in clientsWhoNotFinishedOrder) 
                        cars.Add(CarsCollection.Select(o => o).Where(u => u.idCar == item.idCar).ToList().First());

                    // получили кол-во авто в ремонте
                    int countRepairCars = cars.Count;

                    StatusBarContent = $"Всего автомобилей: {countAllCars} | В ремонте: {countRepairCars}";
                }

                OnPropertyChanged("CurrentUserControl");
            } // set
        } // CurrentUserControl 

        // Коллекция хранящая Клиентов
        public ObservableCollection<Clients> ClientsCollection { get; set; }

        // Выбранная запись о клиенте в таблице Клиентов
        private Clients _selectedClient;
        public Clients SelectedClient {
            get => _selectedClient;
            set {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            } // set
        } // SelectedClient

        // Коллекция хранящая Автомобили
        public ObservableCollection<Cars> CarsCollection { get; set; }

        // Выбранная запись об авто в таблице Автомобили
        private Cars _selectedCar;
        public Cars SelectedCar {
            get => _selectedCar;
            set {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            } // set
        } // SelectedCar 

        // Коллекция хранящая Владельцев авто
        public ObservableCollection<Owners> OwnersCollection { get; set; }

        // Выбранная запись о владельце в таблице Владельцы авто
        private Owners _selectedOwner;
        public Owners SelectedOwner {
            get => _selectedOwner;
            set {
                _selectedOwner = value;
                OnPropertyChanged("SelectedOwner");
            } // set
        } // SelectedOwner 

        // Коллекция хранящая Неисправности
        public ObservableCollection<Defects> DefectsCollection { get; set; }

        // Выбранная запись о неисправности в таблице Неисправности
        private Defects _selectedDefect;
        public Defects SelectedDefect {
            get => _selectedDefect;
            set {
                _selectedDefect = value;
                OnPropertyChanged("SelectedDefect");
            } // set
        } // SelectedDefect 

        // Коллекция хранящая Услуги
        public ObservableCollection<Servicess> ServicessesCollection { get; set; }

        // Выбранная запись об услуге в таблице Услуги
        private Servicess _selectedService;
        public Servicess SelectedService {
            get => _selectedService;
            set {
                _selectedService = value;
                OnPropertyChanged("SelectedService");
            } // set
        } // SelectedService

        // Коллекция хранящая Специальности
        public ObservableCollection<Specialty> SpecialtiesCollection { get; set; }

        // Выбранная запись о специальности в таблице Специальности
        private Specialty _selectedSpecialty;
        public Specialty SelectedSpecialty {
            get => _selectedSpecialty;
            set {
                _selectedSpecialty = value;
                OnPropertyChanged("SelectedSpecialty");
            } // set
        } // SelectedSpecialty 

        // Коллекция хранящая Сотрудников
        public ObservableCollection<Employee> EmployeesCollection { get; set; }

        // Выбранная запись о сотруднике в таблице Сотрудники
        private Employee _selectedEmployee;
        public Employee SelectedEmployee {
            get => _selectedEmployee;
            set {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            } // set
        } // SelectedEmployee

        // Коллекция хранящая Заказы
        private ObservableCollection<Orders> _ordersCollection;
        public ObservableCollection<Orders> OrdersCollection {
            get => _ordersCollection;
            set {
                _ordersCollection = value;
                OnPropertyChanged("OrdersCollection");
            }
        }

        // Выбранная запись о заказе в таблице Заказы
        private Orders _selectedOrder;
        public Orders SelectedOrder {
            get => _selectedOrder;
            set {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            } // set
        } // SelectedOrder

        // Коллекция неисправностей имеющихся автомобилей
        public ObservableCollection<CarsDefects> CarsDefectsCollection { get; set; }

        // Выбранная запись о неисправности авто
        private CarsDefects _selectedCarsDefect;
        public CarsDefects SelectedCarsDefect {
            get => _selectedCarsDefect;
            set {
                _selectedCarsDefect = value;
                OnPropertyChanged("SelectedCarsDefect");
            } // set
        } // SelectedCarsDefect

        #region Манипуляция таблицей - Заказы

        // Добавление заказа
        private void AddOrder() {
            Orders newOrder = new Orders() { idClient = 1, Stat = true, TotalPrice = 2000, WorkingHours = 5 };
            OrdersCollection.Add(newOrder); // добавление в Observable коллекцию, для отслеживания изменений в таблице
            context.Orders.Add(newOrder); // добавление в базу данных
            context.SaveChanges();
            MessageBox.Show(newOrder.ToString());
        } // AddOrder

        // Удаление заказа
        private void RemoveOrder() {
            if (SelectedOrder != null) {
                // работаем с копией, так как нужно удалять в двух коллекциях сразу
                // кажется я упустил тот момент, когда нужно было понять, что коллекции для сущностей не нужны
                var temp = SelectedOrder;
                OrdersCollection.Remove(temp);
                context.Orders.Remove(temp);
                context.SaveChanges();
                _iwind.ShowInfoMessage($"Обьект : {temp.ToString()}\nУспешно удален!");
            } // if
        } // RemoveOrder

        // Команда добавления Заказа
        private RelayCommand _addOrder;
        public RelayCommand AddNewOrder {
            get {
                return _addOrder ??
                    (_addOrder = new RelayCommand(obj => {
                        AddOrder();
                    }));
            } // get
        } // AddNewOrder

        #endregion

        // ----------------------------- Конструкторы -------------------------------
        public ApplicationViewModel() { }
        public ApplicationViewModel(IPageShow ipage, IWindowShow iwind, IUserControlShow iuc) {

            _ipage = ipage; // передаем обьект для работы со страницами, т.е. View
            _iwind = iwind; // передаем обьект для работы с окнами 
            _iuc = iuc; // передаем обьект для работы с UserControl's
            CurrentPage = _ipage.ShowPageMainScreen(); // устанавливаем начальной View по умл. Главную

            context = new ServiceStationEntities(); // обьект контекста данных
            
            // коллекции для работы с данными
            ClientsCollection = new ObservableCollection<Clients>(); // обьект коллекции клиентов
            CarsCollection = new ObservableCollection<Cars>(); // обьект коллекции автомобилей
            OwnersCollection = new ObservableCollection<Owners>(); // обьект коллекции владельцев авто
            DefectsCollection = new ObservableCollection<Defects>(); // обьект коллекции неисправностей
            ServicessesCollection = new ObservableCollection<Servicess>(); // обьект коллекции услуг
            SpecialtiesCollection = new ObservableCollection<Specialty>(); // обьект коллекции специальностей
            EmployeesCollection = new ObservableCollection<Employee>(); // обьект коллекции сотрудников
            OrdersCollection = new ObservableCollection<Orders>(); // обьект коллекции заказов
            CarsDefectsCollection = new ObservableCollection<CarsDefects>(); // обьект коллекции неисправностей имеющихся у авто

            // инициализация Клиентов
            var client = context.Clients.Select(o => o).ToList();
            foreach (var item in client)
                ClientsCollection.Add(item);

            // инициализация Автомобилей
            var car = context.Cars.Select(o => o).ToList();
            foreach (var item in car)
                CarsCollection.Add(item);

            // инициализация Владельцев
            var own = context.Owners.Select(o => o).ToList();
            foreach (var item in own)
                OwnersCollection.Add(item);

            // инициализация Неисправностей
            var def = context.Defects.Select(o => o).ToList();
            foreach (var item in def)
                DefectsCollection.Add(item);

            // инициализация Услуг
            var ser = context.Servicess.Select(o => o).ToList();
            foreach (var item in ser)
                ServicessesCollection.Add(item);

            // инициализация Специальностей
            var spec = context.Specialty.Select(o => o).ToList();
            foreach (var item in spec)
                SpecialtiesCollection.Add(item);

            // инициализация Сотрудников
            var emp = context.Employee.Select(o => o).ToList();
            foreach (var item in emp)
                EmployeesCollection.Add(item);

            // инициализация Заказов
            var ord = context.Orders.Select(o => o).ToList();
            foreach (var item in ord)
                OrdersCollection.Add(item);

            // инициализация Неисправностей имеющихся у авто
            var carsDef = context.CarsDefects.Select(o => o).ToList();
            foreach (var item in carsDef)
                CarsDefectsCollection.Add(item);

        } // ApplicationViewModel

        // ------------------------------- Команды ----------------------------------

        // Команда при клике на пункт меню ГЛАВНАЯ - отображает View главного экрана
        private RelayCommand _openMainScreen;
        public RelayCommand OpenMainScreen {
            get {
                return _openMainScreen ??
                    (_openMainScreen = new RelayCommand(obj => {
                        CurrentPage = _ipage.ShowPageMainScreen();
                    }));
            } // get
        } // OpenMainScreen


        // Команда при клике на пункт меню УПРАВЛЕНИЕ - откроет View экрана для управления СТО
        private RelayCommand _openControlScreen;
        public RelayCommand OpenControlScreen {
            get {
                return _openControlScreen ??
                    (_openControlScreen = new RelayCommand(obj => {
                        CurrentPage = _ipage.ShowPageControlScreen();
                    }));
            } // get
        } // OpenControlScreen 

        #region Команды для раздела УПРАВЛЕНИЕ

        // Команда при клике на пункт меню УПРАВЛЕНИЕ - отображает View экрана для АВТОРИЗАЦИИ
        private RelayCommand _openAuthorizationScreen;
        public RelayCommand OpenAuthorizationScreen {
            get {
                return _openAuthorizationScreen ??
                    (_openAuthorizationScreen = new RelayCommand(obj => {
                        CurrentPage = _ipage.ShowPageAuthorizationScreen();
                    }));
            } // get
        } // OpenAuthorizationScreen 

        // Команда при клике на кнопку "Клиенты" - отобразит таблицу с Клиентами
        private RelayCommand _openClientTable;
        public RelayCommand OpenClientTable {
            get {
                return _openClientTable ??
                    (_openClientTable = new RelayCommand(obj => {
                        CurrentUserControl = _iuc.ShowClientTable();
                    }));
            } // get
        } // OpenClientTable 

        // Команда при клике на кнопку "Автомобили" - отобразит таблицу с Автомобилями
        private RelayCommand _openCarsTable;
        public RelayCommand OpenCarsTable {
            get {
                return _openCarsTable ??
                    (_openCarsTable = new RelayCommand(obj => {
                        CurrentUserControl = _iuc.ShowCarsTable();
                    }));
            } // get
        } // OpenCarsTable

        // Команда при клике на кнопку "Владельцы" - отобразит таблицу с Владельцами авто
        private RelayCommand _openOwnersTable;
        public RelayCommand OpenOwnersTable {
            get {
                return _openOwnersTable ??
                    (_openOwnersTable = new RelayCommand(obj => {
                        CurrentUserControl = _iuc.ShowOwnersTable();
                    }));
            } // get
        } // OpenOwnersTable

        // Команда при клике на кнопку "Неисправности" - отобразит таблицу с видами Неисправностей
        private RelayCommand _openDefectsTable;
        public RelayCommand OpenDefectsTable {
            get {
                return _openDefectsTable ??
                    (_openDefectsTable = new RelayCommand(obj => {
                        CurrentUserControl = _iuc.ShowDefectsTable();
                    }));
            } // get
        } // OpenDefectsTable

        // Метод для добавления неисправности в таблицу "Неисправности"
        public string TitleDef { get; set; } // к этому свойству привязан TextBox окна добавления
        public int IdServ { get; set; }  // к этому свойству привязан TextBox окна добавления
        private void AddDefects() {
            Defects defect = new Defects() { idDef = DefectsCollection.Count + 1, TitleDefect = TitleDef, idService = SelectedService.idService };
            DefectsCollection.Add(defect);
            context.Defects.Add(defect);
            context.SaveChanges();
            // очищаем свойство выбранной услуги, чтобы при включении таблицы услуг, 
            // не была выбрана запись, которую пользователь выбрал при добавлении неисправности.
            // P.S. Иначе юзер будет кричать : "Ааа, как так!?? Я не выбирал, ВСЁ СЛОМАЛОСЬ!!!".
            SelectedService = null;
        } // AddDefects

        // Метод для удаления неисправности из таблицы "Неисправности"
        private void RemoveDefects() {
            if (SelectedDefect != null) {
                Defects deletedEl = SelectedDefect;
                DefectsCollection.Remove(deletedEl);
                context.Defects.Remove(deletedEl);
                context.SaveChanges();
                SelectedDefect = null;
                _iwind.ShowInfoMessage($"Обьект : {deletedEl.ToString()}\nУспешно удален!");
            } // if
        } // RemoveDefects

        // Команда выполняющая добавление неисправности в таблицу
        private RelayCommand _addDefectIntoTable;
        public RelayCommand AddDefectIntoTable {
            get {
                return _addDefectIntoTable ??
                    (_addDefectIntoTable = new RelayCommand(obj => {
                        AddDefects();
                        _iwind.CloseAddDefectWindow();
                        _iwind.ShowInfoMessage("Добавление записи в таблицу \"Неисправности\" - Успешно!");
                    }));
            } // get
        } // AddDefectIntoTable

        // Команда при клике на кнопку "Услуги" - отобразит таблицу с видами Услуг
        private RelayCommand _openServicesTable;
        public RelayCommand OpenServicesTable {
            get {
                return _openServicesTable ??
                    (_openServicesTable = new RelayCommand(obj => {
                        CurrentUserControl = _iuc.ShowServicesTable();
                    }));
            } // get
        } // OpenServicesTable

        // Метод для добавления услуги в таблицу услуг
        public string TitleServ { get; set; } // наименование
        public int WorkHours { get; set; } // время выполнения
        public decimal PriceS { get; set; } // цена

        private void AddServices() {
            // создаем обьект услуга
            Servicess service = new Servicess() { 
                idService = ServicessesCollection.Count + 1, 
                TitleService = TitleServ, 
                WorkingHours = WorkHours, 
                Price = PriceS, 
                idSpecialty = SelectedSpecialty.idSpecialty
            };
            ServicessesCollection.Add(service);
            context.Servicess.Add(service);
            context.SaveChanges();
            SelectedSpecialty = null;
        } // AddServices

        // Метод для удаления услуги из таблицы услуг
        private void RemoveServices() {
            if(SelectedService != null) {
                Servicess deletedEl = SelectedService;
                ServicessesCollection.Remove(deletedEl);
                context.Servicess.Remove(deletedEl);
                context.SaveChanges();
                SelectedService = null;
                _iwind.ShowInfoMessage($"Обьект : {deletedEl.ToString()}\nУспешно удален!");
            } // if
        } // RemoveServices

        // Команда выполняющая добавление услуги в таблицу услуг
        private RelayCommand _addServiceIntoTable;
        public RelayCommand AddServiceIntoTable {
            get {
                return _addServiceIntoTable ??
                    (_addServiceIntoTable = new RelayCommand(obj => {
                        AddServices();
                        _iwind.CloseAddServicesWindow();
                        _iwind.ShowInfoMessage("Добавление записи в таблицу \"Услуги\" - Успешно!");
                    }));
            } // get
        } // AddServiceIntoTable

        // Команда при клике на кнопку "Специальности" - отобразит таблицу с видами Специальностей
        private RelayCommand _openSpecialtyTable;
        public RelayCommand OpenSpecialtyTable {
            get {
                return _openSpecialtyTable ??
                    (_openSpecialtyTable = new RelayCommand(obj => {
                        CurrentUserControl = _iuc.ShowSpecialtyTable();
                    }));
            } // get
        } // OpenSpecialtyTable

        // Команда при клике на кнопку "Сотрудники" - отобразит таблицу с Сотрудниками 
        private RelayCommand _openEmployeeTable;
        public RelayCommand OpenEmployeeTable {
            get {
                return _openEmployeeTable ??
                    (_openEmployeeTable = new RelayCommand(obj => {
                        CurrentUserControl = _iuc.ShowEmployeeTable();
                    }));
            } // get
        } // OpenEmployeeTable

        // Метод для добавления сотрудника в таблицу сотрудников
        public string Surname { get; set; } // фамилия
        public string Name { get; set; } // имя
        public string Patronymic { get; set; } // отчество
        public byte Rank { get; set; } // разряд
        public byte Exp { get; set; } // стаж
        private void ClearField() {
            // очистка полей
            Surname = null;
            Name = null;
            Patronymic = null;
            Rank = 0;
            Exp = 0;
        } // ClearField

        // TODO: Сделать аналог триггера, если добавляемый сотрудник уже есть - менять статус ШТАТ
        private void AddEmployee() {
            
            bool flagThisIsANewEmployee = true;

            foreach(var item in EmployeesCollection) {
                
                if(item.SurnameEmployee == Surname && item.NameEmployee == Name && item.PatronymicEmployee == Patronymic) {
                    
                    int id = EmployeesCollection.IndexOf(item); // id найденного сотрудника

                    // если добавляемый сотрудник уже числится в штате, то говорим об этом и отменяем добавление
                    if (item.StateDiss == true) {
                        _iwind.ShowInfoMessage("Сотрудник с такими данными уже числится в штате!\nОперация добавления отменена.\nСтрока сотрудника выделена.");
                        ClearField(); // очищаем заполненные поля
                        SelectedEmployee = item; // выделяем запись о сотруднике, которого пытались добавить
                        return;
                    } // if

                    // обновляем данные в коллекции сотрудников
                    EmployeesCollection[id].idSpecialty = SelectedSpecialty.idSpecialty;
                    EmployeesCollection[id].Runk = Rank;
                    EmployeesCollection[id].Experience = Exp;
                    EmployeesCollection[id].StateDiss = true;
                    EmployeesCollection[id].StatusWorking = false;

                    // обновляем данные в контексте
                    context.Employee.Find(item.idEmployee).idSpecialty = SelectedSpecialty.idSpecialty;
                    context.Employee.Find(item.idEmployee).Runk = Rank;
                    context.Employee.Find(item.idEmployee).Experience = Exp;
                    context.Employee.Find(item.idEmployee).StateDiss = true;
                    context.Employee.Find(item.idEmployee).StatusWorking = false;

                    // оповещаем пользователя о том, что сотрудник снова принят в штат
                    _iwind.ShowInfoMessage($"Сотрудник : {item.ToString()}\nСнова принят в штат!");

                    flagThisIsANewEmployee = false;
                } // if

            } // foreach

            // если сотрудник новый - создаем новый обьект и добавляем его в коллекцию и контекст
            if (flagThisIsANewEmployee) {
                Employee employee = new Employee() {
                    idEmployee = EmployeesCollection.Count + 1,
                    SurnameEmployee = Surname,
                    NameEmployee = Name,
                    PatronymicEmployee = Patronymic,
                    idSpecialty = SelectedSpecialty.idSpecialty,
                    Runk = Rank,
                    Experience = Exp,
                    StateDiss = true,
                    StatusWorking = false
                };
                EmployeesCollection.Add(employee);
                context.Employee.Add(employee);
                _iwind.ShowInfoMessage("Добавление записи в таблицу \"Сотрудники\" - Успешно!");
            } // if

            context.SaveChanges(); 
            SelectedSpecialty = null;
            ClearField(); // очищаем заполненные поля
        } // AddEmployee

        // Метод для удаления сотрудника (увольнение - меняет статус штата)
        private void RemoveEmployee() {
            
            // если выбранный сотрудник уже был уволен - говорим об этом
            if(SelectedEmployee.StateDiss != true) {
                _iwind.ShowErrorMessage("Данный сотрудник уже уволен!\nОперация увольнения отменена.");
                return;
            } // if

            // если выбранная запись не пустая
            if(SelectedEmployee != null) {
                
                // получаем id удаляемой записи
                int id = EmployeesCollection.IndexOf(SelectedEmployee);

                // так как по не понятным мне причинам, при удалении записи из контекста данных,
                // обьект специальности и ее id становятся равными null, то было принято решение
                // сделать копии этих данных до удаления из контекста, чтобы затем, после удаления
                // элемента из контекста, присвоить эти данные элементу коллекции для корректного
                // отображения данных в таблице
                var spec = SelectedEmployee.Specialty; // копируем специальность сотрудника
                var idSpec = SelectedEmployee.idSpecialty; // копируем id специальности сотрудника

                // ставим статус ШТАТ в коллекции = Уволен (false)
                EmployeesCollection[id].StateDiss = false;

                // удаляем выбранного сотрудника из контекста (срабатывает триггер INSTEAD OF DELETE - мягкое удаление, 
                // делает статус - уволен)
                context.Employee.Remove(SelectedEmployee);
                
                // сохраняем изменения в контексте
                context.SaveChanges();

                // присваиваем уволенному сотруднику, данные о специальности
                EmployeesCollection[id].idSpecialty = idSpec;
                EmployeesCollection[id].Specialty = spec;

                // сообщаем пользователю об успешном увольнении
                _iwind.ShowInfoMessage($"Сотрудник : {SelectedEmployee.ToString()}\nУспешно уволен!");
            
            } // if/else
        } // RemoveEmployee


        // Команда выполняющая добавление нового сотрудника в таблицу сотрудников
        private RelayCommand _addEmployeeIntoTable;
        public RelayCommand AddEmployeeIntoTable {
            get {
                return _addEmployeeIntoTable ??
                    (_addEmployeeIntoTable = new RelayCommand(obj => {
                        AddEmployee();
                        _iwind.CloseAddEmployeeWindow();
                    }));
            } // get
        } // AddEmployeeIntoTable

        // Команда при клике на кнопку "Заказы" - отобразит таблицу с Заказами
        private RelayCommand _openOrdersTable;
        public RelayCommand OpenOrdersTable {
            get {
                return _openOrdersTable ??
                    (_openOrdersTable = new RelayCommand(obj => {
                        CurrentUserControl = _iuc.ShowOrdersTable();
                    }));
            } // get
        } // OpenOrdersTable

        // Команда при клике на кнопку "Добавить"
        private RelayCommand _addElementToTable;
        public RelayCommand AddElementToTable {

            get {
                return _addElementToTable ??
                    (_addElementToTable = new RelayCommand(obj => {
                        if (CurrentUserControl?.Name == "UC_Defects")
                            _iwind.ShowAddDefectWindow(); // вызов окна для добавления данных о неисправности
                        else if (CurrentUserControl?.Name == "UC_Services")
                            _iwind.ShowAddServicesWindow(); // вызов окна для добавления данных об услуге
                        else if (CurrentUserControl?.Name == "UC_Employees")
                            _iwind.ShowAddEmployeeWindow(); // вызов окна для добавления данных о сотруднике
                        else
                            MessageBox.Show("Вы пытаетесь добавить запись в недопустимом месте!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }));
            } // get
        } // AddElementToTable

        // Метод для редактирования обьекта клиента
        public string RegistrationClient { get; set; } // прописка
        public DateTime DateOfApplication_Client { get; set; } // дата обращения
        public bool Client_isOwner { get; set; } // владелец
        private void EditClient() {
            // если запись о клиенте выбрана
            if (SelectedClient != null) {
                var result = _iwind.ShowConfirmationMessage("Вы уверены, что хотите изменить обьект?\nВосстановить прежние данные будет невозможно!");
                if (result == MessageBoxResult.Yes) {
                    SelectedClient.Registration = RegistrationClient;
                    SelectedClient.DateOfApplication = DateOfApplication_Client;
                    SelectedClient.isOwner = Client_isOwner;
                    context.SaveChanges(); // сохраняем изменения в контексте 
                }
                else
                    _iwind.ShowInfoMessage("Операция редактирования отменена.\nДанные нетронуты.");
            } // if
        } // EditClient


        // Команда выполняющая редактирование записи о клиенте
        private RelayCommand _editClientInTable;
        public RelayCommand EditClientInTable {
            get {
                return _editClientInTable ??
                    (_editClientInTable = new RelayCommand(obj => {
                        bool startedStateIsOwner = SelectedClient.isOwner; // начальное значение статуса владельца
                        int idCar = CarsCollection.IndexOf(CarsCollection.Select(o => o).Where(u => u.idCar == SelectedClient.idCar).FirstOrDefault());
                        var item = OwnersCollection.Select(o => o).Where(u => u.idOwner == CarsCollection[idCar].idOwner).ToList(); // владелец авто которое сдавал клиент в ремонт
                        int idOwner = OwnersCollection.IndexOf(item[0]); // получаем идентификатор владельца авто, которое сдавал клиент
                                                                         
                        // присваиваем выбранного вледельца для редактирования
                        SelectedOwner = OwnersCollection.ElementAt(idOwner);
                        
                        // если клиент больше не владелец
                        // если значение статуса владелец отличается от первоначального значения
                        // и первоначальное значение было истинно, то редактируем владельца авто,
                        // которое сдавал клиент
                        if (Client_isOwner != startedStateIsOwner && startedStateIsOwner == true) {
                            var resultQ = _iwind.ShowConfirmationMessage("Вы пытаетесь изменить статус владельца.\nЕсли вы хотите продолжить, Вам нужно заполнить новые данные\nо владельце авто, которое сдавал этот клиент.\nОтменить операцию будет невозможно!\nПродолжить?");

                            // если пользователь нажал - Да, то начинаем редактирование владельца авто
                            if (resultQ == MessageBoxResult.Yes) {

                                // инициализируем поля для редактирования
                                SurnameOwner = SelectedOwner.SurnameOwner;
                                NameOwner = SelectedOwner.NameOwner;
                                PatronymicOwner = SelectedOwner.PatronymicOwner;
                                RegistrationOwner = SelectedOwner.Registration;
                                DateOfApplication_Owner = SelectedOwner.DateOfApplication;

                                // открываем окно для редактирования
                                _iwind.ShowEditOwnerWindow();

                            }
                            else {
                                Client_isOwner = SelectedClient.isOwner;
                                ClientToOwnerData(idOwner); // раз уж клиент остался владельцем, то редактируем его данные и в таблице владельцев
                                _iwind.ShowInfoMessage("Редактирование статуса владельца отменено.\nСтатус \"Владелец\" возвращен в исходное состояние.\nДанная операция никак не влияет на остальные данные, которые вы редактировали.");
                            } // if/else
                        } // if

                        // иначе, если клиент не был владельцем, а теперь стал им - копируем его данные на место предыдущего владельца
                        // или если клиент был владельцем и остался им, то меняем отредактированные данные и для записи
                        // в таблице владельцев
                        else if (Client_isOwner != startedStateIsOwner && startedStateIsOwner == false || Client_isOwner == startedStateIsOwner && startedStateIsOwner == true) {
                            // Заменяем данные о бывшем владельце авто, которое клиент сдал в ремонт, данными клиента
                            ClientToOwnerData(idOwner);
                            if (startedStateIsOwner == false)
                                _iwind.ShowInfoMessage($"Данные о владельце авто с ID - {SelectedClient.idCar}, успешно изменены!\nТеперь владелец авто - \"{SelectedClient.ToString()}\".\nВ следующем диалоге, подтвердите изменение остальных данных о клиенте.");
                        }
                        EditClient(); // вызов метода для редактирования выбранного обьекта
                        _iwind.CloseEditClientWindow();
                    }));
            } // get
        } // EditClientInTable

        // Метод для присваивания данных клиента, записи о владельце
        private void ClientToOwnerData(int idOwner) {
            OwnersCollection.ElementAt(idOwner).SurnameOwner = SelectedClient.SurnameClient;
            OwnersCollection.ElementAt(idOwner).NameOwner = SelectedClient.NameClient;
            OwnersCollection.ElementAt(idOwner).PatronymicOwner = SelectedClient.PatronymicClient;
            OwnersCollection.ElementAt(idOwner).Registration = RegistrationClient;
            OwnersCollection.ElementAt(idOwner).DateOfApplication = DateOfApplication_Client;
            OwnersCollection.ElementAt(idOwner).DateOfBirthday = SelectedClient.DateOfBirthday;
        } // ClientToOwnerData

        // Метод для редактирования обьекта владельца
        public string SurnameOwner { get; set; } // фамилия
        public string NameOwner { get; set; } // имя
        public string PatronymicOwner { get; set; } // отчество
        public string RegistrationOwner { get; set; } // прописка
        public DateTime DateOfApplication_Owner { get; set; } // дата обращения
        private void InitNewDataOwner() {

            // редактируем данные владельца
            SelectedOwner.SurnameOwner = SurnameOwner;
            SelectedOwner.NameOwner = NameOwner;
            SelectedOwner.PatronymicOwner = PatronymicOwner;
            SelectedOwner.Registration = RegistrationOwner;
            SelectedOwner.DateOfApplication = DateOfApplication_Owner;
            
            // получаем id авто редактируемого владельца
            int idCar_Own = CarsCollection.Select(o => o).Where(u => u.idOwner == SelectedOwner.idOwner).ToList()[0].idCar;

            // получаем клиента, который который сдавал авто редактируемого владельца
            var client = ClientsCollection.Select(o => o).Where(u => u.idCar == idCar_Own).ToList()[0];

            // получаем его индекс
            int idClient = ClientsCollection.IndexOf(client);

            // если владельцем был клиент, который сдал авто, то меняем статус *Владелец* у клиента на - false
            if (client.isOwner)
                ClientsCollection[idClient].isOwner = false;
           
        } // InitNewDataOwner
        private void EditOwner() {
            // если запись о владельце выбрана
            if (SelectedOwner != null) {
                // не показываем сообщения для подтверждения, если редактирование происходит при смене владельца (клиент больше не владелец)
                if (CurrentUserControl?.Name == "UC_Clients") {
                    InitNewDataOwner();
                    _iwind.ShowInfoMessage("Данные о владельце успешно добавлены!\nНо остальные данные клиента, все еще в исходном состоянии. Поэтому в следующем диалоге Вы можете подтвердить их изменение, либо отменить.");
                } // иначе, происходит обычное редактирование записи, и поэтому просим подтвердить действия
                else {
                    var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите изменить обьект?\nВосстановить прежние данные будет невозможно!");
                    if (resultQ == MessageBoxResult.Yes)
                        InitNewDataOwner(); // изменяем данные обьекта, на данные из полей ввода
                    else
                        _iwind.ShowInfoMessage("Операция редактирования отменена.\nДанные нетронуты.");
                } // if/else
            } // if

            // сохраняем изменения в контексте 
            context.SaveChanges();
        } // EditOwner

        // Команда выполняющая редактирование записи о владельце
        private RelayCommand _editOwnerInTable;
        public RelayCommand EditOwnerInTable {
            get {
                return _editOwnerInTable ??
                    (_editOwnerInTable = new RelayCommand(obj => {
                        // если происходит смена владельца, т.е. был владельцем клиент,
                        // а стал кто-то другой. То недопустить оставить данные клиента,
                        // для нового владельца
                        if (CurrentUserControl?.Name == "UC_Clients") {
                            if (SurnameOwner == SelectedClient.SurnameClient ||
                                NameOwner == SelectedClient.NameClient &&
                                PatronymicOwner == SelectedClient.PatronymicClient) {
                                _iwind.ShowErrorMessage("Вы не изменили данные!!!\nПожалуйста, не испытывайте мои нервы...");
                                return;
                            } // if
                        } // if
                        EditOwner();
                        _iwind.CloseEditOwnerWindow(); // закрываем окно редактирования
                        
                    }));
            } // get
        } // EditOwnerInTable


        // Метод для редактирования обьекта автомобиля
        public string Color { get; set; }
        public string GovernmentNumber { get; set; }
        private void EditCar() {
            // если запись об автомобиле выбрана и она не пуста
            if (SelectedCar != null) {
                var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите изменить обьект?\nВосстановить прежние данные будет невозможно!");
                if (resultQ == MessageBoxResult.Yes) {
                    SelectedCar.Color = Color;
                    SelectedCar.GovernmentNumber = GovernmentNumber.ToUpper();
                    // сохраняем изменения в контексте 
                    context.SaveChanges();
                }
                else
                    _iwind.ShowInfoMessage("Операция редактирования отменена.\nДанные нетронуты.");
            } // if
        } // EditCar

        // Команда выполняющая редактирование записи об автомобиле
        private RelayCommand _editCarInTable;
        public RelayCommand EditCarInTable {
            get {
                return _editCarInTable ??
                    (_editCarInTable = new RelayCommand(obj => {
                        EditCar();
                        _iwind.CloseEditCarWindow();
                    }));
            } // get
        } // EditCarInTable

        // Метод для редактирования обьекта услуги
        private void EditService() {
            // если запись об услуге выбрана и она не пуста
            if(SelectedService != null) {
                var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите изменить обьект?\nВосстановить прежние данные будет невозможно!");
                if (resultQ == MessageBoxResult.Yes) {
                    SelectedService.TitleService = TitleServ;
                    SelectedService.Price = PriceS;
                    SelectedService.WorkingHours = WorkHours;
                    SelectedService.Specialty = SelectedSpecialty;
                    // сохраняем изменения в контексте 
                    context.SaveChanges();
                }
                else
                    _iwind.ShowInfoMessage("Операция редактирования отменена.\nДанные нетронуты.");
            } // if

        } // EditService

        // Команда выполняющая редактирование записи об услуге
        private RelayCommand _editServiceInTable;
        public RelayCommand EditServiceInTable {
            get {
                return _editServiceInTable ??
                    (_editServiceInTable = new RelayCommand(obj => {
                        EditService();
                        _iwind.CloseEditServicesWindow();
                    }));
            } // get
        } // EditServiceInTable


        // Метод для редактирования сотрудника
        public string DissmisedEmp { get; set; } // статус - уволен ли
        private void EditEmployee() {
            if (SelectedEmployee != null) {
                var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите изменить обьект?\nВосстановить прежние данные будет невозможно!");
                if (resultQ == MessageBoxResult.Yes) {
                    SelectedEmployee.SurnameEmployee = Surname;
                    SelectedEmployee.NameEmployee = Name;
                    SelectedEmployee.PatronymicEmployee = Patronymic;
                    SelectedEmployee.Runk = Rank;
                    SelectedEmployee.Experience = Exp;
                    SelectedEmployee.idSpecialty = SelectedSpecialty.idSpecialty;
                    context.SaveChanges(); // сохраняем данные в контексте
                }
                else
                    _iwind.ShowInfoMessage("Операция редактирования отменена.\nДанные нетронуты.");

            } // if
        } // EditEmployee

        // Команда выполняющая редактирование выбранного сотрудника в таблице
        private RelayCommand _editEmployeeIntoTable;
        public RelayCommand EditEmployeeIntoTable {
            get {
                return _editEmployeeIntoTable ??
                    (_editEmployeeIntoTable = new RelayCommand(obj => {
                        EditEmployee();
                        _iwind.CloseEditEmployeeWindow();
                    }));
            } // get
        } // EditEmployeeIntoTable 

        // Команда при клике на кнопку "Редактировать"
        private RelayCommand _editElementFromTable;
        public RelayCommand EditElementFromTable {
            get {
                return _editElementFromTable ??
                    (_editElementFromTable = new RelayCommand(obj => {
                        // редактирование клиента
                        if (CurrentUserControl?.Name == "UC_Clients") {
                            if (SelectedClient != null) {
                                // Присваиваем переменным прописки и даты обращения клиента, к которым привязан TextBox, дату обращения и прописку 
                                // выбранного клиента. А также переменной флагу - владелец ли клиент, которая привязана к CheckBox, значение свойства
                                // isOwner выбранного клиента. 
                                // P.S.** Да, это костыль... Но все для того, чтобы измененные данные хранились в промежуточных переменных до того,
                                // как нажмут кнопку Сохранить, после чего данные присваиваются обьекту. Так в случае, если редактирование будет отменено, 
                                // мы оставим обьект в первозданном виде.
                                RegistrationClient = SelectedClient.Registration;
                                DateOfApplication_Client = SelectedClient.DateOfApplication;
                                Client_isOwner = SelectedClient.isOwner;
                                _iwind.ShowEditClientWindow();
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для редактирования не выбран!");
                        } // if
                        // редактирование владельца
                        if(CurrentUserControl?.Name == "UC_Owners") {
                            if (SelectedOwner != null) {
                                SurnameOwner = SelectedOwner.SurnameOwner;
                                NameOwner = SelectedOwner.NameOwner;
                                PatronymicOwner = SelectedOwner.PatronymicOwner;
                                RegistrationOwner = SelectedOwner.Registration;
                                DateOfApplication_Owner = SelectedOwner.DateOfApplication;
                                _iwind.ShowEditOwnerWindow();
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для редактирования не выбран!");
                        } // if
                        // редактирование автомобиля
                        if (CurrentUserControl?.Name == "UC_Cars") {
                            if (SelectedCar != null) {
                                Color = SelectedCar.Color;
                                GovernmentNumber = SelectedCar.GovernmentNumber;
                                var item = OwnersCollection.Select(o => o).Where(u => u.idOwner == SelectedCar.idOwner).ToList(); // владелец авто
                                int idOwner = OwnersCollection.IndexOf(item[0]); // получаем идентификатор владельца авто
                                // назначили выбранным владельца редактируемого авто, 
                                // чтобы можно было вызвать окно для редактирования владельца
                                SelectedOwner = OwnersCollection.ElementAt(idOwner);
                                SurnameOwner = SelectedOwner.SurnameOwner;
                                NameOwner = SelectedOwner.NameOwner;
                                PatronymicOwner = SelectedOwner.PatronymicOwner;
                                RegistrationOwner = SelectedOwner.Registration;
                                DateOfApplication_Owner = SelectedOwner.DateOfApplication;
                                _iwind.ShowEditCarWindow();
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для редактирования не выбран!");
                        } // if
                        // редактирование услуги
                        if(CurrentUserControl?.Name == "UC_Services") {
                            if (SelectedService != null) {
                                // присваиваем переменным, которые связаны с полями для ввода в окне, данные выбранной услуги
                                TitleServ = SelectedService.TitleService;
                                WorkHours = SelectedService.WorkingHours;
                                PriceS = SelectedService.Price;
                                SelectedSpecialty = SelectedService.Specialty;
                                // открываем окно для редактирования
                                _iwind.ShowEditServicesWindow();
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для редактирования не выбран!");
                        } // if
                        // редактирование сотрудника
                        if(CurrentUserControl?.Name == "UC_Employees") {
                            if (SelectedEmployee != null) {
                                // присваиваем переменным, которые связаны с полями для ввода в окне, данные выбранного сотрудника
                                Surname = SelectedEmployee.SurnameEmployee;
                                Name = SelectedEmployee.NameEmployee;
                                Patronymic = SelectedEmployee.PatronymicEmployee;
                                Rank = SelectedEmployee.Runk;
                                Exp = SelectedEmployee.Experience;
                                SelectedSpecialty = SelectedEmployee.Specialty;
                                // если уволен, то в окне показать - Уволен: Да
                                // иначе - Уволен: Нет
                                if (SelectedEmployee.StateDiss)
                                    DissmisedEmp = "Да";
                                else
                                    DissmisedEmp = "Нет";
                                
                                // открываем окно для редактирования
                                _iwind.ShowEditEmployeeWindow();
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для редактирования не выбран!");
                        } // if
                    }));
            } // get
        } // EditElementFromTable 

        // Команда при клике на кнопку "Удалить"
        private RelayCommand _removeElementFromTable;
        public RelayCommand RemoveElementFromTable {
            get {
                return _removeElementFromTable ??
                    (_removeElementFromTable = new RelayCommand(obj => {
                        // удаление неисправности
                        if (CurrentUserControl?.Name == "UC_Defects") {
                            if (SelectedDefect != null) {
                                var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите удалить запись о выбранной неисправности?\nДанные навсегда будут удалены!");
                                // если пользователь выбрал - Да, то удалаяем
                                // иначе говорим, что операция удаления была отменена
                                if (resultQ == MessageBoxResult.Yes)
                                    RemoveDefects(); // вызов метода для удаления выбранной неисправности
                                else
                                    _iwind.ShowInfoMessage("Операция удаления отменена!");
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для удаления не выбран!");
                            
                        }  // if
                        // удаление заказа
                        else if (CurrentUserControl?.Name == "UC_Orders") {
                            if (SelectedOrder != null) {
                                var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите удалить запись о выбранном заказе?\nДанные навсегда будут удалены!");
                                if (resultQ == MessageBoxResult.Yes)
                                    RemoveOrder(); // вызов метода для удаления выбранного заказа
                                else
                                    _iwind.ShowInfoMessage("Операция удаления отменена!");
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для удаления не выбран!");
                        } // if
                        // удаление услуги
                        else if (CurrentUserControl?.Name == "UC_Services") {
                            if (SelectedService != null) {
                                var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите удалить запись о выбранной услуге?\nДанные навсегда будут удалены!");
                                if (resultQ == MessageBoxResult.Yes)
                                    RemoveServices(); // вызов метода для удаления выбранной услуги
                                else
                                    _iwind.ShowInfoMessage("Операция удаления отменена!");
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для удаления не выбран!");
                        } // if
                        // удаление (увольнение) сотрудника
                        else if (CurrentUserControl?.Name == "UC_Employees") {
                            if (SelectedEmployee != null) {
                                var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите уволить данного сотрудника?\nДумаю, он очень расстроится...");
                                if (resultQ == MessageBoxResult.Yes)
                                    RemoveEmployee(); // вызов метода для удаления (увольнения) выбранного сотрудника
                                else
                                    _iwind.ShowInfoMessage("Операция увольнения отменена!\nСотрудник спокойно выдохнул...");
                            }
                            else
                                _iwind.ShowErrorMessage("Обьект для удаления не выбран!");
                        } // if
                        else
                            _iwind.ShowErrorMessage("Удаление запрещено!");
                    }));
            } // get
        } // RemoveElementFromTable

        
        // Команда для закрытия окна добавления неисправности
        private RelayCommand _closeWindowAddDefect;
        public RelayCommand CloseWindowAddDefect {
            get {
                return _closeWindowAddDefect ??
                    (_closeWindowAddDefect = new RelayCommand(obj => {
                        var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите отменить действие?\nДанные останутся в прежнем виде.");
                        if (resultQ == MessageBoxResult.Yes)
                            _iwind.CloseAddDefectWindow();
                    }));
            } // get
        } // CloseWindowAddDefect

        // Команда для закрытия окна добавления услуги
        private RelayCommand _closeWindowAddServices;
        public RelayCommand CloseWindowAddServices {
            get {
                return _closeWindowAddServices ??
                    (_closeWindowAddServices = new RelayCommand(obj => {
                        var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите отменить действие?\nДанные останутся в прежнем виде.");
                        if (resultQ == MessageBoxResult.Yes)
                            _iwind.CloseAddServicesWindow();
                    }));
            } // get
        } // CloseWindowAddServices

        // Команда для закрытия окна добавления сотрудника
        private RelayCommand _closeWindowAddEmployee;
        public RelayCommand CloseWindowAddEmployee {
            get {
                return _closeWindowAddEmployee ??
                    (_closeWindowAddEmployee = new RelayCommand(obj => {
                        var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите отменить действие?\nДанные останутся в прежнем виде.");
                        if (resultQ == MessageBoxResult.Yes)
                            _iwind.CloseAddEmployeeWindow();
                    }));
            } // get
        } // CloseWindowAddEmployee

        // Команда для закрытия окна редактирования клиента
        private RelayCommand _closeWindowEditClient;
        public RelayCommand CloseWindowEditClient {
            get {
                return _closeWindowEditClient ??
                    (_closeWindowEditClient = new RelayCommand(obj => {
                        var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите отменить действие?\nДанные останутся в прежнем виде.");
                        if (resultQ == MessageBoxResult.Yes)
                            _iwind.CloseEditClientWindow();
                    }));
            } // get
        } // CloseWindowEditClient 

        // Команда для закрытия окна редактирования владельца
        private RelayCommand _closeWindowEditOwner;
        public RelayCommand CloseWindowEditOwner {
            get {
                return _closeWindowEditOwner ??
                    (_closeWindowEditOwner = new RelayCommand(obj => {
                        // если закрытие происходит при простом редактировании, то закрыть
                        // А если редактирование происходит в следствии изменения статуса клиента *Владелец*,
                        // то отмена редактирования запрещена!
                        if (CurrentUserControl?.Name == "UC_Clients")
                            _iwind.ShowInfoMessage("Данное действие невозможно отменить!\nПожалуйста, заполните данные о новом владельце авто.");
                        else {
                            var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите отменить действие?\nДанные останутся в прежнем виде.");
                            if (resultQ == MessageBoxResult.Yes)
                                _iwind.CloseEditOwnerWindow();
                        }
                    }));
            } // get
        } // CloseWindowEditOwner

        // Команда для открытия окна редактирования владельца (используется при принудительном редактировании, 
        // когда клиент больше не является владельцем)
        private RelayCommand _showWindowEditOwner;
        public RelayCommand ShowWindowEditOwner {
            get {
                return _showWindowEditOwner ??
                    (_showWindowEditOwner = new RelayCommand(obj => _iwind.ShowEditOwnerWindow()));
            } // get
        } // ShowWindowEditOwner

        // Команда для закрытия окна редактирования автомобиля
        private RelayCommand _closeEditCarWindow;
        public RelayCommand CloseEditCarWindow {
            get {
                return _closeEditCarWindow ??
                    (_closeEditCarWindow = new RelayCommand(obj => {
                        var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите отменить действие?\nДанные останутся в прежнем виде.");
                        if (resultQ == MessageBoxResult.Yes)
                            _iwind.CloseEditCarWindow();
                    }));
            } // get
        } // CloseEditCarWindow

        // Команда для закрытия окна редактирования услуги
        private RelayCommand _closeEditServicesWindow;
        public RelayCommand CloseEditServiceWindow {
            get {
                return _closeEditServicesWindow ??
                    (_closeEditServicesWindow = new RelayCommand(obj => {
                        var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите отменить действие?\nДанные останутся в прежнем виде.");
                        if (resultQ == MessageBoxResult.Yes)
                            _iwind.CloseEditServicesWindow();
                    }));
            } // get
        } // CloseEditServiceWindow

        // Команда для закрытия окна редактирования сотрудника
        private RelayCommand _closeEditEmployeeWindow;
        public RelayCommand CloseEditEmployeeWindow {
            get {
                return _closeEditEmployeeWindow ??
                    (_closeEditEmployeeWindow = new RelayCommand(obj => {
                        var resultQ = _iwind.ShowConfirmationMessage("Вы уверены, что хотите отменить действие?\nДанные останутся в прежнем виде.");
                        if (resultQ == MessageBoxResult.Yes)
                            _iwind.CloseEditEmployeeWindow();
                    }));
            } // get
        } // CloseEditEmployeeWindow

        #region Работа с запросами

        // Текущий UserControl для ввода параметров к запросам
        private UserControl _currentParamsUC;
        public UserControl CurrentParamsUC {
            get => _currentParamsUC;
            set {
                _currentParamsUC = value;
                OnPropertyChanged("CurrentParamsUC");
            } // set
        } // CurrentParamsUC

        // Словарь содержащий информацию о запросах. Пары ключ-значение (Запрос - описание запроса)
        public Dictionary<string, string> QueriesCollection { get; set; }

        // Выбранный запрос - номер запроса
        private string _selectedQuery;
        public string SelectedQuery {
            get => _selectedQuery;
            set {
                _selectedQuery = value;
                
                // передаем описание выбранного запроса, свойству привязанному к экспандеру для вывода описания
                SelectedQueryDescription = QueriesCollection[SelectedQuery];

                if (SelectedQuery == "Запрос №1")
                    CurrentParamsUC = _iuc.ShowParamsToQuery1();
                else if (SelectedQuery == "Запрос №2")
                    CurrentParamsUC = _iuc.ShowParamsToQuery2();
                else if (SelectedQuery == "Запрос №3")
                    CurrentParamsUC = _iuc.ShowParamsToQuery2();
                else if (SelectedQuery == "Запрос №4")
                    CurrentParamsUC = _iuc.ShowParamsToQuery4();
                else if (SelectedQuery == "Запрос №5")
                    CurrentParamsUC = _iuc.ShowParamsToQuery5();
                else if (SelectedQuery == "Запрос №6")
                    CurrentParamsUC = _iuc.ShowParamsToQuery6();
                else if (SelectedQuery == "Запрос №7")
                    CurrentParamsUC = null;

                OnPropertyChanged("SelectedQuery");
            } // set
        } // SelectedQuery

        // Описание выбранного запроса 
        private string _selectedQueryDescription;
        public string SelectedQueryDescription {
            get => _selectedQueryDescription;
            set {
                _selectedQueryDescription = value;
                OnPropertyChanged("SelectedQueryDescription");
            } // set
        } // SelectedQueryDescription

        // Команда при клике на кнопку Запросы - откроет окно для работы с запросами
        private RelayCommand _showQueriesWindow;
        public RelayCommand ShowQueriesWindow {
            get {
                return _showQueriesWindow ??
                    (_showQueriesWindow = new RelayCommand(obj => {
                        // инициализируем словарь запросов
                        QueriesCollection = new Dictionary<string, string>() {
                            {"Запрос №1", "Фамилия, имя, отчество и адрес владельца автомобиля с данным номером государственной регистрации?"},
                            {"Запрос №2", "Марка и год выпуска автомобиля данного владельца?"},
                            {"Запрос №3", "Перечень устраненных неисправностей в автомобиле данного владельца?"},
                            {"Запрос №4", "Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения?"},
                            {"Запрос №5", "Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности?"},
                            {"Запрос №6", "Самая распространенная неисправность в автомобилях указанной марки?"},
                            {"Запрос №7", "Количество рабочих каждой специальности на станции?"},
                        };

                        // открываем окно для работы с запросами
                        _iwind.ShowQueriesWindow();
                    }));
            } // get
        } // ShowQueriesWindow

        // Команда для закрытия окна запросов
        private RelayCommand _closeQueriesWindow;
        public RelayCommand CloseQueriesWindow {
            get {
                return _closeQueriesWindow ??
                    (_closeQueriesWindow = new RelayCommand(obj => {
                        _iwind.CloseQueriesWindow();
                    }));
            } // get
        } // CloseQueriesWindow

        // коллекция для вывода результатов запросов
        // Выбран класс ArrayList, так как он может хранить разнотипные обьекты, что и требуется в данной ситуации
        private ArrayList _resultRequest;
        public ArrayList ResultRequest {
            get => _resultRequest;
            set {
                _resultRequest = value;
                OnPropertyChanged("ResultRequest");
            } // set
        } // ResultRequest

        // Команда при клике на кнопку Выполнить - выполняет выбранный запрос
        public string GovNumberToQuery { get; set; } // гос номер для запроса  №1
        public string CarMakeToQuery { get; set; } // марка авто для запроса №6

        private RelayCommand _executeRequest;
        public RelayCommand ExecuteRequest {
            get {
                return _executeRequest ??
                    (_executeRequest = new RelayCommand(obj => {
                        
                        ResultRequest = new ArrayList();

                        // Запрос №1
                        if (SelectedQuery == "Запрос №1" && !string.IsNullOrWhiteSpace(GovNumberToQuery)) {

                            // проверяем, есть ли авто с таким номером, как ввел пользователь
                            bool exist = CarsCollection.Select(o => o).Where(u => u.GovernmentNumber == GovNumberToQuery.ToUpper()).ToList().Count > 0;

                            if (exist) {
                                // получаем id владельца авто
                                int idOwner = CarsCollection.Select(o => o).Where(u => u.GovernmentNumber == GovNumberToQuery.ToUpper()).ToList()[0].idOwner;

                                // получаем обьект владельца
                                Owners owner = OwnersCollection.Select(o => o).Where(u => u.idOwner == idOwner).ToList()[0];

                                // добавляем его в коллекцию результатов
                                ResultRequest.Add(owner);
                            }
                            else
                                _iwind.ShowErrorMessage($"Авто с гос. номером \"{GovNumberToQuery}\" найти не удалось!\nПроверьте введенный Вами номер.");

                        }
                        // Запрос №2
                        else if (SelectedQuery == "Запрос №2" && SelectedOwner != null) {
                            // получаем авто выбранного владельца
                            Cars car = CarsCollection.Select(o => o).Where(u => u.idOwner == SelectedOwner.idOwner).First();

                            Dictionary<string, int> dictCarMakeYear = new Dictionary<string, int>() { { car.CarMake, car.YearOfCarManufacturer } };

                            // добавляем его в коллекцию результатов
                            ResultRequest.AddRange(dictCarMakeYear);
                        }
                        // Запрос №3
                        else if (SelectedQuery == "Запрос №3" && SelectedOwner != null) {

                            // получаем авто выбранного владельца
                            Cars car = CarsCollection.Select(o => o).Where(u => u.idOwner == SelectedOwner.idOwner).First();

                            // получаем неисправности авто данного владельца, у которых статус Устранено = true
                            var defects = CarsDefectsCollection.Select(o => o).Where(u => u.idCar == car.idCar && u.StatusW == true).ToList();

                            // добавляем в коллекцию результатов те неисправности
                            for (int i = 0; i < defects.Count; i++)
                                ResultRequest.Add(DefectsCollection.Select(o => o).Where(u => u.idDef == defects[i].idDefect).ToList()[0]);
                        }
                        // Запрос №4
                        else if (SelectedQuery == "Запрос №4" && SelectedDefect != null && SelectedClient != null) {
                            _iwind.ShowInfoMessage("К сожалению, при проектировании БД, упустил из виду потребность в закреплении опр. сотрудника, к опр. автомобилю... =(\nПоэтому, реализовать данный запрос - невозможно.");
                        }
                        // Запрос №5
                        else if (SelectedQuery == "Запрос №5" && SelectedDefect != null) {

                            // получаем авто с указанным видом неисправности
                            var cars = CarsDefectsCollection.Select(o => o).Where(u => u.idDefect == SelectedDefect.idDef).ToList();

                            // получаем клиентов сдавшего авто с указанным типом неисправности
                            for (int i = 0; i < cars.Count; i++) {
                                ResultRequest.Add(ClientsCollection.Select(o => o).Where(u => u.idCar == cars[i].idCar).ToList()[0]);
                            } // for

                        }
                        // Запрос №6
                        else if (SelectedQuery == "Запрос №6" && !string.IsNullOrWhiteSpace(CarMakeToQuery)) {

                            // получаем все обьекты авто с данной маркой
                            List<Cars> cars = CarsCollection.Select(o => o).Where(u => u.CarMake == CarMakeToQuery).ToList();

                            // коллекция неисправностей у данной марки авто
                            List<Defects> defects = new List<Defects>();

                            // id неисправности
                            int? idDefect = 0;

                            // выбираем все неисправности (как распространенные, так и не очень) у данной марки авто
                            foreach (var item in cars) {
                                // получаем id неисправности текущего элемента коллекции авто
                                idDefect = CarsDefectsCollection.Select(o => o).Where(u => u.idCar == item.idCar).ToList().First().idDefect;

                                // добавляем в коллекцию неисправностей авто данной марки, неисправность с id полученным выше
                                defects.AddRange(DefectsCollection.Select(o => o).Where(u => u.idDef == idDefect).ToList());

                            } // foreach

                            // создаем словарь с парой ключ-значение, в которой ключ - id неисправности, 
                            // а значение - количество встречающихся неисправностей с этим id
                            Dictionary<int, int> dictDefs = new Dictionary<int, int>();

                            // заполняем коллекцию ключей, id-шниками всех неисправностей
                            foreach (var item in DefectsCollection)
                                dictDefs.Add(item.idDef, 0);

                            // проходим по всей коллекции неисправностей данной марки авто
                            foreach (var item in defects) {
                                dictDefs[item.idDef]++; // увеличиваем значение (кол-во), для пары с ключом == item.idDef
                            }

                            int idTopDef = 0; // id Самой распространенной неисправности у данной марки авто

                            // ищем пару с максимальным значением
                            for (int i = 1; i < dictDefs.Count; i++) {
                                for (int j = i + 1; j < dictDefs.Count; j++) {
                                    if (dictDefs[i] > dictDefs[j])
                                        idTopDef = i;
                                    else
                                        idTopDef = j;
                                } // for j
                            } // for i

                            // добавляем в коллекцию результатов, неисправность с найденным id самой распространенной неисправности
                            ResultRequest.Add(DefectsCollection.Select(o => o).Where(u => u.idDef == idTopDef).ToList().First());
                        }
                        // Запрос №7
                        else if (SelectedQuery == "Запрос №7") {

                            // словарь с парой ключ-значение, где ключ - специальность, а значение - количество сотрудников
                            Dictionary<string, int> dictSpec = new Dictionary<string, int>();

                            // инициализируем коллекцию ключей словаря, коллекцией специальностей
                            foreach (var item in SpecialtiesCollection)
                                dictSpec.Add(item.TitleSpecialty, 0);

                            string titleSpec = null;
                            // проходим по всей коллекции сотрудников
                            foreach (var empl in EmployeesCollection) {
                                // получаем наименование специальности текущего сотрудника
                                titleSpec = SpecialtiesCollection.Select(o => o).Where(u => u.idSpecialty == empl.idSpecialty).ToList()[0].TitleSpecialty;

                                // увеличиваем значение в словаре, ключ которого равен titleSpec (наименованию специальности)
                                dictSpec[titleSpec]++;
                            } // foreach

                            ResultRequest.AddRange(dictSpec);
                        }
                        else
                            _iwind.ShowErrorMessage("Не выбран запрос для выполнения, либо не заполенны параметры!");
                    }));
            } // get
        } // ExecuteRequest

        #endregion

        #endregion

        #region Команды для контекстных меню

        #region Таблица клиентов
        public List<Cars> SelectedClientOwner_CarsCollection { get; set; } // перечень авто выбранного владельца или клиента
        public string TitleTableCars { get; set; }

        // Команда открывающая окно с перечнем авто, которые клиент сдавал когда либо в ремонт
        private RelayCommand _showListCarWindow;
        public RelayCommand ShowListCarWindow {
            get {
                return _showListCarWindow ??
                    (_showListCarWindow = new RelayCommand(obj => {
                        // если нужен перечень авто, которые сдавал выбранный клиент
                        if (CurrentUserControl?.Name == "UC_Clients" && SelectedClient != null) {
                            // инициализируем перечень авто выбранного клиента
                            SelectedClientOwner_CarsCollection = CarsCollection.Select(o => o).Where(u => u.idCar == SelectedClient.idCar).ToList();

                            // инициализируем заголовок таблицы
                            TitleTableCars = "Автомобили клиента";

                            // открываем таблицу с отобранными авто
                            _iwind.ShowListCarSC_Window();
                        }
                        else if (CurrentUserControl?.Name == "UC_Owners" && SelectedOwner != null) {
                            // инициализируем перечень авто выбранного владельца
                            SelectedClientOwner_CarsCollection = CarsCollection.Select(o => o).Where(u => u.idOwner == SelectedOwner.idOwner).ToList();

                            // инициализируем заголовок таблицы
                            TitleTableCars = "Автомобили владельца";

                            // открываем таблицу с отобранными авто
                            _iwind.ShowListCarSC_Window();
                        }
                        else
                            _iwind.ShowErrorMessage("Не выбран обьект, перечень авто которого, вы хотите увидеть!");
                    }));
            } // get
        } // ShowListCarWindow

        public List<Orders> SelectedClient_OrdersCollection { get; set; } // перечень заказов выбранного владельца

        // Команда открывающая окно с перечнем заказов, которые клиент когда либо оформлял
        private RelayCommand _showListOrdersWindow;
        public RelayCommand ShowListOrdersWindow {
            get {
                return _showListOrdersWindow ??
                    (_showListOrdersWindow = new RelayCommand(obj => {
                        if (SelectedClient != null) {

                            // инициализируем перечень заказов выбранного клиента
                            SelectedClient_OrdersCollection = OrdersCollection.Select(o => o).Where(u => u.idClient == SelectedClient.idClient).ToList();

                            // открываем таблицу с отобранными заказами
                            _iwind.ShowListOrdersSC_Window();
                        }
                        else
                            _iwind.ShowErrorMessage("Не выбран клиент, перечень заказов которого, вы хотите увидеть!");
                    }));
            } // get
        } // ShowListOrdersWindow

        // Команда для закрытия окна с перечнем авто, которые клиент сдавал когда либо в ремонт
        private RelayCommand _closeListCarWindow;
        public RelayCommand CloseListCarWindow {
            get {
                return _closeListCarWindow ??
                    (_closeListCarWindow = new RelayCommand(obj => {
                        _iwind.CloseListCarSC_Window();
                    }));
            } // get
        } // CloseListCarWindow 

        // Команда для закрытия окна с перечнем заказов, которые клиент когда либо оформлял
        private RelayCommand _closeListOrdersWindow;
        public RelayCommand CloseListOrdersWindow {
            get {
                return _closeListOrdersWindow ??
                    (_closeListOrdersWindow = new RelayCommand(obj => {
                        _iwind.CloseListOrdersSC_Window();
                    }));
            } // get
        } // CloseListOrdersWindow

        #endregion

        #region Таблица авто
        
        public List<CarsDefects> SelectedCar_DefectsCollection { get; set; } // перечень  неисправностей выбранного авто 
        
        private List<string> _titlesDefectsSelectedCar;
        public List<string> TitlesDefectsSelectedCar {
            get => _titlesDefectsSelectedCar;
            set {
                _titlesDefectsSelectedCar = value;
                OnPropertyChanged("TitlesDefectsSelectedCar");
            } // set
        } // TitlesDefectsSelectedCar 

        public int CountFinishDefect { get; set; }
        public decimal TotalSumForDefects { get; set; }
        private List<Servicess> ServicesForDefects { get; set; }

        // Команда открывающая окно с перечнем неисправностей выбранного автомобиля
        private RelayCommand _showListCarDefectsWindow;
        public RelayCommand ShowListCarDefectsWindow {
            get {
                return _showListCarDefectsWindow ??
                    (_showListCarDefectsWindow = new RelayCommand(obj => {
                        
                        if (SelectedCar != null) {
                            
                            ServicesForDefects = new List<Servicess>();
                            
                            // инициализируем перечень неисправностей выбранного авто
                            SelectedCar_DefectsCollection = CarsDefectsCollection.Select(o => o).Where(u => u.idCar == SelectedCar.idCar).ToList();
                            
                            // инициализируем наименования имеющихся неисправностей и затрагиваемые услуги
                            TitlesDefectsSelectedCar = new List<string>();
                            foreach (var item in SelectedCar_DefectsCollection) {
                                foreach (var item2 in DefectsCollection) {
                                    if (item.idDefect == item2.idDef) {
                                        TitlesDefectsSelectedCar.Add(item2.TitleDefect);
                                        ServicesForDefects.Add(ServicessesCollection.First(o => o.idService == item2.idService)); 
                                    } // if
                                } // foreach
                            } // foreach

                            // кол-во устраненных неисправностей
                            CountFinishDefect = SelectedCar_DefectsCollection.Select(o => o).Where(u => u.StatusW == true).ToList().Count;

                            // общая сумма к оплате, за устранение этих неисправностей
                            foreach (var item in ServicesForDefects)
                                TotalSumForDefects += item.Price;


                            // открываем окно с перечнем неисправностей выбранного авто
                            _iwind.ShowListDefectsSC_Window();
                        }
                        else
                            _iwind.ShowErrorMessage("Не выбран автомобиль, перечень неисправностей которого, хотите просмотреть.");
                        
                    }));
            } // get
        } // ShowListCarDefectsWindow

        // Команда закрывающая окно с перечнем неисправностей выбранного автомобиля
        private RelayCommand _closeListCarDefectsWindow;
        public RelayCommand CloseListCarDefectsWindow {
            get {
                return _closeListCarDefectsWindow ??
                    (_closeListCarDefectsWindow = new RelayCommand(obj => {
                        TotalSumForDefects = 0; // обнуляем общую сумму
                        _iwind.CloseListDefectsSC_Window();
                    }));
            } // get
        } // CloseListCarDefectsWindow

        // Команда открывающая окно с информацией о клиенте 
        private RelayCommand _showInfoAboutClientCar;
        public RelayCommand ShowInfoAboutClientCar {
            get {
                return _showInfoAboutClientCar ??
                    (_showInfoAboutClientCar = new RelayCommand(obj => {
                        SelectedClient = ClientsCollection.Select(o => o).Where(u => u.idCar == SelectedCar.idCar).ToList()[0];
                        _iwind.ShowInfoAboutClientSelectedCar();
                    }));
            } // get
        } // ShowInfoAboutClientCar 

        // Команда закрывающая окно с информацией о клиенте 
        private RelayCommand _closeInfoAboutClientCar;
        public RelayCommand CloseInfoAboutClientCar {
            get {
                return _closeInfoAboutClientCar ??
                    (_closeInfoAboutClientCar = new RelayCommand(obj => {
                        _iwind.CloseInfoAboutClientSelectedCar();
                    }));
            } // get
        } // CloseInfoAboutClientCar 


        // Команда открывающая окно с информацией о владельце
        private RelayCommand _showInfoAboutOwnerCar;
        public RelayCommand ShowInfoAboutOwnerCar {
            get {
                return _showInfoAboutOwnerCar ??
                    (_showInfoAboutOwnerCar = new RelayCommand(obj => {
                        SelectedOwner = OwnersCollection.Select(o => o).Where(u => u.idOwner == SelectedCar.idOwner).ToList()[0];
                        _iwind.ShowInfoAboutOwnerSelectedCar();
                    }));
            } // get
        } // ShowInfoAboutOwnerCar 

        // Команда закрывающая окно с информацией о владельце 
        private RelayCommand _closeInfoAboutOnwerCar;
        public RelayCommand CloseInfoAboutOwnerCar {
            get {
                return _closeInfoAboutOnwerCar ??
                    (_closeInfoAboutOnwerCar = new RelayCommand(obj => {
                        _iwind.CloseInfoAboutOwnerSelectedCar();
                    }));
            } // get
        } // CloseInfoAboutOwnerCar 

        #endregion

        #endregion

        #region Команды для раздела ЗАКАЗ

        // Команда при клике на кнопку меню Заказ -> Забрать - откроект View экрана для ввода данных о заказе
        private RelayCommand _openPickUpOrderScreen;
        public RelayCommand OpenPickUpOrderScreen {
            get {
                return _openPickUpOrderScreen ??
                    (_openPickUpOrderScreen = new RelayCommand(obj => {
                        CurrentPage = _ipage.ShowPagePickUpOrder();
                    }));
            } // get
        } // OpenPickUpOrderScreen

        // Команда при клике на кнопку меню Заказ -> Заказать - откроет View экрана для оформления заказа
        private RelayCommand _openCheckoutScreen;
        public RelayCommand OpenCheckoutScreen {
            get {
                return _openCheckoutScreen ??
                    (_openCheckoutScreen = new RelayCommand(obj => {
                        ClearFieldsetClientOwner(); // очищает свойства привязанные к полям ввода данных
                        CurrentPage = _ipage.ShowPageCheckoutScreen();
                    }));
            } // get
        } // OpenCheckoutScreen

        // Команда при клике на кнопку Далее во View оформления заказа - откроет View для заполнения
        // данных об авто
        private RelayCommand _openCheckoutCarScreen;
        public RelayCommand OpenCheckoutCarScreen {
            get {
                return _openCheckoutCarScreen ??
                    (_openCheckoutCarScreen = new RelayCommand(obj => {
                        // создаем экземпляр коллекции неисправностей для данного авто
                        DefectsNewCar = new ObservableCollection<Defects>(); 
                        
                        // если клиент является владельцем, то все его данные присваиваем полям для ввода данных о владельце
                        if (NewClient_isOwner) {
                            SurnameNewOwner = SurnameNewClient;
                            NameNewOwner = NameNewClient;
                            PatronymicNewOwner = PatronymicNewClient;
                            RegistrationNewOwner = RegistrationNewClient;
                            DateOfBirthday_NewOwner = DateOfBirthday_NewClient;
                        } // if

                        // если хотябы одно поле пустое - ругаемся
                        if (
                        string.IsNullOrWhiteSpace(SurnameNewClient) ||
                        string.IsNullOrWhiteSpace(NameNewClient) ||
                        string.IsNullOrWhiteSpace(PatronymicNewClient) ||
                        string.IsNullOrWhiteSpace(RegistrationNewClient) ||
                        string.IsNullOrWhiteSpace(DateOfBirthday_NewClient.ToString()) ||
                        string.IsNullOrWhiteSpace(SurnameNewOwner) ||
                        string.IsNullOrWhiteSpace(NameNewOwner) ||
                        string.IsNullOrWhiteSpace(PatronymicNewOwner) ||
                        string.IsNullOrWhiteSpace(RegistrationNewOwner) ||
                        string.IsNullOrWhiteSpace(DateOfBirthday_NewOwner.ToString())
                        ) {
                            _iwind.ShowErrorMessage("Не все поля для ввода данных заполнены!\nПожалуйста, заполните все поля для ввода. Без данных нельзя оформить заказ!");
                            return;
                        } // if

                        CurrentPage = _ipage.ShowPageInputDataCarScreen();
                    }));
            } // get
        } // OpenCheckoutCarScreen 

        // Команда при клике на кнопку Добавит неисправность, при заполнении данных об авто - 
        // откроет диалог для выбора неисправностей
        private RelayCommand _openSelectDefectsWindow;
        public RelayCommand OpenSelectDefectsWindow {
            get {
                return _openSelectDefectsWindow ??
                    (_openSelectDefectsWindow = new RelayCommand(obj => {
                        _iwind.ShowSelectDefectsWindow();
                    }));
            } // get
        } // OpenSelectDefectsWindow 

        // Метод для очистки всех полей ввода о клиенте и владельце
        private void ClearFieldsetClientOwner() {
            CarMake_NewCar = null;
            Color_NewCar = null;
            GovernmNum_NewCar = null;
            TotalPriceSumOrder = 0;
            SelectedDefect = null;
            SurnameNewOwner = null;
            SurnameNewClient = null;
            NameNewOwner = null;
            NameNewClient = null;
            PatronymicNewOwner = null;
            PatronymicNewClient = null;
            RegistrationNewOwner = null;
            RegistrationNewClient = null;
        } // ClearFieldsetClientOwner


        // Метод для создания нового обьекта клиента - вернет готовый обьект с заполненными данными
        public string SurnameNewClient { get; set; } // фамилия
        public string NameNewClient { get; set; } // имя
        public string PatronymicNewClient { get; set; } // отчество
        public string RegistrationNewClient { get; set; } // прописка
        public DateTime DateOfBirthday_NewClient { get; set; } = DateTime.Parse("01/01/1990"); // дата рождения

        // свойство отвечающее за доступность к полям заполнения данных о владельце
        private bool _enableOwnerFieldset;
        public bool EnableOwnerFieldset {
            get => _enableOwnerFieldset;
            set {
                _enableOwnerFieldset = value;
                OnPropertyChanged("EnableOwnerFieldset");
            } // set
        } // EnableOwnerFieldset

        // свойство для всплывающей подсказки в области полей для заполнения данных о владельце
        // оповещает пользователя о том, что если область недоступна, значит все данные клиента
        // будут добавлены и обьекту владельца, поэтому заполнять данные нет смысла
        static private string messageToolTip = "Заполнять эти данные не нужно!\nКлиент является владельцем, поэтому все его данные добавятся и к записи владельца. \nДаже если вы видите в этих полях какие-то данные, не переживайте, они игнорируются.";
        private string _toolTipForOwnerFieldset = messageToolTip;
        public string ToolTipForOwnerFieldset {
            get => _toolTipForOwnerFieldset;
            set {
                _toolTipForOwnerFieldset = value;
                OnPropertyChanged("ToolTipForOwnerFieldset");
            } // set
        } // ToolTipForOwnerFieldset

        // владелец ли клиент
        private bool _newClient_isOwner = true;
        public bool NewClient_isOwner {
            get => _newClient_isOwner;
            set {
                _newClient_isOwner = value;

                // если клиент владелец, то делаем недоступной для редактирования форму
                // заполнения данных о владельце, и присваиваем полям владельца данные из полей клиента
                if (value == true) {
                    EnableOwnerFieldset = false;
                    ToolTipForOwnerFieldset = messageToolTip;
                }
                else {
                    EnableOwnerFieldset = true;
                    ToolTipForOwnerFieldset = null;
                }

                OnPropertyChanged("NewClient_isOwner");
            } // set
        } // NewClient_isOwner 

        private Clients CreateNewClient(int idCarClient) {
            Clients newClient = new Clients();
            newClient.idClient = ClientsCollection.Last().idClient + 1;
            newClient.SurnameClient = SurnameNewClient;
            newClient.NameClient = NameNewClient;
            newClient.PatronymicClient = PatronymicNewClient;
            newClient.Registration = RegistrationNewClient;
            newClient.DateOfApplication = DateTime.Now;
            newClient.isOwner = NewClient_isOwner;
            newClient.idCar = idCarClient;
            newClient.DateOfBirthday = DateOfBirthday_NewClient;
            return newClient;
        } // AddNewClient

        // Метод для создания нового обьекта владельца - вернет готовый обьект с заполненными данными
        public string SurnameNewOwner { get; set; } // фамилия
        public string NameNewOwner { get; set; } // имя
        public string PatronymicNewOwner { get; set; } // отчество
        public string RegistrationNewOwner { get; set; } // прописка
        public DateTime DateOfBirthday_NewOwner { get; set; } = DateTime.Parse("01/01/1990"); // дата рождения

        private Owners CreateNewOwner() {
            Owners newOwner = new Owners();
            newOwner.idOwner = OwnersCollection.Last().idOwner + 1;
            newOwner.SurnameOwner = SurnameNewOwner;
            newOwner.NameOwner = NameNewOwner;
            newOwner.PatronymicOwner = PatronymicNewOwner;
            newOwner.Registration = RegistrationNewOwner;
            newOwner.DateOfApplication = DateTime.Now;
            newOwner.DateOfBirthday = DateOfBirthday_NewOwner;
            return newOwner;
        } // CreateNewOwner

        // Метод для создания нового обьекта авто - вернет готовый обьект с заполненными данными
        public string CarMake_NewCar { get; set; } // марка
        public string Color_NewCar { get; set; } // цвет
        public int YearOfM_NewCar { get; set; } = 1955; // год выпуска
        public string GovernmNum_NewCar { get; set; } // гос. номер

        private Cars CreateNewCar(int idOwner) {
            Cars newCar = new Cars();
            newCar.idCar = CarsCollection.Last().idCar + 1;
            newCar.CarMake = CarMake_NewCar;
            newCar.Color = Color_NewCar;
            newCar.YearOfCarManufacturer = YearOfM_NewCar;
            newCar.GovernmentNumber = GovernmNum_NewCar.ToUpper();
            newCar.idOwner = idOwner;
            return newCar;
        } // CreateNewCar

        // Метод для создания нового обьекта сущности CarsDefects - вернет готовый обьект с заполненными данными
        // Добавит неисправности к авто
        int workHoursOrder = 0;
        private void AddCarDefects(ObservableCollection<Defects> defects, int idNewCar) {
            workHoursOrder = 0;
            foreach (var item in defects) {
                CarsDefectsCollection.Add(new CarsDefects() { id = CarsDefectsCollection.Last().id + 1, idDefect = item.idDef, idCar = idNewCar, StatusW = false });
                context.CarsDefects.Add(new CarsDefects() { id = CarsDefectsCollection.Last().id + 1, idDefect = item.idDef, idCar = idNewCar, StatusW = false });
                workHoursOrder += ServicessesCollection.Select(o => o).Where(u => u.idService == item.idService).ToList()[0].WorkingHours;
            } // foreach
        } // AddCarDefects

        // Метод для формирования коллекции неисправностей данного авто
        private ObservableCollection<Defects> _defectsNewCar; // коллекция хранящая неисправности оформляемого авто
        public ObservableCollection<Defects> DefectsNewCar {
            get => _defectsNewCar;
            set {
                _defectsNewCar = value;
                OnPropertyChanged("DefectsNewCar");
            } // set
        } // DefectsNewCar 

        // Свойство общей суммы заказа
        private decimal _totalPriceSumOrder;
        public decimal TotalPriceSumOrder {
            get => _totalPriceSumOrder;
            set {
                _totalPriceSumOrder = value;
                OnPropertyChanged("TotalPriceSumOrder");
            } // set
        } // TotalPriceSumOrder

        // Команда для добавления неисправностей к авто
        private RelayCommand _addDefectToDefsCollectionThisCar;
        public RelayCommand AddDefectToDefsCollectionThisCar {
            get {
                return _addDefectToDefsCollectionThisCar ??
                    (_addDefectToDefsCollectionThisCar = new RelayCommand(obj => {
                        
                        if(SelectedDefect == null) {
                            _iwind.ShowErrorMessage("Не выбран элемент добавления!");
                            return;
                        } // if

                        if (!DefectsNewCar.Contains(SelectedDefect)) {
                            DefectsNewCar.Add(SelectedDefect);
                            TotalPriceSumOrder += ServicessesCollection.Select(o => o).Where(u => u.idService == SelectedDefect.idService).ToList()[0].Price;
                        }
                        else
                            _iwind.ShowInfoMessage("Эта неисправность уже добавлена в список.");
                    }));
            } // get
        } // AddDefectToDefsCollectionThisCar 

        // Команда для подтверждения заказа
        private RelayCommand _confirmTheOrder;
        public RelayCommand ConfirmTheOrder {
            get {
                return _confirmTheOrder ??
                    (_confirmTheOrder = new RelayCommand(obj => {
                        
                        // проверяем заполнены ли поля ввода данных об авто 
                        if (string.IsNullOrWhiteSpace(CarMake_NewCar) ||
                        string.IsNullOrWhiteSpace(Color_NewCar) ||
                        YearOfM_NewCar <= 1950 ||
                        string.IsNullOrWhiteSpace(GovernmNum_NewCar)
                        ) {
                            _iwind.ShowErrorMessage("Невозможно подтвердить заказ!\nНе все поля заполнены!");
                            return;
                        } // if

                        // проверяем не пуста ли коллекция неисправностей
                        if(DefectsNewCar == null || DefectsNewCar.Count <= 0) {
                            _iwind.ShowErrorMessage("Невозможно подтвердить заказ!\nВы не добавили ни одной неисправности!");
                            return;
                        } // if

                        // проверяем поле гос.номера, если оно меньше или больше 8-знаков - ругаем
                        if(GovernmNum_NewCar.Length < 8 || GovernmNum_NewCar.Length > 8) {
                            _iwind.ShowErrorMessage("Подтверждение заказа отменено!\nВведенный Вами гос. номер не соответствует требованиям!\nГос. номер не более 8-ми знаков. Пример : AH0000KA");
                            return;
                        } // if

                        // просим повторно подтвердить заказ, и тогда сохранить все данные
                        // если же пользователь передумает, забываем о данных и ничего с ними не делаем
                        var resultConf = _iwind.ShowConfirmationMessage("Пока данные еще в обработке, вы можете отменить заказ.\nУверены в подтверждении заказа?");
                        if (resultConf == MessageBoxResult.Yes) {
                            
                            // добавляем владельца
                            Owners newOwner = CreateNewOwner();
                            OwnersCollection.Add(newOwner);
                            context.Owners.Add(newOwner);

                            // Добавляем авто
                            Cars newCar = CreateNewCar(newOwner.idOwner);
                            CarsCollection.Add(newCar);
                            context.Cars.Add(newCar);

                            // Добавляем неисправности к авто
                            AddCarDefects(DefectsNewCar, newCar.idCar);

                            // Добавляем клиента
                            Clients newClient = CreateNewClient(newCar.idCar);
                            ClientsCollection.Add(newClient);
                            context.Clients.Add(newClient);

                            // Добавляем новый заказ
                            Orders newOrder = new Orders();
                            newOrder.idOrder = OrdersCollection.Last().idOrder + 1;
                            newOrder.idClient = newClient.idClient;
                            newOrder.TotalPrice = TotalPriceSumOrder;
                            newOrder.WorkingHours = workHoursOrder;
                            newOrder.Stat = false;
                            OrdersCollection.Add(newOrder);
                            context.Orders.Add(newOrder);

                            // Сохраняем данные о заказе в БД
                            context.SaveChanges();

                            // поздравляем с оформлением заказа
                            _iwind.ShowInfoMessage($"Поздравляем с успешно оформленным заказом!\nВскоре Вы сможете забрать Ваше авто, предоставив код заказа : {newOrder.idOrder}");
                            CurrentPage = _ipage.ShowPageMainScreen();
                        }
                        else {
                            _iwind.ShowInfoMessage("Заказ отменен.\nСпасибо, что передумали - отдохнем! =)");
                            CurrentPage = _ipage.ShowPageMainScreen();
                        } // if/else
                        
                    }));
            } // get
        } // ConfirmTheOrder

        // Данные для выдачи авто клиенту 
        private int _numberOrder;
        public int NumberOrder {
            get => _numberOrder;
            set {
                _numberOrder = value;
                OnPropertyChanged("NumberOrder");
            } // set
        } // NumberOrder

        // Команда осуществляющая возвращение авто клиенту
        private RelayCommand _takeOfCarToClient;
        public RelayCommand TakeOfCarToClient {
            get {
                return _takeOfCarToClient ??
                    (_takeOfCarToClient = new RelayCommand(obj => {
                        
                        if (NumberOrder >= 1 && OrdersCollection.Contains(OrdersCollection.Select(o => o).Where(u => u.idOrder == NumberOrder).ToList()[0])) {
                            _iwind.ShowInfoMessage($"{ClientsCollection.Select(o => o).Where(u => u.idClient == OrdersCollection.Select(d => d).Where(f => f.idOrder == NumberOrder).ToList()[0].idClient).ToList().First()}, Ваше авто на заднем дворе =)\nСпасибо!");
                            OrdersCollection.Select(d => d).Where(f => f.idOrder == NumberOrder).ToList()[0].Stat = true;
                            context.Orders.Select(d => d).Where(f => f.idOrder == NumberOrder).ToList()[0].Stat = true;
                            
                            var defects = CarsDefectsCollection.Select(o => o).Where(u => u.idCar == ClientsCollection.Select(o => o).Where(v => v.idClient == OrdersCollection.Select(d => d).Where(f => f.idOrder == NumberOrder).ToList()[0].idClient).ToList().First().idCar);
                            foreach (var item in defects)
                                item.StatusW = true;

                            context.SaveChanges();
                            CurrentPage = _ipage.ShowPageMainScreen();
                        }
                        else
                            _iwind.ShowErrorMessage("Заказа с таким номером нет!\nПроверьте правильность введенного номера.");
                    }));
            } // get
        } // TakeOfCarToClient


        #endregion

        // ------------- Реализация интерфейса INotifyPropertyChanged ---------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } // try/catch
        } // OnPropertyChanged

    } // ApplicationViewModel 

} // CourseWork_Samolevich.ViewModels 
