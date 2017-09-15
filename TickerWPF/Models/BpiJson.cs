using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickerWPF.Models
{
    public class BpiJson
    {
        public Time time { get; set; }
        public string disclaimer { get; set; }
        public string chartName { get; set; }
        public Bpi bpi { get; set; }
    }
    public class Bpi
    {
        public USD USD { get; set; }
    }

    public class Time
    {
        public string updated { get; set; }
        public DateTime updatedISO { get; set; }
        public string updateduk { get; set; }
    }

    public class USD
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public decimal rate { get; set; }
        public string description { get; set; }
        public decimal rate_float { get; set; }
    }
}
