using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Modules.Conferences.Core.Repositories;

namespace ModularMonolith.Modules.Conferences.Core.DAL.EF
{
    public class HostDatabaseRepository : IHostRepository
    {
        private readonly ConferencesDbContext _context;
        private readonly DbSet<Host> _hosts;

        public HostDatabaseRepository(ConferencesDbContext context)
        {
            _context = context;
            _hosts = context.Hosts;
        }

        public Task<Host> GetAsync(Guid id) => _hosts.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<Host>> BrowseAsync() => await _hosts.ToListAsync();

        public async Task AddAsync(Host conference)
        {
            await _context.AddAsync(conference);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Host conference)
        {
            _context.Update(conference);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Host conference)
        {
            _context.Remove(conference);
            await _context.SaveChangesAsync();
        }
    }
}