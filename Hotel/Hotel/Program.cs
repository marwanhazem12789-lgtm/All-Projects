using Hotel.Models;
using Hotel.REPOS.Implement;
using Hotel.REPOS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("d")));
            builder.Services.AddScoped<IUser, UserRepo>();
            builder.Services.AddScoped<IRoom, RoomRepo>();
            builder.Services.AddScoped<IServiceType, ServiceTyperepo>();
            builder.Services.AddScoped<IBookingRecord, BookingRecordRepo>();

                var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
