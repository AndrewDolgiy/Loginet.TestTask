using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CompanyDto Company { get; set; }

        public User MapToDb()
        {
            return new User()
            {
                Id = Id,
                Name = Name,
                Email = Email,
                UserName = UserName,
                Phone = Phone,
                Website = Website,
                Address = Address.MapToDb(),
                Company = Company.MapToDb()
            };
        }
    }
}
