using Microsoft.Extensions.DependencyInjection;
using TimeTracking.AppCore;
using TimeTracking.AppCore.Addresses;
using TimeTracking.UI.Helpers;

namespace TimeTracking;

public static class DbSeeder
{
    public static void SeedEmployees(IServiceProvider services)
    {
        var addresses = services.GetRequiredService<IAddressQueryService>();
        var employees = services.GetRequiredService<IEmployeeCrudService>();
        var number = 1;
        var img = ImageHelper.ImageToByte( ImageHelper.LoadDefault());
        foreach (var a in addresses.GetAddressesAsync().GetAwaiter().GetResult())
        {
            employees.ExecuteAsync(new Shared.Commands.NewEmployeeCommand
            {
                New = new Shared.DTOs.EmployeeData { AddressId= a.Id, BirthDate = DateTime.Now - 20 * TimeSpan.FromDays(365) 
                , FirstName = $"Ivan{number}", LastName = $"Ivanov{number}", PersonnelNumber = number++, Photo = img}
            });
        }
    }

    public static void SeedAddresses(IServiceProvider services)
    {
        var addresses = services.GetRequiredService<IAddressCrudService>();
        addresses.ExecuteAsync(new Shared.Commands.NewAddressCommand
        {
            New = new Shared.DTOs.AddressData { City = "Moskow", Country = "Rus", Street = "Lenin str.", House = "2/3", Appartment = 1}
        });
        addresses.ExecuteAsync(new Shared.Commands.NewAddressCommand
        {
            New = new Shared.DTOs.AddressData { City = "Tver", Country = "Rus", Street = "Lenin str.", House = "2/3", Appartment = 11 }
        });
        addresses.ExecuteAsync(new Shared.Commands.NewAddressCommand
        {
            New = new Shared.DTOs.AddressData { City = "Pskov", Country = "Rus", Street = "Lenin str.", House = "2/3", Appartment = 12 }
        });
        addresses.ExecuteAsync(new Shared.Commands.NewAddressCommand
        {
            New = new Shared.DTOs.AddressData { City = "Moskow", Country = "Rus", Street = "Lenin str.", House = "2/3", Appartment = 23 }
        });
        addresses.ExecuteAsync(new Shared.Commands.NewAddressCommand
        {
            New = new Shared.DTOs.AddressData { City = "Moskow", Country = "Rus", Street = "Lenin str.", House = "2/3", Appartment = 42 }
        });
    }

    public static void SeedPositions(IServiceProvider services)
    {
        var positions = services.GetRequiredService<IPositionsCrudService>();
        positions.ExecuteAsync( new Shared.Commands.NewPositionCommand
        {
            New = new Shared.DTOs.PositionData { Title = "First Position", Description = "Something"}
        });
        positions.ExecuteAsync(new Shared.Commands.NewPositionCommand
        {
            New = new Shared.DTOs.PositionData { Title = "Second Position", Description = "Something" }
        });
        positions.ExecuteAsync(new Shared.Commands.NewPositionCommand
        {
            New = new Shared.DTOs.PositionData { Title = "Third Position", Description = "Something" }
        });
        positions.ExecuteAsync(new Shared.Commands.NewPositionCommand
        {
            New = new Shared.DTOs.PositionData { Title = "Fourth Position", Description = "Something" }
        });
        positions.ExecuteAsync(new Shared.Commands.NewPositionCommand
        {
            New = new Shared.DTOs.PositionData { Title = "Fifth Position", Description = "Something" }
        });
    }
    public static void SeedDepartments(IServiceProvider services)
    {
        var deps = services.GetRequiredService<IDeparmentsCrudService>();
        deps.ExecuteAsync(
            new Shared.Commands.NewDepartmentCommand
            {
                New = new Shared.DTOs.DepartmentData { Name = "First Department", Description = "Description First Department" }
            });
        deps.ExecuteAsync(
            new Shared.Commands.NewDepartmentCommand
            {
                New = new Shared.DTOs.DepartmentData { Name = "Second Department", Description = "Description Second Department" }
            });
        deps.ExecuteAsync(
            new Shared.Commands.NewDepartmentCommand
            {
                New = new Shared.DTOs.DepartmentData { Name = "Third Department", Description = "Description Third Department" }
            });

    }
}
