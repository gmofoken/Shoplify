//using Fluent.Infrastructure.FluentModel;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shoplify.Data;
using Shoplify.Ochestration.CartOchestration.Implementation;
using Shoplify.Ochestration.CartOchestration.Interface;
using Shoplify.Ochestration.ProductsOchestration.ProductsImplementation;
using Shoplify.Ochestration.ProductsOchestration.ProductsInterface;
using Shoplify.Ochestration.UsersOchestration.Implementation;
using Shoplify.Ochestration.UsersOchestration.Interface;
using Shoplify.Services.DataServices.CartDataServices.Implementation;
using Shoplify.Services.DataServices.CartDataServices.Interface;
using Shoplify.Services.DataServices.ProductsDataServices.ProductsDataServicesImplementation;
using Shoplify.Services.DataServices.ProductsDataServices.ProductsDataServicesInterface;
using Shoplify.Services.DataServices.UsersDataServices.Implementation;
using Shoplify.Services.DataServices.UsersDataServices.Interface;

var builder = WebApplication.CreateBuilder(args);
//using Fluent.Infrastructure.FluentModel;
builder.Services.AddDbContext<ShoplifyContext>(options =>
//using Fluent.Infrastructure.FluentModel;
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
        maxRetryCount: 10,
        maxRetryDelay: TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null);
    }));

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication().AddSteam();

builder.Services
        .AddAuthentication(o =>
        {
            o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddGoogleOpenIdConnect(options =>
        {
            options.ClientId = "870830986977-3d6vgjijli8gcnpugv1cr8u706btroa7.apps.googleusercontent.com";
            options.ClientSecret = "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";
        });


//CustomServices
builder.Services.AddSingleton<IProductsDataService, ProductsDataService> ();
builder.Services.AddSingleton<IProductsOchestration, ProductsOchestration>();
builder.Services.AddSingleton<IUserDataService, UserDataService>();
builder.Services.AddSingleton<IUserOchestration, UsersOchestration>();
builder.Services.AddSingleton<ICartDataService, CartDataService>();
builder.Services.AddSingleton<ICartOchestrationcs, CartOchestration>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseAuthorization();
app.UseAuthentication();

app.Run();
