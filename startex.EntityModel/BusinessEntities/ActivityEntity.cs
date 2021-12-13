using System;
using System.Collections.Generic;
using System.Text;

namespace startex.EntityModel.BusinessEntities
{
  public class ActivityEntity
  {
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public decimal ActivityID { get; set; }
    public string ActivityName { get; set; }
    public string ActivityType { get; set; }


    //enum ActivityName
    //{
    //  Chat,
    //  Telephone,
    //  Break,
    //  HolidayLeave,
    //  Lunch
    //}


  }
}
