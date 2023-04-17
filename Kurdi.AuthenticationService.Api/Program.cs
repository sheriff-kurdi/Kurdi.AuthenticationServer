

using Kurdi.AuthenticationService.Services;
using Kurdi.AuthenticationService.Api.Routes;
using Kurdi.AuthenticationService.Infrastructure.Data;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddSingleton<RegisterationService>();


builder.Services.AddLocalization();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(cors => { cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });


app.UseAuthenticationPoints();


app.Run();