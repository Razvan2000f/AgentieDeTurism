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
        private readonly IStatiuneService _statiuneService;
        
        //dynamic list populated with all statiuni from the db
        private ObservableCollection<Statiune> _statiuni = new ObservableCollection<Statiune>();
        public ObservableCollection<Statiune> Statiuni
        {
            get { GetStatiuni(); return _statiuni; }
            set { _statiuni = value; }
        } 

        //the currently selected statiune
        public Statiune? Statiune { get; set; }
        //the currently selected start date
        public string? DataDeInceput { get; set; }
        //the currently selected end date
        public string? DataDeSfarsit{get;set; }

        public ICommand AdaugaPerioada { get; set; }

        public AddPerioadaViewModel(IStatiuneService statiuneService)
        {
            _statiuneService = statiuneService;
            AdaugaPerioada = new RelayCommand(Adauga);
        }

        //function to dynamically retrieve all statiuni from the db
        private void GetStatiuni()
        {
            ICollection<Statiune> statiuni = _statiuneService.GetAllStatiuni();
            Statiuni = new ObservableCollection<Statiune>(statiuni);
        }

        private void Adauga(object obj)
        {
            //check if all the selections have been made
            if (Statiune != null && DataDeInceput!=null && DataDeSfarsit!=null)
            {
                //if all the selections are correct then we can add a new perioda
                _statiuneService.AddPerioada(Statiune, DataDeInceput, DataDeSfarsit);
            }
        }
    }
}
