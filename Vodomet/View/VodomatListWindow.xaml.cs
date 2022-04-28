using System.Windows;
using System.Collections.Generic;
using Vodomet.Model;

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
            List<Vodomat> lst = new List<Vodomat>() { new Vodomat() { Id = 1, Address = "qwerty" }, new Vodomat() { Id = 2, Address = "qwerty2" }, new Vodomat() { Id = 3, Address = "qwerty3" } };
            VodomatLstView.ItemsSource = lst;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            VodomatSettingsPage vodomatSettingsPage = new VodomatSettingsPage();
            vodomatSettingsPage.Show();
        }
    }
}