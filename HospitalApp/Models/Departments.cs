using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Assistants = new HashSet<Assistants>();
            Doctors = new HashSet<Doctors>();
            Patients = new HashSet<Patients>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Assistants> Assistants { get; set; }
        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<Patients> Patients { get; set; }
    }
}
