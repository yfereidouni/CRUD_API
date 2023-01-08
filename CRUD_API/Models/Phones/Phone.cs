using CRUD_API.Models.Common;
using CRUD_API.Models.Contacts;

namespace CRUD_API.Models.Phones;

public class Phone : BaseEntity
{
    //ExtraFields in junction table
    public string? PhoneNumber { get; set; }

    public int PhoneTypeId { get; set; }
    public PhoneType PhoneType { get; set; }
    public int ContactId { get; set; }
    public Contact Contact { get; set; }
}