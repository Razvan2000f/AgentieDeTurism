using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AgentieDeTurism.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IStatiuneService _statiuneService;

        public ClientService(IRepositoryWrapper repositoryWrapper, IStatiuneService statiuneService)
        {
            _repositoryWrapper = repositoryWrapper;
            _statiuneService = statiuneService;
        }

        public void AddClient(string nume, string prenume, string numarCI, string serieCI, string strada, string numar, string telefon)
        {
            //create client object
            Client client = new Client()
            {
                Nume = nume,
                Prenume = prenume,
                NumarCI = numarCI,
                SerieCI = serieCI,
                Adresa = strada + " " + numar,
                Telefon = telefon,
            };

            //add to the db
            _repositoryWrapper.ClientRepository.Create(client);
            _repositoryWrapper.Save();
        }

        public void AddRezervare(Client client, Sejur sejur)
        {
            //create rezervare
            Rezervare rezervare = new Rezervare()
            {
                ClientID = client.ID,
                SejurID = sejur.ID,
            };

            //add to the db
            _repositoryWrapper.RezervareRepository.Create(rezervare);
            _repositoryWrapper.Save();
        }

        public ICollection<Client> GetAllClientiPerioada(string dataDeInceput, string dataDeSfarsit)
        {
            ICollection<Client> clientiInPeriodaa = new List<Client>();
            
            //get list of clients
            ICollection<Client> clienti = GetAllClients();

            //iterate through the list
            foreach (Client client in clienti)
            {
                //for each client check if there are any rezevations made
                ICollection<Tuple<string, string>> perioade = GetRezervareClient(client);

                //filter list such that the time intervals match
                foreach (var perioada in perioade)
                {
                    //if both dates match then we add it to the list
                    if (perioada.Item1 == dataDeInceput && perioada.Item2 == dataDeSfarsit)
                    {
                        clientiInPeriodaa.Add(client);
                        break;
                    }
                }
            }

            return clientiInPeriodaa;
        }

        public ICollection<Tuple<string, string>> GetRezervareClient(Client client)
        {
            //get all reservations of a client
            ICollection<Rezervare> rezervari = _repositoryWrapper.RezervareRepository.FindByID(client.ID);

            ICollection<Tuple<string, string>> perioade = new List<Tuple<string, string>>();

            //extract start and end date for a reservation
            foreach (int sejurID in rezervari.Select(rezervare => rezervare.SejurID))
            {
                Sejur sejur = _statiuneService.GetSejurByID(sejurID);
                string dataDeInceput = sejur.DataDeInceput;
                string dataDeSfarsit = sejur.DataDeSfarsit;

                //create new start and end date pair
                Tuple<string, string> perioada = new Tuple<string, string>(dataDeInceput, dataDeSfarsit);

                perioade.Add(perioada);
            }
            
            //order list based on starting date
            return perioade.OrderBy(perioada => perioada.Item1).ToList();
        }

        public ICollection<Client> GetAllClients()
        {
            var query = _repositoryWrapper.ClientRepository.FindAll();
            ICollection<Client> clienti = query.ToList();
            return clienti;
        }
    }
}
