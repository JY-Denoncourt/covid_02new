using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        //------------------------------------------ Variables

        private BaseViewModel contentViewModel;
        public CustomerViewModel customerViewModel;
        public InvoiceViewModel invoiceViewModel;

        //------------------------------------------ Definitions

        public BaseViewModel ContentViewModel
        {
            get => contentViewModel;
            set
            {
                contentViewModel = value;
                OnPropertyChanged();
            }
        }

        //------------------------------------------ Constructeurs

        public MainViewModel()
        {
            customerViewModel = new CustomerViewModel();
            invoiceViewModel = new InvoiceViewModel();

            ContentViewModel = customerViewModel;
        }
    
        //------------------------------------------ Methodes

        private void changeViewModel(string vm)
        {
            if (vm == "customer")
                ContentViewModel = customerViewModel;
            else if (vm == "invoice")
            {
                //ContentViewModel = invoiceViewModel;
            }
        }
    
    }
}
