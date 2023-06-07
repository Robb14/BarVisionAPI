using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configurar servicios necesarios para la aplicación
        // Ejemplo: services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Configurar middleware para el manejo de errores en producción
            // Ejemplo: app.UseExceptionHandler("/Home/Error");
        }

        // Configurar middleware y enrutamiento
        // Ejemplo: app.UseRouting();
        //          app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
