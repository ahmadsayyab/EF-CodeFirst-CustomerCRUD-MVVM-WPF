using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD.EF.CodeFirst.WPF.Services
{
    public class AlertService : IAlertService
    {
        public bool Confirm(string message, string title = "Confirmation")
        {
            return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
            
        }
    }
}
