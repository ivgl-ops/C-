using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackListt
{
    public class Teacher
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Rating Mark {get; set;}

        public override string ToString()
        {
            return Name + " - " + Subject  + " - " + Mark+"*";
        }
    }
}
