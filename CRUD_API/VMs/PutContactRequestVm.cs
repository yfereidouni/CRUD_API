using CRUD_API.Models.Phones;

namespace CRUD_API.VMs
{
    public class PutContactRequestVm
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public List<PutPhoneVm>? Phones { get; set; }

        public NewLocationVm? Location { get; set; }
    }
}
