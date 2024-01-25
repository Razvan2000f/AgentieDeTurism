using AgentieDeTurism.Core;
using AgentieDeTurism.Models;
using AgentieDeTurism.Services.Interfaces;
using AgentieDeTurism.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgentieDeTurism.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        public string Username { get; set; } = "";

        //field not directly bindable due to security concerns from password box
        public string Password { get; set; } = "";
        public ICommand ToRegister { get; set; }
        public ICommand Login { get; set; }
        public INavigation Navigation { get; set; }

        private readonly IClientService _clientService;

        public LoginViewModel(IClientService clientService, INavigation navigation)
        {
            Navigation = navigation;
            _clientService = clientService;
            ToRegister = new RelayCommand(OnToRegister);
            Login = new RelayCommand(OnLogin);
        }

        //log in user
        private void OnLogin(object obj)
        {
            //check for administrator login because it will be able to see a slightly different view
            if (Username == "Admin" && Password == "Admin")
            {
                Navigation.NavigateToMainView<LoggedInAdminViewModel>();
            }

            bool check = _clientService.CheckIfClientExist(Username, Password);
            if (check)
            {
                Navigation.NavigateToMainView<LoggedInViewModel>();
            }
        }

        //switch to register view
        private void OnToRegister(object obj)
        {
            Navigation.NavigateToMainView<RegisterViewModel>();
        }
    }
}
