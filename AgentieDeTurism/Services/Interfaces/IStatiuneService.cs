using AgentieDeTurism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Services.Interfaces
{
    public interface IStatiuneService
    {
        void AddPerioada(Statiune statiune, string dataDeInceput, string dataDeSfarsit);
        void AddStatiune(string nume, string dataDeInceput, string dataDeSfarsit);
        ICollection<Sejur> GetAllSejururi();
        ICollection<Statiune> GetAllStatiuni();
        ICollection<Statiune> GetAllStatiuniPerioada(string dataDeInceput, string dataDeSfarsit);
        ICollection<Tuple<string, string>> GetPerioadeStatiune(Statiune statiune);
        Sejur GetSejurByID(int sejurId);
        Sejur GetSejurByPerioada(string dataDeInceput, string dataDeSfarsit);
        Statiune GetStatiuneByID(int id);
    }
}
