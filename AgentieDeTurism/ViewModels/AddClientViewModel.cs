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
        private string _nume;
        public string Nume
        {
            get { return _nume; }
            set { _nume = value; }
        }

        private string _prenume;
        public string Prenume
        {
            get { return _prenume; }
            set { _prenume = value; }
        }
        private string _numarCI;
        public string NumarCI
        {
            get { return _numarCI; }
            set { _numarCI = value; }
        }
        private string _serieCI;
        public string SerieCI
        {
            get { return _serieCI; }
            set { _serieCI = value; }
        }
        private string _telefon;
        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

        private string _strada;
        public string Strada
        {
            get { return _strada; }
            set { _strada = value; }
        }

        private string _numar;
        public string Numar
        {
            get { return _numar; }
            set { _numar = value; }
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
        private int _statiunea;
        public int Statiunea
        {
            get { return _statiunea; }
            set { _statiunea = value; }
        }

        public ICommand AdaugaClient { get; set; }
        private IClientService _clientService;

        public AddClientViewModel(IClientService clientService)
        {
            _clientService = clientService;
            AdaugaClient = new RelayCommand(Adauga);
        }

        private void Adauga(object obj)
        {
            _clientService.AddClient(Nume, Prenume, NumarCI, SerieCI, Strada, Numar, Telefon, DataDeInceput, DataDeSfarsit,0);
        }
    }
}
