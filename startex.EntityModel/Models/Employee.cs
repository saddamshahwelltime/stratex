using System;
using System.Collections.Generic;

#nullable disable

namespace startex.EntityModel.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Breaks = new HashSet<Break>();
            Leaves = new HashSet<Leaf>();
            Shifts = new HashSet<Shift>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Break> Breaks { get; set; }
        public virtual ICollection<Leaf> Leaves { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
