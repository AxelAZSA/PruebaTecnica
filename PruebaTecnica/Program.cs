using PruebaTecnica.Service.IRepository;
using PruebaTecnica.Service.Repositorios;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("MyDb");

builder.Services.AddDbContext<DbIContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ITenisRepository, TenisRepository>();
builder.Services.AddScoped<IZapatosRepository, ZapatosRepository>();
builder.Services.AddScoped<IBotasRepository, BotasRepository>();

builder.Services.AddCors(options => options.AddPolicy(name: "prueba", policy =>
{
    policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
}));

var app = builder.Build();



//app.Services.CreateScope(ITenisRepository,TenisRepository);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
