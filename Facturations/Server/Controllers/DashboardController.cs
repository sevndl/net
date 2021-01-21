using Facturations.Server.Models;
using Facturations.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System;

namespace Facturations.Server.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class DashboardController : ControllerBase
  {
    private readonly ILogger<DashboardController> _logger;
    private readonly IBusinessData _data;

    public DashboardController(ILogger<DashboardController> logger, IBusinessData data)
    {
      _logger = logger;
      _data = data;
    }

    [HttpGet]
    public string Get()
    {
      // TODO => créer du json exploitable
      StringBuilder sb = new StringBuilder();
      TextWriter tw = new StringWriter(sb);

      using (JsonWriter writer = new JsonTextWriter(tw))
      {
        writer.WriteStartObject();
        writer.WritePropertyName("caAttendu");
        writer.WriteValue(_data.getCAAttendu());
        writer.WritePropertyName("caReel");
        writer.WriteValue(_data.getCAReel());
        writer.WriteEndObject();
      }
      return tw.ToString();
    }
  }
}
