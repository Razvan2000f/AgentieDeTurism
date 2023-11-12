using AgentieDeTurism.Core;
using AgentieDeTurism.Models;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgentieDeTurism.ViewModels
{
    public class AddStatiuneViewModel : ViewModel
    {
        private IStatiuneService _statiuneService;

        private string _nume;
        public string Nume
        {
            get { return _nume; }
            set { _nume = value; }
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

        public ICommand AdaugaStatiune { get; set; }

        public AddStatiuneViewModel(IStatiuneService statiuneService)
        {
            _statiuneService= statiuneService;
            AdaugaStatiune = new RelayCommand(Adauga);
        }

        private void Adauga(object obj)
        {
            _statiuneService.AddStatiune(Nume, DataDeInceput, DataDeSfarsit);
        }
    }
}
