using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Patients
    {
        public Patients()
        {
            PatientDrugs = new HashSet<PatientDrugs>();
            Treatements = new HashSet<Treatements>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Dob { get; set; }
        public string Disease { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public int DepartmentId { get; set; }
        public int AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual Departments Department { get; set; }
        public virtual ICollection<PatientDrugs> PatientDrugs { get; set; }
        public virtual ICollection<Treatements> Treatements { get; set; }
    }
}
