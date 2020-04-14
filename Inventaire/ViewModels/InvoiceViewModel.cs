using app_models;
using BillingManagement.Business;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class InvoiceViewModel : BaseViewModel
    {
        //-------------------------------------------------------------------------------- Variables

        #region //Variables
        readonly InvoicesDataService invoicesDataService = new InvoicesDataService();

        private ObservableCollection<Invoice> invoices;
        private Invoice selectedInvoice;

        #endregion

        //-------------------------------------------------------------------------------- Definitions

        #region //Definitions
        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
                OnPropertyChanged();
            }
        }

        public Invoice SelectedInvoice
        {
            get => selectedInvoice;
            set
            {
                selectedInvoice = value;
                OnPropertyChanged();
            }
        }
        #endregion

        //-------------------------------------------------------------------------------- Constructeur

        public InvoiceViewModel()
        {
            Invoices = new ObservableCollection<Invoice>(invoicesDataService.GetAll());
            Debug.WriteLine(Invoices.Count);
        }


        //--------------------------------------------------------------------------------  Methodes

    }
}
