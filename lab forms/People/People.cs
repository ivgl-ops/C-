using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class People
    {
        public string Name;
        public string Surname;
        public int Age;
        public override string ToString()
        {
            return Name +" " + Surname + " " + Age ;
        }
    }
}
