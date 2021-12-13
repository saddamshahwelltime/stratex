using startex.EntityModel.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace startex.Repositories.Interfaces
{
  public interface IActivityRepository
  {
    
    public List<ActivityEntity> GetActivities();
    public List<ActivityEntity> GetActivity(int UserID);

  }
}
