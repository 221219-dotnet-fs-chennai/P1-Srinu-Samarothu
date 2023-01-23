using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    public class TSkills
    {
        public string? Skill { get; set; }
        public int? Rate { get; set; }
        public int Tid { get; set; }
        public TSkills() { }
        public override string ToString()
        {
            return $"   Skill - {Skill}     Proficiency - {Rate}";
        }
    }
}
