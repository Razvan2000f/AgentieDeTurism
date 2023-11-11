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
    public class MainWindowViewModel
    {
        public ICommand AdaugaStatiuni { get; set; }

        private Frame _contentFrame;

        public MainWindowViewModel(Frame contentFrame)
        {
            AdaugaStatiuni = new RelayCommand(AddStatiune);
            _contentFrame = contentFrame;
        }

        private void AddStatiune(object obj)
        {
            AddStatiuneView addStatiuneView= new AddStatiuneView();  
            _contentFrame.Navigate(addStatiuneView);
        }
    }
}
