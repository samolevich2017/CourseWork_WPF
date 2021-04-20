using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using CourseWork_Samolevich.Services;
using System.Configuration;

namespace CourseWork_Samolevich {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public ApplicationViewModel _viewModel;
        public MainWindow() {
            InitializeComponent();
        } // MainWindow

        // Событие загрузки окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = new ApplicationViewModel(new PageShowService(), new WindowShowService(), new UserControlShowService());
            DataContext = _viewModel;
        }

        #region Обработчики событий для элементов меню

        // Событие клика по кнопке открытия меню
        private void buttonOpenMenu_Click(object sender, RoutedEventArgs e) {
            // скрыть кнопку для открытия
            buttonOpenMenu.Visibility = Visibility.Collapsed;
            // показать кнопку для закрытия
            buttonCloseMenu.Visibility = Visibility.Visible;
        } // buttonOpenMenu_Click

        // Событие клика по кнопке закрытия меню
        private void buttonCloseMenu_Click(object sender, RoutedEventArgs e) {
            // показать кнопку для открытия
            buttonOpenMenu.Visibility = Visibility.Visible;
            // скрыть кнопку для закрытия
            buttonCloseMenu.Visibility = Visibility.Collapsed;
        } // buttonOpenMenu_Click

        
        // Событие клика по кнопке меню - Выйти (завершает работу приложения)
        private void btnExit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        #endregion

    } // method MainWindow
} // class MainWindow
