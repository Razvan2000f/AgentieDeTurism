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
    public class RezervareSejurViewModel : ViewModel
    {
        private readonly IStatiuneService _statiuneService;
        private readonly IClientService _clientService;

        //containts all the time intervals available for a given statiune

        //dictionary to keep all the possible dates for a certain statiune
        private readonly Dictionary<Statiune, ICollection<Tuple<string, string>>> listStatiuniPerioade = new Dictionary<Statiune, ICollection<Tuple<string, string>>>();

        //list containing all the clients from the db
        private ObservableCollection<Client> _clienti=new ObservableCollection<Client>();
        public ObservableCollection<Client> Clienti
        {
            get { GetClienti(); return _clienti; }
            set { _clienti = value; }
        }

        public Client Client { get; set; } = new Client();

        //list containing all the statiuni in the db
        private ObservableCollection<Statiune> _statiuni=new ObservableCollection<Statiune>();
        public ObservableCollection<Statiune> Statiuni
        {
            get { GetStatiuni(); return _statiuni; }
            set { _statiuni = value; }
        }

        private Statiune _statiune = new Statiune();
        public Statiune Statiune
        {
            get { return _statiune; }
            set { _statiune = value; SetPerioade(value); }
        }
       
        public ObservableCollection<string> DateDeInceput { get; set; }=new ObservableCollection<string>();
        public string DataDeInceput { get; set; } = "";
        public ObservableCollection<string> DateDeSfarsit { get; set; } = new ObservableCollection<string>();
        public string DataDeSfarsit { get; set; } = "";
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

            foreach (string perioada in inceput)
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
            Sejur sejur = _statiuneService.GetSejurByPerioada(DataDeInceput, DataDeSfarsit);
            _clientService.AddRezervare(Client, sejur);
        }
    }
}
