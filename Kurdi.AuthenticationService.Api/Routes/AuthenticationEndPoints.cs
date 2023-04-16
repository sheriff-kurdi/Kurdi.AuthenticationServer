

using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;

namespace Kurdi.AuthenticationService.Api.Routes
{

    public static class AuthenticationPoints
    {
        private static Logger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

        public static void UseAuthenticationPoints(this WebApplication app)
        {


            RouteGroupBuilder stockGroup = app.MapGroup("/api/stock").WithTags("Stock");
            RouteGroupBuilder simpleGroup = app.MapGroup("/").WithTags("Simple");

            simpleGroup.MapGet("/log", LogAction);

        }
        public static IResult LogAction()
        {
            logger.Info("from minimal/22-8");
            logger.Error("waaarn from minimal/22-8");
            return Results.Ok("hii");
        }


    }
}


// stockGroup.MapGet("/{sku}", async (string sku, [FromServices] IProductsRepo stockItemsRepository) =>
// {
//     Product? stockItem = await stockItemsRepository.Find(stock => stock.SKU == sku).Include(stock => stock.ProductDetails).FirstOrDefaultAsync();
//     if (stockItem == null) return Results.NotFound();
//     return Results.Ok(new Responses.BaseResponse<Product>(stockItem));
// });

// stockGroup.MapPost("/", async ([FromBody] Product stockItem, [FromServices] IProductsRepo stockItemsRepository) =>
// {
//     await stockItemsRepository.Create(stockItem);
//     return Results.Created(stockItem.SKU, stockItem);
// });