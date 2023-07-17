//using Fluent.Infrastructure.FluentModel;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shoplify.Data;
using Shoplify.Ochestration.ProductsOchestration.ProductsImplementation;
using Shoplify.Ochestration.ProductsOchestration.ProductsInterface;
using Shoplify.Ochestration.UsersOchestration.Implementation;
using Shoplify.Ochestration.UsersOchestration.Interface;
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication().AddSteam();
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//})
//            .AddGoogle(options =>
//            {
//                options.ClientId = "[MyGoogleClientId]";
//                options.ClientSecret = "[MyGoogleSecretKey]";
            //});
builder.Services
        .AddAuthentication(o =>
        {
            // This forces challenge results to be handled by Google OpenID Handler, so there's no
            // need to add an AccountController that emits challenges for Login.
            o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            // This forces forbid results to be handled by Google OpenID Handler, which checks if
            // extra scopes are required and does automatic incremental auth.
            o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            // Default scheme that will handle everything else.
            // Once a user is authenticated, the OAuth2 token info is stored in cookies.
            o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddGoogleOpenIdConnect(options =>
        {
            options.ClientId = "threaded-ab54f";
            options.ClientSecret = "909346088826-tumf11v8dhjl84i05u0vtf3577jk7trg.apps.googleusercontent.com";
        });


//CustomServices
builder.Services.AddSingleton<IProductsDataService, ProductsDataService> ();
builder.Services.AddSingleton<IProductsOchestration, ProductsOchestration>();
builder.Services.AddSingleton<IUserDataService, UserDataService>();
builder.Services.AddSingleton<IUserOchestration, UsersOchestration>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
