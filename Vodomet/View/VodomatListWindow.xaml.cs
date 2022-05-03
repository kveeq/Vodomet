using System.Windows;
using System.Collections.Generic;
using Vodomet.Model;
using System.Windows.Controls;

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
            Button button = new Button();
            button.Width = 100;
            button.Height = 50;
            button.Background = btn1.Background;
            button.Content = "123";
            List<Vodomat> lst = new List<Vodomat>() { new Vodomat() { Id = 1, Address = "qwerty" , Button = button}, new Vodomat() { Id = 2, Address = "qwerty2" }, new Vodomat() { Id = 3, Address = "qwerty3" } };
            VodomatLstView.ItemsSource = lst;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            VodomatSettingsPage vodomatSettingsPage = new VodomatSettingsPage();
            vodomatSettingsPage.Show();
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var qq = sender as ListView;
            var vodomat = ((Vodomat)qq.SelectedItem);
            MessageBox.Show(vodomat.Address);
            VodomatSettingsPage vodomatSettingsPage = new VodomatSettingsPage() { vodomat = vodomat};
            vodomatSettingsPage.Show();
        }
    }
}