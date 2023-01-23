using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeUI;
using Trainer;

namespace TraineeLib
{
    public class SetAllDetails
    {
        public void Display(TLogin login1)
        {
        ADD:
            Console.Clear();
            TLogin login = TLoginRepo.FetchEmail(login1.Email);
            Console.WriteLine("\n-- ** Please enter your choice using the Keywords on LHS ** --");
            Console.WriteLine($"'ALL' : Add all details at once");
            Console.WriteLine($"'TD' : Add Trainer details {login.TDstatus}");
            Console.WriteLine($"'CD' : Add Contact details {login.CDstatus}");
            Console.WriteLine($"'EDU' : Add Education details {login.EDUstatus}");
            Console.WriteLine($"'ED' : Add Experience details {login.EDstatus}");
            Console.WriteLine($"'SD' : Add Skill details {login.SDstatus}");
            Console.WriteLine("'LOGIN' : Login into your account");
            Console.WriteLine("'EXIT' : Exit ");
            Console.Write("\nChoose and Enter a Keyword : ");
            TDetailsRepo detailsRepo = new TDetailsRepo();
            TContactDetailsRepo contactRepo = new TContactDetailsRepo();
            TEducationRepo educationRepo = new TEducationRepo();
            TExperienceRepo experienceRepo = new TExperienceRepo();
            TSkillsRepo skillRepo = new TSkillsRepo();
            TDetails details = new TDetails();
            switch (Console.ReadLine())
            {
                case "ALL":
                    int c = 0;
                    if (login.TDstatus.Length == 0)
                    {
                        details = detailsRepo.GetDetails(login);
                        c++;
                        login = TLoginRepo.FetchEmail(login.Email);
                    }
                    if (login.CDstatus.Length == 0)
                    {
                        contactRepo.GetDetails(details);
                        c++;
                        login = TLoginRepo.FetchEmail(login.Email);
                    }
                    if (login.EDUstatus.Length == 0)
                    {
                        educationRepo.GetDetails(details);
                        c++;
                        login = TLoginRepo.FetchEmail(login.Email);
                    }
                    if (login.EDstatus.Length == 0)
                    {
                        experienceRepo.GetDetails(details);
                        c++;
                        login = TLoginRepo.FetchEmail(login.Email);
                    }
                    if (login.EDstatus.Length == 0)
                    {
                        skillRepo.GetDetails(details);
                        c++;
                        login = TLoginRepo.FetchEmail(login.Email);
                    }
                    if(c == 0) {
                        Console.Clear();
                        Console.WriteLine("\n*** It seems you entered all your details earlier ***\n\nPress enter to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"\n----- *** Yahoo :) '{details.Fname} {details.Lname}', you added all details successfully *** -----");
                    }
                    goto ADD;
                case "TD":
                    if (login.TDstatus.Length == 0)
                    {
                        details = detailsRepo.GetDetails(login);
                        login = TLoginRepo.FetchEmail(login.Email);
                        Console.Write("\nHit enter to add more details...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("\n--- INFO : You've already entered Trainer Details ---\n\nPress enter to continue...");
                        Console.ReadKey();
                    }
                    goto ADD;
                case "CD":
                    if (login.CDstatus.Length == 0)
                    {
                        details = detailsRepo.fetchDetails(login);
                        contactRepo.GetDetails(details);
                        login = TLoginRepo.FetchEmail(login.Email);
                        Console.Write("\nHit enter to add more details...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("\n--- INFO : You've already entered Contact Details ---\n\nPress enter to continue...");
                        Console.ReadKey();
                    }
                    goto ADD;
                case "EDU":
                    if (login.EDUstatus.Length == 0)
                    {
                        details = detailsRepo.fetchDetails(login);
                        educationRepo.GetDetails(details);
                        login = TLoginRepo.FetchEmail(login.Email);
                        Console.Write("\nHit enter to add more details...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("\n--- INFO : You've already entered Education Details ---\n\nPress enter to continue...");
                        Console.ReadKey();
                    }
                    goto ADD;
                case "ED":
                    if (login.EDstatus.Length == 0)
                    {
                        details = detailsRepo.fetchDetails(login);
                        experienceRepo.GetDetails(details);
                        login = TLoginRepo.FetchEmail(login.Email);
                        Console.Write("\nHit enter to add more details...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("\n--- INFO : You've already entered Experience Details ---\n\nPress enter to continue...");
                        Console.ReadKey();
                    }
                    goto ADD;
                case "SD":
                    if (login.SDstatus.Length == 0)
                    {
                        details = detailsRepo.fetchDetails(login);
                        skillRepo.GetDetails(details);
                        login = TLoginRepo.FetchEmail(login.Email);
                        Console.Write("\nHit enter to add more details...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("\n--- INFO : You've already entered Skill(S) ---\n\nPress enter to continue...");
                        Console.ReadKey();
                    }
                    goto ADD;
                case "EXIT":
                    Console.Clear();
                    Console.WriteLine("Closing your profile :)\n\n\t\t... *** Comeback Again *** ...");
                    Environment.Exit(0);
                    goto ADD;
                case "LOGIN":
                    Menu menu = new Menu();
                    menu.Display(TLoginRepo.FetchEmail(login.Email));
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("** Invalid input **");
                    Console.Write("\nHit enter to view the \"Add details\" menu...");
                    Console.ReadKey();
                    goto ADD;
            }
            //Console.WriteLine($"----- *** Yahoo :) '{details.Fname} {details.Lname}', you added all details successfully *** -----");
        }
    }
}
