namespace TimeTracking.Shared.DTOs
{
    public class AddressListItem
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int Appartment { get; set; }

        public override string ToString()
        {
            return $"city {City} str. {Street} {House}, app. {Appartment}";
        }
    }
}
