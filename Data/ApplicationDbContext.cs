using LeaveManagement.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                        .Property(a => a.LeaveBalance)
                        .HasDefaultValue(22);

            modelBuilder
                .Entity<UserLeave>()
                .Property(e => e.CreatedAt)
                .HasDefaultValue(new DateTime());

            modelBuilder.Entity<LeaveReason>()
                .HasData(
                    new LeaveReason { Id = 1, Value = "Annual Vacation" },
                    new LeaveReason { Id = 2, Value = "Sick Leave" },
                    new LeaveReason { Id = 3, Value = "Maternity Leave" },
                    new LeaveReason { Id = 4, Value = "Unpaid Leave" }
            );

        }
        public DbSet<UserLeave> UserLeaves { get; set; }
        public DbSet<LeaveReason> LeaveReasons { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
