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
using System.Windows.Shapes;

namespace CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo {
    /// <summary>
    /// Логика взаимодействия для InfoAboutOwnerSelectedCar.xaml
    /// </summary>
    public partial class InfoAboutOwnerSelectedCar : Window {
        public InfoAboutOwnerSelectedCar() {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }
    }
}
