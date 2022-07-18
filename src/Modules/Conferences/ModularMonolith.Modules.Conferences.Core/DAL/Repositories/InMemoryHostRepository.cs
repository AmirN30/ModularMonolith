using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Modules.Conferences.Core.Repositories;

namespace ModularMonolith.Modules.Conferences.Core.DAL.Repositories
{
    public class InMemoryHostRepository : IHostRepository
    {
        private readonly List<Host> _hosts = new();

        public Task<Host> GetAsync(Guid id) => 
            Task.FromResult(_hosts.SingleOrDefault(x => x.Id == id));

        public async Task<IReadOnlyList<Host>> BrowseAsync()
        {
            await Task.CompletedTask;
            return _hosts;
        }

        public Task AddAsync(Host host)
        {
            _hosts.Add(host);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Host host)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Host host)
        {
            _hosts.Remove(host);
            return Task.CompletedTask;
        }
    }
}