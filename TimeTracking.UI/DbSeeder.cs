using Microsoft.Extensions.DependencyInjection;
using TimeTracking.AppCore;
using TimeTracking.AppCore.Addresses;
using TimeTracking.UI.Helpers;

namespace TimeTracking;

public static class DbSeeder
{
    public static void Seed(IServiceProvider services)
    {
        SeedPositions(services);
        SeedDepartments(services);
        SeedEmployeesWithAddress(services);
        SeedAddresses(services);
        SeedEmployees(services);
        SeedAssignments(services);
    }

    public static void SeedAssignments(IServiceProvider services)
    {
        var employees = services.GetRequiredService<IEmployeeQueryService>();
        var departments = services.GetRequiredService<IDeparmentsQueryService>();
        var positions = services.GetRequiredService<IPositionsQueryService>();
        var asignment = services.GetRequiredService<IAssignmentCrudService>();

        var depsArr = departments.GetDepartmentsAsync().GetAwaiter().GetResult();
        var posArr = positions.GetPositionsAsync().GetAwaiter().GetResult();
        var empsArr = employees.HandleAsync(new Shared.Queries.GetEmployeePersonalInfoListQuery()).GetAwaiter().GetResult();
        var rnd = new Random();

        foreach (var e in empsArr)
        {
            asignment.ExecuteAsync(new Shared.Commands.NewAssignmentCommand
            {
                New = new Shared.DTOs.AssignmentData
                {
                    DateCreated= DateTime.Now,
                    DateModified= DateTime.Now,
                    DepartmentID = depsArr[rnd.Next(0,depsArr.Length)].DepartmentId,
                    PositionID = posArr[rnd.Next(0, posArr.Length)].Id,
                    EmployeeID = e.ID
                }
            });
        }
    }


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

    public static void SeedEmployeesWithAddress(IServiceProvider services)
    {
        var employees = services.GetRequiredService<IEmployeeCrudService>();
        var img = ImageHelper.ImageToByte(ImageHelper.LoadDefault());
        for (var number = 1; number < 5; number++)
        {
            employees.ExecuteAsync(new Shared.Commands.NewEmployeeCommand
            {
                New = new Shared.DTOs.EmployeeData
                {
                    BirthDate = DateTime.Now - 20 * TimeSpan.FromDays(365),
                    FirstName = $"Petr{number}",
                    LastName = $"Petrov{number}",
                    PersonnelNumber = 100 + number,
                    Photo = img,
                },
                Address = new Shared.DTOs.AddressData { Appartment = 12, City = "Leningrad", Country = "Rus", House = "42/1", Street = "Lenin"}
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
