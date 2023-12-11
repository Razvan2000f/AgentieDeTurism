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
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StatiuneService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddStatiune(string nume, string dataDeInceput, string dataDeSfarsit)
        {
            //create new statiune
            Statiune statiune = new Statiune()
            {
                Nume = nume
            };

            //add to the db the statiune
            _repositoryWrapper.StatiuneRepository.Create(statiune);
            _repositoryWrapper.Save();
            
            //add a perioada to the stations
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
            //create new sejur
            Sejur sejur = new Sejur()
            {
                StatiuneID = statiune.ID,
                DataDeInceput = dataDeInceput,
                DataDeSfarsit = dataDeSfarsit
            };

            //add the sejur to the db
            _repositoryWrapper.SejurRepository.Create(sejur);
            _repositoryWrapper.Save();
        }

        public ICollection<Tuple<string, string>> GetPerioadeStatiune(Statiune statiune)
        {
            //get all sejur based on a statiune
            ICollection<Sejur> sejururi = _repositoryWrapper.SejurRepository.FindByID(statiune.ID);

            ICollection<Tuple<string, string>> perioade = new List<Tuple<string, string>>();

            //extract start and end time
            foreach (Sejur sejur in sejururi)
            {
                string dataDeInceput = sejur.DataDeInceput;
                string dataDeSfarsit = sejur.DataDeSfarsit;

                Tuple<string, string> perioada = new Tuple<string, string>(dataDeInceput, dataDeSfarsit);

                perioade.Add(perioada);
            }

            //order list based on the start date
            return perioade.OrderBy(perioada => perioada.Item1).ToList();
        }

        public ICollection<Statiune> GetAllStatiuniPerioada(string dataDeInceput, string dataDeSfarsit)
        {
            //create empty list to store all statiuni that are available on a certain period
            ICollection<Statiune> statiuniInPerioada = new List<Statiune>();

            //retrieve all statiuni
            ICollection<Statiune> statiuni = GetAllStatiuni();
            //iterate through the list to filter the statiuni
            foreach (Statiune statiune in statiuni)
            {
                //get all available periods for a statiune
                ICollection<Tuple<string, string>> perioade = GetPerioadeStatiune(statiune);
                //check all periods for the statiune
                foreach (var perioada in perioade)
                {
                    //if the dates match then we can add the statiune to the list
                    if (perioada.Item1 == dataDeInceput && perioada.Item2 == dataDeSfarsit)
                    {
                        statiuniInPerioada.Add(statiune);
                        break;
                    }
                }
            }

            return statiuniInPerioada;
        }

        public ICollection<Sejur> GetAllSejururi()
        {
            var query = _repositoryWrapper.SejurRepository.FindAll();
            ICollection<Sejur> sejururi = query.ToList();
            return sejururi;
        }

        public Statiune GetStatiuneByID(int id)
        {
            Statiune statiune = _repositoryWrapper.StatiuneRepository.FindById(id);
            return statiune;
        }

        public Sejur GetSejurByPerioada(string dataDeInceput, string dataDeSfarsit)
        {
            List<Sejur> sejururi = (List<Sejur>)GetAllSejururi();

            //filter the list based on the start and end date
            sejururi = sejururi.Where(sejur => sejur.DataDeInceput == dataDeInceput && sejur.DataDeSfarsit == dataDeSfarsit).ToList();
            return sejururi[0];
        }

        public Sejur GetSejurByID(int sejurId)
        {
            Sejur sejur=_repositoryWrapper.SejurRepository.FindByID(sejurId).ToList()[0];
            return sejur;
        }
    }
}
