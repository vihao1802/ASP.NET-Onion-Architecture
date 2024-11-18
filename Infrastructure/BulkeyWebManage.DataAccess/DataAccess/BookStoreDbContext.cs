using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BulkeyWebManage.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Bulkey.Domain.Entites;

namespace BulkeyWebManage.DataAccess.DataAccess;

public class BookStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Book { get; set; } // table in database
    public DbSet<Genre> Genre { get; set; }
    public DbSet<BookCatalogue> BookCatalogue { get; set; }
    public DbSet<Catalogue> Catalogue { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<CartDetail> CartDetail { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //AspNetUsers
        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");

        //Seed Data
        // builder.Entity<Genre>().HasData(
        //     new Genre { Id = 1, Name = "Fiction", Description = "Fiction books" },
        //     new Genre { Id = 2, Name = "Non-Fiction", Description = "Non-fiction books" },
        //     new Genre { Id = 3, Name = "Science Fiction", Description = "Science fiction books" },
        //     new Genre { Id = 4, Name = "Fantasy", Description = "Fantasy books" },
        //     new Genre { Id = 5, Name = "Mystery", Description = "Mystery books" }
        // );
    }
}
