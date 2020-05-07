using System;
using DanceStudio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DanceStudio.Data
{
    public class DanceStudioContext : IdentityDbContext<IdentityUser>
    {
        public DanceStudioContext(DbContextOptions<DanceStudioContext> options) : base(options)
        {
        }
        
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Dance> Dances { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<IdentityUser>() 
                .ToTable( "Users" );
            
            // One to One
            
            modelBuilder
                .Entity<Group>()
                .HasOne(p => p.Coach)
                .WithOne(c => c.Group);

            // One to Many
            
            modelBuilder
                .Entity<Group>()
                .HasOne(p => p.Dance)
                .WithMany(r => r.Groups);
            

            //Many to Many
            
            modelBuilder.Entity<GroupMember>().HasKey(sc => new { sc.GroupId, sc.MemberId });

            modelBuilder.Entity<GroupMember>()
                .HasOne(sc => sc.Group)
                .WithMany(p => p.GroupMembers)
                .HasForeignKey(sc => sc.GroupId);

            modelBuilder.Entity<GroupMember>()
                .HasOne(sc => sc.Member)
                .WithMany(p => p.GroupMembers)
                .HasForeignKey(sc => sc.MemberId);

        }

    }
}