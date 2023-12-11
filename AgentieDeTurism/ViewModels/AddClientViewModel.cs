using AgentieDeTurism.Core;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgentieDeTurism.ViewModels
{
    public class AddClientViewModel:ViewModel
    {
        public string Nume { get; set; } = "";
        public string Prenume { get; set; } = "";
        public string NumarCI { get; set; } = "";
        public string SerieCI { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Strada { get; set; } = "";
        public string Numar { get; set; } = "";

        public ICommand AdaugaClient { get; set; }
        private readonly IClientService _clientService;

        public AddClientViewModel(IClientService clientService)
        {
            _clientService = clientService;
            AdaugaClient = new RelayCommand(Adauga);
        }

        private void Adauga(object obj)
        {
            //add new client with input data
            _clientService.AddClient(Nume, Prenume, NumarCI, SerieCI, Strada, Numar, Telefon);
        }
    }
}
