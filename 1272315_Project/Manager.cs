using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1272315_Project
{
    public abstract class Manager
    {
        public abstract string ManagerFname { get; set; }
        public abstract string ManagerLname { get; set; }

        public abstract string GetFullname();
       
    }
}
