using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDbProject.Models
{
    public partial class CourseGrade
    {
        public int CourseGradeId { get; set; }
        public DateTime? GradeDate { get; set; }
        public int FstudentId { get; set; }
        public int FcourseId { get; set; }
        public int? FgradeId { get; set; }
        public int? FteacherId { get; set; }

        public virtual Course Fcourse { get; set; }
        public virtual Grade Fgrade { get; set; }
        public virtual Student Fstudent { get; set; }
        public virtual Employee Fteacher { get; set; }
    }
}
