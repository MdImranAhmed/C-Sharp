using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1272315_Project
{
    internal class Program
    {
        static ProjectRepository repository = new ProjectRepository();
        static void Main(string[] args)
        {
            try
            {
                DoTask();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
            Console.ReadKey();
        }

        private static void DoTask()
        {            
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\tProject Details Application\r");
            Console.WriteLine("\t\t\t\t\t---------------------------\n");
            Console.Write("How many operation do you want to perform? \t");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 0)
            {
                for (int i = 1; i <= number; i++)
                {
                    Console.ForegroundColor= ConsoleColor.White;
                    Console.WriteLine("\t\t\t--Operations: (1.Show List, 2.Add, 3.Edit,  4.Delete,  5.Search).....\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter The Operation Number: \t");
                    Console.ForegroundColor = ConsoleColor.White;
                    int opvalue = Convert.ToInt32( Console.ReadLine());
                    switch (opvalue)
                    {
                        case 1:
                            ShowProject(null);
                            break;
                        case 2:
                            AddProject();
                            break;
                        case 3:
                            EditProject();
                            break;
                        case 4:
                            DeleteProject();
                            break;
                        case 5:
                           Search();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid number Input. Please Enter Correct Number.");
                            break;
                    }

                }
            }
            else
            {
                System.Environment.Exit(0);
            }


        }

        private static void Search()
        {
            Console.WriteLine("\t\t\t\t\t----Search Options----\n\t\t( 1.ProjectCode,\t\t2.Project Title,\t3.Manager First name,\n\t\t  4.Budget,\t\t\t5.Department,\t\t6.Manager Last name ).....\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter The Search Option Number: \t");
            Console.ForegroundColor = ConsoleColor.White;
            int opvalue = Convert.ToInt32(Console.ReadLine());          
                switch (opvalue)
                {
                    case 1:
                        SearchByCode();
                        break;
                    case 2:
                        SearchByTitle();
                        break;
                    case 3:
                        SearchByFName();
                        break;
                    case 4:
                        SearchByBudget();
                        break;
                    case 5:
                        SearchByDepartmrnt();
                        break;
                    case 6:
                        SearchByLName();
                        break;
                    default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number Input. Please Enter Correct Number.");
                    break;
                }
        }
        private static void SearchByLName()
        {
            List<Project> list3 = new List<Project>();

            list3 = repository.GetAllProject().ToList();
            Console.Write("Project Manager Last name:\t");
            string manlName = Console.ReadLine();
            try
            {

                Project man1 = list3.Find(t => t.ManagerLname == manlName);
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", "Project Code", "Project Title", "Manager Full name", "Department", "Budget"));
                Console.WriteLine(string.Format(" {0,15}  {1,20} {2,20}   {3,15}  {4,15}", "------------", "-------------", "-----------------", "----------", "-------"));
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", man1.ProjectCode, man1.ProjectTitle, man1.GetFullname(), man1.Department, man1.Budget));
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Project Found for Given Name or Invalid Manager Last Name. \nPlease Enter Correct Project Manager Last name.");
            }
            Console.WriteLine();
        }

        private static void SearchByDepartmrnt()
        {
            List<Project> list4 = new List<Project>();

            list4 = repository.GetAllProject().ToList();
            Console.Write("Enter DepertMent Number \n Hints* \t1.IT,\t2.HR,\t3.PayRoll,\t4.Sales,\t0.None: \t");
            int deptvalue1 = Convert.ToInt32(Console.ReadLine());
            Department dept = (Department)Enum.Parse(typeof(Department), deptvalue1.ToString());
            try
            {

                Project dept1 = list4.Find(t => t.Department == dept);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", "Project Code", "Project Title", "Manager Full name", "Department", "Budget"));
                Console.WriteLine(string.Format(" {0,15}  {1,20} {2,20}   {3,15}  {4,15}", "------------", "-------------", "-----------------", "----------", "-------"));
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", dept1.ProjectCode, dept1.ProjectTitle, dept1.GetFullname(), dept1.Department, dept1.Budget));
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Project Found for Given Department or Invalid Department name. \nPlease Enter Correct Project Department Name.");
            }
            Console.WriteLine();
        }

        private static void SearchByBudget()
        {
            List<Project> list5 = new List<Project>();

            list5 = repository.GetAllProject().ToList();
            Console.Write("Enter Project Budget: \t");
            double budget = Convert.ToDouble(Console.ReadLine());
            try
            {

                Project bud = list5.Find(t => t.Budget == budget);
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", "Project Code", "Project Title", "Manager Full name", "Department", "Budget"));
                Console.WriteLine(string.Format(" {0,15}  {1,20} {2,20}   {3,15}  {4,15}", "------------", "-------------", "-----------------", "----------", "-------"));
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", bud.ProjectCode, bud.ProjectTitle, bud.GetFullname(), bud.Department, bud.Budget));
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Project Found for Given Budget or Invalid Budget. \nPlease Enter Correct Project Budget.");
            }
            Console.WriteLine();
        }

        private static void SearchByFName()
        {
            List<Project> list2 = new List<Project>();

            list2 = repository.GetAllProject().ToList();
            Console.Write("Project Manager First Name:\t");
            string manName = Console.ReadLine();
            try
            {

                Project man = list2.Find(t => t.ManagerFname == manName);

                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", "Project Code", "Project Title", "Manager Full name", "Department", "Budget"));
                Console.WriteLine(string.Format(" {0,15}  {1,20} {2,20}   {3,15}  {4,15}", "------------", "-------------", "-----------------", "----------", "-------"));
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", man.ProjectCode, man.ProjectTitle, man.GetFullname(), man.Department, man.Budget));


            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Project Found for Given Name or Invalid Manager First Name. \nPlease Enter Correct Project Manager First name.");
            }
            Console.WriteLine();
        }

        private static void SearchByTitle()
        {
            List<Project> list1 = new List<Project>();

            list1 = repository.GetAllProject().ToList();
            Console.Write("Project Title:\t");
            string titl = Console.ReadLine();
            try
            {

                Project title = list1.Find(t => t.ProjectTitle == titl);
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", "Project Code", "Project Title", "Manager Full name", "Department", "Budget"));
                Console.WriteLine(string.Format(" {0,15}  {1,20} {2,20}   {3,15}  {4,15}", "------------", "-------------", "-----------------", "----------", "-------"));
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", title.ProjectCode, title.ProjectTitle, title.GetFullname(), title.Department, title.Budget));
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Project Found for Given Title or Invalid Project Title. \nPlease Enter Correct    Project Title.");
            }
            Console.WriteLine();
        }


        private static void SearchByCode()
        {
            List<Project> list = new List<Project>();

            list = repository.GetAllProject().ToList();
            Console.Write("Enter Project Code: \t");
            int deptvalue = Convert.ToInt32(Console.ReadLine());
           
            try
            {
                Project mat = list.Find(m => m.ProjectCode == deptvalue);
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", "Project Code", "Project Title", "Manager Full name", "Department", "Budget"));
                Console.WriteLine(string.Format(" {0,15}  {1,20} {2,20}   {3,15}  {4,15}", "------------", "-------------", "-----------------", "----------", "-------"));

                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", mat.ProjectCode, mat.ProjectTitle, mat.GetFullname(), mat.Department, mat.Budget));
                
            }
                
            catch (Exception )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Project Found for Given code or Invalid Project Code. \nPlease Enter Correct Project Code.");
            }
            Console.WriteLine(  );
        }

        private static void DeleteProject()
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Review Old Project Details:");
            Console.WriteLine("--------------------");
            Console.ForegroundColor = ConsoleColor.White;
            ShowProject(null);
            Console.WriteLine();
            Project project = new Project();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Project Code: \t");
            Console.ForegroundColor = ConsoleColor.White;
            int code = Convert.ToInt32(Console.ReadLine());
            project.ProjectCode = code;
            repository.DeleteProject(code);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Project Data Deleted Successfully");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Updated Project Details:");
            Console.WriteLine("-----------------------");
            Console.ForegroundColor = ConsoleColor.White;
            ShowProject(null);

        }        

        private static void EditProject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Review Old Project Details:");
            Console.WriteLine("--------------------");
            Console.ForegroundColor = ConsoleColor.White;
            ShowProject(null);
            Console.WriteLine();
            Project project = new Project();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Project Code: \t");
            Console.ForegroundColor = ConsoleColor.White;
            int code = Convert.ToInt32( Console.ReadLine());
            project.ProjectCode = code;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Project Title: \t");
            Console.ForegroundColor = ConsoleColor.White;
            string title = Console.ReadLine();
            project.ProjectTitle = title;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Manager First Name: \t");
            Console.ForegroundColor = ConsoleColor.White;
            string fname = Console.ReadLine();
            project.ManagerFname = fname;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Manager Last Name: \t");
            Console.ForegroundColor = ConsoleColor.White;
            string lname = Console.ReadLine();
            project.ManagerLname = lname;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter DepertMent Number \n Hints* \t1.IT,\t2.HR,\t3.PayRoll,\t4.Sales,\t0.None: \t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int deptvalue = Convert.ToInt32(Console.ReadLine());
            Department dept = (Department)Enum.Parse(typeof(Department), deptvalue.ToString());
            project.Department = dept;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Project Budget: \t");
            Console.ForegroundColor = ConsoleColor.White;
            double budget = Convert.ToDouble(Console.ReadLine());
            project.Budget = budget;
            repository.UpdateProject(project);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Project Data Updated Successfully");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Updated Project Details:");
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            ShowProject(null);
        }

        private static void AddProject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Review Old Project Details:");
            Console.WriteLine("--------------------");
            Console.ForegroundColor = ConsoleColor.White;
            ShowProject(null);
            Console.WriteLine();
            Project project = new Project();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write("Enter Project Title: \t");
            Console.ForegroundColor = ConsoleColor.White;
            string title = Console.ReadLine();
            project.ProjectTitle = title;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Manager First Name: \t");
            Console.ForegroundColor = ConsoleColor.White;
            string fname = Console.ReadLine();
            project.ManagerFname = fname;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Manager Last Name: \t");
            Console.ForegroundColor = ConsoleColor.White;
            string lname = Console.ReadLine();
            project.ManagerLname = lname;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter DepertMent Number \n Hints* \t1.IT,\t2.HR,\t3.PayRoll,\t4.Sales,\t0.None: \t");
            Console.ForegroundColor = ConsoleColor.White;
            int deptvalue = Convert.ToInt32(Console.ReadLine());
            Department dept = (Department)Enum.Parse(typeof(Department), deptvalue.ToString());
            project.Department = dept;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Project Budget: \t");
            Console.ForegroundColor = ConsoleColor.White;
            double budget = Convert.ToDouble( Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            project.Budget = budget;
            repository.InsertProject(project);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Project Data Saved Successfully");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Updated Project Details:");
            Console.WriteLine("-------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            ShowProject(null);
        }
       
        private static void ShowProject(Project project)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            List<Project> list = new List<Project>();
            Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", "Project Code", "Project Title", "Manager Full name", "Department", "Budget"));
            Console.WriteLine(string.Format(" {0,15}  {1,20} {2,20}   {3,15}  {4,15}", "------------", "-------------", "-----------------", "----------", "-------"));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            list = repository.GetAllProject().ToList();           
            foreach (var item in list)
            {
                Console.WriteLine(string.Format("|{0,15}|{1,20}|{2,20}|{3,18}|{4,15}|", item.ProjectCode, item.ProjectTitle, item.GetFullname(), item.Department, item.Budget));
            }
            Console.WriteLine();         
        }
       
    }
}
