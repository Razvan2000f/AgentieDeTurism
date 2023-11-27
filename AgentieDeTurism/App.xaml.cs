using AgentieDeTurism.Core;
using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories;
using AgentieDeTurism.Repositories.Interfaces;
using AgentieDeTurism.Services;
using AgentieDeTurism.Services.Interfaces;
using AgentieDeTurism.ViewModels;
using AgentieDeTurism.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AgentieDeTurism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider _serviceProvider;
        public App()
        {
            // Set up dependency injection container
            var services = new ServiceCollection();

            //register services
            services.AddSingleton<Context>();
            services.AddSingleton<IRepositoryWrapper, RepositoryWrapper>();
            services.AddSingleton<IStatiuneService, StatiuneService>();
            services.AddSingleton<IClientService, ClientService>();

            //register viewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<AddStatiuneViewModel>();
            services.AddSingleton<AddClientViewModel>();
            services.AddSingleton<AddPerioadaViewModel>();
            services.AddSingleton<AfisareSejururiViewModel>();
            services.AddSingleton<AfisareStatiuniViewModel>();
            services.AddSingleton<RezervareSejurViewModel>();
            services.AddSingleton<AfisareRezervareViewModel>();

            //set main window and bind it to the viewmodel 
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });
            
            //add navigation and function for dynamic binding
            services.AddSingleton<INavigation, Navigation>();
            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            // Register your MainWindow

             _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow= _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
