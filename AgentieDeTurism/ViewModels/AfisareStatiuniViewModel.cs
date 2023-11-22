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
    public class AfisareStatiuniViewModel:ViewModel
    {
        private IStatiuneService _statiuneService;
        private ObservableCollection<string> _statiuni=new ObservableCollection<string>();
        public ObservableCollection<string> Statiuni
        {
            get { GetStatiuni(); return _statiuni; }
            set { _statiuni.Clear(); foreach (string nume in value) { _statiuni.Add(nume); } }
        }
    

        private string _dataDeInceput;
        public string DataDeInceput
        {
            get {  return _dataDeInceput; }
            set {  _dataDeInceput = value; GetStatiuniPerioada(); }
        }

        private string _dataDeSfarsit;
        public string DataDeSfarsit
        {
            get {  return _dataDeSfarsit; }
            set { _dataDeSfarsit = value; GetStatiuniPerioada(); }
        }

        public AfisareStatiuniViewModel(IStatiuneService statiuneService)
        {
            _statiuneService = statiuneService;
        }

        private void GetStatiuni()
        {
            ICollection<Statiune> statiuni = _statiuneService.GetAllStatiuni();

            ICollection<string> nume=new List<string>();
            foreach(Statiune statiune in statiuni)
            {
                nume.Add(statiune.Nume);
            }

            Statiuni = new ObservableCollection<string>(nume);
        }

        private void GetStatiuniPerioada()
        {
            ICollection<Statiune> statiuni =_statiuneService.GetAllStatiuniPerioada(DataDeInceput, DataDeSfarsit);
            
            ICollection<string> nume=new List<string>();
            foreach(Statiune statiune in statiuni)
            {
                nume.Add(statiune.Nume);
            }
            
            Statiuni = new ObservableCollection<string>(nume);
        }

    }
}
