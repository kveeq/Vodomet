using Microsoft.Data.SqlClient;
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
    /// Логика взаимодействия для DeleteAlertWindow.xaml
    /// </summary>
    public partial class DeleteAlertWindowUser : Window
    {
        User user1;
        public DeleteAlertWindowUser(User user)
        {
            InitializeComponent();
            user1 = user;
            lbl.Text = $"Вы действительно хотите удалить пользователя {user.Name} {user.Surname}";
        }

        private void Delete()
        {
            string sqlExpression = $"DELETE FROM Auth WHERE IdUser = {user1.Id} DELETE FROM Users WHERE Id = {user1.Id}";

            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }

            user1.Tankist?.Invoke("Пользователь удален!");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (user1.Id != App.user.Id && App.user.IdRole == 1)
            {
                Delete();
                this.Close();
            }
            else
            {
                user1.Tankist.Invoke("Нельзя удалить самого себя (Может удалять только админ)");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
