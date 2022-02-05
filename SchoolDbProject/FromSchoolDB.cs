using System;
using System.Collections.Generic;
using System.Text;
using SchoolDbProject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace SchoolDbProject
{
    internal class FromSchoolDB
    {
        //Get list of students
        public List<Student> GetStudents(OrderBy name, OrderBy asceDesc)
        {
            using SchoolDbProjectContext Context = new SchoolDbProjectContext();
            if (name == OrderBy.FirstName && asceDesc == OrderBy.Ascending)
            {
                return (from Student in Context.Student orderby Student.StudentFname ascending select Student).ToList<Student>();
            }
            else if(name == OrderBy.FirstName && asceDesc == OrderBy.Decending)
            {
                return (from Student in Context.Student orderby Student.StudentFname descending select Student).ToList<Student>();
            }
            else if(name == OrderBy.LastName && asceDesc == OrderBy.Ascending)
            {
                return (from Student in Context.Student orderby Student.StudentLname ascending select Student).ToList<Student>();
            }
            else
            {
                return (from Student in Context.Student orderby Student.StudentLname descending select Student).ToList<Student>();
            }
        }
        //Get list of classes
        public List<SchoolClass> GetClassList()
        {
            using SchoolDbProjectContext Context = new SchoolDbProjectContext();
            return (from SchoolClass in Context.SchoolClass orderby SchoolClass.ClassId ascending select SchoolClass).ToList<SchoolClass>();
        }
        //Get list of students from a class
        public List<Student> GetClassStudents(int classId)
        {
            using SchoolDbProjectContext Context = new SchoolDbProjectContext();
            return (from Student in Context.Student where Student.FclassId == classId select Student).ToList<Student>();           
        }
        //Get list of employee roles
        public List<Role> GetEmpRoles()
        {
            using SchoolDbProjectContext Context = new SchoolDbProjectContext();
            return (from Role in Context.Role orderby Role.RoleId ascending select Role).ToList<Role>();
        }
     
        //Get names of the different grades
        public List<Grade> GetGradeNames()
        {
            using SchoolDbProjectContext Context = new SchoolDbProjectContext();
            return (from Grade in Context.Grade orderby Grade.GradeId ascending select Grade).ToList<Grade>();
        }
    }
}
