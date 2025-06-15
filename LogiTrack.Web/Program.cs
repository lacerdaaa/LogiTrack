using Microsoft.EntityFrameworkCore;
using LogiTrack.Core.Data;
using LogiTrack.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EstoqueDbContext>(options =>
    options.UseMySql(DatabaseConfig.GetConnectionString(),
        ServerVersion.Parse(DatabaseConfig.GetMySqlVersion())));

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Garantir que o banco existe
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EstoqueDbContext>();
    context.Database.EnsureCreated();
}

app.Run();