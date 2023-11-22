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
        private IStatiuneService _statiuneService;
        private IClientService _clientService;
        private ObservableCollection<string> _clienti = new ObservableCollection<string>();
        public ObservableCollection<string> Clienti
        {
            get { GetClienti(); return _clienti; }
            set { _clienti.Clear(); foreach (string nume in value) { _clienti.Add(nume); } }
        }

        private string _dataDeInceput;
        public string DataDeInceput
        {
            get { return _dataDeInceput; }
            set { _dataDeInceput = value; GetPerioadaClienti(); }
        }

        private string _dataDeSfarsit;
        public string DataDeSfarsit
        {
            get { return _dataDeSfarsit; }
            set { _dataDeSfarsit = value; GetPerioadaClienti(); }
        }

        public AfisareRezervareViewModel(IStatiuneService statiuneService, IClientService clientService)
        {
            _statiuneService = statiuneService;
            _clientService = clientService;
        }

        private void GetClienti()
        {
            ICollection<Client> clienti = _clientService.GetAllClients();

            ICollection<string> nume = new List<string>();
            foreach (Client client in clienti)
            {
                nume.Add(client.Nume);
            }

            Clienti = new ObservableCollection<string>(nume);
        }

        private void GetPerioadaClienti()
        {
            ICollection<Client> clienti = _clientService.GetAllClientiPerioada(DataDeInceput, DataDeSfarsit);

            ICollection<string> nume = new List<string>();
            foreach (Client client in clienti)
            {
                nume.Add(client.Nume);
            }

            Clienti = new ObservableCollection<string>(nume);
        }

    }
}
