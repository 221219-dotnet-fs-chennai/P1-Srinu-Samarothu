using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    public class TEducation
    { 
        public string? UG_college { get; set; }
        public int UG_percentage { get; set;  }
        public int UG_passout_year { get; set; }
        public string? PG_college { get; set; }
        public int PG_percentage { get; set; }
        public int PG_passout_year { get; set; }
        public int Tid { get; set; }
        public TEducation() { }
        public override string ToString()
        {
            return $"========> UG details : \nCollege name - {UG_college} \nPercentage - {UG_percentage} \nPassout year - {UG_passout_year} \n\n--------> PG details : \nCollege name - {PG_college} \nPercentage - {PG_percentage} \nPassout year - {PG_passout_year}";
        }
    }
}
