using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<JobEntity> Jobs { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
    }
}
