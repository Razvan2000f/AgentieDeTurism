using AgentieDeTurism.Services;
using AgentieDeTurism.Services.Interfaces;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Set up dependency injection container
            var services = new ServiceCollection();

            // Register your services
            services.AddSingleton<IStatiuneService, StatiuneService>();

            // Register your MainWindow
            services.AddTransient<AddStatiuneViewModel>();

            services.BuildServiceProvider();

        }
    }
}
