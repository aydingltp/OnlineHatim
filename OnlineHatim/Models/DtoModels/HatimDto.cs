using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineHatim.Models.DtoModels
{
    public class HatimDto
    {
        public string Name { get; set; }
        public DateTime EndDate { get; set; }
        public string UrlCode { get; set; }
        public List<HatimCuz> HatimCuz { get; set; }
        public bool IsEnd { get; set; } = false;




    }
}
