using DF = DataFluentApi.Entities;
using DataFluentApi;
using Models;
using System.Security.Cryptography;

namespace Business_Logic
{
    public class TrainerLogic : ILogic
    {
        static string? _mail;
        static int _id;

        LogicActions action;

        ITrainerRepo<DF.TraineeLogin> loginRepo;
        ITrainerRepo<DF.TraineeTrainerDetail> trainerRepo;
        ITrainerRepo<DF.TraineeContactDetail> contactRepo;
        ITrainerRepo<DF.Education> educationRepo;
        ITrainerRepo<DF.Experience> experienceRepo;
        ITrainerRepo<DF.Skill> skillRepo;
        public TrainerLogic(ITrainerRepo<DF.TraineeLogin> _login, ITrainerRepo<DF.TraineeTrainerDetail> _trainer, ITrainerRepo<DF.TraineeContactDetail> _contact, ITrainerRepo<DF.Education> _education, ITrainerRepo<DF.Experience> _experience, ITrainerRepo<DF.Skill> _skill, LogicActions _action)
        {
            loginRepo = _login;
            trainerRepo = _trainer;
            contactRepo = _contact;
            educationRepo = _education;
            experienceRepo = _experience;
            skillRepo = _skill;
            action = _action;
        }


        //-------------------- Login Details --------------------

        

        public TraineeLogin AddLogin(TraineeLogin details)
        {
            _mail = details.Email;

            DF.TraineeLogin entityLogin = Mapper.MapGetEntityLogin(details);
            loginRepo.AddDetails(entityLogin);
            return Mapper.MapGetModelLogin(entityLogin);
        }

        public IEnumerable<TraineeLogin> GetLoginDetails()
        {
            return Mapper.MapAllLogins(loginRepo.GetDetails());
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
                        entitylogin.Password = login.Password;
                    }
                    if (login.Tdstatus != 0 && entitylogin.Tdstatus != login.Tdstatus)
                    {
                        entitylogin.Tdstatus = login.Tdstatus;
                    }
                    if (login.Cdstatus != 0 && entitylogin.Cdstatus != login.Cdstatus)
                    {
                        entitylogin.Cdstatus = login.Cdstatus;
                    }
                    if (login.Edustatus != 0 && entitylogin.Edustatus != login.Edustatus)
                    {
                        entitylogin.Edustatus = login.Edustatus;
                    }
                    if (login.Edstatus != 0 && entitylogin.Edstatus != login.Edstatus)
                    {
                        entitylogin.Edstatus = login.Edstatus;
                    }
                    if (login.Sdstatus != 0 && entitylogin.Sdstatus != login.Sdstatus)
                    {
                        entitylogin.Sdstatus = login.Sdstatus;
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
            var search = loginRepo.GetDetails().Where(l => l.Email == mail).First();
            return Mapper.MapGetModelLogin(loginRepo.DeleteDetails(search));
        }
        


        //-------------------- Trainer Details --------------------


        public TraineeTrainerDetail AddTrainer(string? mail, TraineeTrainerDetail tDetails)
        {
            _id = action.GetUniqueId();
            tDetails.Tid = _id;
            tDetails.Mail = mail;

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
            DF.TraineeTrainerDetail trainer = trainerRepo.GetDetails().Where(t => t.Mail == Email).First();
            return Mapper.MapGetModelTrainer(trainer);
        }

        public TraineeTrainerDetail DeleteTrainer(string? mail)
        {
            var search = trainerRepo.GetDetails().Where(l => l.Mail == mail).First();
            return Mapper.MapGetModelTrainer(trainerRepo.DeleteDetails(search));
        }


        public void UpdateTrainer(string? mail, TraineeTrainerDetail trainer)
        {
            try
            {
                DF.TraineeTrainerDetail entityTrainer = trainerRepo.GetDetails().Where(t => t.Mail == mail).First();

                if (entityTrainer != null)
                {
                    if (trainer.FirstName != "string" && entityTrainer.FirstName != trainer.FirstName)
                    {
                        entityTrainer.FirstName = trainer.FirstName;
                    }
                    if (trainer.LastName != "string" && entityTrainer.LastName != trainer.LastName)
                    {
                        entityTrainer.LastName = trainer.LastName;
                    }
                    if (trainer.Dob != "string" && entityTrainer.Dob != trainer.Dob)
                    {
                        entityTrainer.Dob = trainer.Dob;
                    }
                    if (trainer.Gender != "string" && entityTrainer.Gender != trainer.Gender)
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
            contactDetails.MailId = mail;
            var entityContact = Mapper.MapGetEntityContact(contactDetails);
            contactRepo.AddDetails(entityContact);
            return contactDetails;
        }

        public TraineeContactDetail GetTrainerContact(string? Email)
        {
            int id = action.GetTrainerId(Email);
            DF.TraineeContactDetail trainerContact = contactRepo.GetDetails().Where(c => c.Tid == id).First();
            return Mapper.MapGetModelContact(trainerContact);
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
            int id = action.GetTrainerId(mail);
            var search = contactRepo.GetDetails().Where(l => l.Tid == id).First();
            return Mapper.MapGetModelContact(contactRepo.DeleteDetails(search));
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
            int id = action.GetTrainerId(Email);
            DF.Education trainerEducation = educationRepo.GetDetails().Where(c => c.Tid == id).First();
            return Mapper.MapGetModelEducation(trainerEducation);
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
            int id = action.GetTrainerId(mail);
            var search = educationRepo.GetDetails().Where(l => l.Tid == id).First();
            return Mapper.MapGetModelEducation(educationRepo.DeleteDetails(search));
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
            int id = action.GetTrainerId(Email);
            List<DF.Experience> trainerExperience = experienceRepo.GetDetails().Where(c => c.Tid == id).ToList();
            return Mapper.MapAllModelExperiences(trainerExperience);
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
            int id = action.GetTrainerId(mail);
            var search = experienceRepo.GetDetails().Where(l => l.Tid == id && l.Company == company).First();
            return Mapper.MapGetModelExperience(experienceRepo.DeleteDetails(search));
        }

        public IEnumerable<Experience> DeleteAllTrainerExperience(string? mail)
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
            int id = action.GetTrainerId(Email);
            List<DF.Skill> trainerSkill = skillRepo.GetDetails().Where(c => c.Tid == id).ToList();
            return Mapper.MapAllModelSkills(trainerSkill);
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
            int id = action.GetTrainerId(mail);
            var search = skillRepo.GetDetails().Where(l => l.Tid == id && l.Skill1 == skill).First();
            return Mapper.MapGetModelSkill(skillRepo.DeleteDetails(search));
        }

        public IEnumerable<Skill> DeleteAllTrainerSkill(string? mail)
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


    }
}
