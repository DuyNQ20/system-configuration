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
    public class PersonalSettingDescriptionsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonalSettingDescriptionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PersonalSettingDescriptions
        [HttpGet]
        public IEnumerable<PersonalSettingDescription> GetPersonalSettingDescription()
        {
            return _context.PersonalSettingDescription;
        }

        // GET: api/PersonalSettingDescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalSettingDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalSettingDescription = await _context.PersonalSettingDescription.FindAsync(id);

            if (personalSettingDescription == null)
            {
                return NotFound();
            }

            return Ok(personalSettingDescription);
        }

        // PUT: api/PersonalSettingDescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalSettingDescription([FromRoute] int id, [FromBody] PersonalSettingDescription personalSettingDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalSettingDescription.ID)
            {
                return BadRequest();
            }

            _context.Entry(personalSettingDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalSettingDescriptionExists(id))
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

        // POST: api/PersonalSettingDescriptions
        [HttpPost]
        public async Task<IActionResult> PostPersonalSettingDescription([FromBody] PersonalSettingDescription personalSettingDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonalSettingDescription.Add(personalSettingDescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalSettingDescription", new { id = personalSettingDescription.ID }, personalSettingDescription);
        }

        // DELETE: api/PersonalSettingDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalSettingDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalSettingDescription = await _context.PersonalSettingDescription.FindAsync(id);
            if (personalSettingDescription == null)
            {
                return NotFound();
            }

            _context.PersonalSettingDescription.Remove(personalSettingDescription);
            await _context.SaveChangesAsync();

            return Ok(personalSettingDescription);
        }

        private bool PersonalSettingDescriptionExists(int id)
        {
            return _context.PersonalSettingDescription.Any(e => e.ID == id);
        }
    }
}