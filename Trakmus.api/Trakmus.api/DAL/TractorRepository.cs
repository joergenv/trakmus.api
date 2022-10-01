using System;
using System.Collections.Generic;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Trakmus.api.DAL
{
    public interface ITractorRepository : IDisposable
    {
        IEnumerable<Tractor> GetTractors();
        Tractor GetTractorById(Guid tractorId);
        void Insert(Tractor tractor);
        void Update(Tractor tractor);
        void Delete(Guid tractorId);

        void Save();
    }

    public class TractorRepository : ITractorRepository, IDisposable
    {
        private TrakMusContext context;

        public TractorRepository(TrakMusContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tractor> GetTractors()
        {
            return context.Tractors.ToList();
        }

        public Tractor GetTractorById(Guid tractorId)
        {
            return context.Tractors.FirstOrDefault(t => t.GuidId == tractorId);
        }

        public void Insert(Tractor tractor)
        {
            context.Tractors.Add(tractor);
        }

        public void Update(Tractor tractor)
        {
            context.Entry(tractor).State = EntityState.Modified;
        }

        public void Delete(Guid tractorId)
        {
            var t = context.Tractors.FirstOrDefault(t=>t.GuidId == tractorId);
            if (t == null)
                throw new Exception("Traktor blev ikke fundet");

            context.Tractors.Remove(t);
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
