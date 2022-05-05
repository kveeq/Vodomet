using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodomet.Model
{
    public class BonusHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AddedBonus { get; set; }
        public DateTime Date {  get; set; }
        public int Group { get; set; }


        public static ICollection<BonusHistory> GetAquaUsers()
        {
            string sqlExpression = $"Select * from BonusHistory b join AquaAccount a On b.IdAquaAccount = a.Id";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                BonusHistory? user = null;
                List<BonusHistory> users = new List<BonusHistory>();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new BonusHistory();
                        user.Id = int.Parse(reader.GetValue(0).ToString());
                        user.Date = Convert.ToDateTime(reader.GetValue(1).ToString());
                        user.AddedBonus = Convert.ToDouble(reader.GetValue(2).ToString());
                        user.Group = Convert.ToInt32(reader.GetValue(10).ToString());
                        user.Name = reader.GetValue(11).ToString() + " " + reader.GetValue(12).ToString();
                        users.Add(user);
                    }
                }

                reader.Close();
                return users;
            }
        }
    }
}
