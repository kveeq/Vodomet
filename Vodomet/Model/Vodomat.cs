using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vodomet.Model
{
    public class Vodomat
    {
        public Vodomat()
        {
        }

        public Vodomat(string address, double kopilka, double amountLitres, int pO, DateTime hit, DateTime lowWater, DateTime noWater, DateTime fullTank, DateTime clag, DateTime temp, DateTime no220B, DateTime mDB, DateTime pC)
        {
            Address = address;
            Kopilka = kopilka;
            AmountLitres = amountLitres;
            PO = pO;
            Hit = hit;
            LowWater = lowWater;
            NoWater = noWater;
            FullTank = fullTank;
            Clag = clag;
            Temp = temp;
            No220B = no220B;
            MDB = mDB;
            PC = pC;
        }

        public int? Id { get; set; }
        public string? Address { get; set; }
        public double? Kopilka { get; set; }
        public double? AmountLitres { get; set; }
        public int PO { get; set; }
        public DateTime Hit { get; set; }
        public DateTime LowWater { get; set; }
        public DateTime NoWater { get; set; }
        public DateTime FullTank { get; set; }
        public DateTime Clag { get; set; }
        public DateTime Temp { get; set; }
        public DateTime No220B { get; set; }
        public DateTime MDB { get; set; }
        public DateTime PC { get; set; }

        public Setting? Settings { get; set; }
        public int IdSettings { get; set; }
        public string? FirmWareVersion { get; set; }
        public int IdMarketing { get; set; }


        public static List<Vodomat> GetVodomats()
        {
            string sqlExpression = $"SELECT * FROM Vodomat";
            using (SqlConnection connection = new(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                Vodomat? user = null;
                List<Vodomat> vodomats = new();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new Vodomat();
                        user.Id = int.Parse(reader.GetValue(0).ToString());
                        user.Address = reader.GetValue(1).ToString();
                        user.Kopilka = Convert.ToDouble(reader.GetValue(2));
                        user.AmountLitres = Convert.ToDouble(reader.GetValue(3));
                        user.PO = Convert.ToInt32(reader.GetValue(4));
                        user.Hit = Convert.ToDateTime(reader.GetValue(5));
                        user.LowWater = Convert.ToDateTime(reader.GetValue(6).ToString());
                        user.NoWater = Convert.ToDateTime(reader.GetValue(7).ToString());
                        user.FullTank = Convert.ToDateTime(reader.GetValue(8).ToString());
                        user.Clag = Convert.ToDateTime(reader.GetValue(9).ToString());
                        user.Temp = Convert.ToDateTime(reader.GetValue(10).ToString());
                        user.No220B = Convert.ToDateTime(reader.GetValue(11).ToString());
                        user.MDB = Convert.ToDateTime(reader.GetValue(12).ToString());
                        user.PC = Convert.ToDateTime(reader.GetValue(13).ToString());
                        user.IdSettings = Convert.ToInt32(reader.GetValue(14).ToString());
                        user.FirmWareVersion = reader.GetValue(15).ToString();
                        user.IdMarketing = Convert.ToInt32(reader.GetValue(16).ToString());
                        vodomats.Add(user);
                    }
                }

                reader.Close();
                return vodomats;
            }
        }
    }
}
