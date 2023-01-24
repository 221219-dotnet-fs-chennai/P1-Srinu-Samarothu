using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TraineeLib
{
    public class RegexValidation
    {
        //------ TRAINER ID ------
        public bool ValidateID(string id)
        {
            string pattern = @"^[0-9]{3}$";
            return (Regex.IsMatch(id, pattern) && id.Length == 3);
        }

        //-------- MOBILE NUMBER -------

        public bool ValidateNumber(string number)
        {
            string pattern = @"^[6-9]\d{9}$";
            return Regex.IsMatch(number, pattern);
        }

        //------- PASSWORD -------

        public bool ValidatePassword(string password)
        {
            string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        //------- EMAIL -------
        public bool ValidateEmail(string email)
        {
            Log.Information("Validating Email...");
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }

        //------- PINCODE -------
        public bool ValidateZipcode(string zipcode)
        {
            string pattern = @"^\d{6}$";
            return Regex.IsMatch(zipcode, pattern);
        }

        //-------- DOB ----------
        public bool ValidateDOB(string dob)
        {
            string pattern = @"(0[1-9]|1[0-9]|2[0-9]|3[01]).(0[1-9]|1[012]).([1][9][5-9]\d|[2][0][0-2][0-5])";
            return Regex.IsMatch(dob, pattern);
        }
    }
}
