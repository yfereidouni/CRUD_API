namespace CRUD_API.VMs
{
    public class PutPhoneVm
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }

        public int PhoneTypeId { get; set; }
    }
}
