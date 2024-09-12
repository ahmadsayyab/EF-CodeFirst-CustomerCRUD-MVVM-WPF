using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD.EF.CodeFirst.WPF.Contexts;
using CRUD.EF.CodeFirst.WPF.Models;
using CRUD.EF.CodeFirst.WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUD.EF.CodeFirst.WPF.ViewModels
{
    public class MainUIViewModel : ObservableObject
    {
        CustomerDbContext customerDbContext;
        private readonly IAlertService _alertService;

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get => customers;
            set => SetProperty(ref customers, value);
        }


        //[ObservableProperty]
        //private string _name;

        //[ObservableProperty]
        //private string _email; 

        //[ObservableProperty]
        //private int _age; 

        //[ObservableProperty]
        //private string _address;

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private int age;
        public int Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        private string address;
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                if(SetProperty(ref selectedCustomer, value))
                {
                    if(selectedCustomer != null)
                    {
                        Name = selectedCustomer.Name;
                        Email = selectedCustomer.Email;
                        Age = selectedCustomer.Age;
                        Address = selectedCustomer.Address;
                    }
                }
            }
        }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public MainUIViewModel(IAlertService alertService)
        {
            _alertService = alertService;
            Customers = new ObservableCollection<Customer>();
            customerDbContext = new CustomerDbContext();
            InsertCommand = new RelayCommand(Insert);
            UpdateCommand = new RelayCommand(Update);
            DeleteCommand = new RelayCommand(Delete);
            LoadData();
        }
      
        private void Delete()
        {
            if (SelectedCustomer != null)
            {
                var confirmDelete = _alertService.Confirm("Are you sure you want to delete this customer?", "Confirm Delete");
                if (confirmDelete)
                {
                    customerDbContext.Customers.Remove(SelectedCustomer);
                    customerDbContext.SaveChanges();
                    LoadData();
                }
            }
        }

        private void Update()
        {
            if(selectedCustomer != null)
            {
                SelectedCustomer.Name = Name;
                SelectedCustomer.Email = Email;
                SelectedCustomer.Age = Age;
                SelectedCustomer.Address = Address;

                customerDbContext.SaveChanges();

                LoadData();
            }
        }

        private void Insert()
        {
            var customers = new Customer
            {
                Name = Name,
                Email = Email,
                Age = Age,
                Address = Address,

            };

            SaveUser(customers);
        }

        private void SaveUser(Customer customer)
        {
            var existingUser = customerDbContext.Customers.Find(customer.Id);
            if (existingUser != null)
            {
                customerDbContext.Entry(existingUser).CurrentValues.SetValues(customer);
            }

            else
            {
                customerDbContext.Customers.Add(customer);
            }

            customerDbContext.SaveChanges();
            Customers.Add(customer);

        }

        public void LoadData()
        {
            try
            {
              var  customersList = customerDbContext.Customers.ToList();
                Customers.Clear();
               foreach(var customer in customersList)
                {
                    Customers.Add(customer);

                    
                }

          
            }catch (Exception ex) { }
        }
    }
}
