using SMS.Data;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly SMSContext db;
        private readonly ICartService cartService;

        public UserService(SMSContext db, ICartService cartService)
        {
            this.db = db;
            this.cartService = cartService;
        }
        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };
            var cardId = this.cartService.CreateCart();
            user.CartId = cardId;
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

     
            public User GetUserOrNull(string username, string password)
            {
                var passwordHash = this.HashPassword(password);
                var user = this.db.Users.FirstOrDefault(
                    x => x.Username == username
                    && x.Password == passwordHash);
                return user;
            }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
