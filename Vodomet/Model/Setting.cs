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
        public string Name { get; set; }
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
    }
}