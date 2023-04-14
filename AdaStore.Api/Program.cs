using AdaStore.Shared.Conts;
using AdaStore.Shared.Data;
using AdaStore.Shared.Enums;
using AdaStore.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;

    options.Lockout.AllowedForNewUsers = false;
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var scope = app.Services.CreateScope();

var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

if (!await roleManager.RoleExistsAsync(Conts.Admin))
    await roleManager.CreateAsync(new IdentityRole<int>(Conts.Admin));

if (!await roleManager.RoleExistsAsync(Conts.Buyer))
    await roleManager.CreateAsync(new IdentityRole<int>(Conts.Buyer));

if (await userManager.FindByEmailAsync("admin@adastore.co") == null)
{
    var user = new User
    {
        UserName = "admin@adastore.co",
        Email = "admin@adastore.co",
        Name = "Admin",
        Profile = Profiles.Admin,
    };

    var result = await userManager.CreateAsync(user, "1234567");

    if (result.Succeeded)
        await userManager.AddToRoleAsync(user, Conts.Admin);
}

app.Run();
