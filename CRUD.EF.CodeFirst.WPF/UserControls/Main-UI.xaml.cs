using CRUD.EF.CodeFirst.WPF.Models;
using CRUD.EF.CodeFirst.WPF.Services;
using CRUD.EF.CodeFirst.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD.EF.CodeFirst.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for Main_UI.xaml
    /// </summary>
    public partial class Main_UI : UserControl
    {
        public Main_UI()
        {
            InitializeComponent();
            var alertService = new AlertService();

            // Pass the alertService to the MainUIViewModel constructor
            this.DataContext = new MainUIViewModel(alertService);

        }

        private void dgCustomerData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dgCustomerData.SelectedItem is Customer selectedCustomer)
            {
                if (DataContext is MainUIViewModel viewModel)
                {
                    viewModel.SelectedCustomer = selectedCustomer;
                }
            }
        }
    }
}
