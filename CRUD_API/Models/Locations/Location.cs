using CRUD_API.Models.Common;
using CRUD_API.Models.Contacts;

namespace CRUD_API.Models.Locations;

public class Location : BaseEntity
{
    public string? StreetName { get; set; }
    public string? StreetNumber { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    //Relationships
    //public List<Contact> Contacts { get; set; }
}
