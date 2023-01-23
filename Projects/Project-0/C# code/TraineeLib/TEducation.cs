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
        public float? UG_percentage { get; set;  }
        public int? UG_passout_year { get; set; }
        public string? PG_college { get; set; }
        public float PG_percentage { get; set; }
        public int? PG_passout_year { get; set; }
        public int? Tid { get; set; }
        public TEducation() { }
        public override string ToString()
        {
            return $"--- *** UG details *** --- \n   College name - {UG_college} \n   Percentage - {UG_percentage} \n  Passout year - {UG_passout_year} \n\n--- *** PG details *** --- \n   College name - {PG_college} \n   Percentage - {PG_percentage} \n  Passout year - {PG_passout_year}";
        }
    }
}
