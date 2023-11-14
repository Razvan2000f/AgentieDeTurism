using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string NumarCI { get; set; }
        public string SerieCI { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string DataDeInceput { get; set; }
        public string DataDeSfarsit { get; set; }
        public int StatiuneaDorita { get; set; }
    }
}
