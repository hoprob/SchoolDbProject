using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDbProject.Models
{
    public partial class Grade
    {
        public Grade()
        {
            CourseGrade = new HashSet<CourseGrade>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public virtual ICollection<CourseGrade> CourseGrade { get; set; }
    }
}
