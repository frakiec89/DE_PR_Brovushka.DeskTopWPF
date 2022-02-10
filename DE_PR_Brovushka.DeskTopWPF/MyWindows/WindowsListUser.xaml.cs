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
                cbSort.ItemsSource = Service.SortContentServise.SortUser();
                cbSort.SelectedIndex = 0;
                cbFilter.ItemsSource = Service.SortContentServise.FiltreUser();
                cbFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btEnd_Click(object sender, RoutedEventArgs e)
        {
            MyWindows.WindowsAdmin windowsAdmin = new MyWindows.WindowsAdmin();
            windowsAdmin.Show();
            Close();
        }

        private void btAddUser_Click(object sender, RoutedEventArgs e)
        {
            MyWindows.AddUser addUser = new MyWindows.AddUser();  
            addUser.Show();
            Close();
        }

        private void listBoxUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var user = listBoxUser.SelectedItem as DB.User;
            if (user != null)
            {
              var windows =  new MyWindows.WindowChangeUser(user);
                windows.Show();
                Close();
            }
        }
    }
}
