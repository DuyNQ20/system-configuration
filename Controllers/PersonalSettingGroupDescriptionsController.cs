using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Configuration.Data;
using Configuration.Models;

namespace Configuration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalSettingGroupDescriptionsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonalSettingGroupDescriptionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PersonalSettingGroupDescriptions
        [HttpGet]
        public IEnumerable<PersonalSettingGroupDescription> GetPersonalSettingGroupDescription()
        {
            return _context.PersonalSettingGroupDescription;
        }

        // GET: api/PersonalSettingGroupDescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalSettingGroupDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalSettingGroupDescription = await _context.PersonalSettingGroupDescription.FindAsync(id);

            if (personalSettingGroupDescription == null)
            {
                return NotFound();
            }

            return Ok(personalSettingGroupDescription);
        }

        // PUT: api/PersonalSettingGroupDescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalSettingGroupDescription([FromRoute] int id, [FromBody] PersonalSettingGroupDescription personalSettingGroupDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalSettingGroupDescription.ID)
            {
                return BadRequest();
            }

            _context.Entry(personalSettingGroupDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalSettingGroupDescriptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonalSettingGroupDescriptions
        [HttpPost]
        public async Task<IActionResult> PostPersonalSettingGroupDescription([FromBody] PersonalSettingGroupDescription personalSettingGroupDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonalSettingGroupDescription.Add(personalSettingGroupDescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalSettingGroupDescription", new { id = personalSettingGroupDescription.ID }, personalSettingGroupDescription);
        }

        // DELETE: api/PersonalSettingGroupDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalSettingGroupDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalSettingGroupDescription = await _context.PersonalSettingGroupDescription.FindAsync(id);
            if (personalSettingGroupDescription == null)
            {
                return NotFound();
            }

            _context.PersonalSettingGroupDescription.Remove(personalSettingGroupDescription);
            await _context.SaveChangesAsync();

            return Ok(personalSettingGroupDescription);
        }

        private bool PersonalSettingGroupDescriptionExists(int id)
        {
            return _context.PersonalSettingGroupDescription.Any(e => e.ID == id);
        }
    }
}