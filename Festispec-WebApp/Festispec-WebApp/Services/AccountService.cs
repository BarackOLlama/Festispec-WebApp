using System;
using System.Collections.Generic;
using System.Linq;
using Festispec_WebApp.Helpers;
using Festispec_WebApp.Models;

namespace Festispec_WebApp.Services
{
   public interface IAccountService
    {
        Accounts Authenticate(string username, string password);
        IEnumerable<Accounts> GetAll();
        Accounts GetById(int id);
        Accounts Create(Accounts user, string password);
        void Update(Accounts user, string password = null);
        void Delete(int id);
    }
 
    public class AccountService : IAccountService
    {
        private FSContext _context;
 
        public AccountService(FSContext context)
        {
            _context = context;
        }

        public AccountService()
        {
            
        }
 
        public Accounts Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
 
            var user = _context.Accounts.SingleOrDefault(x => x.Username == username);
 
            // check if username exists
            if (user == null)
                return null;
 
            // check if password is correct
            if (!VerifyPasswordHash(password, user.Password, user.Salt))
                return null;
 
            // authentication successful
            return user;
        }
 
        public IEnumerable<Accounts> GetAll()
        {
            return _context.Accounts;
        }
 
        public Accounts GetById(int id)
        {
            return _context.Accounts.Find(id);
        }

        public void Update(Accounts user, string password = null)
        {
            throw new NotImplementedException();
        }

        public Accounts Create(Accounts user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");
 
            if (_context.Accounts.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");
 
            String passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
 
            user.Password = passwordHash;
            user.Salt = passwordSalt;
 
            _context.Accounts.Add(user);
            _context.SaveChanges();
 
            return user;
        }
 
        public void Delete(int id)
        {
            var user = _context.Accounts.Find(id);
            if (user != null)
            {
                _context.Accounts.Remove(user);
                _context.SaveChanges();
            }
        }
 
        // private helper methods
 
        private static void CreatePasswordHash(string password, out String passwordHash, out String passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
 
            passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            passwordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt);
        }
 
        private static bool VerifyPasswordHash(string password, String storedHash, String storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            
            string saltedPw = BCrypt.Net.BCrypt.HashPassword(password, storedSalt);
            if (saltedPw == storedHash)
            {
                return true;                
            }

            return false;
        }
    }
}