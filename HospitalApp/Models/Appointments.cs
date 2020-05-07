using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Appointments
    {
        public Appointments()
        {
            Patients = new HashSet<Patients>();
        }

        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public DateTimeOffset DateTime { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual ICollection<Patients> Patients { get; set; }
    }
}
