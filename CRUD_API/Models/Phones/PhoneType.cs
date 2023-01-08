using CRUD_API.Models.Common;

namespace CRUD_API.Models.Phones;

public class PhoneType : BaseEntity
{
    public string? Name { get; set; }

    //Relations
    //public List<Phone> Phones { get; set; }
}