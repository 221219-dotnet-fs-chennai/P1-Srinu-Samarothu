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
        public TLogin() { }
        public TLogin(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
        public override string ToString()
        {
            return $@"Email - {Email}";
        }
    }
}
