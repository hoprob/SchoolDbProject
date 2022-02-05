using System;
using System.Collections.Generic;
using System.Text;
using SchoolDbProject.Models;
using System.Linq;

namespace SchoolDbProject
{
    internal class ToSchoolDB
    {
        //Add a new employee to Db
        public void AddEmployee(string firstName, string lastName, int roleId)
        {
            using SchoolDbProjectContext Context = new SchoolDbProjectContext();
            Employee emp = new Employee()
            {
                EmpFname = firstName,
                EmpLname = lastName,
                FroleId = roleId
            };
            Context.Employee.Add(emp);
            Context.SaveChanges();
        }
    }
}
