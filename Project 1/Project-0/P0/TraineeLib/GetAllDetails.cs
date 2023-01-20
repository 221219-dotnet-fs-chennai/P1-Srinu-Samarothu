using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer;

namespace TraineeLib
{
    public class GetAllDetails
    {
        TLogin login;
        public GetAllDetails(TLogin login1) { login = login1; }
        public void DisplayGET()
        {
            Console.Clear();
            Console.WriteLine("------- ** GET options ** -------");
            Console.WriteLine("'ALL' : Get all details");
            Console.WriteLine("'TD' : Trainer Details");
            Console.WriteLine("'CD' : Contact details");
            Console.WriteLine("'EDU' : Education Details");
            Console.WriteLine("'SD' : Skill(s) Details");
            Console.WriteLine("'ED' : Experience(s) Details");
            Console.WriteLine("'BACK' : Go Back");
            Console.Write("\nChoose and Enter a Keyword : ");
            TDetailsRepo detailsRepo = new TDetailsRepo();
            TDetails details = detailsRepo.fetchDetails(login);
            TContactDetailsRepo contactRepo = new TContactDetailsRepo();
            TEducationRepo educationRepo = new TEducationRepo();
            TSkillsRepo skillRepo = new TSkillsRepo();
            TExperienceRepo experienceRepo = new TExperienceRepo();
            switch (Console.ReadLine())
            {
                case "ALL":
                    Console.WriteLine("---- @ Trainer Details ----");
                    Console.WriteLine(details.ToString());
                    Console.WriteLine("\n---- @ Contact Details ----");
                    var contactList = contactRepo.fetchDetails(details);
                    Console.WriteLine(contactList.ToString());
                    Console.WriteLine("\n---- @ Education Details ----");
                    var educationList = educationRepo.fetchDetails(details);
                    Console.WriteLine(educationList.ToString());
                    Console.WriteLine("\n---- @ Skill(s) Details ----");
                    var skillList = skillRepo.fetchDetails(details);
                    foreach(var skill in skillList)
                    {
                        Console.WriteLine(skill.ToString());
                        Console.WriteLine(":----------------------------------------------------------------------:");
                    }
                    Console.WriteLine("\n---- @ Experience(s) Details ----");
                    var experienceList = experienceRepo.fetchDetails(details);
                    foreach (var exp in experienceList)
                    {
                        Console.WriteLine(exp.ToString());
                        Console.WriteLine(":----------------------------------------------------------------------:");
                    }
                    break;

                case "TD":
                    Console.WriteLine("---- @ Trainer Details ----");
                    TDetails details1 = detailsRepo.fetchDetails(login);
                    Console.WriteLine(details1.ToString());
                    break;
                case "CD":
                    Console.WriteLine("\n---- @ Contact Details ----");
                    var cList = contactRepo.fetchDetails(details);
                    Console.WriteLine(cList.ToString());
                    break;
                case "EDU":
                    Console.WriteLine("\n---- @ Education Details ----");
                    var eduList = educationRepo.fetchDetails(details);
                    Console.WriteLine(eduList.ToString());
                    break;
                case "SD":
                    Console.WriteLine("\n---- @ Skill(s) Details ----");
                    var sList = skillRepo.fetchDetails(details);
                    foreach (var skill in sList)
                    {
                        Console.WriteLine(skill.ToString());
                        Console.WriteLine(":----------------------------------------------------------------------:");
                    }
                    break;
                case "ED":
                    Console.WriteLine("\n---- @ Experience(s) Details ----");
                    var expList = experienceRepo.fetchDetails(details);
                    foreach (var exp in expList)
                    {
                        Console.WriteLine(exp.ToString());
                        Console.WriteLine(":----------------------------------------------------------------------:");
                    }
                    break;
                case "BACK":
                    break;
                default:
                    Console.WriteLine("ERR : Invalid input \nReturning back to Menu ");
                    break;
            }
        }

        public void DisplayUPDATE()
        {
            TDetailsRepo detailsRepo = new TDetailsRepo();
            TDetails details = detailsRepo.fetchDetails(login);
            UpdateProfileMenu profile = new UpdateProfileMenu(details);
            profile.Display();
        }

    }
}
