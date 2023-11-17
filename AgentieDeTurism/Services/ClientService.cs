using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Services
{
    public class ClientService:IClientService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ClientService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void AddClient(string nume, string prenume, string numarCI, string serieCI, string strada, string numar, string telefon, string dataDeInceput, string dataDeSfarsit, int idStatiune)
        {
            Client client = new Client()
            {
                Nume = nume,
                Prenume = prenume,
                NumarCI = numarCI,
                SerieCI = serieCI,
                Adresa = strada + " " + numar,
                Telefon= telefon,
                DataDeInceput = dataDeInceput,
                DataDeSfarsit = dataDeSfarsit,
                StatiuneaDorita = idStatiune
            };

            _repositoryWrapper.ClientRepository.Create(client);
            _repositoryWrapper.Save();
        }
    }
}
