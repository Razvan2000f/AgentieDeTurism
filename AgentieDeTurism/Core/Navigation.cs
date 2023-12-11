using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Core
{
    public class Navigation : ObservableObject, INavigation
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;
        //current view displayed in the main windows of the app
        private ViewModel? _currentView ;
        public ViewModel? CurrentView 
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public Navigation(Func<Type,ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        //change the current window based on menu selection
        public void NavigatoTo<T>() where T : ViewModel
        {
            ViewModel viewModel=_viewModelFactory.Invoke(typeof(T));
            CurrentView= viewModel;
        }
    }
}
