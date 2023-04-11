
using Microsoft.AspNetCore.Mvc;

namespace Kurdi.AuthenticationService.Api.Routes
{
    public static class AuthenticationPoints
    {
        public static void UseAuthenticationPoints(this WebApplication app)
        {
            RouteGroupBuilder stockGroup = app.MapGroup("/api/stock").WithTags("Stock");



            stockGroup.MapGet("/{sku}", async (string sku, [FromServices] IProductsRepo stockItemsRepository) =>
            {
                Product? stockItem = await stockItemsRepository.Find(stock => stock.SKU == sku).Include(stock => stock.ProductDetails).FirstOrDefaultAsync();
                if (stockItem == null) return Results.NotFound();
                return Results.Ok(new Responses.BaseResponse<Product>(stockItem));
            });

            stockGroup.MapPost("/", async ([FromBody] Product stockItem, [FromServices] IProductsRepo stockItemsRepository) =>
            {
                await stockItemsRepository.Create(stockItem);
                return Results.Created(stockItem.SKU, stockItem);
            });


        }


    }
}