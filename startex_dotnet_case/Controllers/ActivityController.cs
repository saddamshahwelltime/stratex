using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using startex.EntityModel.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using startex.EntityModel.BusinessEntities;

namespace startex_dotnet_case.Controllers
{
  [ApiController]
  [Route("api/activity/[controller]")]
  public class ActivityController : ControllerBase
  {
    private readonly stratexDBContext _stratexDBContext;

    public ActivityController(stratexDBContext context)
    {
      _stratexDBContext = context;
    }

    [HttpGet("{id}")]
    public IEnumerable<WeatherForecast> Get()
    {
      return null;
    }
  }
}
