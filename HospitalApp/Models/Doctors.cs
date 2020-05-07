using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
            Treatements = new HashSet<Treatements>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpectiality { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Treatements> Treatements { get; set; }
    }
}
