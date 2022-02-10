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
    /// Логика взаимодействия для WindowImage.xaml
    /// </summary>
    public partial class WindowImage : Window
    {
        public WindowImage()
        {
            InitializeComponent();
            Loaded += WindowImage_Loaded;
        }

        public Uri PathSelect { get; internal set; }

        private void WindowImage_Loaded(object sender, RoutedEventArgs e)
        {
            imageList.ItemsSource = Service.ImageService.AllImageUrl();
        }

        private void imageList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var image = imageList.SelectedItem as Model.ImageUsercs;
            if (image != null)
            {
                PathSelect = new Uri(image.Path);
                DialogResult = true;
                Close();
            }
        }
    }
}
