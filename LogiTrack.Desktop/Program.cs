using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LogiTrack.Core.Data;
using LogiTrack.Core.Services;
using LogiTrack.Desktop.Forms;
using LogiTrack.Desktop.Services;
using LogiTrack.Core.Services.Interfaces;

namespace LogiTrack.Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();

            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EstoqueDbContext>();
                context.Database.EnsureCreated();
            }

            var mainForm = host.Services.GetRequiredService<FormPrincipal>();
            Application.Run(mainForm);
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<EstoqueDbContext>(options =>
                        options.UseMySql(DatabaseConfig.GetConnectionString(),
                            ServerVersion.Parse(DatabaseConfig.GetMySqlVersion())));

                    services.AddScoped<IProdutoService, ProdutoService>();
                    services.AddScoped<ICategoriaService, CategoriaService>();

                    services.AddSingleton<FormService>();

                    services.AddTransient<FormPrincipal>();
                    services.AddTransient<FormProdutos>();
                    services.AddTransient<FormCategorias>();
                    services.AddTransient<FormProdutoDetalhes>();
                    services.AddTransient<FormCategoriasDetalhes>();
                });
    }
}