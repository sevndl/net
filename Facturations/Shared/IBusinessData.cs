using System;
using System.Collections.Generic;

namespace Facturations.Shared
{
  public interface IBusinessData
  {
    IEnumerable<Facture> Factures { get; }
    double CAAttendu { get; }
    double CAReel { get; }
    void AjouterFacture(string client, string reference, DateTime dateEmission, DateTime dateReglementAttendu, double montantDu, double montantRegle);
  }
}
