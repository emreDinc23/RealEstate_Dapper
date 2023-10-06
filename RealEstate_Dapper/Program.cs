using RealEstate_Dapper.Models.DapperContext;
using RealEstate_Dapper.Repositories.CategoryRepositories;
using RealEstate_Dapper.Repositories.OurServicesRepository;
using RealEstate_Dapper.Repositories.PopulerLocationRepositories;
using RealEstate_Dapper.Repositories.ProductRepositories;
using RealEstate_Dapper.Repositories.WhoWeAreReporitories;
using RealEstate_Dapper.Repositories.WhoWeAreServicesRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
builder.Services.AddTransient<IWhoWeAreServicesRepository, WhoWeAreServicesRepository>();
builder.Services.AddTransient<IOurServicesRepository, OurServicesRepository>();
builder.Services.AddTransient<IPopulerLocationRepository, PopulerLocationRepostiyory>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
