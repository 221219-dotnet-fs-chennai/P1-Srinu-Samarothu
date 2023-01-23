using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    public class TLogin
    {
        string? email, password;

        public string? Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string? Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string? TDstatus { get; set; }
        public string? CDstatus { get; set; }
        public string? EDUstatus { get; set; }
        public string? EDstatus { get; set; }
        public string? SDstatus { get; set; }
        public TLogin() { }
        public TLogin(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
        public override string ToString()
        {
            return $"-  Email - \"{Email}\"";
        }
    }
}
