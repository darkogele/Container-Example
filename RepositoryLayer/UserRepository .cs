using DomainLayer;
using RepositoryLayer.AppDataContext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public bool DeleteUser(long userId)
        {
            var removed = false;
            User user = GetUser(userId);

            if (user != null)
            {
                removed = true;
                _context.Users.Remove(user);
            }

            return removed;
        }

        public User GetUser(long Id)
        {
            return _context.Users.Find(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}
