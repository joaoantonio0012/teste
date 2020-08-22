using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testebitzen.Areas.Identity.Data;
using testebitzen.Data;

[assembly: HostingStartup(typeof(testebitzen.Areas.Identity.IdentityHostingStartup))]
namespace testebitzen.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<testebitzenContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("testebitzenContextConnection")));

                services.AddDefaultIdentity<testebitzenUser>()
                    .AddEntityFrameworkStores<testebitzenContext>();
            });
        }
    }
}