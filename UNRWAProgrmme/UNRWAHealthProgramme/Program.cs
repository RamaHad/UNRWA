using BackEnd;
using BackEnd.Entities;
using IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repo;
using UNRWAHealthProgramme.Models;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

////identity configuration
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders(); //to update later
//our Repo Services
builder.Services.AddSingleton<UserIRepo, UserRepo>();
builder.Services.AddSingleton<IndividualIRepo, IndividualRepo>();
builder.Services.AddSingleton<AppointmentIRepo, AppointmentRepo>();
builder.Services.AddSingleton<ServiceIRepo, ServiceRepo>();
builder.Services.AddSingleton<TeamIRepo, TeamRepo>();
builder.Services.AddSingleton<EmployeeIRepo, EmployeeRepo>();
builder.Services.AddSingleton<TimeSloteIRepo, TimeSloteRepo>();
builder.Services.AddSingleton<StudyLevelIRepo, StudyLevelRepo>();
builder.Services.AddScoped<ApplicationDBContext>();

builder.Services.AddSingleton<RelationshipIRepo, RelationshipRepo>();

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

//Identity Configuration
//By this on every HTTP Request, the user’s credentials will be added on a Cookie or URL.
//This will associate a give user with the HTTP request he or she makes to the application.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
