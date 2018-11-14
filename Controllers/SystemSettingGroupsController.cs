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
    public class SystemSettingGroupsController : ControllerBase
    {
        private readonly DataContext _context;

        public SystemSettingGroupsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SystemSettingGroups
        [HttpGet]
        public IEnumerable<SystemSettingGroup> GetSystemSettingGroup()
        {
            return _context.SystemSettingGroup;
        }

        // GET: api/SystemSettingGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSystemSettingGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var systemSettingGroup = await _context.SystemSettingGroup.FindAsync(id);

            if (systemSettingGroup == null)
            {
                return NotFound();
            }

            return Ok(systemSettingGroup);
        }

        // PUT: api/SystemSettingGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemSettingGroup([FromRoute] int id, [FromBody] SystemSettingGroup systemSettingGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != systemSettingGroup.ID)
            {
                return BadRequest();
            }

            _context.Entry(systemSettingGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemSettingGroupExists(id))
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

        // POST: api/SystemSettingGroups
        [HttpPost]
        public async Task<IActionResult> PostSystemSettingGroup([FromBody] SystemSettingGroup systemSettingGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SystemSettingGroup.Add(systemSettingGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemSettingGroup", new { id = systemSettingGroup.ID }, systemSettingGroup);
        }

        // DELETE: api/SystemSettingGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemSettingGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var systemSettingGroup = await _context.SystemSettingGroup.FindAsync(id);
            if (systemSettingGroup == null)
            {
                return NotFound();
            }

            _context.SystemSettingGroup.Remove(systemSettingGroup);
            await _context.SaveChangesAsync();

            return Ok(systemSettingGroup);
        }

        private bool SystemSettingGroupExists(int id)
        {
            return _context.SystemSettingGroup.Any(e => e.ID == id);
        }
    }
}