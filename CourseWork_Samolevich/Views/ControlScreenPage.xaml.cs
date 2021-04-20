using CourseWork_Samolevich.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork_Samolevich.Views {
    /// <summary>
    /// Логика взаимодействия для ControlScreenPage.xaml
    /// </summary>
    public partial class ControlScreenPage : Page {
        public ControlScreenPage() {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }
    }
}
