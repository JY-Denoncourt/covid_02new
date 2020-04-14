using app_models;
using BillingManagement.Business;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        //-------------------------------------------------------------------------------- Variables

        #region //Variables
        readonly CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        #endregion

        //-------------------------------------------------------------------------------- Definition

        #region //Definitions
        public ObservableCollection<Customer> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //-------------------------------------------------------------------------------- Constructeur
        
        public CustomerViewModel()
        {
            InitValues();
        }

        //-------------------------------------------------------------------------------- Methodes
        
        private void InitValues()
        {
            Customers = new ObservableCollection<Customer>(customersDataService.GetAll());
            Debug.WriteLine(Customers.Count);
        }

    }
}
