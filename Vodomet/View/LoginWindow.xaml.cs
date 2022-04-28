using System.Windows;
using Vodomet.Model;

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
            User.UnSuccessLogin += LogIn;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.LogIn(txtLogin.Text, txtPass.Password);
            if (App.user != null)
            {
                VodomatListWindow vodomatListWindow = new VodomatListWindow();
                vodomatListWindow.Show();
                this.Close();
            }
        }

        private void LogIn(string mess)
        {
            MessageBox.Show(mess);
        }
    }
}