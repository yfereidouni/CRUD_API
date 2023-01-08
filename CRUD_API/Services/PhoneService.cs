using CRUD_API.Repositories.Phones;

namespace CRUD_API.Services;

public class PhoneService : IPhoneService
{
    private readonly IPhoneRepository _phoneRepository;

    public PhoneService(IPhoneRepository phoneRepository)
    {
        _phoneRepository = phoneRepository;
    }

}