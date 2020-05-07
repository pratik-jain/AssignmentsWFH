using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class PatientDrugs
    {
        public int PatientDrugId { get; set; }
        public int PatientId { get; set; }
        public int DrugId { get; set; }
        public string Time { get; set; }

        public virtual Drugs Drug { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
