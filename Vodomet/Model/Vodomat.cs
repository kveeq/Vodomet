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

        public Vodomat(string address, double kopilka, double amountLitres, int pO, DateOnly hit, DateOnly lowWater, DateTime noWater, DateOnly fullTank, DateOnly clag, DateOnly temp, DateOnly no220B, DateOnly mDB, DateOnly pC)
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

        public int Id { get; set; }
        public string Address { get; set; }
        public double Kopilka { get; set; }
        public double AmountLitres { get; set; }
        public int PO { get; set; }
        public DateOnly Hit { get; set; }
        public DateOnly LowWater { get; set; }
        public DateTime NoWater { get; set; }
        public DateOnly FullTank { get; set; }
        public DateOnly Clag { get; set; }
        public DateOnly Temp { get; set; }
        public DateOnly No220B { get; set; }
        public DateOnly MDB { get; set; }
        public DateOnly PC { get; set; }
        public Button Button { get; set; }

        public Setting Settings { get; set; }

    }
}
