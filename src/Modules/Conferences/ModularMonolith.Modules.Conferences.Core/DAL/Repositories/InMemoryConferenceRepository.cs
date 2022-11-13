using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Modules.Conferences.Core.Repositories;

namespace ModularMonolith.Modules.Conferences.Core.DAL.Repositories
{
    public class InMemoryConferenceRepository : IConferenceRepository
    {
        private readonly List<Conference> _conferences = new();

        public Task<Conference> GetAsync(Guid id) => 
            Task.FromResult(_conferences.SingleOrDefault(x => x.Id == id));

        public async Task<IReadOnlyList<Conference>> BrowseAsync()
        {
            await Task.CompletedTask;
            return _conferences;
        }

        public Task AddAsync(Conference host)
        {
            _conferences.Add(host);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Conference host)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Conference host)
        {
            _conferences.Remove(host);
            return Task.CompletedTask;
        }
    }
}