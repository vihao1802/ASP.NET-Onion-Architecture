using BulkeyWebManage.DataAccess.Data;
using BulkeyWebManage.DataAccess.DataAccess;
using BulkeyWebManage.Domain.Entites;
using BulkeyWebManage.Domain.Setting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BulkeyWebManage.DataAccess;

public static class ConfigurationService
{
    public static void AutoMigration(this WebApplication webApplication)
    {
        using (var scope = webApplication.Services.CreateScope())
        {
            {
                var appContext = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
                //appContext.Database.EnsureCreated();//check database 
                appContext.Database.MigrateAsync().Wait(); //generate all in folder Migration
            }
        }
    }

}
