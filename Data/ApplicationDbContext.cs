using DataAssembler1.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAssembler1.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Passport> Passports { get; set; }
        public DbSet<Child> Child { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Passport>().HasKey(p => new {p.Series, p.Number}).HasName("PassportKey");

            builder.Entity<Child>()
                .HasOne<Passport>()
                .WithMany(c => c.Children)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
