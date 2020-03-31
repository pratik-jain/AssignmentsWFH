using System;
using System.Collections.Generic;

namespace StudentInfoMgmt.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentDetails = new HashSet<StudentDetails>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<StudentDetails> StudentDetails { get; set; }
    }
}
