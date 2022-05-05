using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodomet.Model
{
    public class CollectionHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int VodomatId { get; set; }
        public string Address { get; set; }
        public double CollectSum { get; set; }
        public double WriteDown { get; set; }
        public double AmountSum { get; set; }

        public static ICollection<CollectionHistory> GetCollectionHistory()
        {
            string sqlExpression = $"Select * From CollectionHistory ch Join Collector c On ch.IdCollector = c.Id Join Vodomat v On v.Id = ch.IdVodomat";
            using (SqlConnection connection = new SqlConnection(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                CollectionHistory? user = null;
                List<CollectionHistory> users = new List<CollectionHistory>();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new CollectionHistory();
                        user.Id = int.Parse(reader.GetValue(0).ToString());
                        user.Date = Convert.ToDateTime(reader.GetValue(6).ToString());
                        user.VodomatId = Convert.ToInt32(reader.GetValue(1).ToString());
                        user.Address = reader.GetValue(12).ToString();
                        user.CollectSum = Convert.ToDouble(reader.GetValue(2).ToString());
                        user.WriteDown = Convert.ToDouble(reader.GetValue(3).ToString());
                        user.AmountSum = Convert.ToDouble(reader.GetValue(4).ToString());
                        user.Name = reader.GetValue(7).ToString() + " " + reader.GetValue(8).ToString();
                        users.Add(user);
                    }
                }

                reader.Close();
                return users;
            }
        }
    }
}