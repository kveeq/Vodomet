using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodomet.Model
{
    public class Collector
    {
        public DateTime Date { get; set; }
        public string? IdKey { get; set; }
        public string? CollectorName { get; set; }
        public string? comment { get; set; }
        public bool? Permission { get; set; }
    }
}
