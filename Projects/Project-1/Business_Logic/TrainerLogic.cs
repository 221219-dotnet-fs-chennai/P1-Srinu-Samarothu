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
        public TrainerLogic(ITrainerRepo<DF.TraineeLogin> _login, ITrainerRepo<DF.TraineeTrainerDetail> _trainer, ITrainerRepo<DF.TraineeContactDetail> _contact, LogicActions _action)
        {
            loginRepo = _login;
            trainerRepo = _trainer;
            contactRepo = _contact;
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
                    entitylogin.Password = login.Password;
                    entitylogin.Tdstatus = login.Tdstatus;
                    entitylogin.Cdstatus = login.Cdstatus;
                    entitylogin.Edustatus = login.Edustatus;
                    entitylogin.Edstatus = login.Edstatus;
                    entitylogin.Sdstatus = login.Sdstatus;
                    loginRepo.UpdateDetails(entitylogin);
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
                    entityTrainer.FirstName = trainer.FirstName;
                    entityTrainer.LastName = trainer.LastName;
                    entityTrainer.Dob = trainer.Dob;
                    entityTrainer.Gender = trainer.Gender;
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
                    entityTrainer.MobileNumber = contact.MobileNumber;
                    entityTrainer.AddressLane = contact.AddressLane;
                    entityTrainer.City = contact.City;
                    entityTrainer.State = contact.State;
                    entityTrainer.Zipcode = contact.Zipcode;
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

    }
}
