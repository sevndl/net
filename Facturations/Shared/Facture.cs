using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturations.Shared
{
    public class Facture
    {
        public Facture(string client, string reference, DateTime dateEmission, DateTime dateReglementAttendu, int montantDu, int montantRegle)
        {
            this.client = client;
            this.reference = reference;
            this.dateEmission = dateEmission;
            this.dateReglementAttendu = dateReglementAttendu;
            this.montantDu = montantDu;
            this.montantRegle = montantRegle;
        }
        [Required(ErrorMessage = "La référence de la facture est obligatoire")]
        // ajouter des validations
        public string client { get; set; }
        public string reference { get; set; }
        public DateTime dateEmission { get; set; }
        public DateTime dateReglementAttendu { get; set; }
        public int montantDu { get; set; }
        public int montantRegle { get; set; }

    }
}
