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
            List<Vodomat> lst = Vodomat.GetVodomats();
            VodomatLstView.ItemsSource = lst;
            List<Collector> list = new() { new Collector() { CollectorName = "ff"}, new Collector() { CollectorName = "ff"},  };
            CollectorsLstView.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            VodomatSettingsPage vodomatSettingsPage = new VodomatSettingsPage();
            vodomatSettingsPage.Show();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vodomat = (Vodomat)(sender as ListView).SelectedItem;
            MessageBox.Show(vodomat.Address);
            VodomatSettingsPage vodomatSettingsPage = new VodomatSettingsPage() { vodomat = vodomat};
            vodomatSettingsPage.Show();
        }
    }
}