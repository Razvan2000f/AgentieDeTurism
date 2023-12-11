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
    public class AfisareSejururiViewModel : ViewModel
    {
        private readonly IStatiuneService _statiuneService;
        private ObservableCollection<Statiune> _statiuni=new ObservableCollection<Statiune>();
        public ObservableCollection<Statiune> Statiuni
        {
            get { GetStatiuni(); return _statiuni; }
            set { _statiuni = value; }
        }

        private Statiune _statiune=new Statiune();
        public Statiune Statiune
        {
            get { return _statiune; }
            set { _statiune = value; AfiseazaPerioade(); }
        }

        public ObservableCollection<Tuple<string, string>> Perioade { get; set; }
        public AfisareSejururiViewModel(IStatiuneService statiuneService)
        {
            _statiuneService = statiuneService;
            Perioade = new ObservableCollection<Tuple<string, string>>();
        }

        //retrieve all periods for a given statiune
        private void AfiseazaPerioade()
        {
            ICollection<Tuple<string, string>> perioade = _statiuneService.GetPerioadeStatiune(Statiune);

            Perioade.Clear();
            foreach (Tuple<string, string> perioada in perioade)
            {
                Perioade.Add(perioada);
            }
        }

        //retrieve all statiuni in the db
        private void GetStatiuni()
        {
            ICollection<Statiune> statiuni = _statiuneService.GetAllStatiuni();
            Statiuni = new ObservableCollection<Statiune>(statiuni);
        }
    }
}
