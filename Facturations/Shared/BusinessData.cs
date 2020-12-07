using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturations.Shared
{
    public class BusinessData
    {
        public BusinessData()
        {
            Factures = new Facture[] {
                new Facture("client1", 19486, DateTime.Now, DateTime.Now, 10000, 4500),
                new Facture("client2", 1248095, DateTime.Now, DateTime.Now, 15000, 5000)
            };
        }

        public IEnumerable<Facture> Factures { get; }
    }
}
