using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.Repositories;

namespace ContactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await _unitOfWork.Contacts.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            await _unitOfWork.Contacts.AddAsync(contact);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            await _unitOfWork.Contacts.UpdateAsync(contact);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _unitOfWork.Contacts.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
