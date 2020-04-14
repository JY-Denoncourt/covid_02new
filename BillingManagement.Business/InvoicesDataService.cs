using app_models;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BillingManagement.Business
{
    public class InvoicesDataService : IDataService<Invoice>
    {
        //------------------------------------------------------------- Variables

        public List<Invoice> invoices;
        private List<Customer> _customers = new CustomersDataService().GetAll().ToList();


        //------------------------------------------------------------- Constructeurs

        public InvoicesDataService()
        {
            initValues();

        }

        //------------------------------------------------------------- Methodes


        private void initValues()
        {
            Random rnd = new Random();                                  //Pour creer nb aleatoire

            invoices = new List<Invoice>();

            foreach (var customer in _customers)
            {
                int nbInvoices = rnd.Next(10);                         //Pour creer le nb entre 0 et 10 invoice

                for (int i = 0; i < nbInvoices; i++)
                {
                    var invoice = new Invoice(customer);               //creer une invoice temps 
                    invoice.SubTotal = rnd.NextDouble() * 100 + 50;    //lui done un nombre a subtotal
                    customer.Invoices.Add(invoice);                    //va l'ajouter dans la liste de chaque customer              
                    invoices.Add(invoice);                             //va l'ajouter dans ma liste complete de invoice
                }
            }
        }


        //Pour la liste complete
        public IEnumerable<Invoice> GetAll()
        {
            foreach (Invoice c in invoices)
            {
                yield return c;
            }
        }

    }
}
