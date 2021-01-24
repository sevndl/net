using Facturations.Server.Models;
using Facturations.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System;
using Newtonsoft.Json.Linq;

namespace Facturations.Server.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class DashboardController : ControllerBase
  {
    private readonly IBusinessData _data;

    public DashboardController(IBusinessData data)
    {
      _data = data;
    }

    // bonne forme mais pas exploitable car string
    /*[HttpGet]
    public string Get()
    {
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
    }*/


    // bonne forme mais pas exploitable car string
    [HttpGet]
    public string Get()
    {
      return JsonConvert.SerializeObject(new { caAttendu = _data.getCAAttendu(), caReel = _data.getCAReel() });
    }

    // bonne forme mais je ne comprends pas pourquoi les valeurs ne sont pas récupérées et un tableau vide [] apparaît à la place
    /*[HttpGet]
    public JObject Get()
    {
      return JObject.Parse("{ \"caAttendu\": " + _data.getCAAttendu() + ", \"caReel\": " + _data.getCAReel() + " }");
    }*/

    // bonne forme mais je ne comprends pas pourquoi les valeurs ne sont pas récupérées et un tableau vide [] apparaît à la place
    /*[HttpGet]
    public object Get()
    {
      return JsonConvert.DeserializeObject("{ \"caAttendu\": " + _data.getCAAttendu() + ", \"caReel\": " + _data.getCAReel() + " }");
    }*/
  }
}