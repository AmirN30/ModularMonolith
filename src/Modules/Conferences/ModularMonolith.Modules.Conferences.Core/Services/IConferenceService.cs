using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModularMonolith.Modules.Conferences.Core.DTO;

namespace ModularMonolith.Modules.Conferences.Core.Services
{
    public interface IConferenceService
    {
        Task<ConferenceDetailsDto> GetAsync(Guid id);
        Task<IReadOnlyList<ConferenceDto>> BrowseAsync();
        Task AddAsync(ConferenceDetailsDto dto);
        Task UpdateAsync(ConferenceDetailsDto dto);
        Task DeleteAsync(Guid id);
    }
}