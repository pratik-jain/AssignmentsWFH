using System;
using System.Collections.Generic;

namespace StudentInfoMgmt.Models
{
    public partial class Courses
    {
        public Courses()
        {
            StudentDetails = new HashSet<StudentDetails>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Fee { get; set; }

        public virtual ICollection<StudentDetails> StudentDetails { get; set; }
    }
}
