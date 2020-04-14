using app_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace BillingManagement.Models
{
    public class Invoice : INotifyPropertyChanged
    {
        #region //Variables
        public static int globalID = 0;

        public int invoiceId { get; private set; }    //Auto-incrementer

        private Customer customer;                    //Il s’agit du propriétaire de la facture

        private double subTotal;

        #endregion

        //------------------------------------------------------------------------------- Definitions

        #region //Definition variables 
        public DateTime CreationDateTime { get; }

        public Customer Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }

        public double SubTotal
        {
            get => subTotal;
            set
            {
                subTotal = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FedTax));
                OnPropertyChanged(nameof(ProvTax));
                OnPropertyChanged(nameof(Total));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        //------------------------------------------------------------------------------- Constructeurs

        #region //Constructeurs
        public Invoice()  //De base qui instancie CreationDateTime avec le moment de la création.
        {
            CreationDateTime = DateTime.Now;
            invoiceId = Interlocked.Increment(ref globalID);     //  Interlocked.Increment(ref invoiceId);
        }

        public Invoice(Customer custumer1)  //Avec un Customer en paramètre et ne pas oublier la CreationDatetime.
        {
            Customer = custumer1;
            CreationDateTime = DateTime.Now;
            invoiceId = Interlocked.Increment(ref globalID); ;
        }
        #endregion

        //--------------------------------------------------------------------------------Methodes

        #region //Methodes
        public double FedTax => subTotal * 0.05;

        public double ProvTax => subTotal * 0.09975;

        public double Total => subTotal + FedTax + ProvTax;

        public string Info => $"{CreationDateTime} : {Total}";
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

}

