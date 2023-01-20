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
            return $"Worked in - {Company} \nWorked as - {Designation} \nWorked for - {Experience} months";
        }
    }
}
