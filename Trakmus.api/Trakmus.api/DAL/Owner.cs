using System;
using System.Collections.Generic;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Trakmus.api.DAL
{
    public interface IOwnerRepository : IDisposable
    {
        IEnumerable<Owner> GetOwners();
        Owner GetOwnerById(Guid ownerId);
        void Insert(Owner owner);
        void Update(Owner owner);
        void Delete(Guid ownerId);

        void Save();
    }


    public class OwnerRepository : IOwnerRepository, IDisposable
    {
        private TrakMusContext context;

        public OwnerRepository(TrakMusContext context)
        {
            this.context = context;
        }

        public IEnumerable<Owner> GetOwners()
        {
            return context.Owners.ToList();
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return context.Owners.FirstOrDefault(t => t.GuidId == ownerId);
        }

        public void Insert(Owner owner)
        {
            context.Owners.Add(owner);
        }

        public void Update(Owner owner)
        {
            context.Entry(owner).State = EntityState.Modified;
        }

        public void Delete(Guid ownerId)
        {
            var t = context.Owners.FirstOrDefault(t => t.GuidId == ownerId);
            if (t == null)
                throw new Exception("Brugeren blev ikke fundet");

            context.Owners.Remove(t);
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
