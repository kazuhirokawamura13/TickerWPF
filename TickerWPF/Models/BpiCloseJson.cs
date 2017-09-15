using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TickerWPF.Models
{
    public class BpiCloseJson
    {
        public object bpi { get; set; }
        public string disclaimer { get; set; }
        public CloseTime time { get; set; }
    }

    public class CloseTime
    {
        public string updated { get; set; }
        public DateTime updatedISO { get; set; }
    }

}
