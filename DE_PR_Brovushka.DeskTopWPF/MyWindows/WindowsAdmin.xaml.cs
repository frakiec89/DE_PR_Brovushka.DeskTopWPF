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

namespace DE_PR_Brovushka.DeskTopWPF.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для WindowsAdmin.xaml
    /// </summary>
    public partial class WindowsAdmin : Window
    {
        public WindowsAdmin()
        {
            InitializeComponent();
        }

        private void btListUser_Click(object sender, RoutedEventArgs e)
        {
            MyWindows.WindowsListUser windowsListUser = new MyWindows.WindowsListUser();
            windowsListUser.Show(); 
            Close();    
        }
    }
}
