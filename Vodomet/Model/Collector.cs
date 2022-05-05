using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodomet.Model
{
    public class Collector
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? CollectorName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Comment { get; set; }
        public string Permission { get; set; }
        public bool IsChecked { get => Permission == "Разрешено"; set => Permission = value ? "Разрешено": "Запрещено"; }
        public Action<string> Tankist; 


        public static ICollection<Collector> GetCollectors()
        {
            string sqlExpression = $"Select * FROM Collector";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                Collector? user = null;
                List<Collector> result = new List<Collector>();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new Collector();
                        user.Id = int.Parse(reader.GetValue(0)?.ToString());
                        user.Date = Convert.ToDateTime(reader.GetValue(1).ToString());
                        user.Name = reader.GetValue(2).ToString();
                        user.Surname = reader.GetValue(3).ToString();
                        user.CollectorName = user.Name + " " + user.Surname;
                        user.Comment= reader.GetValue(4).ToString();
                        var a = Convert.ToBoolean(reader.GetValue(5).ToString());
                        user.Permission = a ? "Разрешено" : "Запрещено";
                        result.Add(user);
                    }
                }

                reader.Close();
                return result;
            }
        }

        public void Update()
        {
            string sqlExpression = $"Update Collector Set Name = '{Name}', Surname = '{Surname}', Comment = '{Comment}', Permission = '{IsChecked}' Where Id = {Id} ";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
            
            Tankist?.Invoke("Обновление завершено успешно!");
        }
    }
}
