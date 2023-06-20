using RohitDI_Mvc.DAL;
using RohitDI_Mvc.Models;
using RohitDI_Mvc.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RohitDI_Mvc.RepositoryServiess
{
    public class SchemeMasterServies : ISchemeMaster
    {
        DataAccess _context = new DataAccess();
       
        public int AddUser(Registration entity)
        {
            try
            {
                _context.Registration.Add(entity);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Registration GetSingleRocordID(int? RegistrationID)
        {
            try
            {
                return _context.Registration.FirstOrDefault(u => u.RegistrationID == RegistrationID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void UpdateUsersReg(Registration Update)
        {
            var existingEntity = _context.Registration.Find(Update.RegistrationID);

            if (existingEntity != null)
            {
                existingEntity.Name = Update.Name;
                existingEntity.Mobileno = Update.Mobileno;
                existingEntity.EmailID = Update.EmailID;
                existingEntity.Username = Update.Username;
                existingEntity.Password = Update.Password;
                existingEntity.Gender = Update.Gender;
                existingEntity.Birthdate = Update.Birthdate;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Entity not found");
            }
        }
        public IQueryable<Registration> ListofRegisteredUser()
        {
            try
            {
                var IQueryableRegistered = (from register in _context.Registration select register);
                return IQueryableRegistered;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int RegisterUserDelete(int? RegistrationID)
        {
            var entityToDelete = _context.Registration.FirstOrDefault(e => e.RegistrationID == RegistrationID);
            if (entityToDelete != null)
            {
                _context.Registration.Remove(entityToDelete);
                return _context.SaveChanges();
            }
            else
            {
                return 0; 
            }

        }
    }
}