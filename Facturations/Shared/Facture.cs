using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturations.Shared
{
    public class Facture
    {
        public string client { get; set; }
        public int numero { get; set; }
        public DateTime dateEmission { get; set; }
        public DateTime dateReglementAttendu { get; set; }
        public int montantDu { get; set; }
        public int montantRegle { get; set; }

        public Facture(string client, int numero, DateTime dateEmission, DateTime dateReglementAttendu, int montantDu, int montantRegle)
        {
            this.client = client;
            this.numero = numero;
            this.dateEmission = dateEmission;
            this.dateReglementAttendu = dateReglementAttendu;
            this.montantDu = montantDu;
            this.montantRegle = montantRegle;
        }
    }
}
