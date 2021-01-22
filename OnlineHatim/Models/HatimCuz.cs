using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace OnlineHatim.Models
{
    public class HatimCuz
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Cuz { get; set; }
    }
}
