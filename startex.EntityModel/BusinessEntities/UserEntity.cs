using System;
using System.Collections.Generic;
using System.Text;

namespace startex.EntityModel.BusinessEntities
{
  public class UserEntity
  {
    public decimal EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public List<ActivityEntity> Activities { get; set; }




  }
}
