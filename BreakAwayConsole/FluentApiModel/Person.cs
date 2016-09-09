using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiModel
{
    public class Person
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] RowVersion { get; set; }
        public Address Address { get; set; }

        public PersonPhoto Photo { get; set; }

        public List<Lodging> PrimaryContactFor { get; set; }
        public List<Lodging> SecondaryContactFor { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
