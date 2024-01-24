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

        public MainWindowViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Navigation.NavigateToMainView<LoginViewModel>();
        }
    }
}
