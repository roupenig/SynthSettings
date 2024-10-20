using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SynthSettings.Repositories;

namespace SynthSettings.Tests.Integration;
public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<SettingContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);

            }
            services.AddDbContext<SettingContext>(options =>
            {
                options.UseInMemoryDatabase("InMemorySettingTest");
            });
            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<SettingContext>())
            {
                appContext.Database.EnsureCreated();
            }
        });
    }
}
