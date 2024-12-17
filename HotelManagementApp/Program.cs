using HotelManagementApp.BookingFolder;
using HotelManagementApp.Data;
using HotelManagementApp.PaymentFolder;
using HotelManagementApp.RoomsFolder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
//How to set Cookie Session
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie(option =>
    {
        option.LoginPath = "/Access/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });

//register DbContext for Guest
builder.Services.AddDbContext<GuestDbContext>(options
    => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//N.B: when having different DbContext like this, use this command to run your migration. NOT FOR D FIRST DbContext ABOVE but for all the rest below
//add-migration RoomTable -Context HotelManagementApp.RoomsFolder.RoomDbContext
//update-database RoomTable -Context HotelManagementApp.RoomsFolder.RoomDbContext
//register DbContext for Room
builder.Services.AddDbContext<RoomDbContext>(actions
    => actions.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//register DbContext for Booking
//add-migration BookingTable -Context HotelManagementApp.BookingFolder.BookingDbContext
//update-database BookingTable -Context HotelManagementApp.BookingFolder.BookingDbContext
builder.Services.AddDbContext<BookingDbContext>(writeAnyThing
    => writeAnyThing.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//register DbContext for Payment
builder.Services.AddDbContext<PaymentDbContext>(choices
    => choices.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
