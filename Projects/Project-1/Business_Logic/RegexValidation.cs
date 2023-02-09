
using Microsoft.Identity.Client;
using System.Text.RegularExpressions;


namespace Business_Logic
{
    public class RegexValidation : Exception
    {
        /*//------ TRAINER ID ------
        public bool ValidateID(string id)
        {
            string pattern = @"^[1-9][0-9]{2}$";
            if(Regex.IsMatch(id, pattern) && id.Length == 3) 
            { 
                return true; 
            }
            else
            {
                throw new Exception("Please check your ID");
            }
        }
        */
        //-------- MOBILE NUMBER -------

        public bool ValidateNumber(string? number)
        {
            string pattern = @"^[6-9]\d{9}$";
            if(Regex.IsMatch(number, pattern)) 
            { 
                return true; 
            }
            else
            {
                throw new Exception($@"Mobile number is not in correct format: 
                                       1. It must start with one of the numbers between [6 to 9] 
                                       2. It mustcontain 10-digits");
            }
        }

        //------- PASSWORD -------

        public bool ValidatePassword(string? password)
        {
            string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            if(Regex.IsMatch(password, pattern))
            {
                return true;
            }
            else
            {
                throw new Exception($@"Password is not in correct format:
                                       Rules to create password...
                                           1. Must be of '8 characters' long
                                           2. Must include atleast an 'Uppercase' alphabet
                                           3. Must contain atleast a digit");
            }
        }

        //------- EMAIL -------
        public bool ValidateEmail(string? email)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            if(Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            {
                throw new Exception($"Email is not in correct format, please check it \"{email}\"");
            }
        }

        //------- PINCODE -------
        public bool ValidateZipcode(string? zipcode)
        {
            string pattern = @"^\d{6}$";
            if(Regex.IsMatch(zipcode, pattern))
            {
                return true;
            }
            else
            {
                throw new Exception($@"Zipcode is not in correct format
                                       -> Must contain 6-digits");
            }
        }

        //-------- DOB ----------
        public bool ValidateDOB(string? dob)
        {
            string pattern = @"(0[1-9]|1[0-9]|2[0-9]|3[01]).(0[1-9]|1[012]).([1][9][5-9]\d|[2][0][0-5]\d)";
            if(Regex.IsMatch(dob, pattern))
            {
                return true;
            }
            else
            {
                throw new Exception($@"DOB is not in correct format
                                       -> Format : dd:mm:yyyy");
            }
        }
    }
}
