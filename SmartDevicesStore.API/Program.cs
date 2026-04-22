using Microsoft.EntityFrameworkCore;
using SmartDevicesStore.API.Data;
using SmartDevicesStore.API.Models;

var builder = WebApplication.CreateBuilder(args);


// ≈÷«›… Œœ„… CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNetlify",
        policy =>
        {
            policy.WithOrigins("https://69e80af40eccf700084c3330--poetic-sunflower-19983c.netlify.app") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// 2.  ⁄—Ì› ﬁ«⁄œ… «·»Ì«‰« 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowNetlify");

app.UseAuthorization();

app.MapControllers();



//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    // „”Ã «·»Ì«‰« 
//    context.Database.ExecuteSqlRaw("DELETE FROM Products");
//    context.Database.ExecuteSqlRaw("DELETE FROM Categories");
//    // «—Ã«⁄ «· —ﬁÌ„ „‰ «·»œ«Ì…
//    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Products', RESEED, 0)");
//    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Categories', RESEED, 0)");
//    // ›Õ’ ≈–« ﬂ«‰  «·√’‰«› ›«—€…
//    if (!context.Categories.Any())
//    {
//        var categories = new List<Category>
//        {
//            new Category {
//                Name = "·«» Ê»«  –ﬂÌ…",
//                Products = new List<Product> {
//                    new Product { Name = "MacBook Air M3", Description = "ÃÂ«“ Œ›Ì› Ê√‰Ìﬁ »√ÕœÀ „⁄«·Ã«  √»·", Price = 1100, StockQuantity = 10, ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?q=80&w=500" },
//                    new Product { Name = "Dell XPS 13 Plus", Description = " ’„Ì„ „” ﬁ»·Ì Ê√œ«¡ ›«∆ﬁ ··√⁄„«·", Price = 1300, StockQuantity = 8, ImageUrl = "https://images.unsplash.com/photo-1588872657578-7efd1f1555ed?q=80&w=500" },
//                    new Product { Name = "ASUS ROG Zephyrus G14", Description = "ÊÕ‘ «·ÃÌ„‰Ã «·’€Ì— »ﬂ—  ‘«‘… RTX 40-series", Price = 1599, StockQuantity = 4, ImageUrl = "https://images.unsplash.com/photo-1593642632823-8f785ba67e45?q=80&w=500" },
//                    new Product { Name = "Dell XPS 13 Plus", Description = "‘«‘… InfinityEdge Ê ’„Ì„ „” ﬁ»·Ì ·« Ìﬁ«Ê„", Price = 1399, StockQuantity = 6, ImageUrl = "https://images.unsplash.com/photo-1588872657578-7efd1f1555ed?q=80&w=500" }

//                }
//            },
//            new Category {
//                Name = "«·ÂÊ« › «·–ﬂÌ…",
//                Products = new List<Product> {
//                    new Product { Name = "Samsung S24 Ultra", Description = " Ã—»… –ﬂ«¡ «’ÿ‰«⁄Ì „ ﬂ«„·… „⁄ ﬁ·„ S Pen", Price = 1100, StockQuantity = 20, ImageUrl = "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?q=80&w=500" }
//                }
//            },
//            new Category {
//                Name = "”„«⁄«  Ê„·Õﬁ«  –ﬂÌ…",
//                Products = new List<Product> {
//                    new Product { Name = "Bose QC Ultra", Description = "«·—«Õ… «·„À«·Ì… ·’Ê  €«„— Ì√Œ–ﬂ ·⁄«·„ ¬Œ—", Price = 429, StockQuantity = 10, ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?q=80&w=500" },
//                    new Product { Name = "Sennheiser Momentum 4", Description = "œﬁ… ’Ê  √·„«‰Ì… Ê»ÿ«—Ì…  œÊ„ ·‘Â— ﬂ«„·", Price = 299, StockQuantity = 8, ImageUrl = "https://images.unsplash.com/photo-1484704849700-f032a568e944?q=80&w=500" },
//                    new Product { Name = "iPad Pro M2", Description = "ÃÂ«“ ·ÊÕÌ »ﬁÊ… «·ﬂ„»ÌÊ — ·„Õ»Ì «·—”„ Ê«· ’„Ì„", Price = 1099, StockQuantity = 9, ImageUrl = "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?q=80&w=500" }
//                }
//            }
//        };

//        context.Categories.AddRange(categories);
//        context.SaveChanges();
//    }
//}


app.Run();