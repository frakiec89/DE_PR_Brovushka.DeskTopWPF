using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DE_PR_Brovushka.DeskTopWPF.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для WindowChangeUser.xaml
    /// </summary>
    public partial class WindowChangeUser : Window
    {

        DB.User User = null;
        public WindowChangeUser(DB.User user)
        {
            InitializeComponent();
            User=user;
            this.Loaded += WindowChangeUser_Loaded;
            Closing += WindowChangeUser_Closed;
        }

        private void WindowChangeUser_Closed(object? sender, EventArgs e)
        {
            MyWindows.WindowsListUser w = new MyWindows.WindowsListUser();
            w.Show();
        }

        private void WindowChangeUser_Loaded(object sender, RoutedEventArgs e)
        {
            tbName.Text = User.Name;
            tbPasswor.Text = User.Password;
            var content = Service.UserTypeService.GetTypeService();
            cbTypeUser.ItemsSource = content;
            cbTypeUser.SelectedIndex = cbTypeUser.Items.IndexOf(content.Single(x => x.DepartmentID == User.DepartmentID));
            ImageUser.Source = new BitmapImage(new Uri( User.PathImage));
        }

        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User.Name = tbName.Text;
                User.Password = tbPasswor.Text;
                var d = cbTypeUser.SelectedItem as DB.Department;
                if (d != null)
                {
                    User.Department = d;
                }
                User.PathImage = ImageUser.Source.ToString();
                Service.UserService.ChangeUser(User);
                MessageBox.Show("Пользователь  обновлен в бд");
             
                Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void btDell_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены"  , "предупреждение" , MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                Service.UserService.DellUser(User);
                MessageBox.Show("Пользователь  Удален из бд");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void ImageUser_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MyWindows.WindowImage image = new MyWindows.WindowImage();
            if( image.ShowDialog()== true)
            {
                ImageUser.Source = new BitmapImage(image.PathSelect);
            }
        }
    }
}
