using System;
using System.Collections.Generic;

namespace StudentInfoMgmt.Models
{
    public partial class StudentDetails
    {
        public int StudentDetailId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public bool FeeStatus { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Students Student { get; set; }
    }
}
