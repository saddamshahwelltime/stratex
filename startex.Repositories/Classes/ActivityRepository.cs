using System;
using System.Collections.Generic;
using System.Text;
using startex.Repositories.Classes;
using startex.Repositories.Base;
using startex.Repositories.Interfaces;
using startex.EntityModel.Contexts;
using startex.EntityModel.BusinessEntities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace startex.Repositories.Classes
{
  public class ActivityRepository : RepositoryBase, IActivityRepository
  {
    private readonly stratexDBContext _stratexDBContext;

    public ActivityRepository(stratexDBContext context)
    {
      _stratexDBContext = context;
    }

    public List<ActivityEntity> GetActivities()
    {
      throw new NotImplementedException();
    }

    public List<ActivityEntity> GetActivity(int UserID)
    {
      List<ActivityEntity> userActivities = new List<ActivityEntity>();

      var breaks = _stratexDBContext.Breaks.Where(b => b.EmployeeId == UserID)
        .Include(b => b.Activity)
        .ToList();

      foreach (var a in breaks)
      {
        ActivityEntity actviity = new ActivityEntity
        {
          ActivityID = a.Activity.Id,
          ActivityType = "Break",
          ActivityName = a.Activity.Name,
          StartDateTime = a.StartDateTime,
          EndDateTime = a.EndDateTime
        };
        userActivities.Add(actviity);
      }

      var leaves = _stratexDBContext.Leaves.Where(l => l.EmployeeId == UserID)
        .Include(l => l.Activity)
        .ToList();
      foreach (var a in leaves)
      {
        ActivityEntity actviity = new ActivityEntity
        {
          ActivityID = a.Activity.Id,
          ActivityType = "Leave",
          ActivityName = a.Activity.Name,
          StartDateTime = a.StartDateTime,
          EndDateTime = a.EndDateTime
        };
        userActivities.Add(actviity);
      }

      var shifts = _stratexDBContext.Shifts.Where(s => s.EmployeeId == UserID)
        .Include(s => s.Activity)
        .ToList();
      foreach (var a in shifts)
      {
        ActivityEntity actviity = new ActivityEntity
        {
          ActivityID = a.Activity.Id,
          ActivityType = "Shift",
          ActivityName = a.Activity.Name,
          StartDateTime = a.StartDateTime,
          EndDateTime = a.EndDateTime
        };
        userActivities.Add(actviity);
      }

      return userActivities;
    }
  }
}
