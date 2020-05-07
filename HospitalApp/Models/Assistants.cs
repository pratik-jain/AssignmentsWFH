using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Assistants
    {
        public Assistants()
        {
            Treatements = new HashSet<Treatements>();
        }

        public int AssistantId { get; set; }
        public string AssistantName { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Treatements> Treatements { get; set; }
    }
}
