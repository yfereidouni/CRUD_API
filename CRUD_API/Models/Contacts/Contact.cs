using CRUD_API.Models.Common;
using CRUD_API.Models.Locations;
using CRUD_API.Models.Phones;

namespace CRUD_API.Models.Contacts;

public class Contact : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }

    //Relations
    public List<Phone> Phones { get; set; }

    //Location
    public int LocationId { get; set; }
    public Location Location { get; set; }
}