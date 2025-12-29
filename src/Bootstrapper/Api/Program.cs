var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCatalogModule(builder.Configuration);
builder.Services.AddBasketModule(builder.Configuration);
builder.Services.AddOrderingModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline 
app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.Run();
