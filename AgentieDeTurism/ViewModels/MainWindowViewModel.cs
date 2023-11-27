using AgentieDeTurism.Core;
using AgentieDeTurism.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgentieDeTurism.ViewModels
{
    public class MainWindowViewModel: ViewModel
    {
        private INavigation _navigation;
        public INavigation Navigation
        {
            get => _navigation;
            set
            {
                _navigation=value;
                OnPropertyChanged();
            }
        }
        public ICommand AdaugaStatiuni { get; set; }
        public ICommand AdaugaClienti { get; set; }
        public ICommand AdaugaPerioada { get; set; }
        public ICommand AfisareSejururi { get; set; }
        public ICommand AfisareStatiuni { get; set; }
        public ICommand AdaugaRezervare { get; set; }
        public ICommand AfisareRezervari { get; set; }

        
        public MainWindowViewModel(INavigation navigation)
        {
            Navigation = navigation;

            //set the navigation such that the viewmodels will automatically bind to the view
            AdaugaStatiuni = new RelayCommand(o => { Navigation.NavigatoTo<AddStatiuneViewModel>(); },o=>true) ;
            AdaugaClienti = new RelayCommand(o => { Navigation.NavigatoTo<AddClientViewModel>(); },o=>true) ;
            AdaugaPerioada = new RelayCommand(o => { Navigation.NavigatoTo<AddPerioadaViewModel>(); },o=>true) ;
            AfisareSejururi = new RelayCommand(o => { Navigation.NavigatoTo<AfisareSejururiViewModel>(); },o=>true) ;
            AfisareStatiuni = new RelayCommand(o => { Navigation.NavigatoTo<AfisareStatiuniViewModel>(); },o=>true) ;
            AdaugaRezervare = new RelayCommand(o => { Navigation.NavigatoTo<RezervareSejurViewModel>(); },o=>true) ;
            AfisareRezervari = new RelayCommand(o => { Navigation.NavigatoTo<AfisareRezervareViewModel>(); },o=>true) ;
        }
    }
}
