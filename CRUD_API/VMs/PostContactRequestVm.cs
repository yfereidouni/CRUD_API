using CRUD_API.Models.Phones;

namespace CRUD_API.VMs
{
    public class PostContactRequestVm
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public List<PostPhoneVm>? Phones { get; set; }

        public NewLocationVm? Location { get; set; }
    }
}
