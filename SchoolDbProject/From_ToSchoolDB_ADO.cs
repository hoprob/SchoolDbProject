using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SchoolDbProject.Models;
namespace SchoolDbProject
{
    internal class From_ToSchoolDB_ADO
    {
        string connectionString = @"Data Source=LAPTOP-7C3L3U47;
Initial Catalog=SchoolDbProject; Integrated Security=True;Connect Timeout=30;
Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
MultiSubnetFailover=False";
       
        public List<string> GetEmployees()
        {
            List<string> employees = new List<string>();
            using (SqlConnection connection = 
                new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT EmpFname," +
                    " EmpLname, Role.EmpRole, DATEDIFF(YEAR, HiringDate," +
                    " GETDATE()) FROM Employee JOIN Role " +
                    " ON Employee.FroleId = Role.RoleId", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        string fName = reader.GetString(0);
                        string lName = reader.GetString(1);
                        string role = reader.GetString(2);
                        int yearsHired = reader.GetInt32(3);
                        string emp = fName + "###" + lName + "###" + role +
                            "###" + yearsHired;
                        employees.Add(emp);
                    }
                    reader.Close();
                }
            }
            return employees;
        }
        public List<string> GetEmployees(int roleId)
        {
            List<string> employees = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT EmpFname," +
                    " EmpLname" +
                    " FROM Employee WHERE FroleId = " + roleId, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string fName = reader.GetString(0);
                        string lName = reader.GetString(1);
                        string emp = fName + " " + lName;
                        employees.Add(emp);
                    }
                    reader.Close();
                }
            }
            return employees;
        }
        public List<string> GetGrades(int days)
        {
            List<string> grades = new List<string>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SELECT StudentFName+" +
                    "' '+ StudentLName, CourseName, GradeName FROM CourseGrade " +
                    "JOIN Student ON CourseGrade.FStudentId = Student.StudentId " +
                    "JOIN Course ON CourseGrade.FCourseId = Course.CourseId " +
                    "JOIN Grade ON CourseGrade.FGradeId = Grade.GradeId " +
                    "WHERE DATEDIFF(DAY, GradeDate, GETDATE()) < " + days,
                    connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string courseName = reader.GetString(1);
                        string grade = reader.GetString(2);
                        grades.Add(name+"###"+courseName+"###"+grade);
                    }
                    reader.Close();
                }
            }
            return grades;
        }
        public List<string> GetGradeStatstics()
        {
            List<string> grades = new List<string>();
            FromSchoolDB FromDb = new FromSchoolDB();
            List<Grade> gradeNames = FromDb.GetGradeNames();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SELECT CourseName," +
                    " AVG(FGradeId), MAX(FGradeId), MIN(FGradeId) FROM Course " +
                    "JOIN CourseGrade ON Course.CourseId = CourseGrade.FCourseId" +
                    " Group By CourseName", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        string courseName = reader.GetString(0);
                        int avg = reader.GetInt32(1);
                        int max = reader.GetInt32(2);
                        int min = reader.GetInt32(3);
                        grades.Add(courseName + "###" + 
                            gradeNames[avg-1].GradeName + "###" +
                            gradeNames[max-1].GradeName + "###" + 
                            gradeNames[min-1].GradeName);
                    }
                    reader.Close();
                }
            }
            return grades;
        }
        public void AddStudent(string firstName, string lastName,
            string socSecNum, int classId)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"INSERT INTO" +
                    $" Student(StudentFName, StudentLName, StudentSocSecNum," +
                    $" FClassId) " +
                    $" VALUES('{firstName}', '{lastName}', '{socSecNum}', {classId})", connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
