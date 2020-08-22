using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using teste.Areas.Identity.Data;
using teste.Models;

[assembly: HostingStartup(typeof(teste.Areas.Identity.IdentityHostingStartup))]
namespace teste.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<testeContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("testeContextConnection")));

                services.AddDefaultIdentity<testeUser>()
                    .AddEntityFrameworkStores<testeContext>();
            });
        }
    }
}