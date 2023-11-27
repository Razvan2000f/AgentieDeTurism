using AgentieDeTurism.Core;
using AgentieDeTurism.Models;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgentieDeTurism.ViewModels
{
    public class RezervareSejurViewModel:ViewModel
    {
        private IStatiuneService _statiuneService;
        private IClientService _clientService;

        //containts all the time intervals available for a given statiune
        private Dictionary<Statiune, ICollection<Tuple<string,string>>> listStatiuniPerioade=new Dictionary<Statiune, ICollection<Tuple<string, string>>>();

        private ObservableCollection<Client> _clienti;
        public ObservableCollection<Client> Clienti
        {
            get { GetClienti(); return _clienti; }
            set { _clienti = value; }
        }

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        private ObservableCollection<Statiune> _statiuni;
        public ObservableCollection<Statiune> Statiuni
        {
            get { GetStatiuni(); return _statiuni; }
            set { _statiuni = value; }
        }

        private Statiune _statiune;
        public Statiune Statiune
        {
            get { return _statiune; }
            set { _statiune = value; SetPerioade(value); }
        }

        private ObservableCollection<string> _dateDeInceput;
        public ObservableCollection<string> DateDeInceput
        {
            get { return _dateDeInceput; }
            set { _dateDeInceput = value; }
        }

        private string _dataDeInceput;
        public string DataDeInceput
        {
            get { return _dataDeInceput; }
            set { _dataDeInceput = value; }
        }

        private ObservableCollection<string> _dateDeSfarsit;
        public ObservableCollection<string> DateDeSfarsit
        {
            get { return _dateDeSfarsit; }
            set { _dateDeSfarsit = value; }
        }

        private string _dataDeSfarsit;
        public string DataDeSfarsit
        {
            get { return _dataDeSfarsit; }
            set { _dataDeSfarsit = value; }
        }

        public ICommand Rezerva { get; set; }

        public RezervareSejurViewModel(IStatiuneService statiuneService, IClientService clientService)
        {
            _statiuneService = statiuneService;
            _clientService = clientService;
            Rezerva = new RelayCommand(AdaugaRezervare);

            SetItemSources();
        }

        private void SetItemSources()
        {
            //set empty collections
            DateDeInceput = new ObservableCollection<string>();
            DateDeSfarsit = new ObservableCollection<string>();

            ICollection<Sejur> sejururi = _statiuneService.GetAllSejururi();

            //extract all ids of statiuni that have a sejur available
            ICollection<int> statiuniID = sejururi.Select(sejur => sejur.StatiuneID).Distinct().ToList();

            //extract all available time intervals for a given statiune
            foreach (int id in statiuniID)
            {
                Statiune statiune = _statiuneService.GetStatiuneByID(id);
                ICollection<Tuple<string, string>> perioade = _statiuneService.GetPerioadeStatiune(statiune);

                listStatiuniPerioade[statiune] = perioade;
            }
        }

        private void GetStatiuni()
        {
            Statiuni = new ObservableCollection<Statiune>(listStatiuniPerioade.Keys);
        }

        private void GetClienti()
        {
            ICollection<Client> clienti = _clientService.GetAllClients();
            Clienti = new ObservableCollection<Client>(clienti);
        }
        //set all the available dates to be chosen from the lists
        private void SetPerioade(Statiune statiuneSelectata)
        {
            ICollection<Tuple<string, string>> perioade = listStatiuniPerioade[statiuneSelectata];

            ICollection<string> inceput = perioade.Select(perioada => perioada.Item1).ToList();
            ICollection<string> sfarsit = perioade.Select(perioada => perioada.Item2).ToList();

            DateDeInceput.Clear();
            DateDeSfarsit.Clear();

            foreach(string perioada in inceput)
            {
                DateDeInceput.Add(perioada);
            }

            foreach (string perioada in sfarsit)
            {
                DateDeSfarsit.Add(perioada);
            }
        }

        private void AdaugaRezervare(object obj)
        {
            Sejur sejur= _statiuneService.GetSejurByPerioada(DataDeInceput, DataDeSfarsit);
            _clientService.AddRezervare(Client, sejur);
        }
    }
}
