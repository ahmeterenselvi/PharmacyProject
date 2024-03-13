using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Profile
{
    public record ResultUserDto
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string TurkishIdentityNumber { get; init; }
        public string City { get; init; }
        public string District { get; init; }
        public string ImageUrl { get; init; }
    }
}
