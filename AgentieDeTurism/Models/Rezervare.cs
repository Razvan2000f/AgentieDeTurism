using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Models
{
    //many to many relationship between client and sejur
    public class Rezervare
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int SejurID { get; set; }
    }
}
