using System;
using BulkeyWebManage.DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BulkeyWebManage.DataAccess;

public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    public BookStoreDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();
        optionsBuilder.UseSqlServer("DefaultConnection");  
        return new BookStoreDbContext(optionsBuilder.Options);
    }
}
