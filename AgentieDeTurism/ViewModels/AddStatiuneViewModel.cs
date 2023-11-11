using AgentieDeTurism.Core;
using AgentieDeTurism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgentieDeTurism.Views
{
    public class AddStatiuneViewModel
    {
        public ICommand AdaugaStatiune { get; set; }
        public string Nume { get { return _nume; }  set { _nume = value; } }
        public string _nume { get; set; }

        public AddStatiuneViewModel()
        {
            AdaugaStatiune = new RelayCommand(Adauga);
        }

        private void Adauga(object obj)
        {
            

        }
    }
}
