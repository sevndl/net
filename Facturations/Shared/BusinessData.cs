using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturations.Shared
{
    public class BusinessData
    {
        private int CAAttendu;
        private int CAReel;
        public IEnumerable<Facture> Factures;

        public BusinessData()
        {
            Factures = new Facture[] {
                new Facture("client1", "19486", DateTime.Now, DateTime.Now, 10000, 4500),
                new Facture("client2", "1248095", DateTime.Now, DateTime.Now, 15000, 5000),
                new Facture("client3", "27", DateTime.Now, DateTime.Now, 1234, 5678)
            };
        }

        public IEnumerable<Facture> getFactures()
        {
            return this.Factures;
        }

        public void AjouterFacture(string client, string reference, string dateEmission, string dateReglementAttendu, string montantDu, string montantRegle)
        {
            Console.WriteLine(client);
            Facture nouvelleFacture = new Facture(client, reference, Convert.ToDateTime(dateEmission), Convert.ToDateTime(dateReglementAttendu), int.Parse(montantDu), int.Parse(montantRegle));
            Console.WriteLine(nouvelleFacture.client);
            Factures.Append(nouvelleFacture);
            Console.WriteLine("Facture ajoutée");
        }

        public int getCAAttendu()
        {
            foreach (var facture in Factures)
            {
                CAAttendu += facture.montantDu;
            }
            return CAAttendu;
        }

        public int getCAReel()
        {
            foreach (var facture in Factures)
            {
                CAReel += facture.montantRegle;
            }
            return CAReel;
        }
    }
}
