namespace CRUD_API.VMs
{
    public class NewContactVm
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        //Relationships
        public List<NewPhoneVm>? Phones { get; set; }

        public NewLocationVm? Location { get; set; }
    }
}
