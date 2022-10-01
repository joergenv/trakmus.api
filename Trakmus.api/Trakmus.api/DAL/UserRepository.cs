using System;
using System.Collections.Generic;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Trakmus.api.DAL
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid userId);
        void Insert(User user);
        void Update(User user);
        void Delete(Guid userId);

        void Save();
    }


    public class UserRepository : IUserRepository, IDisposable
    {
        private TrakMusContext context;

        public UserRepository(TrakMusContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(Guid userId)
        {
            return context.Users.FirstOrDefault(t => t.GuidId == userId);
        }

        public void Insert(User user)
        {
            context.Users.Add(user);
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(Guid userId)
        {
            var t = context.Users.FirstOrDefault(t => t.GuidId == userId);
            if (t == null)
                throw new Exception("Brugeren blev ikke fundet");

            context.Users.Remove(t);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
