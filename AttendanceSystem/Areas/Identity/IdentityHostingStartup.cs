using System;
using AttendanceSystem.Areas.Identity.Data;
using AttendanceSystem.Data;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AttendanceSystem.Areas.Identity.IdentityHostingStartup))]
namespace AttendanceSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EwidencjaContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EwidencjaDbContext")));

                //services.AddDefaultIdentity<AttendanceSystemUser>(options => options.SignIn.RequireConfirmedAccount = false)
                //    .AddEntityFrameworkStores<EwidencjaContext>();
            });
        }
    }
}