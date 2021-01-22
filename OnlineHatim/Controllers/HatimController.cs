using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineHatim.Models;

namespace OnlineHatim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HatimController : ControllerBase
    {
        private readonly DataContext _context;
        public HatimController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hatim>>> GetHatimler()
        {
            var hatimler = await _context.Hatims.ToListAsync();

            if (hatimler == null)
                return BadRequest();

            return hatimler;
        }
        [HttpPost]
        public async ActionResult Create(string name)
        {
            new Hatim
            {
                Name = name,
                UrlCode = ""
            };
        }

        string CreateUrlCode()
        {

        }

    }
}
