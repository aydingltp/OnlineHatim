using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineHatim.Models;
using Slugify;

namespace OnlineHatim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HatimController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ISlugHelper _helper;
        public HatimController(DataContext context, ISlugHelper helper)
        {
            _context = context;
            _helper = helper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hatim>>> GetAll()
        {
            var hatimler = await _context.Hatims.ToListAsync();

            if (hatimler.Count == 0)
                return BadRequest();

            return Ok(hatimler);
        }

        [HttpGet("{code}")]// api/hatim/code?=
        public async Task<ActionResult<Hatim>> GetByUrlCode(string code)
        {
            var hatim = await _context.Hatims.FirstOrDefaultAsync(p => p.UrlCode == code);
            if (hatim==null)
                BadRequest();

            return Ok(hatim);
        }

        [HttpPost]
        public async Task<ActionResult> Create(string name)
        {
            if (string.IsNullOrEmpty(name)) BadRequest();

            var hatim = new Hatim
            {
                Name = name,
                UrlCode = CreateUrlCode(name)
            };
            await _context.Hatims.AddAsync(hatim);
            await _context.SaveChangesAsync();

            return Ok(hatim);
        }

        [NonAction]
        string CreateUrlCode(string name)
        {
            var urlCode = _helper.GenerateSlug(name);
            var i = 0;
            while (_context.Hatims.Any(p => p.UrlCode == urlCode))
            {
                urlCode += i;
                i++;
            }

            return urlCode;
        }

    }
}
