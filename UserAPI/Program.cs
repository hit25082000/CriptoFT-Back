using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;
using UserAPI.Data;
using UserAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
//Added manualy
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("userconnection"));

});

builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
    opt => opt.SignIn.RequireConfirmedEmail = true)
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<ArticleService, ArticleService>();
builder.Services.AddScoped<VideoService, VideoService>();
builder.Services.AddScoped<RegisterService, RegisterService>();
builder.Services.AddScoped<EmailService, EmailService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LoginService, LoginService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddEntityFrameworkMySQL();
        new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
            .TryAddCoreServices();
    }
}