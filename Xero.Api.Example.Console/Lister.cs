using System.Collections.Generic;
using System.Linq;

namespace Xero.Api.Example.Console
{
    internal class Lister
    {
        private readonly IXeroApi _api;

        public Lister(IXeroApi api)
        {
            _api = api;
        }

        public void List()
        {
            System.Console.WriteLine("Your organisation is called {0}", _api.Core.FindOrganisationAsync().Result.LegalName);

            System.Console.WriteLine("There are {0} accounts", _api.Core.Accounts.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} bank transactions", _api.Core.BankTransactions.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} bank transfers", _api.Core.BankTransfers.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} branding themes", _api.Core.BrandingThemes.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} contacts", GetTotalContactCount());
            System.Console.WriteLine("There are {0} credit notes", _api.Core.CreditNotes.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} currencies", _api.Core.Currencies.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} employees", _api.Core.Employees.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} expense claims", _api.Core.ExpenseClaims.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} defined items", _api.Core.Items.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} invoices", GetTotalInvoiceCount());
            System.Console.WriteLine("There are {0} journal entries", _api.Core.Journals.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} manual journal entries", _api.Core.ManualJournals.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} payments", _api.Core.Payments.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} receipts", _api.Core.Receipts.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} repeating invoices", _api.Core.RepeatingInvoices.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} tax rates", _api.Core.TaxRates.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} tracking categories", _api.Core.TrackingCategories.FindAsync().Result.Count());
            System.Console.WriteLine("There are {0} users", _api.Core.Users.FindAsync().Result.Count());

            
            ListReports(_api.Core.Reports.Named(), "named");
            ListReports(_api.Core.Reports.PublishedAsync().Result, "published");
            System.Console.WriteLine("Done!");
            System.Console.ReadLine();
        }

        private int GetTotalContactCount()
        {
            int count = _api.Core.Contacts.FindAsync().Result.Count();
            int total = count;
            int page = 2;

            while(count == 100)
            {
                count = _api.Core.Contacts.Page(page++).FindAsync().Result.Count();
                total += count;
            }

            return total;
        }

        private int GetTotalInvoiceCount()
        {
            int count = _api.Core.Invoices.FindAsync().Result.Count();
            int total = count;
            int page = 2;

            while (count == 100)
            {
                count = _api.Core.Invoices.Page(page++).FindAsync().Result.Count();
                total += count;
            }

            return total;
        }

        private void ListReports(IEnumerable<string> reports, string name)
        {
            var enumerable = reports as IList<string> ?? reports.ToList();
            System.Console.WriteLine("There are {0} {1} reports", enumerable.Count(), name);
                
            if (enumerable.Any())
            {
                System.Console.WriteLine("Named:");
                foreach (var r in enumerable)
                {
                    System.Console.WriteLine("\t{0}", r);
                }
            }
        }
    }
}