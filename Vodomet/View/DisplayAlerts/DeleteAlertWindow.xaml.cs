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
    public partial class DeleteAlertWindow : Window
    {
        Collector collector;
        public DeleteAlertWindow(Collector coll)
        {
            InitializeComponent();
            collector = coll;
            lbl.Text = $"Вы действительно хотите удалить коллектора {coll.CollectorName}";
        }

        private void Delete()
        {
            string sqlExpression = $"DELETE FROM Collector WHERE Id = {collector.Id}";

            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }

            collector.Tankist?.Invoke("Коллектор удален!");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (App.user.IdRole == 1)
            {
                Delete();
                this.Close();
            }
            else
            {
                collector.Tankist.Invoke("Может удалять только админ");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
