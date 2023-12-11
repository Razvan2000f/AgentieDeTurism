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
        private readonly IStatiuneService _statiuneService;
        public string Nume { get; set; } = "";
        public string DataDeInceput { get; set; } = "";
        public string DataDeSfarsit { get; set; } = "";

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
