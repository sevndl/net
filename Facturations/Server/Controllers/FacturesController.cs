using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Facturations.Shared;

namespace Facturations.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FacturesController : ControllerBase
    {
        private readonly ILogger<FacturesController> _logger;
        private readonly BusinessData _data;

        public FacturesController(ILogger<FacturesController> logger, BusinessData data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet]
        public IList<Facture> Get()
        {
            return _data.Factures;
        }

        [HttpGet("{reference}")]
        public ActionResult<Facture> Get(string reference)
        {
            var facture = _data.Factures.Where(f => f.reference == reference).FirstOrDefault();
            if (facture != null)
            {
                return facture;
            } 
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Facture> AjouterFacture()
        {
            string client = Request.Form["client"];
            string reference = Request.Form["reference"];
            string dateEmission = Request.Form["dateEmission"];
            string dateReglementAttendu = Request.Form["dateReglementAttendu"];
            string montantDu = Request.Form["montantDu"];
            string montantRegle = Request.Form["montantRegle"];

            _data.AjouterFacture(client, reference, dateEmission, dateReglementAttendu, montantDu, montantRegle);
            return Redirect("/tableauDeBord");
        }
    }
}
