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
    public class PersonalSettingGroupsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonalSettingGroupsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PersonalSettingGroups
        [HttpGet]
        public IEnumerable<PersonalSettingGroup> GetPersonalSettingGroup()
        {
            return _context.PersonalSettingGroup;
        }

        // GET: api/PersonalSettingGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalSettingGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalSettingGroup = await _context.PersonalSettingGroup.FindAsync(id);

            if (personalSettingGroup == null)
            {
                return NotFound();
            }

            return Ok(personalSettingGroup);
        }

        // PUT: api/PersonalSettingGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalSettingGroup([FromRoute] int id, [FromBody] PersonalSettingGroup personalSettingGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalSettingGroup.ID)
            {
                return BadRequest();
            }

            _context.Entry(personalSettingGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalSettingGroupExists(id))
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

        // POST: api/PersonalSettingGroups
        [HttpPost]
        public async Task<IActionResult> PostPersonalSettingGroup([FromBody] PersonalSettingGroup personalSettingGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonalSettingGroup.Add(personalSettingGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalSettingGroup", new { id = personalSettingGroup.ID }, personalSettingGroup);
        }

        // DELETE: api/PersonalSettingGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalSettingGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalSettingGroup = await _context.PersonalSettingGroup.FindAsync(id);
            if (personalSettingGroup == null)
            {
                return NotFound();
            }

            _context.PersonalSettingGroup.Remove(personalSettingGroup);
            await _context.SaveChangesAsync();

            return Ok(personalSettingGroup);
        }

        private bool PersonalSettingGroupExists(int id)
        {
            return _context.PersonalSettingGroup.Any(e => e.ID == id);
        }
    }
}