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

        }

        public PhoneContext()
        {

        }

        public DbSet<PhoneBookUser> PhoneBookUsers { get; set; }

    }
}
