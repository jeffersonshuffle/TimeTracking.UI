using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Helpers;

namespace TimeTracking.UI.Models;

public class AddressEditModel: ObservableObject
{
    private readonly AddressData address;
    public AddressEditModel(AddressData address) => this.address = address;

    public string City
    {
        get => address.City;
        set => SetProperty(address.City, value, address, (u, n) => u.City = n);
    }
    public string Street
    {
        get => address.Street;
        set => SetProperty(address.Street, value, address, (u, n) => u.Street = n);
    }
    public string House
    {
        get => address.House;
        set => SetProperty(address.House, value, address, (u, n) => u.House = n);
    }
    public int Appartment
    {
        get => address.Appartment;
        set => SetProperty(address.Appartment, value, address, (u, n) => u.Appartment = n);
    }
}