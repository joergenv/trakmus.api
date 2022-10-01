using System;
using System.Collections.Generic;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Trakmus.api.DAL
{
    public interface IManufacturerRepository : IDisposable
    {
        IEnumerable<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturerById(Guid modelId);
        void Insert(Manufacturer manufacturer);
        void Update(Manufacturer manufacturer);
        void Delete(Guid modelId);

        void Save();
    }


    public class ManufacturerRepository : IManufacturerRepository, IDisposable
    {
        private TrakMusContext context;

        public ManufacturerRepository(TrakMusContext context)
        {
            this.context = context;
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return context.Manufactureres.ToList();
        }

        public Manufacturer GetManufacturerById(Guid manufacturerId)
        {
            return context.Manufactureres.FirstOrDefault(t => t.GuidId == manufacturerId);
        }

        public void Insert(Manufacturer manufacturer)
        {
            context.Manufactureres.Add(manufacturer);
        }

        public void Update(Manufacturer manufacturer)
        {
            context.Entry(manufacturer).State = EntityState.Modified;
        }

        public void Delete(Guid manufacturerId)
        {
            var m = context.Manufactureres.FirstOrDefault(t => t.GuidId == manufacturerId);
            if (m == null)
                throw new Exception("Fabrikanten blev ikke fundet");

            context.Manufactureres.Remove(m);
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
