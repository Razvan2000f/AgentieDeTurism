using AgentieDeTurism.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgentieDeTurism.ViewModels
{
    public class LoggedInViewModel : ViewModel
    {
        private INavigation _navigation;
        public INavigation Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public ICommand AfisareSejururi { get; set; }
        public ICommand AfisareStatiuni { get; set; }
        public ICommand AdaugaRezervare { get; set; }

        public LoggedInViewModel(INavigation navigation)
        {
            _navigation = navigation;

            //set the navigation such that the viewmodels will automatically bind to the view
            AfisareSejururi = new RelayCommand(o => { Navigation.NavigatoTo<AfisareSejururiViewModel>(); }, o => true);
            AfisareStatiuni = new RelayCommand(o => { Navigation.NavigatoTo<AfisareStatiuniViewModel>(); }, o => true);
            AdaugaRezervare = new RelayCommand(o => { Navigation.NavigatoTo<RezervareSejurViewModel>(); }, o => true);
        }
    }
}

