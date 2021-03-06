using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineHatim.Models
{
    public class Hatim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlCode { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public bool IsEnd { get; set; } = false;
        public bool IsPrivate { get; set; }
        public List<HatimCuz> HatimCuz { get; set; }

    }
}
