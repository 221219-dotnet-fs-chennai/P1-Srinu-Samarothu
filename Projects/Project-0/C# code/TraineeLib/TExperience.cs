using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    public class TExperience
    {
        public string? Company { get; set; }
        public string? Designation { get; set; }
        public int Experience { get; set; }
        public int Tid { get; set; }
        public TExperience () { }
        public override string ToString()
        {
            int year = Experience / 12;
            int months = Experience % 12;
            if(year > 0) 
                return $"   Worked in - {Company} \n   Worked as - {Designation} \n   Worked for - {year} year(s) {months} month(s)";
            else
                return $"   Worked in - {Company} \n   Worked as - {Designation} \n   Worked for - {months} months";
        }
    }
}
