using BillingManagement.UI.ViewModels.Command;
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
        public ChangeViewCommand ChangeViewCommand { get; set; }

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
            ChangeViewCommand = new ChangeViewCommand(ChangeView);

            customerViewModel = new CustomerViewModel();
            invoiceViewModel = new InvoiceViewModel();

            ContentViewModel = customerViewModel;
        }
    
        //------------------------------------------ Methodes

        public void ChangeView(string vm)
        {
            if (vm == "customers")
                ContentViewModel = customerViewModel;
            else if (vm == "invoices")
                ContentViewModel = invoiceViewModel;
            
        }
    
    }
}
