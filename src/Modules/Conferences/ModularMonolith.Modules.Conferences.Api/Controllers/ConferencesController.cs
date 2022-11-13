using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Services;

namespace ModularMonolith.Modules.Conferences.Api.Controllers
{
    internal class ConferencesController : BaseController
    {
        private readonly IConferenceService _conferenceService;

        public ConferencesController(
            IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<ConferenceDetailsDto>>> Get(Guid id)
        {
            var host = await _conferenceService.GetAsync(id);
            if (host is null)
                return NotFound();
            
            return Ok(host);
        }
            
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ConferenceDto>>> BrowseAsync() => 
            Ok(await _conferenceService.BrowseAsync());

        [HttpPost]
        public async Task<ActionResult> AddAsync(ConferenceDetailsDto host)
        {
            await _conferenceService.AddAsync(host);
            return CreatedAtAction(nameof(Get), new {id = host.Id}, null);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, ConferenceDetailsDto dto)
        {
            dto.Id = id;
            await _conferenceService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _conferenceService.DeleteAsync(id);
            return NoContent();
        }
    }
}