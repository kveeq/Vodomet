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

namespace Vodomet.View
{
    /// <summary>
    /// Логика взаимодействия для VodomatListWindow.xaml
    /// </summary>
    public partial class VodomatListWindow : Window
    {
        public VodomatListWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VodomatSettingsPage vodomatSettingsPage = new VodomatSettingsPage();
            vodomatSettingsPage.Show();
        }
    }
}
