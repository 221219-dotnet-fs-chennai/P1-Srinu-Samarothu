using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    public class TDetails
    {
        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Gender { get; set; }
        public string?  Dob { get; set; }
        public string? email { get; set; }

        public TDetails() { }

        public override string ToString()
        {
            return $"-* ID - {Id} \n-* First name - {Fname} \n-* Last name - {Lname} \n-* Gender - {Gender} \n-* Date Of Birth - {Dob} \n-* Email - {email}";
        }
    }
}
