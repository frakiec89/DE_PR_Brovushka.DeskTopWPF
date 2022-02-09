﻿using System;
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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            this.Loaded += AddUser_Loaded;
        }

        private void AddUser_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cbTypeUser.ItemsSource = Service.UserTypeService.GetTypeService();
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
                        Service.UserService.AddUser(tbName.Text, tbPasswor.Text, ustype);
                        MessageBox.Show("Пользователь добавлен в бд");
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
    }
}