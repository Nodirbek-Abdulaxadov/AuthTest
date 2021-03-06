using System;
using AuthTest.Areas.Identity.Data;
using AuthTest.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AuthTest.Areas.Identity.IdentityHostingStartup))]
namespace AuthTest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthTestDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthTestDBContextConnection")));

                services.AddDefaultIdentity<AuthTestUser>(options => options.SignIn.RequireConfirmedAccount = false
                                                            /*{
                                                             * options.SignIn.RequireConfirmedAccount = false
                                                             * options.Password.RequiredLowerCase = false
                                                             * options.Password.RequiredUpperCase = false
                                                             }*/
                                                            )
                    .AddEntityFrameworkStores<AuthTestDBContext>();
            });
        }
    }
}