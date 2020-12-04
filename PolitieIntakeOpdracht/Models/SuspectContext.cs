using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolitieIntakeOpdracht.Models
{
    public class SuspectContext : DbContext
    {
        public SuspectContext(DbContextOptions<SuspectContext> options) 
            : base(options)
        {
        }

        public DbSet<Suspect> Suspects { get; set;  }
    }
}
