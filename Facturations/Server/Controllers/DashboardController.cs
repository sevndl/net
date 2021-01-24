using Facturations.Server.Models;
using Facturations.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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

    [HttpGet]
    public Dictionary<string, double> Get()
    {
      return new Dictionary<string, double> { { "caAttendu", _data.getCAAttendu() }, { "caReel", _data.getCAReel() } };
    }
  }
}