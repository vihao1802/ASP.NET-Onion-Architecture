using System;
using System.Drawing;
using BulkeyWebManage.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkeyWebManage.DataAccess.Data;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {} 

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Image> Image { get; set; }
}
