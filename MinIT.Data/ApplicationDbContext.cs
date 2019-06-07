using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinIT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<MeetingItem> MeetingItems { get; set; }

        public DbSet<MeetingType> MeetingTypes { get; set; }

        public DbSet<ItemStatus> MeetingItemStatuses { get; set; }

        public DbSet<MeetingItemStatus> MeetingItemStatusHistory { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MeetingItem>().HasKey(x => new { x.MeetingId, x.ItemId});

            builder.Entity<MeetingItemStatus>().HasKey(x => new { x.ItemId, x.ItemStatusId });
        }
    }
}
