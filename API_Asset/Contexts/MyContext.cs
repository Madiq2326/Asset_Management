using API_Asset.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_Asset.Contexts
{
    public class MyContext : IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<OutgoingItem> OutgoingItems { get; set; }
        public DbSet<IncomingItem> IncomingItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().ToTable("users");
            builder.Entity<IdentityRole>().ToTable("roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("userroles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("userclaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("userlogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("roleclaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("usertokens");
        }
    }
}
