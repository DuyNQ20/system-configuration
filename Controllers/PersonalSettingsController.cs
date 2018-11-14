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
    public class PersonalSettingsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonalSettingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PersonalSettings
        [HttpGet]
        public IEnumerable<PersonalSetting> GetPersonalSetting()
        {
            return _context.PersonalSetting;
        }

        // GET: api/PersonalSettings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalSetting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalSetting = await _context.PersonalSetting.FindAsync(id);

            if (personalSetting == null)
            {
                return NotFound();
            }

            return Ok(personalSetting);
        }

        // PUT: api/PersonalSettings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalSetting([FromRoute] int id, [FromBody] PersonalSetting personalSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalSetting.ID)
            {
                return BadRequest();
            }

            _context.Entry(personalSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalSettingExists(id))
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

        // POST: api/PersonalSettings
        [HttpPost]
        public async Task<IActionResult> PostPersonalSetting([FromBody] PersonalSetting personalSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonalSetting.Add(personalSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalSetting", new { id = personalSetting.ID }, personalSetting);
        }

        // DELETE: api/PersonalSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalSetting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalSetting = await _context.PersonalSetting.FindAsync(id);
            if (personalSetting == null)
            {
                return NotFound();
            }

            _context.PersonalSetting.Remove(personalSetting);
            await _context.SaveChangesAsync();

            return Ok(personalSetting);
        }

        private bool PersonalSettingExists(int id)
        {
            return _context.PersonalSetting.Any(e => e.ID == id);
        }
    }
}