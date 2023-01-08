namespace CRUD_API.VMs
{
    public class ContactResponseVm
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        //Relationships
        public List<NewPhoneVm>? Phones { get; set; }

        public NewLocationVm? Location { get; set; }
    }
}
