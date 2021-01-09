using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Facturations.Shared;
using Newtonsoft.Json;
using System.Text;
using System.IO;

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
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("caAttendu");
                writer.WriteValue(_data.getCAAttendu());
                writer.WritePropertyName("caReel");
                writer.WriteValue(_data.getCAReel());
                writer.WriteEnd();
            }
            return sb.ToString();
        }
    }
}
