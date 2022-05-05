using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodomet.Model
{
    public class User
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int IdRole { get; set; }
        public string Fio { get; set; }
        public static event Action<string>? UnSuccessLogin;
        public Action<string>? Tankist;

        public static void LogIn(string login, string pass)
        {
            string sqlExpression = $"Select * FROM Role ua Join Auth a ON a.IdRole = ua.Id Join dbo.Users u On u.Id = a.IdUser Where Login = '{login}' AND Password = '{pass}'";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader(); 

                User? user = null;
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new User();
                        user.Id = int.Parse(reader.GetValue(6)?.ToString());
                        user.IdRole = int.Parse(reader.GetValue(2).ToString());
                        user.Role = reader.GetValue(1).ToString();
                        user.Login = reader.GetValue(4).ToString();
                        user.Password = reader.GetValue(5).ToString();
                        user.Name = reader.GetValue(7).ToString();
                        user.Surname = reader.GetValue(8).ToString();
                        user.Patronymic = reader.GetValue(9).ToString();
                        user.Email = reader.GetValue(10).ToString();
                        user.PhoneNumber = reader.GetValue(11).ToString();
                    }
                }

                reader.Close();
                if (user != null)
                    App.user = user;
                else
                    UnSuccessLogin?.Invoke("Не удачный вход!");
            }
        }

        public static ICollection<User> GetUsers()
        {
            string sqlExpression = $"Select * FROM Role ua Join Auth a ON a.IdRole = ua.Id Join dbo.Users u On u.Id = a.IdUser";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                User? user = null;
                List<User> users = new List<User>();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new User();
                        user.Id = int.Parse(reader.GetValue(6)?.ToString());
                        user.Role = reader.GetValue(1).ToString();
                        user.Login = reader.GetValue(4).ToString();
                        user.Password = reader.GetValue(5).ToString();
                        user.Name = reader.GetValue(7).ToString();
                        user.Surname = reader.GetValue(8).ToString();
                        user.Patronymic = reader.GetValue(9).ToString();
                        user.Email = reader.GetValue(10).ToString();
                        user.PhoneNumber = reader.GetValue(11).ToString();
                        user.IdRole = Convert.ToInt32(reader.GetValue(2).ToString());
                        user.Fio = user.Name + " " + user.Surname + " " + user.Patronymic;
                        users.Add(user);
                    }
                }

                reader.Close();
                return users;
            }
        }

        public void Update()
        {
            string sqlExpression = $"Update Users Set Name = '{Name}', Surname = '{Surname}', Patronymic = '{Patronymic}' Where Id = {Id} Update Role Set Name = '{Role}'";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }

            Tankist?.Invoke("Обновление завершено успешно!");
        }

        private int GetId()
        {
            string sqlExpression = $"Select r.Id from Auth a Join Role r on a.IdRole = r.Id Where a.IdUser = {Id}";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()) // если есть данные
                    {
                        return int.Parse(reader.GetValue(0).ToString());
                    }
                }
            }

            return 0;
        }
    }
}
