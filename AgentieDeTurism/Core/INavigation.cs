using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Core
{
    public interface INavigation
    {
        ViewModel? CurrentView { get; }
        void NavigatoTo<T>() where T : ViewModel;
    }
}
