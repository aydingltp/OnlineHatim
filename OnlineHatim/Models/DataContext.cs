using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineHatim.Models
{
    public class DataContext:DbContext
    {
        public DbSet<Hatim> Hatims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HatimCuz> HatimCuzes { get; set; }
    }
}
