using CRUD_API.Models.Phones;

namespace CRUD_API.VMs
{
    public class ContactRequestVm
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public List<NewPhoneVm>? Phones { get; set; }

        public NewLocationVm? Location { get; set; }
    }
}
