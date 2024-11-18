using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BulkeyWebManage.DataAccess.DataAccess;
using BulkeyWebManage.Domain.Entites;


namespace BulkeyWebManage.DataAccess.Configuration;

public static class ConfigurationDbAccess {
    public static void RegisterDb(this IServiceCollection services, IConfiguration configuration){
        
      // builder.Services.RegisterDb(builder.Configuration);
 var ConnectionString = configuration.GetConnectionString("DefaultConnection")?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

      services.AddDbContext<BookStoreDbContext>(options =>
      options.UseSqlServer(ConnectionString));

     services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BookStoreDbContext>();
    }
    // public static void ConfigureServices(IServiceCollection services)
    // {
    //     services.AddDbContext<BookStoreDbContext>(
    //         option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
    //     );
    // }
}
