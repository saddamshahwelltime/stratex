using System;
using System.Collections.Generic;
using System.Text;
using startex.EntityModel.BusinessEntities;

namespace startex.Services.Interfaces
{
  public interface IUserService
  {
    public ScheduleEntity GetSchedule(int UserID);
  }
}
