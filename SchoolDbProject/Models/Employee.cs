using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDbProject.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Course = new HashSet<Course>();
            CourseGrade = new HashSet<CourseGrade>();
        }

        public int EmpId { get; set; }
        public string EmpFname { get; set; }
        public string EmpLname { get; set; }
        public int FroleId { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HiringDate { get; set; }

        public virtual Role Frole { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseGrade> CourseGrade { get; set; }
    }
}
