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
    public class UserSettingsController : ControllerBase
    {
        private readonly DataContext _context;

        public UserSettingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserSettings
        [HttpGet]
        public IEnumerable<UserSetting> GetUserSetting()
        {
            return _context.UserSetting;
        }

        // GET: api/UserSettings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserSetting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userSetting = await _context.UserSetting.FindAsync(id);

            if (userSetting == null)
            {
                return NotFound();
            }

            return Ok(userSetting);
        }

        // PUT: api/UserSettings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSetting([FromRoute] int id, [FromBody] UserSetting userSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userSetting.ID)
            {
                return BadRequest();
            }

            _context.Entry(userSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSettingExists(id))
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

        // POST: api/UserSettings
        [HttpPost]
        public async Task<IActionResult> PostUserSetting([FromBody] UserSetting userSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserSetting.Add(userSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSetting", new { id = userSetting.ID }, userSetting);
        }

        // DELETE: api/UserSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSetting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userSetting = await _context.UserSetting.FindAsync(id);
            if (userSetting == null)
            {
                return NotFound();
            }

            _context.UserSetting.Remove(userSetting);
            await _context.SaveChangesAsync();

            return Ok(userSetting);
        }

        private bool UserSettingExists(int id)
        {
            return _context.UserSetting.Any(e => e.ID == id);
        }
    }
}