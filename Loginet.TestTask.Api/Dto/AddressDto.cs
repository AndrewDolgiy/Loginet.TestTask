using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Dto
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoDto Geo { get; set; }

        public Address MapToDb()
        {
            return new Address()
            {
                Street = Street,
                Suite = Suite,
                City = City,
                Zipcode = Zipcode,
                Geo = Geo.MapToDb()
            };
        }
    }
}
