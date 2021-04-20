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

namespace CourseWork_Samolevich.Views.TablesUserControls.WindowForShowMoreInfo.UC_ParametrsQuery {
    /// <summary>
    /// Логика взаимодействия для UC_Query_2.xaml
    /// </summary>
    public partial class UC_Query_2 : UserControl {
        public UC_Query_2() {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }
    }
}
