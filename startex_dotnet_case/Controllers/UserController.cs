using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using startex.EntityModel.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using startex.EntityModel.BusinessEntities;
using startex.Services.Interfaces;
using startex.Services.Classes;

namespace startex_dotnet_case.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private readonly stratexDBContext _stratexDBContext;
    private readonly IUserService _userService;

    public UserController(stratexDBContext context)
    {
      _stratexDBContext = context;

      _userService = new UserService(_stratexDBContext);
    }

    [HttpGet("schedule/{id}")]
    public ScheduleEntity GetSchedule(int id)
    {
       return _userService.GetSchedule(id);

    }
  }
}
