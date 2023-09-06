using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1272315_Project
{
    public class Project : Manager
    {
        public int ProjectCode { get; set; }
        public string ProjectTitle { get; set; }        
        public double Budget { get; set; }
        public Department Department { get; set; }
        public override string ManagerFname { get ; set ; }
        public override string ManagerLname { get ; set ; }

        public override string GetFullname()
        {
            return ManagerFname + " " + ManagerLname;
        }
    }
}

