using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;


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
        }

        private void WindowChangeUser_Loaded(object sender, RoutedEventArgs e)
        {
           tbName.Text = User.Name;
           tbPasswor.Text = User.Password;
           var content  = Service.UserTypeService.GetTypeService();
           cbTypeUser.ItemsSource = content;
           cbTypeUser.SelectedIndex = cbTypeUser.Items.IndexOf(content.Single(x=>x.DepartmentID==User.DepartmentID));
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
                Service.UserService.ChangeUser(User);
                MessageBox.Show("Пользователь  обнавлен в бд");
               
                MyWindows.WindowsListUser windowsListUser = new MyWindows.WindowsListUser();
                windowsListUser.Show();
                Close();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }

           

        }
    }
}
