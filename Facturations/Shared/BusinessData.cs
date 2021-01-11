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
      Factures.Add(new Facture("client1", "19486", DateTime.Now, DateTime.Now, 10000, 4500));
      Factures.Add(new Facture("client2", "1248095", DateTime.Now, DateTime.Now, 15000, 5000));
      Factures.Add(new Facture("client3", "27", DateTime.Now, DateTime.Now, 1234, 5678));
    }

    public IList<Facture> getFactures()
    {
      return Factures;
    }

    public void AjouterFacture(string client, string reference, string dateEmission, string dateReglementAttendu, string montantDu, string montantRegle)
    {
      Factures.Add(new Facture(client, reference, Convert.ToDateTime(dateEmission), Convert.ToDateTime(dateReglementAttendu), int.Parse(montantDu), int.Parse(montantRegle)));
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
