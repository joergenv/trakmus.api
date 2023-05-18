using System;
using System.Collections.Generic;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Trakmus.api.DAL
{
    public interface ITractorRepository : IRepositoryBase<Tractor>
    {
        Task<Tractor> GetTractorByIdAsync(Guid id);

        //IQueryable<Tractor> Search(string s);

        Task<List<Person>> GetOwnersAsync();

        Task<List<Tractor>> GetAllTractorsAsync();

        Task<Tractor> CreateTractorAsync(Tractor tractor);

        Task<Tractor> UpdateTractorAsync(Tractor tractor);

    }


    public class TractorRepository : RepositoryBase<Tractor>, ITractorRepository
    {

        public TractorRepository(TrakMusContext context) : base(context)
        {

        }

        public async Task<Tractor> GetTractorByIdAsync(Guid id)
        {
            return await FindAll().FirstOrDefaultAsync<Tractor>(m => m.Id == id);
        }

        public async Task<List<Tractor>> GetAllTractorsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Tractor> CreateTractorAsync(Tractor tractor)
        {
            return await CreateAsync(tractor);
        }

        public async Task<List<Person>> GetOwnersAsync()
        {
            var owners = await FindAll().Select(p => p.Owner).GroupBy(p => p.Id).Select(g => g.First()).ToListAsync();
            return owners;
            
        }

        public async Task<Tractor> UpdateTractorAsync(Tractor tractor)
        {
            return await UpdateAsync(tractor);
        }
        public void DeleteTractor(Guid id)
        {
            return;
        }
    }
}
