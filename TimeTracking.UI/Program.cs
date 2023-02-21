#define SeedDb
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeTracking.UI.Helpers;
using TimeTracking.UI.ViewModels;
using TimeTracking.UI.Views;

namespace TimeTracking.UI;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        host.Start();

        using var scope = host.Services.CreateScope();
#if SeedDb
        //DbSeeder.SeedEmployees(scope.ServiceProvider);
        //DbSeeder.SeedAddresses(scope.ServiceProvider);
        //DbSeeder.SeedDepartments(scope.ServiceProvider);
        //DbSeeder.SeedPositions(scope.ServiceProvider);
#endif
        ApplicationConfiguration.Initialize();
        Application.Run(new EditEmployeeForm());
        //Application.Run(new TimeTrackingForm(scope.ServiceProvider.GetRequiredService<IDepartmentsViewModel>()));
        host.StopAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
       .ConfigureAppConfiguration((context, configurationBuilder) =>
       {
           configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
           configurationBuilder.AddJsonFile("appsettings.json", optional: false);
       })
       .ConfigureServices((hostContext, services) =>
       {
           services.AddDAL(hostContext.Configuration);           
           services.UseAppCore();
           services.AddViewModels();
       });
}