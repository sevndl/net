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
        public IEnumerable<Facture> Get()
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
            } else
            {
                return NotFound();
            }
        }
    }
}
