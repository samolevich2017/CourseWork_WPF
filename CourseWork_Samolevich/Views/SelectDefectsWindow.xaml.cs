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

namespace CourseWork_Samolevich.Views {
    /// <summary>
    /// Логика взаимодействия для SelectDefectsWindow.xaml
    /// </summary>
    public partial class SelectDefectsWindow : Window {
        public SelectDefectsWindow() {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
