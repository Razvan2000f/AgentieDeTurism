using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Services.Interfaces
{
    public interface IStatiuneService
    {
        void AddStatiune(string nume, string dataDeInceput, string dataDeSfarsit);
    }
}
