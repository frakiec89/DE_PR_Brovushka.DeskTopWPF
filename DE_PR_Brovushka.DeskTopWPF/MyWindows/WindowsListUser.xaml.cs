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
    /// Логика взаимодействия для WindowsListUser.xaml
    /// </summary>
    public partial class WindowsListUser : Window
    {
        public WindowsListUser()
        {
            InitializeComponent();

            Loaded += WindowsListUser_Loaded;
        }

        private void WindowsListUser_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                listBoxUser.ItemsSource = Service.UserService.GetUser(0, 20);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
