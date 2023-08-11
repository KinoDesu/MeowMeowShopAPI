using MeowMeowShopAPI.repositories;
using MeowMeowShopAPI.repositories.interfaces;
using MeowMeowShopAPI.services;
using MeowMeowShopAPI.services.interfaces;

WebApplicationOptions webApplicationOptions = new()
{
    WebRootPath = "index.html", //Setting the WebRootPath as MyWebRoot
    Args = args, //Setting the Command Line Arguments in Args
    EnvironmentName = "Development", //Changing to Production
};

var builder = WebApplication.CreateBuilder(webApplicationOptions);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
