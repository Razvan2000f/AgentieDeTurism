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
    public class AfisareSejururiViewModel:ViewModel
    {
        private IStatiuneService _statiuneService;
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
            set { _statiune = value; AfiseazaPerioade(); }
        }

        private ObservableCollection<Tuple<string, string>> _perioade;
        public ObservableCollection<Tuple<string, string>> Perioade
        {
            get { return _perioade; }
            set { _perioade = value; }
        }

        public AfisareSejururiViewModel(IStatiuneService statiuneService)
        {
            _statiuneService = statiuneService;
        }

        private void AfiseazaPerioade()
        {
            ICollection<Tuple<string, string>>perioade=_statiuneService.GetPerioadeStatiune(Statiune);

            Perioade=new ObservableCollection<Tuple<string, string>>(perioade);
        }


        private void GetStatiuni()
        {
            ICollection<Statiune> statiuni = _statiuneService.GetAllStatiuni();
            Statiuni = new ObservableCollection<Statiune>(statiuni);
        }

    }
}
