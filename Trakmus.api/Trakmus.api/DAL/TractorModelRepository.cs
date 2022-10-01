using System;
using System.Collections.Generic;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Trakmus.api.DAL
{
    public interface ITractorModelRepository : IDisposable
    {
        IEnumerable<TractorModel> GetTractorModels();
        TractorModel GetTractorModelById(Guid modelId);
        void Insert(TractorModel tractorModel);
        void Update(TractorModel tractorModel);
        void Delete(Guid modelId);

        void Save();
    }


    public class TractorModelRepository : ITractorModelRepository, IDisposable
    {
        private TrakMusContext context;

        public TractorModelRepository(TrakMusContext context)
        {
            this.context = context;
        }

        public IEnumerable<TractorModel> GetTractorModels()
        {
            return context.TractorModels.ToList();
        }

        public TractorModel GetTractorModelById(Guid modelId)
        {
            return context.TractorModels.FirstOrDefault(t => t.GuidId == modelId);
        }

        public void Insert(TractorModel tractorModel)
        {
            context.TractorModels.Add(tractorModel);
        }

        public void Update(TractorModel tractorModel)
        {
            context.Entry(tractorModel).State = EntityState.Modified;
        }

        public void Delete(Guid modelId)
        {
            var t = context.TractorModels.FirstOrDefault(t => t.GuidId == modelId);
            if (t == null)
                throw new Exception("Modellen blev ikke fundet");

            context.TractorModels.Remove(t);
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
