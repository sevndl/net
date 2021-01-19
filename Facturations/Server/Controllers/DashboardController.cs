using Facturations.Server.Models;
using Facturations.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Facturations.Server.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class DashboardController : ControllerBase
  {
    private readonly ILogger<DashboardController> _logger;
    private readonly BusinessDataSql _data;

    public DashboardController(ILogger<DashboardController> logger, BusinessDataSql data)
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
