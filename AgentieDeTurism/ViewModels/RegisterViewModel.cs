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
    public class RegisterViewModel:ViewModel
    {
        public string Username { get; set; } = "";
        //field not directly bindable due to security concerns from password box
        public string Password { get; set; } = "";
        //field not directly bindable due to security concerns from password box
        public string ConfirmPassword { get; set; } = "";
        public string Nume { get; set; } = "";
        public string Prenume { get; set; } = "";
        public string NumarCI { get; set; } = "";
        public string SerieCI { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Strada { get; set; } = "";
        public string Numar { get; set; } = "";

        public ICommand Register { get; set; }
        public ICommand ToLogin { get; set; }
        private readonly IClientService _clientService;
        private readonly INavigation _navigation;

        public RegisterViewModel(IClientService clientService, INavigation navigation)
        {
            _clientService = clientService;
            _navigation = navigation;
            Register = new RelayCommand(Adauga);
            ToLogin = new RelayCommand(OnToLogin);
        }

        //switch to login view
        private void OnToLogin(object obj)
        {
            _navigation.NavigateToMainView<LoginViewModel>();
        }

        private void Adauga(object obj)
        {
            if (Password == ConfirmPassword)
            {
                //add new client with input data
                _clientService.AddClient(Nume, Prenume, NumarCI, SerieCI, Strada, Numar, Telefon, Username, Password);
            }
        }
    }
}
