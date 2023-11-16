using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Services
{
    public class StatiuneService : IStatiuneService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StatiuneService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddStatiune(string nume, string dataDeInceput, string dataDeSfarsit)
        {
            Statiune statiune = new Statiune()
            {
                Nume = nume
            };

            AddPerioada(statiune, dataDeInceput, dataDeSfarsit);
        }

        public ICollection<Statiune> GetAllStatiuni()
        {
            var query = _repositoryWrapper.StatiuneRepository.FindAll();
            ICollection<Statiune> statiuni = query.ToList();
            return statiuni;
        }

        public void AddPerioada(Statiune statiune, string dataDeInceput, string dataDeSfarsit)
        {
            Sejur sejur = new Sejur()
            {
                Statiune = statiune,
                StatiuneID = statiune.ID,
                DataDeInceput = dataDeInceput,
                DataDeSfarsit = dataDeSfarsit
            };

            _repositoryWrapper.SejurRepository.Update(sejur);
            _repositoryWrapper.Save();
        }

        public ICollection<Tuple<string, string>> GetPerioadeStatiune(Statiune statiune)
        {
            var query = _repositoryWrapper.SejurRepository.FindAll();
            ICollection<Sejur> sejururi = query.ToList();

            ICollection<Tuple<string, string>> perioade = new List<Tuple<string, string>>();

            foreach (Sejur sejur in sejururi)
            {
                string dataDeInceput=sejur.DataDeInceput;
                string dataDeSfarsit = sejur.DataDeSfarsit;

                Tuple<string, string> perioada=new Tuple<string, string>(dataDeSfarsit, dataDeInceput);

                perioade.Add(perioada);
            }

            return perioade;
        }
    }
}
