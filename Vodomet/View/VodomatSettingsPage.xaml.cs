using System.Windows;
using Vodomet.Model;

namespace Vodomet.View
{
    /// <summary>
    /// Логика взаимодействия для VodomatSettingsPage.xaml
    /// </summary>
    public partial class VodomatSettingsPage : Window
    {
        public Vodomat vodomat;
        public VodomatSettingsPage()
        {
            InitializeComponent();
        }

        private void SaveSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные сохранены!");
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}