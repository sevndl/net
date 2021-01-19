using System;
using System.Collections.Generic;

namespace Facturations.Shared
{
  public class BusinessData/* : IBusinessData*/
  {
    private double CAAttendu;
    private double CAReel;
    private List<Facture> factures = null;

    public BusinessData()
    {
    }

    public IEnumerable<Facture> Factures => factures;

    public void AjouterFacture(string client, string reference, DateTime dateEmission, DateTime dateReglementAttendu, double montantDu, double montantRegle)
    {
      factures.Add(new Facture(client, reference, dateEmission, dateReglementAttendu, montantDu, montantRegle));
    }

    public double getCAAttendu()
    {
      foreach (Facture facture in factures)
      {
        CAAttendu += facture.montantDu;
      }
      return CAAttendu;
    }

    public double getCAReel()
    {
      foreach (Facture facture in factures)
      {
        CAReel += facture.montantRegle;
      }
      return CAReel;
    }
  }
}
