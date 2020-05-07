using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Treatements
    {
        public int TreatementId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AssistantId { get; set; }

        public virtual Assistants Assistant { get; set; }
        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
