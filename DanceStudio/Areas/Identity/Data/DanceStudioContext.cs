using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceStudio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DanceStudio.Areas.Identity.Data
{
    public partial class DanceStudioContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        
        public DanceStudioContext(DbContextOptions<DanceStudioContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
