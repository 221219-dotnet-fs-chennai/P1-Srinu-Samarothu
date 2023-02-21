using DF = DataFluentApi.Entities;
using DV = DataFluentApi.Views;
using DataFluentApi;
using Models;
using System.Security.Cryptography;
using DataFluentApi.Views;
using System.Linq;

namespace Business_Logic
{
    public class TrainerLogic : ILogic
    {
        static string? _mail;
        static int _id;

        RegexValidation regex = new RegexValidation();

        LogicActions action;

        ITrainerRepo<DF.TraineeLogin> loginRepo;
        ITrainerRepo<DF.TraineeTrainerDetail> trainerRepo;
        ITrainerRepo<DF.TraineeContactDetail> contactRepo;
        ITrainerRepo<DF.Education> educationRepo;
        ITrainerRepo<DF.Experience> experienceRepo;
        ITrainerRepo<DF.Skill> skillRepo;
        IFilterRepo<DV.VirtualTable> filterRepo;
        public TrainerLogic(ITrainerRepo<DF.TraineeLogin> _login, ITrainerRepo<DF.TraineeTrainerDetail> _trainer, ITrainerRepo<DF.TraineeContactDetail> _contact, ITrainerRepo<DF.Education> _education, ITrainerRepo<DF.Experience> _experience, ITrainerRepo<DF.Skill> _skill, IFilterRepo<DV.VirtualTable> _filterRepo, LogicActions _action)
        {
            loginRepo = _login;
            trainerRepo = _trainer;
            contactRepo = _contact;
            educationRepo = _education;
            experienceRepo = _experience;
            skillRepo = _skill;
            filterRepo = _filterRepo;
            action = _action;
        }


        //-------------------- Login Details --------------------

        

        public TraineeLogin AddLogin(TraineeLogin details)
        {

            regex.ValidateEmail(details.Email);
            regex.ValidatePassword(details.Password);
            _mail = details.Email;
            DF.TraineeLogin entityLogin = Mapper.MapGetEntityLogin(details);
            loginRepo.AddDetails(entityLogin);
            return Mapper.MapGetModelLogin(entityLogin);
        }

        public TraineeLogin GetLoginDetails(string email, string password)
        {
            try
            {
                return Mapper.MapGetModelLogin(loginRepo.GetDetails().Where(l => l.Email == email && l.Password == password).FirstOrDefault());
            }
            catch(Exception)
            {
                throw new Exception("User does not exist!!!");
            }
        }



        public void UpdateLogin(string? mail, string? pwd, TraineeLogin login)
        {
            try
            {
                DF.TraineeLogin entitylogin = loginRepo.GetDetails().Where(t => t.Email == mail && t.Password == pwd ).First();
                login.Email = mail;

                if (entitylogin != null)
                {
                    if (login.Password != "string" && entitylogin.Password != login.Password) {
                        if(regex.ValidatePassword(login.Password))
                            entitylogin.Password = login.Password;
                    }
                    loginRepo.UpdateDetails(entitylogin);
                }
                else
                {
                    Console.WriteLine("Credentials does not exist (or) incorrect");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public TraineeLogin DeleteLogin(string? mail)
        {
            try
            {
                var search = loginRepo.GetDetails().Where(l => l.Email == mail).First();
                return Mapper.MapGetModelLogin(loginRepo.DeleteDetails(search));
            }
            catch(Exception)
            {
                throw new Exception("Email does not exist");
            }
        }
        


        //-------------------- Trainer Details --------------------


        public TraineeTrainerDetail AddTrainer(TraineeTrainerDetail tDetails)
        {
            regex.ValidateEmail(tDetails.Mail);
            _id = action.GetUniqueId();
            tDetails.Tid = _id;
            //tDetails.Mail = mail;

            regex.ValidateDOB(tDetails.Dob);
            var entityTrainer = Mapper.MapGetEntityTrainer(tDetails);
            trainerRepo.AddDetails(entityTrainer);
            return tDetails;
        }


        public IEnumerable<TraineeTrainerDetail> GetTrainerDetails()
        {
            return Mapper.MapAllTrainers(trainerRepo.GetDetails());
        }

        public TraineeTrainerDetail GetTrainerDetails(string? Email)
        {
            try
            {
                DF.TraineeTrainerDetail trainer = trainerRepo.GetDetails().Where(t => t.Mail == Email).First();
                return Mapper.MapGetModelTrainer(trainer);
            }
            catch(Exception)
            {
                throw new Exception("Email does not exist");
            }
        }

        public TraineeTrainerDetail DeleteTrainer(string? mail)
        {
            try
            {
                var search = trainerRepo.GetDetails().Where(l => l.Mail == mail).First();
                return Mapper.MapGetModelTrainer(trainerRepo.DeleteDetails(search));
            }
            catch (Exception)
            {
                throw new Exception("Email does not exist");
            }
        }


        public void UpdateTrainer(string? mail, TraineeTrainerDetail trainer)
        {
            try
            {
                DF.TraineeTrainerDetail entityTrainer = trainerRepo.GetDetails().Where(t => t.Mail == mail).First();

                if (entityTrainer != null)
                {
                    if (entityTrainer.FirstName != trainer.FirstName)
                    {
                        entityTrainer.FirstName = trainer.FirstName;
                    }
                    if (entityTrainer.LastName != trainer.LastName)
                    {
                        entityTrainer.LastName = trainer.LastName;
                    }
                    if (entityTrainer.Dob != trainer.Dob)
                    {
                        if(regex.ValidateDOB(trainer.Dob))
                            entityTrainer.Dob = trainer.Dob;
                    }
                    if (entityTrainer.Gender != trainer.Gender)
                    {
                        entityTrainer.Gender = trainer.Gender;
                    }
                    trainerRepo.UpdateDetails(entityTrainer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // --------------------- Contact Details -----------------

        public TraineeContactDetail AddTrainerContact(string? mail, TraineeContactDetail contactDetails)
        {
            contactDetails.Tid = action.GetTrainerId(mail);
            //contactDetails.MailId = mail;

            regex.ValidateEmail(contactDetails.MailId);

            regex.ValidateNumber(Convert.ToString(contactDetails.MobileNumber));
            regex.ValidateZipcode(Convert.ToString(contactDetails.Zipcode));
            var entityContact = Mapper.MapGetEntityContact(contactDetails);
            contactRepo.AddDetails(entityContact);
            return contactDetails;
        }

        public TraineeContactDetail GetTrainerContact(string? Email)
        {
            try
            {
                int id = action.GetTrainerId(Email);
                DF.TraineeContactDetail trainerContact = contactRepo.GetDetails().Where(c => c.Tid == id).First();
                return Mapper.MapGetModelContact(trainerContact);
            }
            catch(Exception) 
            {
                throw new Exception("Email does not exist");
            }
        }

        public void UpdateTrainerContact(string? mail, TraineeContactDetail contact)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                DF.TraineeContactDetail entityTrainer = contactRepo.GetDetails().Where(t => t.Tid == id).First();

                if (entityTrainer != null)
                {
                    if(contact.MobileNumber != 0 && entityTrainer.MobileNumber != contact.MobileNumber)
                    {
                        if(regex.ValidateNumber(Convert.ToString(contact.MobileNumber)))
                            entityTrainer.MobileNumber = contact.MobileNumber;
                    }
                    if (contact.AddressLane != "string" && entityTrainer.AddressLane != contact.AddressLane)
                    {
                        entityTrainer.AddressLane = contact.AddressLane;
                    }
                    if (contact.City != "string" && entityTrainer.City != contact.City)
                    {
                        entityTrainer.City = contact.City;
                    }
                    if (contact.State != "string" && entityTrainer.State != contact.State)
                    {
                        entityTrainer.State = contact.State;
                    }
                    if (contact.Zipcode != "string" && entityTrainer.Zipcode != contact.Zipcode)
                    {
                        if(regex.ValidateZipcode(Convert.ToString(contact.Zipcode)))
                            entityTrainer.Zipcode = contact.Zipcode;
                    }
                    contactRepo.UpdateDetails(entityTrainer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public TraineeContactDetail DeleteTrainerContact(string? mail)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                var search = contactRepo.GetDetails().Where(l => l.Tid == id).First();
                return Mapper.MapGetModelContact(contactRepo.DeleteDetails(search));
            }
            catch(Exception) 
            {
                throw new Exception("Email does not exist");
            }
        }


        // --------------------- Education Details -----------------

        public Education AddTrainerEducation(string? mail, Education educationDetails)
        {
            educationDetails.Tid = action.GetTrainerId(mail);
            var entityEducation = Mapper.MapGetEntityEducation(educationDetails);
            educationRepo.AddDetails(entityEducation);
            return educationDetails;
        }

        public Education GetTrainerEducation(string? Email)
        {
            try
            {
                int id = action.GetTrainerId(Email);
                DF.Education trainerEducation = educationRepo.GetDetails().Where(c => c.Tid == id).First();
                return Mapper.MapGetModelEducation(trainerEducation);
            }
            catch(Exception) 
            { 
                throw new Exception("Email does not exist"); 
            }
        }


        public void UpdateTrainerEducation(string? mail, Education education)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                DF.Education entityEducation = educationRepo.GetDetails().Where(t => t.Tid == id).First();

                if (entityEducation != null)
                {
                    if (education.UgCollege != "string" && entityEducation.UgCollege != education.UgCollege)
                    {
                        entityEducation.UgCollege = education.UgCollege;
                    }
                    if (education.UgPercentage != 0 && entityEducation.UgPercentage != education.UgPercentage)
                    {
                        entityEducation.UgPercentage = education.UgPercentage;
                    }
                    if (education.UgPassoutYear != 0 && entityEducation.UgPassoutYear != education.UgPassoutYear)
                    {
                        entityEducation.UgPassoutYear = education.UgPassoutYear;
                    }
                    if (education.PgCollege != "string" && entityEducation.PgCollege != education.PgCollege)
                    {
                        entityEducation.PgCollege = education.PgCollege;
                    }
                    if (education.PgPercentage != 0 && entityEducation.PgPercentage != education.PgPercentage)
                    {
                        entityEducation.PgPercentage = education.PgPercentage;
                    }
                    if (education.PgPassoutYear != 0 && entityEducation.PgPassoutYear != education.PgPassoutYear)
                    {
                        entityEducation.PgPassoutYear = education.PgPassoutYear;
                    }
                    educationRepo.UpdateDetails(entityEducation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Education DeleteTrainerEducation(string? mail)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                var search = educationRepo.GetDetails().Where(l => l.Tid == id).First();
                return Mapper.MapGetModelEducation(educationRepo.DeleteDetails(search));
            }
            catch (Exception)
            {
                throw new Exception("Email does not exist");
            }
        }


        // --------------------- Experience Details -----------------

        public Experience AddTrainerExperience(string? mail, Experience experienceDetails)
        {
            experienceDetails.Tid = action.GetTrainerId(mail);
            var entityExperience = Mapper.MapGetEntityExperience(experienceDetails);
            experienceRepo.AddDetails(entityExperience);
            return Mapper.MapGetModelExperience(entityExperience);
        }

        public IEnumerable<Experience> GetTrainerExperience(string? Email)
        {
            try
            {
                int id = action.GetTrainerId(Email);
                List<DF.Experience> trainerExperience = experienceRepo.GetDetails().Where(c => c.Tid == id).ToList();
                return Mapper.MapAllModelExperiences(trainerExperience);
            }
            catch (Exception)
            {
                throw new Exception("Email does not exist");
            }
        }

        public void UpdateTrainerExperience(string? mail, string? company, Experience experience)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                DF.Experience _entityExperience = experienceRepo.GetDetails().Where(t => t.Tid == id && t.Company == company).First();
                var entityExperience = experienceRepo.DeleteDetails(_entityExperience);

                if (entityExperience != null)
                {
                    if (experience.Company != "string" && entityExperience.Company != experience.Company)
                    {
                        entityExperience.Company = experience.Company;
                    }
                    if (experience.Designation != "string" && entityExperience.Designation != experience.Designation)
                    {
                        entityExperience.Designation = experience.Designation;
                    }
                    if (experience.OverallExperience != 0 && entityExperience.OverallExperience != experience.OverallExperience)
                    {
                        entityExperience.OverallExperience = experience.OverallExperience;
                    }
                    experienceRepo.UpdateDetails(entityExperience);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Experience DeleteTrainerExperience(string? mail, string? company)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                var search = experienceRepo.GetDetails().Where(l => l.Tid == id && l.Company == company).First();
                return Mapper.MapGetModelExperience(experienceRepo.DeleteDetails(search));
            }
            catch (Exception)
            {
                throw new Exception("Email or Company does not exist");
            }
        }

        public IEnumerable<Experience> DeleteAllTrainerExperience(string? mail)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                List<Experience> experiences = new List<Experience>();
                var searches = experienceRepo.GetDetails().Where(l => l.Tid == id).ToList();
                foreach (var search in searches)
                {
                    experiences.Add(Mapper.MapGetModelExperience(experienceRepo.DeleteDetails(search)));
                }
                return experiences;
            }
            catch (Exception)
            {
                throw new Exception("Email does not exist");
            }
        }



        // --------------------- Skill Details -----------------

        public Skill AddTrainerSkill(string? mail, Skill skillDetails)
        {
            skillDetails.Tid = action.GetTrainerId(mail);
            var entitySkill = Mapper.MapGetEntitySkill(skillDetails);
            skillRepo.AddDetails(entitySkill);
            return Mapper.MapGetModelSkill(entitySkill);
        }

        public IEnumerable<Skill> GetTrainerSkill(string? Email)
        {
            try
            {
                int id = action.GetTrainerId(Email);
                List<DF.Skill> trainerSkill = skillRepo.GetDetails().Where(c => c.Tid == id).ToList();
                return Mapper.MapAllModelSkills(trainerSkill);
            }
            catch (Exception)
            {
                throw new Exception("Email does not exist");
            }
        }

        public void UpdateTrainerSkill(string? mail, string? skill, Skill trainer)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                DF.Skill _entitySkill = skillRepo.GetDetails().Where(t => t.Tid == id && t.Skill1 == skill).First();
                var entitySkill = skillRepo.DeleteDetails(_entitySkill);

                if (entitySkill != null)
                {
                    if (trainer.Skill1 != "string" && entitySkill.Skill1 != trainer.Skill1)
                    {
                        entitySkill.Skill1 = trainer.Skill1;
                    }
                    if (trainer.Proficiency != 0 && entitySkill.Proficiency != trainer.Proficiency)
                    {
                        entitySkill.Proficiency = trainer.Proficiency;
                    }
                    skillRepo.UpdateDetails(entitySkill);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Skill DeleteTrainerSkill(string? mail, string? skill)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                var search = skillRepo.GetDetails().Where(l => l.Tid == id && l.Skill1 == skill).First();
                return Mapper.MapGetModelSkill(skillRepo.DeleteDetails(search));
            }
            catch (Exception)
            {
                throw new Exception("Email or Skill does not exist");
            }
        }

        public IEnumerable<Skill> DeleteAllTrainerSkill(string? mail)
        {
            try
            {
                int id = action.GetTrainerId(mail);
                List<Skill> experiences = new List<Skill>();
                var searches = skillRepo.GetDetails().Where(l => l.Tid == id).ToList();
                foreach (var search in searches)
                {
                    experiences.Add(Mapper.MapGetModelSkill(skillRepo.DeleteDetails(search)));
                }
                return experiences;
            }
            catch (Exception)
            {
                throw new Exception("Email does not exist");
            }
        }



        // ---------------------- Filtering -----------------------


        public IEnumerable<SkillFilter> GetTrainersBySkill(string? skill) 
        {
            var filterTable = filterRepo.GetVirtualTable();
            List<SkillFilter> skillFilters = new List<SkillFilter>();
            List<int> ids = (from s in skillRepo.GetDetails()
                             where s.Skill1 == skill
                             select s.Tid).ToList();
            foreach (VirtualTable vtable in filterTable)
            {
                if (ids.Contains(vtable.Tid))
                {
                    skillFilters.Add(new SkillFilter()
                    {
                        FirstName = vtable.FirstName,
                        LastName = vtable.LastName,
                        Gender = vtable.Gender,
                        City = vtable.City ?? "NA",
                        skill = (from s in skillRepo.GetDetails()
                                 where vtable.Tid == s.Tid && s.Skill1 == skill
                                 select s.Skill1).First(),
                        proficiency = (from s in skillRepo.GetDetails()
                                       where vtable.Tid == s.Tid && s.Skill1 == skill
                                       select s.Proficiency).First()
                    });
                }
                else
                {
                    continue;
                }
            }
            return skillFilters;
        }


        public IEnumerable<SkillFilter> GetTrainersBySkillAndGender(string? skill, string? gender)
        {
            var filterTable = filterRepo.GetVirtualTable();
            List<SkillFilter> skillFilters = new List<SkillFilter>();
            List<int> ids = (from s in skillRepo.GetDetails()
                             where s.Skill1 == skill
                             select s.Tid).ToList();
            foreach (VirtualTable vtable in filterTable)
            {
                if (ids.Contains(vtable.Tid) && vtable.Gender == gender)
                {
                    skillFilters.Add(new SkillFilter()
                    {
                        FirstName = vtable.FirstName,
                        LastName = vtable.LastName,
                        Gender = vtable.Gender,
                        City = vtable.City,
                        skill = (from s in skillRepo.GetDetails()
                                 where vtable.Tid == s.Tid && s.Skill1 == skill
                                 select s.Skill1).First(),
                        proficiency = (from s in skillRepo.GetDetails()
                                       where vtable.Tid == s.Tid && s.Skill1 == skill
                                       select s.Proficiency).First()
                    });
                }
                else
                {
                    continue;
                }
            }
            return skillFilters;
        }


        public IEnumerable<GenderFilter> GetTrainerByGender(string? gender)
        {
            var filterTable = filterRepo.GetVirtualTable().Where(f => f.Gender == gender);
            List<GenderFilter> genderFilters = new List<GenderFilter>();

            foreach(VirtualTable vtable in filterTable)
            {
                genderFilters.Add(new GenderFilter()
                {
                    FirstName = vtable.FirstName,
                    LastName = vtable.LastName,
                    Gender = vtable.Gender,
                    //allSkills = action.GetSkillDictionary(vtable.Tid) ?? null,
                    City = vtable.City,
                    State = vtable.State,
                    Zipcode = vtable.Zipcode,
                }) ;
            }
            return genderFilters;
        }


        public IEnumerable<GenderFilter> GetTrainerByCity(string? city)
        {
            var filterTable = filterRepo.GetVirtualTable().Where(f => f.City == city);
            List<GenderFilter> genderFilters = new List<GenderFilter>();

            foreach (VirtualTable vtable in filterTable)
            {
                genderFilters.Add(new GenderFilter()
                {
                    FirstName = vtable.FirstName,
                    LastName = vtable.LastName,
                    Gender = vtable.Gender,
                    //allSkills = action.GetSkillDictionary(vtable.Tid) ?? null,
                    City = vtable.City,
                    State = vtable.State,
                    Zipcode = vtable.Zipcode,
                });
            }
            return genderFilters;
        }


    }
}
