using AgentieDeTurism.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgentieDeTurism.ViewModels
{
    public class LoggedInAdminViewModel : ViewModel
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

        public ICommand AdaugaStatiuni { get; set; }
        public ICommand AdaugaPerioada { get; set; }
        public ICommand AfisareSejururi { get; set; }
        public ICommand AfisareStatiuni { get; set; }
        public ICommand AfisareRezervari { get; set; }


        public LoggedInAdminViewModel(INavigation navigation)
        {
            _navigation = navigation;

            //set the navigation such that the viewmodels will automatically bind to the view
            AdaugaStatiuni = new RelayCommand(o => { Navigation.NavigatoTo<AddStatiuneViewModel>(); }, o => true);
            AdaugaPerioada = new RelayCommand(o => { Navigation.NavigatoTo<AddPerioadaViewModel>(); }, o => true);
            AfisareSejururi = new RelayCommand(o => { Navigation.NavigatoTo<AfisareSejururiViewModel>(); }, o => true);
            AfisareStatiuni = new RelayCommand(o => { Navigation.NavigatoTo<AfisareStatiuniViewModel>(); }, o => true);
            AfisareRezervari = new RelayCommand(o => { Navigation.NavigatoTo<AfisareRezervareViewModel>(); }, o => true);
        }
    }
}
