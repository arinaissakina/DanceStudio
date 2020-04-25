using System;
using DanceStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace DanceStudio.Data
{
    public class DanceStudioContext : DbContext
    {
        public DanceStudioContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Dance> Dances { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
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
                .WithMany(p => p.GroupMembers);

            modelBuilder.Entity<GroupMember>()
                .HasOne(sc => sc.Member)
                .WithMany(p => p.GroupMembers);

        }
    }
}