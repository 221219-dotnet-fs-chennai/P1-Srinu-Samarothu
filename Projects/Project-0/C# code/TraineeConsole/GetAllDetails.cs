using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer;
using Serilog;

namespace TraineeLib
{
    public class GetAllDetails
    {
        TLogin login;
        public GetAllDetails(TLogin login1) { login = login1; }
        public void DisplayGET()
        {
            GET:
            Console.Clear();
            Console.WriteLine("------- ** GET options ** -------");
            Console.WriteLine("'ALL' : Get all details");
            Console.WriteLine("'TD' : Trainer Details");
            Console.WriteLine("'CD' : Contact details");
            Console.WriteLine("'EDU' : Education Details");
            Console.WriteLine("'SD' : Skill(s) Details");
            Console.WriteLine("'ED' : Experience(s) Details");
            Console.WriteLine("'<-' : Go Back");
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
                    Log.Information("Printing all Trainer details");
                    Console.Clear();
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
                    Console.Write("-- INFO : Press enter to return to menu --");
                    Console.ReadLine();
                    Log.Information("All trainer details are displayed");
                    goto GET;

                case "TD":
                    Log.Information("Displaying Trainer details");
                    Console.Clear();
                    Console.WriteLine("---- @ Trainer Details ----");
                    TDetails details1 = detailsRepo.fetchDetails(login);
                    Console.WriteLine(details1.ToString());
                    Console.Write("-- INFO : Press enter to return to menu --");
                    Console.ReadLine();
                    goto GET;
                case "CD":
                    Log.Information("Displaying Contact details");
                    Console.Clear();
                    Console.WriteLine("\n---- @ Contact Details ----");
                    var cList = contactRepo.fetchDetails(details);
                    Console.WriteLine(cList.ToString());
                    Console.Write("-- INFO : Press enter to return to menu --");
                    Console.ReadLine();
                    goto GET;
                case "EDU":
                    Log.Information("Displaying Education details");
                    Console.Clear();
                    Console.WriteLine("\n---- @ Education Details ----");
                    var eduList = educationRepo.fetchDetails(details);
                    Console.WriteLine(eduList.ToString());
                    Console.Write("-- INFO : Press enter to return to menu --");
                    Console.ReadLine();
                    goto GET;
                case "SD":
                    Log.Information("Displaying Skills");
                    Console.Clear();
                    Console.WriteLine("\n------------------------- @ Skill(s) Details -------------------------");
                    var sList = skillRepo.fetchDetails(details);
                    foreach (var skill in sList)
                    {
                        Console.WriteLine(skill.ToString());
                        Console.WriteLine(":----------------------------------------------------------------------:");
                    }
                    Console.Write("-- INFO : Press enter to return to menu --");
                    Console.ReadLine();
                    goto GET;
                case "ED":
                    Log.Information("Displaying Experience details");
                    Console.Clear();
                    Console.WriteLine("\n---------------------- @ Experience(s) Details -----------------------");
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
                    Console.Clear();
                    Console.WriteLine("ERR : Invalid input \nEnter any key to return back to Menu ");
                    Console.ReadLine();
                    goto GET;
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
