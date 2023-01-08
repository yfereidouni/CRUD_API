using CRUD_API.Models.Contacts;
using CRUD_API.Services;
using CRUD_API.VMs;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        public async Task<ActionResult<Contact>> GetAllContacts()
        {
            var contact = await _contactService.GetAllContactsWithAllDependenciesAsync();
            return Ok(contact);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var contact = await _contactService.GetContactByIdWithAllDependenciesAsync(id);
            return Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> CreateContact([FromBody] PostContactRequestVm data)
        {
            var result = await _contactService.CreateContactWithDependenciesAsync(data);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> UpdateContact([FromBody] PutContactRequestVm data)
        {
            var result = await _contactService.UpdateContactWithDependenciesAsync(data);
            return Ok(result);
        }
    }
}
