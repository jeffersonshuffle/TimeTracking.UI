namespace TimeTracking.Shared.DTOs
{
    public class AddressData
    {
        public string Country { get; set; } = "Rus";
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int Appartment { get; set; }        
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
    }
}
