using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDbProject.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseGrade = new HashSet<CourseGrade>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int? FteacherId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employee Fteacher { get; set; }
        public virtual ICollection<CourseGrade> CourseGrade { get; set; }
    }
}
