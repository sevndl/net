using System;
using System.ComponentModel.DataAnnotations;

namespace Facturations.Shared
{
  public class Facture
  {
    [Required(ErrorMessage = "Champ obligatoire")]
    public string client { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    public string reference { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    public DateTime dateEmission { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    public DateTime dateReglementAttendu { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    public int montantDu { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    public int montantRegle { get; set; }

    public Facture(string client, string reference, DateTime dateEmission, DateTime dateReglementAttendu, int montantDu, int montantRegle)
    {
      this.client = client;
      this.reference = reference;
      this.dateEmission = dateEmission;
      this.dateReglementAttendu = dateReglementAttendu;
      this.montantDu = montantDu;
      this.montantRegle = montantRegle;
    }
  }
}
