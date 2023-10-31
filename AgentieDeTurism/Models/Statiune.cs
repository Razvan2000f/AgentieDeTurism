using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Models
{
    public class Statiune
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public DateTime DataDeInceput { get; set; }
        public DateTime DataDeSfarsit { get; set; }
    }
}
