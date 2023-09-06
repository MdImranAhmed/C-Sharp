using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1272315_Project
{
    public interface IProjectRepository
    {

        IEnumerable<Project> GetAllProject();
        Project GetProjectByCode(int code);   

        Project InsertProject(Project project);
        Project UpdateProject(Project project);
        Project DeleteProject(int id);    

    }
}
