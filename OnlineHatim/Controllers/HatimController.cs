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

        [HttpPost("takecuz/{hatimName}/{id?}")]
        public async Task<ActionResult> TakeCuzById([FromRoute] string hatimName, [FromRoute] int id, [FromQuery] string fullName)
        {
            fullName.Trim();

            if(string.IsNullOrEmpty(fullName)) 
                return BadRequest();

            var hatim = await _context.Hatims.Include(p => p.HatimCuz).Where(p => p.UrlCode == hatimName).FirstOrDefaultAsync();
            var cuz = hatim.HatimCuz.Where(p => p.CuzNo == id + 1).FirstOrDefault();

            // cüzü başkası aldımı kontrol eksik tmmdır :)
            if (cuz.FullName == null || string.IsNullOrEmpty(cuz.FullName))
            {
                cuz.FullName = fullName;
                hatim.Count++;
                if(hatim.Count == 30)
                {
                    hatim.IsEnd = true;
                }
                _context.Update(hatim);
                var saveChanges = await _context.SaveChangesAsync();

                if (saveChanges > 0)
                {
                    var data = await GetByUrlCode(hatimName);
                    return Ok(data);
                }
            }   
            
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<Hatim>>> GetAll()
        {
            var hatimler = await _context.Hatims.Where(p => p.IsPrivate == false).OrderByDescending(i=>i.CreatedDate).ToListAsync();

            if (hatimler.Count == 0)
                return BadRequest();
                
            return Ok(hatimler);
        }

        [HttpGet("hatim-gizli")]
        public async Task<ActionResult<List<Hatim>>> Gizli()
        {
            var hatimler = await _context.Hatims.Where(p => p.IsPrivate == true).OrderByDescending(i=>i.CreatedDate).ToListAsync();

            if (hatimler.Count == 0)
                return BadRequest();
                
            return Ok(hatimler);
        }

        [HttpGet("{code}")]// api/hatim/mirfan
        public async Task<ActionResult<Hatim>> GetByHatimName(string code)
        {
            var data = await GetByUrlCode(code);
            if (data == null)
                return BadRequest();

            return Ok(data);
        }

        [NonAction]
        public async Task<HatimDto> GetByUrlCode(string code)
        {
            var hatim = await _context.Hatims.Include(p => p.HatimCuz).FirstOrDefaultAsync(p => p.UrlCode == code);
            var cuz = hatim.HatimCuz.OrderBy(p => p.CuzNo).ToList();
            
            return new HatimDto { UrlCode = hatim.UrlCode, EndDate = hatim.EndDate.Date, Name = hatim.Name, HatimCuz = cuz };
        }

        [HttpPost]
        public async Task<ActionResult> Create(Hatim data)
        {
            if (string.IsNullOrEmpty(data.Name)) return BadRequest();

            var hatim = new Hatim
            {
                Name = data.Name,
                EndDate = data.EndDate,
                UrlCode = CreateUrlCode(data.Name),
                IsPrivate = data.IsPrivate
            };
            await _context.Hatims.AddAsync(hatim);
            await _context.SaveChangesAsync();

            var hatimcuz = new List<HatimCuz>();
            for (int i = 1; i <= 30; i++)
            {
                hatimcuz.Add(new HatimCuz
                {
                    CuzNo = i,
                    Hatim = hatim
                });
            }
            await _context.HatimCuzes.AddRangeAsync(hatimcuz);
            await _context.SaveChangesAsync();

            return Ok(new HatimDto { Name = hatim.Name, EndDate = hatim.EndDate, UrlCode = hatim.UrlCode });
        }

        [NonAction]
        string CreateUrlCode(string name)
        {
            var urlCode = _helper.GenerateSlug(name);
            var i = 0;
            while (_context.Hatims.Any(p => p.UrlCode == urlCode))
            {
                if (i >= 1)
                {
                    urlCode = urlCode.Substring(0, urlCode.Length - 1);
                    urlCode += i;
                }
                else
                {
                    urlCode += i;
                }
                i++;
            }

            return urlCode;
        }

    }
}
