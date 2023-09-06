using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace _1272315_Project
{
    public class ProjectRepository : IProjectRepository
    {
        private List<Project> _projectsList;

        public ProjectRepository()
        {
            _projectsList = new List<Project>()
            {
                new Project(){ ProjectCode=1,ProjectTitle="Pensions system",ManagerFname="Morgan",ManagerLname="Philips",Budget=1000000,Department=Department.IT},
                new Project(){ ProjectCode=2,ProjectTitle="Salaries System",ManagerFname="Hubert",ManagerLname="Martin",Budget=1500000,Department=Department.HR},
                new Project(){ ProjectCode=3,ProjectTitle="HR System",ManagerFname = "Kennedy", ManagerLname = "Lewis", Budget = 1200000, Department = Department.PayRoll},
                new Project(){ ProjectCode=4,ProjectTitle="Sales System",ManagerFname = "Robert", ManagerLname = "James", Budget = 1300000, Department = Department.Sales},
                
            };
        }
       
        public Project GetProjectByCode(int code)
        {
            Project prjt = (from pro in _projectsList where pro.ProjectCode == code select pro).Single();
            return prjt as Project;
        }
        public Project DeleteProject(int code)
        {
            Project pro = GetProjectByCode(code);
            if (pro != null)
            {
                _projectsList.Remove(pro);
            }
            return pro;
        }
        public IEnumerable<Project> GetAllProject()
        {
            return _projectsList;
        }
        public Project InsertProject(Project insrtProject)
        {
            Project prjt = ((from pro in _projectsList orderby pro.ProjectCode descending select pro).Take(1)).Single() as Project;
            insrtProject.ProjectCode = prjt.ProjectCode + 1;
            _projectsList.Add(insrtProject);
            return insrtProject;
        }
        public Project UpdateProject(Project updtproject)
        {
            Project prjt = GetProjectByCode(updtproject.ProjectCode);
            if (prjt != null)
            {
                prjt.ProjectTitle = updtproject.ProjectTitle;
                prjt.ManagerFname = updtproject.ManagerFname;
                prjt.ManagerLname = updtproject.ManagerLname;
                prjt.Department = updtproject.Department;
                prjt.Budget = updtproject.Budget;               
            }
            return prjt;
        }

       

        
    }
}
