using Microsoft.EntityFrameworkCore;
using Q.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
