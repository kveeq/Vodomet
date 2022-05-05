using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodomet.Model
{
    public class AquaAccountHistory
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public int VodomatId { get; set; }
        public double AddCash { get; set; }
        public double AddBankCard { get; set; }
        public double Writedown { get; set; }
        public double Litres { get; set; }
        public double Bonus { get; set; }
        public double Balance { get; set; }

        public static ICollection<AquaAccountHistory> GetAquaAccountHistory()
        {
            string sqlExpression = "Select * from AquaAccountHistory a Join AquaAccount aa On a.IdAquaAccount = aa.Id";
            using (SqlConnection connection = new(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                AquaAccountHistory? user = null;
                List<AquaAccountHistory> vodomats = new();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new AquaAccountHistory();
                        user.Id = int.Parse(reader.GetValue(0).ToString());
                        user.VodomatId = Convert.ToInt32(reader.GetValue(1));
                        user.Date = Convert.ToDateTime(reader.GetValue(2).ToString());
                        user.AddCash = Convert.ToDouble(reader.GetValue(3));
                        user.AddBankCard = Convert.ToInt32(reader.GetValue(4));
                        user.Writedown = Convert.ToDouble(reader.GetValue(5));
                        user.Litres = Convert.ToDouble(reader.GetValue(6).ToString());
                        user.Balance = Convert.ToDouble(reader.GetValue(10).ToString());
                        user.Bonus = Convert.ToDouble(reader.GetValue(11).ToString());
                        vodomats.Add(user);
                    }
                }

                reader.Close();
                return vodomats;
            }
        }
    }
}