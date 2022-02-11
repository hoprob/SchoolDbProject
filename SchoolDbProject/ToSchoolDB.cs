using System;
using System.Collections.Generic;
using System.Text;
using SchoolDbProject.Models;
namespace SchoolDbProject
{
    internal class ToSchoolDB
    {
        //Add a new employee to Db
        public void AddEmployee(string firstName, string lastName, int roleId,
            decimal salary)
        {
            using SchoolDbProjectContext Context = new SchoolDbProjectContext();
            Employee emp = new Employee()
            {
                EmpFname = firstName,
                EmpLname = lastName,
                FroleId = roleId,
                Salary = salary,
                HiringDate = DateTime.Now
            };
            Context.Employee.Add(emp);
            Context.SaveChanges();
        }
    }
}
