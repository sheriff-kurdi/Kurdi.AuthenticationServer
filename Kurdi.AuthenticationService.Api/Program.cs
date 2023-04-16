

using Kurdi.AuthenticationService.Api.Routes;
using Kurdi.AuthenticationService.Infrastructure.Data;
using Kurdi.AuthenticationService.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>();
// builder.Services.AddSingleton<TokenGenerator>();
// builder.Services.AddSingleton<AuthenticationService>();
builder.Services.AddSingleton<SimpleService>();


builder.Services.AddLocalization();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(cors => { cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });


app.UseAuthenticationPoints();


app.Run();