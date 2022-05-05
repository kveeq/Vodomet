using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodomet.Model
{
    public class AquaAccount
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Password { get; set; }
        public double Price { get; set; }
        public double Balance { get;set; }
        public double Bonus { get; set; }
        public double AddedBonus { get; set; }
        public int Group { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Fio { get; set; }


        public static ICollection<AquaAccount> GetAquaUsers()
        {
            string sqlExpression = $"Select * FROM AquaAccount";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                AquaAccount? user = null;
                List<AquaAccount> users = new List<AquaAccount>();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new AquaAccount();
                        user.Id = int.Parse(reader.GetValue(0).ToString());
                        user.Password = Convert.ToInt32(reader.GetValue(1).ToString());
                        user.Price = Convert.ToDouble(reader.GetValue(2).ToString());
                        user.Balance = Convert.ToDouble(reader.GetValue(3).ToString());
                        user.Bonus = Convert.ToDouble(reader.GetValue(4).ToString());
                        user.AddedBonus = Convert.ToDouble(reader.GetValue(5).ToString());
                        user.Group = Convert.ToInt32(reader.GetValue(6).ToString());
                        user.Name = reader.GetValue(7).ToString();
                        user.Surname = reader.GetValue(8).ToString();
                        user.PhoneNumber = reader.GetValue(9).ToString();
                        user.Fio = user.Name + " " + user.Surname;
                        users.Add(user);
                    }
                }

                reader.Close();
                return users;
            }
        }
    }
}
