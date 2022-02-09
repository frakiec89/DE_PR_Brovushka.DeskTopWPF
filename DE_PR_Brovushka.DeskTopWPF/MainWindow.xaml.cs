using Microsoft.EntityFrameworkCore;
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

namespace DE_PR_Brovushka.DeskTopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Service.AuthenticationService.IsTry(tbName.Text, tbPasswor.Text))
                {
                    switch (Service.AuthenticationService.GetUserType(tbName.Text, tbPasswor.Text))
                    {
                        case "Admin": RunAdmin(); break;
                        case "Гость": RunUSer(); break;
                        default: MessageBox.Show("Ошибка в роле пользователя"); break;
                    }
                }
                else
                {
                    MessageBox.Show("Невенрный логин  или  пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RunUSer()
        {
          MyWindows.WindowUser windowUser = new MyWindows.WindowUser();
            windowUser.Show();  
            this.Close();   
        }

        private void RunAdmin()
        {
            MyWindows.WindowsAdmin windowUser = new MyWindows.WindowsAdmin();
            windowUser.Show();
            this.Close();
        }
    }
}
