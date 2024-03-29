﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Modules.Conferences.Core.Repositories;

namespace ModularMonolith.Modules.Conferences.Core.DAL.EF
{
    public class ConferenceDatabaseRepository : IConferenceRepository
    {
        private readonly ConferencesDbContext _context;
        private readonly DbSet<Conference> _conferences;

        public ConferenceDatabaseRepository(ConferencesDbContext context)
        {
            _context = context;
            _conferences = context.Conferences;
        }

        public Task<Conference> GetAsync(Guid id) => _conferences.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<Conference>> BrowseAsync() => await _conferences.ToListAsync();

        public async Task AddAsync(Conference conference)
        {
            await _context.AddAsync(conference);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Conference conference)
        {
            _context.Update(conference);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Conference conference)
        {
            _context.Remove(conference);
            await _context.SaveChangesAsync();
        }
    }
}