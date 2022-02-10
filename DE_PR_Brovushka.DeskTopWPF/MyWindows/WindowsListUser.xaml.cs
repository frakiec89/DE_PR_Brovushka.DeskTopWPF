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

        List<DB.User> users = new List<DB.User>(); // старт  контент

        public WindowsListUser()
        {
            InitializeComponent();

            Loaded += WindowsListUser_Loaded;
        }

        private async void  WindowsListUser_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                users = await  Service.UserService.GetUser(0, 20);
                listBoxUser.ItemsSource = users;
                cbSort.ItemsSource = Service.SortContentServise.SortUser();
                cbSort.SelectedIndex = 0;
                cbFilter.ItemsSource = Service.SortContentServise.FiltreUser();
                cbFilter.SelectedIndex = 0;
                cbSort.SelectionChanged += CbSort_SelectionChanged;
                tbSourse.TextChanged += TbSourse_TextChanged;
                cbFilter.SelectionChanged += CbFilter_SelectionChanged;
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

        private void TbSourse_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            cbSort.SelectedIndex=0;

            if (string.IsNullOrWhiteSpace(tbSourse.Text))
            {
                listBoxUser.ItemsSource = users;
                return;
            }

            var content = new List<DB.User>();
            content.AddRange(users);
            if (content != null)
                listBoxUser.ItemsSource = content.Where
                    (  (x=>  x.Name.ToLower().
                    Contains(tbSourse.Text.ToLower()))
                    );

            return;
        }


        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbSourse.Clear();
            cbFilter.SelectedIndex = 0; 
            if (cbSort.SelectedIndex == 0)
            {
                listBoxUser.ItemsSource = users;
                return;
            }

            //грязно  
            if (cbSort.SelectedIndex == 1) // по  пользователю
            {
                var content = new List<DB.User>();
                content.AddRange(users);
                if (content != null)
                    listBoxUser.ItemsSource = content.OrderBy(x => x.Name);
                
                return;
            }

            //грязно  
            if (cbSort.SelectedIndex == 2) // по  пользователю
            {
                var content = new List<DB.User>();
                content.AddRange(users);
                if (content != null)
                    listBoxUser.ItemsSource = content.OrderByDescending(x => x.Name);

                return;
            }

            //грязно  
            if (cbSort.SelectedIndex == 3) // по  пользователю
            {
                var content = new List<DB.User>();
                content.AddRange(users);
                if (content != null)
                    listBoxUser.ItemsSource = content.OrderBy(x => x.DepartmentID);

                return;
            }
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbSourse.Clear();
            cbSort.SelectedIndex = 0;
            if (cbFilter.SelectedIndex == 0)
            {
                listBoxUser.ItemsSource = users;
                return;
            }

            //грязно  
            if (cbFilter.SelectedIndex == 1) // Админов
            {
                var content = new List<DB.User>();
                content.AddRange(users);
                if (content != null)
                    listBoxUser.ItemsSource = content.Where(x=>x.DepartmentID==1);

                return;
            }


            //грязно  
            if (cbFilter.SelectedIndex == 2) // гостй
            {
                var content = new List<DB.User>();
                content.AddRange(users);
                if (content != null)
                    listBoxUser.ItemsSource = content.Where(x => x.DepartmentID == 2);

                return;
            }

        }


    }
}
