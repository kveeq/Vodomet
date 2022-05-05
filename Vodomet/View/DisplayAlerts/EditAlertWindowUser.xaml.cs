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
using Vodomet.Model;

namespace Vodomet.View.DisplayAlerts
{
    /// <summary>
    /// Логика взаимодействия для EditAlertWindow.xaml
    /// </summary>
    public partial class EditAlertWindowUser : Window
    {
        public User user1;
        public EditAlertWindowUser(User user)
        {
            InitializeComponent();
            user1 = user;
            cmbBoxRoles.ItemsSource = new List<string>() { "Администратор","Бухгалтер"};
            this.DataContext = user;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.user.IdRole == 1)
            {
                user1.Update();
            }
            else
            {
                user1.Tankist.Invoke("Может редактировать только администратор");
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
