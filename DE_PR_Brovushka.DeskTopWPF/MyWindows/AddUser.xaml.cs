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
    /// Логика  взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            this.Loaded += AddUser_Loaded;
            Closing += AddUser_Closed;
        }

        private void AddUser_Closed(object? sender, EventArgs e)
        {
            MyWindows.WindowsListUser w = new MyWindows.WindowsListUser();
            w.Show();
        }

        private void AddUser_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cbTypeUser.ItemsSource = Service.UserTypeService.GetTypeService();
                ImageUser.Source = new BitmapImage(new Uri(new DB.User().PathImage ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            if (cbTypeUser.SelectedItem != null)
            {
                var ustype = cbTypeUser.SelectedItem as DB.Department;
                if (ustype != null)
                {
                    try
                    {
                        Service.UserService.AddUser(tbName.Text, tbPasswor.Text, ustype , ImageUser.Source);
                        MessageBox.Show("Пользователь добавлен в бд");
                        Close();  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Укажите роль пользователя");
            }
        }

        private void ImageUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyWindows.WindowImage image = new WindowImage();
            if( image.ShowDialog()==true )
            {
                ImageUser.Source = new BitmapImage(image.PathSelect);
            }
        }
    }
}
