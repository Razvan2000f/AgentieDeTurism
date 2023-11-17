using AgentieDeTurism.Core;
using AgentieDeTurism.Models;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AgentieDeTurism.ViewModels
{
    public class AddPerioadaViewModel : ViewModel
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
            set { _statiune = value; }
        }

        private string _dataDeInceput;
        public string DataDeInceput
        {
            get { return _dataDeInceput; }
            set { _dataDeInceput = value; }
        }

        private string _dataDeSfarsit;
        public string DataDeSfarsit
        {
            get { return _dataDeSfarsit; }
            set { _dataDeSfarsit = value; }
        }

        public ICommand AdaugaPerioada { get; set; }

        public AddPerioadaViewModel(IStatiuneService statiuneService)
        {
            _statiuneService = statiuneService;
            AdaugaPerioada = new RelayCommand(Adauga);
        }

        private void GetStatiuni()
        {
            ICollection<Statiune> statiuni=_statiuneService.GetAllStatiuni();
            Statiuni=new ObservableCollection<Statiune>(statiuni);
        }

        private void Adauga(object obj)
        {
            _statiuneService.AddPerioada(Statiune, DataDeInceput, DataDeSfarsit);
        }
    }
}
