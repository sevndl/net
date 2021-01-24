using Facturations.Server.Models;
using Facturations.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Facturations.Server.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class FacturesController : ControllerBase
  {
    private readonly IBusinessData _data;

    public FacturesController(IBusinessData data)
    {
      _data = data;
    }

    [HttpGet]
    public IEnumerable<Facture> Get()
    {
      return _data.Factures;
    }

    [HttpGet("{reference}")]
    public ActionResult<Facture> Get(string reference)
    {
      Facture facture = _data.Factures.Where(f => f.reference == reference).FirstOrDefault();
      if (facture != null)
      {
        return facture;
      }
      else
      {
        return NotFound("Aucune facture avec cette référence.");
      }
    }

    [HttpPost]
    public void AjouterFacture([FromBody] Facture NewFacture)
    {
      _data.AjouterFacture(NewFacture.client, NewFacture.reference, NewFacture.dateEmission, NewFacture.dateReglementAttendu, NewFacture.montantDu, NewFacture.montantRegle);
    }
  }
}
