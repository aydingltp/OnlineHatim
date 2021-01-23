using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineHatim.Models;
using OnlineHatim.Models.DtoModels;
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
            if (hatim == null)
                return BadRequest();

            return Ok(new HatimDto { UrlCode = hatim.UrlCode, EndDate = hatim.EndDate, Name = hatim.Name });
        }

        [HttpPost]
        public async Task<ActionResult> Create(Hatim data)
        {
            if (string.IsNullOrEmpty(data.Name)) return BadRequest();

            var hatim = new Hatim
            {
                Name = data.Name,
                EndDate = data.EndDate,
                UrlCode = CreateUrlCode(data.Name)
            };
            await _context.Hatims.AddAsync(hatim);
            await _context.SaveChangesAsync();

            var hatimcuz = new List<HatimCuz>();
            for (int i = 1; i <= 30; i++)
            {
                hatimcuz.Add(new HatimCuz
                {
                    CuzNo = i,
                    HatimId = hatim.Id
                });
            }
            await _context.HatimCuzes.AddRangeAsync(hatimcuz);
            await _context.SaveChangesAsync ();

            return Ok(new HatimDto { Name = hatim.Name, EndDate = hatim.EndDate, UrlCode = hatim.UrlCode });
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
