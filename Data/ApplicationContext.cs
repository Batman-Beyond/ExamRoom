using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var timeSlot = modelBuilder.Entity<TimeSlot>();

            timeSlot.HasOne(b => b.Partner).WithMany(a => a.TimeSlots).HasForeignKey("Partner_Id");
        }

        public DbSet<Partner> Partner { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
    }
}
