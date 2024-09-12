using CRUD.EF.CodeFirst.WPF.Services;
using CRUD.EF.CodeFirst.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD.EF.CodeFirst.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create instances
            var alertService = new AlertService();
            var viewModel = new MainUIViewModel(alertService);

            var mainWindow = new MainWindow
            {
                DataContext = viewModel
            };

            mainWindow.Show();
        }
    }
}
