using System;
using System.Collections.Generic;

namespace Facturations.Shared
{
  public class BusinessData
  {
    private int CAAttendu;
    private int CAReel;
    public IList<Facture> Factures = new List<Facture>();

    public BusinessData()
    {
    }

    public IList<Facture> getFactures()
    {
      return Factures;
    }

    public void AjouterFacture(string client, string reference, DateTime dateEmission, DateTime dateReglementAttendu, int montantDu, int montantRegle)
    {
      Factures.Add(new Facture(client, reference, dateEmission, dateReglementAttendu, montantDu, montantRegle));
    }

    public int getCAAttendu()
    {
      foreach (Facture facture in Factures)
      {
        CAAttendu += facture.montantDu;
      }
      return CAAttendu;
    }

    public int getCAReel()
    {
      foreach (Facture facture in Factures)
      {
        CAReel += facture.montantRegle;
      }
      return CAReel;
    }
  }
}
