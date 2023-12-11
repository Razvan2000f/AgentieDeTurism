using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Models
{
    public class Sejur
    {
        public int ID { get; set; }
        public string DataDeInceput { get; set; } = "";
        public string DataDeSfarsit { get; set; } = "";
        public int StatiuneID { get; set; }
    }
}
