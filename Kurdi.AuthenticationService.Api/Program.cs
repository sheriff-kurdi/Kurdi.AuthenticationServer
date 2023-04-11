
using Kurdi.AuthenticationService.Api.Middleware;
using Kurdi.AuthenticationService.Api.Routes;
using Kurdi.AuthenticationService.Core.Contracts;
using Kurdi.AuthenticationService.Infrastructure.Data;
using Kurdi.AuthenticationService.Infrastructure.DataAccess;
using Kurdi.AuthenticationService.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddLocalization();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(cors => { cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

app.UseLanguageMiddleware();

app.UseStockEndPoints();
app.UseCategoriesEndPoints();
app.UseSalesOrdersEndPoints();

app.MapGet("/", () =>
{    return Translator.Translate("VALIDATION:NOT_VALID_LANGUAGE");
});
app.Run();