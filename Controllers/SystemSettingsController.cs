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
    public class SystemSettingsController : ControllerBase
    {
        private readonly DataContext _context;

        public SystemSettingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SystemSettings
        [HttpGet]
        public IEnumerable<SystemSetting> GetSystemSetting()
        {
            return _context.SystemSetting;
        }

        // GET: api/SystemSettings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSystemSetting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var systemSetting = await _context.SystemSetting.FindAsync(id);

            if (systemSetting == null)
            {
                return NotFound();
            }

            return Ok(systemSetting);
        }

        // PUT: api/SystemSettings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemSetting([FromRoute] int id, [FromBody] SystemSetting systemSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != systemSetting.ID)
            {
                return BadRequest();
            }

            _context.Entry(systemSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemSettingExists(id))
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

        // POST: api/SystemSettings
        [HttpPost]
        public async Task<IActionResult> PostSystemSetting([FromBody] SystemSetting systemSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SystemSetting.Add(systemSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemSetting", new { id = systemSetting.ID }, systemSetting);
        }

        // DELETE: api/SystemSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemSetting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var systemSetting = await _context.SystemSetting.FindAsync(id);
            if (systemSetting == null)
            {
                return NotFound();
            }

            _context.SystemSetting.Remove(systemSetting);
            await _context.SaveChangesAsync();

            return Ok(systemSetting);
        }

        private bool SystemSettingExists(int id)
        {
            return _context.SystemSetting.Any(e => e.ID == id);
        }
    }
}