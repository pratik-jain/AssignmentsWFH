using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Drugs
    {
        public Drugs()
        {
            PatientDrugs = new HashSet<PatientDrugs>();
        }

        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public int Price { get; set; }

        public virtual ICollection<PatientDrugs> PatientDrugs { get; set; }
    }
}
