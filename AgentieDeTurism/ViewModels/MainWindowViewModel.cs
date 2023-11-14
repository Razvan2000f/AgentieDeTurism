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


        public MainWindowViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AdaugaStatiuni = new RelayCommand(o => { Navigation.NavigatoTo<AddStatiuneViewModel>(); },o=>true) ;
            AdaugaClienti = new RelayCommand(o => { Navigation.NavigatoTo<AddClientViewModel>(); },o=>true) ;
        }
    }
}
