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
    public class AfisareStatiuniViewModel : ViewModel
    {
        private readonly IStatiuneService _statiuneService;
        public ObservableCollection<string> Statiuni{get;set;}


        private string _dataDeInceput = "";
        public string DataDeInceput
        {
            get { return _dataDeInceput; }
            set { _dataDeInceput = value; GetStatiuniPerioada(); }
        }

        private string _dataDeSfarsit = "";
        public string DataDeSfarsit
        {
            get { return _dataDeSfarsit; }
            set { _dataDeSfarsit = value; GetStatiuniPerioada(); }
        }

        public AfisareStatiuniViewModel(IStatiuneService statiuneService)
        {
            _statiuneService = statiuneService;
            Statiuni = new ObservableCollection<string>();
            GetStatiuni();
        }

        //retrieve all statiuni in the db
        private void GetStatiuni()
        {
            ICollection<Statiune> statiuni = _statiuneService.GetAllStatiuni();
            SetStatiuni(statiuni);
        }


        //retrieve all statiuni in a given time interval
        private void GetStatiuniPerioada()
        {
            ICollection<Statiune> statiuni = _statiuneService.GetAllStatiuniPerioada(DataDeInceput, DataDeSfarsit);
            SetStatiuni(statiuni);
        }

        private void SetStatiuni(ICollection<Statiune> statiuni)
        {
            ICollection<string> nume = new List<string>();
            foreach (Statiune statiune in statiuni)
            {
                nume.Add(statiune.Nume);
            }

            Statiuni.Clear(); foreach (string n in nume)
            {
                Statiuni.Add(n);
            }
        }
    }
}
