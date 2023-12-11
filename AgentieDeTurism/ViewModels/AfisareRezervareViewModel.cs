using AgentieDeTurism.Core;
using AgentieDeTurism.Models;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.ViewModels
{
    public class AfisareRezervareViewModel:ViewModel
    {
        private readonly IClientService _clientService;
        public ObservableCollection<string> Clienti { get; set; } = new ObservableCollection<string>();

        //filter clients on value set for both start and end date
        private string _dataDeInceput = "";
        public string DataDeInceput
        {
            get { return _dataDeInceput; }
            set { _dataDeInceput = value; GetPerioadaClienti(); }
        }

        private string _dataDeSfarsit = "";
        public string DataDeSfarsit
        {
            get { return _dataDeSfarsit; }
            set { _dataDeSfarsit = value; GetPerioadaClienti(); }
        }

        public AfisareRezervareViewModel(IStatiuneService statiuneService, IClientService clientService)
        {
            _clientService = clientService;
            GetClienti();
        }

        private void GetClienti()
        {
            ICollection<Client> clienti = _clientService.GetAllClients();
            SetClienti(clienti); 
        }


        //function to be called when a period changes to filter clients
        private void GetPerioadaClienti()
        {
            //get all clients based on the period of time set
            ICollection<Client> clienti = _clientService.GetAllClientiPerioada(DataDeInceput, DataDeSfarsit);
            SetClienti(clienti);
        }

        private void SetClienti(ICollection<Client> clienti)
        {
            //parse the names from the clients
            ICollection<string> nume = new List<string>();
            foreach (Client client in clienti)
            {
                nume.Add(client.Nume + " " + client.Prenume);
            }

            //visually add the names on the list
            ObservableCollection<string> numeClienti = Clienti;
            numeClienti.Clear();
            foreach (string n in nume)
            {
                numeClienti.Add(n);
            }
        }
    }
}
