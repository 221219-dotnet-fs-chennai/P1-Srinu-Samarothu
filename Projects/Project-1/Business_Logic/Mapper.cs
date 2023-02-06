using DF = DataFluentApi.Entities;
using Models;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace Business_Logic
{
    public class Mapper
    {
        // ---------------------- Login Mapper ------------------------
        public static TraineeLogin MapGetModelLogin(DF.TraineeLogin login)
        {
            return new TraineeLogin()
                {
                    Email = login.Email,
                    Password = null,
                    Tdstatus = login.Tdstatus,
                    Cdstatus = login.Cdstatus,
                    Edustatus = login.Edustatus,
                    Edstatus = login.Edstatus,
                    Sdstatus = login.Sdstatus
                };
        }


        public static IEnumerable<TraineeLogin> MapAllLogins(IEnumerable<DF.TraineeLogin> logins)
        {
            return logins.Select(MapGetModelLogin);
        }




        public static DF.TraineeLogin MapGetEntityLogin(TraineeLogin modelLogin)
        {
            return new DF.TraineeLogin()
            {
                Email = modelLogin.Email,
                Password = modelLogin.Password,
                Tdstatus = modelLogin.Tdstatus,
                Cdstatus = modelLogin.Cdstatus,
                Edstatus = modelLogin.Edstatus,
                Edustatus = modelLogin.Edustatus,
                Sdstatus = modelLogin.Sdstatus
            };
        }



        // ---------------------- Trainer Mapper ------------------------

        public static TraineeTrainerDetail MapGetModelTrainer(DF.TraineeTrainerDetail trainer)
        {
            return new TraineeTrainerDetail()
            {
                Tid = trainer.Tid,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                Dob = trainer.Dob,
                Gender = trainer.Gender,
                Mail = trainer.Mail
            };
        }

        public static IEnumerable<TraineeTrainerDetail> MapAllTrainers(IEnumerable<DF.TraineeTrainerDetail> logins)
        {
            return logins.Select(MapGetModelTrainer);
        }



        public static DF.TraineeTrainerDetail MapGetEntityTrainer(TraineeTrainerDetail modelTrainer)
        {

            return new DF.TraineeTrainerDetail()
            {
                Tid = modelTrainer.Tid,
                FirstName = modelTrainer.FirstName,
                LastName = modelTrainer.LastName,
                Dob = modelTrainer.Dob,
                Gender = modelTrainer.Gender,
                Mail = modelTrainer.Mail
            };
        }


        // ---------------------- Contact Mapper ------------------------

        public static DF.TraineeContactDetail MapGetEntityContact(TraineeContactDetail contactDetail)
        {
            return new DF.TraineeContactDetail()
            {
                MobileNumber = contactDetail.MobileNumber,
                AddressLane = contactDetail.AddressLane,
                City = contactDetail.City,
                State = contactDetail.State,
                Zipcode = contactDetail.Zipcode,
                Tid = contactDetail.Tid,
                MailId = contactDetail.MailId 
            };
        }


        public static TraineeContactDetail MapGetModelContact(DF.TraineeContactDetail contactDetail)
        {
            return new TraineeContactDetail()
            {
                MobileNumber = contactDetail.MobileNumber,
                AddressLane = contactDetail.AddressLane,
                City = contactDetail.City,
                State = contactDetail.State,
                Zipcode = contactDetail.Zipcode,
                Tid = contactDetail.Tid,
                MailId = contactDetail.MailId
            };
        }

        // ---------------------- Education Mapper ------------------------

        public static DF.Education MapGetEntityEducation(Education educationDetail)
        {
            return new DF.Education()
            {
                UgCollege = educationDetail.UgCollege,
                UgPercentage = educationDetail.UgPercentage,
                UgPassoutYear = educationDetail.UgPassoutYear,
                PgCollege = educationDetail.PgCollege,
                PgPercentage = educationDetail.PgPercentage,
                PgPassoutYear = educationDetail.PgPassoutYear,
                Tid = educationDetail.Tid,
            };
        }


        public static Education MapGetModelEducation(DF.Education educationDetail)
        {
            return new Education()
            {
                UgCollege = educationDetail.UgCollege,
                UgPercentage = educationDetail.UgPercentage,
                UgPassoutYear = educationDetail.UgPassoutYear,
                PgCollege = educationDetail.PgCollege,
                PgPercentage = educationDetail.PgPercentage,
                PgPassoutYear = educationDetail.PgPassoutYear,
                Tid = educationDetail.Tid,
            };
        }
    }
}