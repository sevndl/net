using Facturations.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Facturations.Server.Models
{
  public class BusinessDataSql : IBusinessData, IDisposable
  {
    private SqlConnection cnct;

    public BusinessDataSql(string connectionString)
    {
      cnct = new SqlConnection(connectionString);
    }

    public void Dispose()
    {
      cnct.Dispose();
    }

    public IEnumerable<Facture> Factures => cnct.Query<Facture>("SELECT * FROM Facturation");

    public double getCAAttendu()
    {
      if (Factures.Count() == 0) { return 0; }
      else { return cnct.QuerySingleOrDefault<double>("SELECT SUM(montantDu) FROM Facturation"); }
    }

    public double getCAReel()
    {
      if (Factures.Count() == 0) { return 0; }
      else { return cnct.QuerySingleOrDefault<double>("SELECT SUM(montantRegle) FROM Facturation"); }
    }

    public void AjouterFacture(string reference, string client, DateTime dateEmission, DateTime dateReglementAttendu, double montantDu, double montantRegle)
    {
      var p = new DynamicParameters();
      p.Add("@reference", reference, DbType.String, ParameterDirection.Input);
      p.Add("@client", client, DbType.String, ParameterDirection.Input);
      p.Add("@dateEmission", dateEmission, DbType.DateTime, ParameterDirection.Input);
      p.Add("@dateReglementAttendu", dateReglementAttendu, DbType.DateTime, ParameterDirection.Input);
      p.Add("@montantDu", montantDu, DbType.Double, ParameterDirection.Input);
      p.Add("@montantRegle", montantRegle, DbType.Double, ParameterDirection.Input);
      p.Add("@CAAttendu", getCAAttendu() + montantDu, DbType.Double, ParameterDirection.Input);
      p.Add("@CAReel", getCAReel() + montantRegle, DbType.Double, ParameterDirection.Input);
      cnct.Execute(@"INSERT INTO Facturation (Reference, Client, DateEmission, DateReglementAttendu, MontantDu, MontantRegle, CAAttendu, CAReel) VALUES (@reference, @client, @dateEmission, @dateReglementAttendu, @montantDu, @montantRegle, @CAAttendu, @CAReel)", p);
    }
  }
}
