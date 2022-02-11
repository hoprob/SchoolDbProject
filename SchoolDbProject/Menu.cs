using System;
using SchoolDbProject.Models;
using System.Collections.Generic;
using System.Threading;
namespace SchoolDbProject
{
    internal class Menu
    {
        private FromSchoolDB FromDb;
        private ToSchoolDB ToDb;
        private From_ToSchoolDB_ADO ADO;
        public Menu()
        {
            FromDb = new FromSchoolDB();
            ToDb = new ToSchoolDB();
            ADO = new From_ToSchoolDB_ADO();
        }
        public void StartMenu()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*             Välkommen            *");
                Console.WriteLine("\t*               Till               *");
                Console.WriteLine("\t*           Skoldatabasen!         *");
                Console.WriteLine("\t************************************");
                Console.WriteLine("\n\t   Välj vad du vill göra:\n");
                Console.WriteLine("\t[1] Elevinformation");
                Console.WriteLine("\t[2] Personalinformation");
                Console.WriteLine("\t[3] Kurs- och Betygsinformation");
                Console.WriteLine("\t[4] Administrera personal");
                Console.WriteLine("\t[5] Administrera elever");
                Console.WriteLine("\t[6] Avsluta");
                switch(Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        StudentInfoMenu();
                        break;
                    case "2":
                        Console.Clear();
                        EmployeeInfoMenu();
                        break;
                    case "3":
                        Console.Clear();
                        CourseAndGradeInfoMenu();
                        break;
                    case "4":
                        Console.Clear();
                        AdminEmployees();
                        break;
                    case "5":
                        Console.Clear();
                        AdminStudents();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\t\tERROR! Du måste skriva in en" +
                            " siffra mellan 1 och 6!");
                        break;
                }
            }
        }
        private void StudentInfoMenu()
        {
            bool menuBool = true;
            while (menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*         StudentInformation       *");
                Console.WriteLine("\t*                                  *");
                Console.WriteLine("\t************************************");
                Console.WriteLine("\n\t   Välj vad du vill göra:\n");
                Console.WriteLine("\t[1] Hämta lista på alla elever");
                Console.WriteLine("\t[2] Hämta lista på elever i en klass");
                Console.WriteLine("\t[3] Gå tillbaka");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        GetAllStudents();
                        break;
                    case "2":
                        Console.Clear();
                        GetAllStudentsFromClass();
                        break;
                    case "3":
                        Console.Clear();
                        menuBool = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\t\tERROR! Du måste skriva in en" +
                            " siffra mellan 1 och 3!");
                        break;
                }
            }           
        }
        private void EmployeeInfoMenu()
        {
            bool menuBool = true;
            Console.Clear();
            while (menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*        Personalinformation       *");
                Console.WriteLine("\t*                                  *");
                Console.WriteLine("\t************************************");
                Console.WriteLine("\n\tVälj hur du vill se listan:\n");
                Console.WriteLine("\t[1] Se information om all personal");
                Console.WriteLine("\t[2] Se personal inom en yrkesroll");
                Console.WriteLine("\t[3] Visa antal anställda på avdelningar");
                Console.WriteLine("\t[4] Gå tillbaka");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("\t╔════════════════════════════════" +
                            "═════════════════════════╗");
                        Console.WriteLine(String.Format("\t║{0, -20}│{1, -20}" +
                            "│{2, -15}║", "        NAMN", "     AVDELNING",
                            "  ÅR ANSTÄLLD"));
                        Console.WriteLine("\t╠════════════════════════════════" +
                            "═════════════════════════╣");
                        foreach (var emp in ADO.GetEmployees())
                        {
                            string[] empArr = emp.Split("###");
                            Console.WriteLine(String.Format("\t║{0, -20}│{1, -20}│" +
                                "{2, 15}║", empArr[0] +" "+ empArr[1], empArr[2],
                                empArr[3]));
                            Console.WriteLine("\t║────────────────────────────" +
                                "─────────────────────────────║");
                        }
                        Console.WriteLine("\t╚════════════════════════════════" +
                            "═════════════════════════╝");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        bool roleMenuBool = true;
                        while (roleMenuBool)
                        {
                            Console.WriteLine("\t************************************");
                            Console.WriteLine("\t*            Hämta lista           *");
                            Console.WriteLine("\t*       På Personal(yrkesroll)     *");
                            Console.WriteLine("\t************************************");
                            Console.WriteLine("\n\tVälj vilken yrkesroll du vill" +
                                " se:\n");
                            List<Role> roleList = FromDb.GetEmpRoles();
                            foreach (var role in roleList)
                            {
                                Console.WriteLine($"\t[{role.RoleId}]" +
                                    $" {role.EmpRole}");
                            }
                            string input = Console.ReadLine();
                            int roleId;
                            if (!Int32.TryParse(input, out roleId) || roleId < 1 
                                || roleId > roleList.Count)
                            {
                                Console.Clear();
                                Console.WriteLine($"\n\tERROR! Du måste skriva" +
                                    $" en siffra mellan 1 och {roleList.Count}");
                                continue;
                            }
                            Console.Clear();
                            Console.WriteLine("\t╔══════════════════════════════╗");
                            Console.WriteLine(String.Format("\t║{0, -30}║", $"          ALLA {roleList[roleId - 1].EmpRole.ToUpper()}"));
                            Console.WriteLine("\t╠══════════════════════════════╣");
                            foreach (var emp in ADO.GetEmployees(roleId))
                            {
                                Console.WriteLine(String.Format("\t║{0, -30}║",
                                    emp));
                                Console.WriteLine("\t║─────────────────────────" +
                                    "─────║");
                            }
                            Console.WriteLine("\t╚═════════════════════════════" +
                                "═╝");
                            Console.ReadKey();
                            Console.Clear();
                            roleMenuBool = false;
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Dictionary<string, int> EmpRoleCount =
                            FromDb.GetRoleEmployeeCount();
                        Console.WriteLine("\t╔════════════════════════════════" +
                            "════╗");
                        Console.WriteLine(String.Format("\t║{0, -20}│{1, -15}║"
                            , "     AVDELNING", "ANTAL ANSTÄLLDA"));
                        Console.WriteLine("\t╠════════════════════════════════" +
                            "════╣");
                        foreach (var item in EmpRoleCount)
                        {
                            Console.WriteLine(String.Format("\t║{0, -20}│{1, 15}" +
                                "║", item.Key, item.Value));
                            Console.WriteLine("\t║────────────────────────────" +
                                "────────║");
                        }
                        Console.WriteLine("\t╚═════════════════════════════════" +
                            "═══╝");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        menuBool = false;
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\t\tERROR! Du måste skriva in en " +
                            "siffra mellan 1 och 4!");
                        break;
                }
            }
        }
        private void CourseAndGradeInfoMenu()
        {
            bool menuBool = true;
            while (menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*           Kurs- och Betygs       *");
                Console.WriteLine("\t*             Information          *");
                Console.WriteLine("\t************************************");
                Console.WriteLine("\n\t   Välj vad du vill göra:\n");
                Console.WriteLine("\t[1] Visa betyg satta senaste månaden");
                Console.WriteLine("\t[2] Visa kurser med betygsstatistik");
                Console.WriteLine("\t[3] Visa alla aktiva kurser");
                Console.WriteLine("\t[4] Gå tillbaka");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        GetGrades();
                        break;
                    case "2":
                        Console.Clear();
                        GetGradesStatistics();
                        break;
                    case "3":
                        Console.Clear();
                        ICollection<Course> activeCourses = FromDb.GetActiveCourses();
                        string active;
                        Console.WriteLine("\t╔════════════════════════════════" +
                            "════╗");
                        Console.WriteLine(String.Format("\t║{0, -20}│{1, -15}║"
                            , "        KURS", "    STATUS"));
                        Console.WriteLine("\t╠════════════════════════════════" +
                            "════╣");
                        foreach (Course course in activeCourses)
                        {
                            active = Convert.ToBoolean(course.IsActive) ?
                                "Aktiv" : "Ej Aktiv";
                            Console.WriteLine(String.Format("\t║{0, -20}│{1, 15}" +
                                "║", course.CourseName, active));
                            Console.WriteLine("\t║─────────────────────────────" +
                                "───────║");
                        }
                        Console.WriteLine("\t╚═════════════════════════════════" +
                            "═══╝");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        menuBool = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\t\tERROR! Du måste skriva in en" +
                            " siffra mellan 1 och 4!");
                        break;
                }
            }
        }
        private void AdminEmployees()
        {
            bool menuBool = true;
            while (menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*            Administera           *");
                Console.WriteLine("\t*             Personal             *");
                Console.WriteLine("\t************************************");
                Console.WriteLine("\n\tVälj vad du vill göra:\n");
                Console.WriteLine("\t[1] Lägga till en anställd");
                Console.WriteLine("\t[2] Gå tillbaka");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        AddEmployee();
                        break;
                    case "2":
                        Console.Clear();
                        menuBool = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\t\tERROR! Du måste skriva in en" +
                            " siffra mellan 1 och 2!");
                        break;
                }
            }
        }
        private void AdminStudents()
        {
            bool menuBool = true;
            while (menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*            Administera           *");
                Console.WriteLine("\t*              Elever              *");
                Console.WriteLine("\t************************************");
                Console.WriteLine("\n\tVälj vad du vill göra:\n");
                Console.WriteLine("\t[1] Lägga till en elev");
                Console.WriteLine("\t[2] Gå tillbaka");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        AddStudent();
                        break;
                    case "2":
                        Console.Clear();
                        menuBool = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\t\tERROR! Du måste skriva in en" +
                            " siffra mellan 1 och 2!");
                        break;
                }
            }
        }
        private void GetAllStudents()
        {
            bool menuBool = true;
            while(menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*            Hämta alla            *");
                Console.WriteLine("\t*              Elever              *");
                Console.WriteLine("\t************************************");
                Console.WriteLine("\n\tVälj hur du vill sortera listan:\n");
                Console.WriteLine("\t[1] Förnamn i stigande ordning");
                Console.WriteLine("\t[2] Förnamn i fallande ordning");
                Console.WriteLine("\t[3] Efternamn i stigande ordning");
                Console.WriteLine("\t[4] Efternamn i fallande ordning");
                Console.WriteLine("\t[5] Gå tillbaka");
                switch (Console.ReadLine())
                {
                    case "1":
                        PrintStudents(OrderBy.FirstName, OrderBy.Ascending);
                        break;
                    case "2":
                        PrintStudents(OrderBy.FirstName, OrderBy.Decending);
                        break;
                    case "3":
                        PrintStudents(OrderBy.LastName, OrderBy.Ascending);
                        break;
                    case "4":
                        PrintStudents(OrderBy.LastName, OrderBy.Decending);
                        break;
                    case "5":
                        menuBool = false;
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\t\tERROR! Du måste skriva in en" +
                            " siffra mellan 1 och 5!");
                        break;
                }
            }
        }
        private void PrintStudents(OrderBy name, OrderBy order)
        {
            Console.Clear();
            Console.WriteLine("\t╔══════════════════════════════════════════" +
                "════════════════════╗");
            Console.WriteLine(String.Format("\t║{0, -20}│{1, -20}│{2, -20}║",
                "FÖRNAMN", "EFTERNAMN", "PERSONNUMMER"));
            Console.WriteLine("\t╠═══════════════════════════════════════════" +
                "═══════════════════╣");
            foreach (var student in FromDb.GetStudents(name, order))
            {
                Console.WriteLine(String.Format("\t║{0, -20}│{1, -20}│{2, -20}" +
                    "║", student.StudentFname, student.StudentLname,
                    student.StudentSocSecNum));
                Console.WriteLine("\t║─────────────────────────────────────────" +
                    "─────────────────────║");
            }
            Console.WriteLine("\t╚════════════════════════════════════════════" +
                "══════════════════╝");           
            Console.ReadKey();
            Console.Clear();
        }
        private void GetAllStudentsFromClass()
        {
            bool menuBool = true;
            while (menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*         Hämta alla elever        *");
                Console.WriteLine("\t*           Från en klass          *");
                Console.WriteLine("\t************************************");
                Console.WriteLine("\n\tVälj vilken klass du vill hämta elever " +
                    "från:");
                List<SchoolClass> classList = FromDb.GetClassList();
                foreach (var classItem in classList)
                {
                    Console.WriteLine($"\t[{classItem.ClassId}]" +
                        $" {classItem.ClassName}");
                }
                string input = Console.ReadLine();
                int classId;
                if (!Int32.TryParse(input, out classId)||
                    classId > classList.Count || Convert.ToInt32(input) < 1)
                {
                    Console.Clear();
                    Console.WriteLine($"\n\tERROR! Du måste skriva en siffra " +
                        $"mellan 1 och {classList.Count}");
                    continue;
                }
                Console.Clear();
                Console.WriteLine("\t╔═════════════════════════╗");
                Console.WriteLine(String.Format("\t║{0, -25}║", $" " +
                    $"    ELEVER I {classList[classId - 1].ClassName}"));
                Console.WriteLine("\t╠═════════════════════════╣");
                foreach (var student in FromDb.GetClassStudents(classId))
                {
                    Console.WriteLine(String.Format("\t║{0, -25}║",
                        student.StudentFname+" "+student.StudentLname));
                    Console.WriteLine("\t║─────────────────────────║");
                }
                Console.WriteLine("\t╚═════════════════════════╝");
                Console.ReadKey();
                Console.Clear();
                menuBool = false;
            }           
        }      
        private void AddEmployee()
        {
            bool menuBool = true;
            while(menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*           Lägga till en          *");
                Console.WriteLine("\t*             Anställd             *");
                Console.WriteLine("\t************************************\n");
                Console.WriteLine("\tVälj vilken typ av anställd du vill lägga" +
                    " till: \n");
                List<Role> roleList = FromDb.GetEmpRoles();   
                foreach (var role in roleList)
                {
                    Console.WriteLine($"\t[{role.RoleId}] {role.EmpRole}");
                }
                string input = Console.ReadLine();
                int roleId;
                if (!Int32.TryParse(input, out roleId) || roleId < 1 ||
                    roleId > roleList.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"\n\tERROR! Du måste skriva en siffra" +
                        $" mellan 1 och {roleList.Count}");
                    continue;
                }
                Console.Write("\tMata in förnamn: ");
                string firstName = Console.ReadLine();
                Console.Write("\n\tMata in efternamn: ");
                string lastName = Console.ReadLine();
                Console.Write($"\n\tMata in vilken månadslön {firstName} skall" +
                    $" ha: ");
                decimal salary;
                while(!Decimal.TryParse(Console.ReadLine(), out salary))
                {
                    Console.Write("\tERROR! Du måste skriva in lön med" +
                        " siffror!\n\tFörsök igen: ");
                }
                ToDb.AddEmployee(firstName, lastName, roleId, salary);
                Console.WriteLine("\n\t\tAnställd tillagd i databasen!");
                Thread.Sleep(2000);
                Console.Clear();
                menuBool = false;   
            }
        }
        private void GetGrades()
        {
            Console.WriteLine("\t╔════════════════════════════════════════════" +
                "════════╗");
            Console.WriteLine(String.Format("\t║{0, -52}║",
                "              BETYG DEN SENASTE MÅNADEN"));
            Console.WriteLine("\t╠════════════════════════════════════════════" +
                "════════╣");
            Console.WriteLine(String.Format("\t║{0, -20}│{1, -20}│{2, -10}║",
                "        ELEV", "        KURS", "  BETYG"));
            Console.WriteLine("\t╠════════════════════════════════════════════" +
                "════════╣");
            foreach (var grade in ADO.GetGrades(31))
            {
                string[] gradeArray = grade.Split("###");
                Console.WriteLine(String.Format("\t║{0, -20}│{1, -20}│{2, -10}" +
                    "║", gradeArray[0], gradeArray[1], gradeArray[2]));
                Console.WriteLine("\t║────────────────────────────────────────" +
                    "────────────║");
            }
            Console.WriteLine("\t╚════════════════════════════════════════════" +
                "════════╝");
            Console.ReadKey();
            Console.Clear();
        }
        private void GetGradesStatistics()
        {
            Console.WriteLine("\t╔════════════════════════════════════════════" +
                "═════════╗");
            Console.WriteLine(String.Format("\t║{0, -53}║",
                "               KURSER MED BETYGSSTATISTIK"));
            Console.WriteLine("\t╠═════════════════════════════════════════════" +
                "════════╣");
            Console.WriteLine(String.Format("\t║{0, -20}│{1, -10}│{2, -10}│" +
                "{3, -10}║", "        KURS", "GENOMSNITT", "   MAX", "   MIN"));
            Console.WriteLine("\t╠════════════════════════════════════════════" +
                "═════════╣");
            foreach (var grade in ADO.GetGradeStatstics())
            {
                string[] gradeArray = grade.Split("###");
                Console.WriteLine(String.Format("\t║{0, -20}│{1, -10}│{2, -10}│" +
                    "{3, -10}║", gradeArray[0], gradeArray[1], gradeArray[2],
                    gradeArray[3]));
                Console.WriteLine("\t║───────────────────────────────────────" +
                    "──────────────║");
            }
            Console.WriteLine("\t╚═══════════════════════════════════════════" +
                "══════════╝");
            Console.ReadKey();
            Console.Clear();
        }
        private void AddStudent()
        {
            bool menuBool = true;
            while(menuBool)
            {
                Console.WriteLine("\t************************************");
                Console.WriteLine("\t*           Lägg till ny           *");
                Console.WriteLine("\t*               Elev               *");
                Console.WriteLine("\t************************************\n");
                Console.WriteLine("\tVälj vilken klass du vill lägga till" +
                    " eleven i: \n");
                List<SchoolClass> classList = FromDb.GetClassList();
                foreach (var classItem in classList)
                {
                    Console.WriteLine($"\t[{classItem.ClassId}]" +
                        $" {classItem.ClassName}");
                }
                string input = Console.ReadLine();
                int classId;
                if (!Int32.TryParse(input, out classId) ||
                    classId > classList.Count || Convert.ToInt32(input) < 1)
                {
                    Console.Clear();
                    Console.WriteLine($"\n\tERROR! Du måste skriva en siffra" +
                        $" mellan 1 och {classList.Count}");
                    continue;
                }
                Console.Write("\tMata in förnamn: ");
                string firstName = Console.ReadLine();
                Console.Write("\tMana in efternamn: ");
                string lastName = Console.ReadLine();
                Console.Write("\tMata in personnummer (YYYYMMDD-NNNN): ");
                string socSecNum = Console.ReadLine();
                ADO.AddStudent(firstName, lastName, socSecNum, classId);
                Console.WriteLine("\n\t\tElev tillagd i databasen!");
                Thread.Sleep(2000);
                Console.Clear();
                menuBool = false;
            }           
        }
    }
}
