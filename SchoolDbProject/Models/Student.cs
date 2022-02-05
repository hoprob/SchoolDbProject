using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDbProject.Models
{
    public partial class Student
    {
        public Student()
        {
            CourseGrade = new HashSet<CourseGrade>();
        }

        public int StudentId { get; set; }
        public string StudentFname { get; set; }
        public string StudentLname { get; set; }
        public string StudentSocSecNum { get; set; }
        public int FclassId { get; set; }

        public virtual SchoolClass Fclass { get; set; }
        public virtual ICollection<CourseGrade> CourseGrade { get; set; }
    }
}
