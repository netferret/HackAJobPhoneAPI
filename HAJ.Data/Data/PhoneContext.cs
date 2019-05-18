using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAJ.PhoneAPI.Domain.Data
{
    public class PhoneContext : DbContext
    {
        public PhoneContext(DbContextOptions<PhoneContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<PhoneBookUser> PhoneBookUsers { get; set; }

    }
}
