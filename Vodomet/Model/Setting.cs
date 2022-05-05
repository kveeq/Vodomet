using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodomet.Model
{
    public class Setting
    {
        public int Id { get; set; }
        public int DrebezgId { get; set; }
        public int RecoveryId { get; set; }
        public int TriggeringId { get; set; }
        public int NotificationId { get; set; }
        public int PulsePerLitre { get; set; }
        public int MaxLitres { get; set; }
        public int CoinRatio { get; set; }
        public int BanknoteRatio { get; set; }
        public string APN { get; set; }
        public string SIMNumber { get; set; }
        public int TimeOfShowKeysBalance { get; set; }
        public bool FreeWaterDeliveryMode { get; set; }
        public Action<string> Tankist;

        public static Setting GetSetting(int Id)
        {
            string sqlExpression = $"Select * from Setting where Id = {Id}";
            using (SqlConnection connection = new(App.connectionString))
            {
                connection.Open();

                SqlCommand command = new(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                Setting? user = null;

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        user = new Setting();
                        user.Id = int.Parse(reader.GetValue(0).ToString());
                        user.DrebezgId = int.Parse(reader.GetValue(1).ToString());
                        user.RecoveryId = Convert.ToInt32(reader.GetValue(2));
                        user.TriggeringId = Convert.ToInt32(reader.GetValue(3));
                        user.NotificationId = Convert.ToInt32(reader.GetValue(4));
                        user.PulsePerLitre = Convert.ToInt32(reader.GetValue(5));
                        user.MaxLitres = Convert.ToInt32(reader.GetValue(6).ToString());
                        user.CoinRatio = Convert.ToInt32(reader.GetValue(7).ToString());
                        user.BanknoteRatio = Convert.ToInt32(reader.GetValue(8).ToString());
                        user.APN = reader.GetValue(9).ToString();
                        user.SIMNumber = reader.GetValue(10).ToString();
                        user.TimeOfShowKeysBalance = Convert.ToInt32(reader.GetValue(11).ToString());
                        user.FreeWaterDeliveryMode = Convert.ToBoolean(reader.GetValue(12).ToString());
                    }
                }

                reader.Close();
                return user;

            }
        }

        public void Update()
        {
            string sqlExpression = $"Update Setting Set PulsePerLitre = '{PulsePerLitre}', MaxLitres = '{MaxLitres}', CoinRatio = '{CoinRatio}', BanknoteRatio = '{BanknoteRatio}', APN = '{APN}', SIMNumber = '{SIMNumber}', TimeOfShowKeysBalance = '{TimeOfShowKeysBalance}', FreeWaterDeliveryMode = '{FreeWaterDeliveryMode}' Where Id = {Id} ";
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