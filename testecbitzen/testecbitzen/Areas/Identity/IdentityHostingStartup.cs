using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testecbitzen.Areas.Identity.Data;
using testecbitzen.Models;

[assembly: HostingStartup(typeof(testecbitzen.Areas.Identity.IdentityHostingStartup))]
namespace testecbitzen.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<testecbitzenContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("testecbitzenContextConnection")));

                services.AddDefaultIdentity<testecbitzenUser>()
                    .AddEntityFrameworkStores<testecbitzenContext>();
            });
        }
    }
}