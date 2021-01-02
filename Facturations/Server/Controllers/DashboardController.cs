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
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly BusinessData _data;

        public DashboardController(ILogger<DashboardController> logger, BusinessData data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet]
        public string Get()
        {
            return "[{\"caAttendu\":\"" + _data.getCAAttendu() + "\"},{\"caReel\":\"" + _data.getCAReel() + "\"}]";
        }
    }
}
