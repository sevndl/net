using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Facturations.Shared;

namespace Facturations.Server.Models
{
  public class BusinessDataSql : IDisposable
  {
    private SqlConnection cnct;
    private double CAAttendu;
    private double CAReel;

    public BusinessDataSql(string connectionString)
    {
      cnct = new SqlConnection(connectionString);
    }

    public void Dispose()
    {
      cnct.Dispose();
    }

    public IEnumerable<Facture> Factures => cnct.Query<Facture>("SELECT * FROM Facturations ORDER BY DateReglementAttendu DESC");

    public void AjouterFacture(string reference, string client, DateTime dateEmission, DateTime dateReglementAttendu, double montantDu, double montantRegle)
    {
      var p = new DynamicParameters();
      p.Add("@reference", reference, DbType.String, ParameterDirection.Input);
      p.Add("@client", client, DbType.String, ParameterDirection.Input);
      p.Add("@dateEmission", dateEmission, DbType.DateTime, ParameterDirection.Input);
      p.Add("@dateReglementAttendu", dateReglementAttendu, DbType.DateTime, ParameterDirection.Input);
      p.Add("@montantDu", montantDu, DbType.Double, ParameterDirection.Input);
      p.Add("@montantRegle", montantRegle, DbType.Double, ParameterDirection.Input);
      cnct.Execute(@"INSERT INTO Facturations (Reference, Client, DateEmission, DateReglementAttendu, MontantDu, MontantRegle) VALUES (@reference, @client, @dateEmission, @dateReglementAttendu, @montantDu, @montantRegle)", p);
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
