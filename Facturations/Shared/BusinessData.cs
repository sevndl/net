using System;
using System.Collections.Generic;

namespace Facturations.Shared
{
  public class BusinessData
  {
    private double CAAttendu;
    private double CAReel;
    public IList<Facture> Factures = new List<Facture>();

    public BusinessData()
    {
    }

    public IList<Facture> getFactures()
    {
      return Factures;
    }

    public void AjouterFacture(string client, string reference, DateTime dateEmission, DateTime dateReglementAttendu, double montantDu, double montantRegle)
    {
      Factures.Add(new Facture(client, reference, dateEmission, dateReglementAttendu, montantDu, montantRegle));
    }

    public double getCAAttendu()
    {
      foreach (Facture facture in Factures)
      {
        CAAttendu += facture.montantDu;
      }
      return CAAttendu;
    }

    public double getCAReel()
    {
      foreach (Facture facture in Factures)
      {
        CAReel += facture.montantRegle;
      }
      return CAReel;
    }
  }
}
