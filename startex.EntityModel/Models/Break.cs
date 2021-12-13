using System;
using System.Collections.Generic;

#nullable disable

namespace startex.EntityModel.Models
{
    public partial class Break
    {
        public decimal Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal ActivityId { get; set; }
        public decimal EmployeeId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
