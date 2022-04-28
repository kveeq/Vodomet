using System.Windows;

namespace Vodomet.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VodomatListWindow vodomatListWindow = new VodomatListWindow();
            vodomatListWindow.Show();
            this.Close();
        }
    }
}
