using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Models.AbstractionViewModel;
using Contacts.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        protected readonly ContactsDbContext dbContext;

        public ContactsController(ContactsDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var entity = new AllContactsAbstraction()
            {
                Contacts = await dbContext.Contacts
                .AsNoTracking()
                .Select(e => new ContactsInfoViewModel(
                    e.Id,
                    e.FirstName,
                    e.LastName,
                    e.Email,
                    e.PhoneNumber,
                    e.Address,
                    e.Website
                    ))
                .ToListAsync()
            };
    
            return View(entity);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var newEntity = new ContactsFormViewModel()
            {

            };

            return View(newEntity);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ContactsFormViewModel addedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addedModel);
            }

            var entity = new Contact() 
            { 
                FirstName = addedModel.FirstName,
                LastName = addedModel.LastName,
                Email = addedModel.Email,
                PhoneNumber = addedModel.PhoneNumber,
                Address = addedModel.Address,
                Website = addedModel.Website
            };

            await dbContext.Contacts.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int ContactId)
        {
            var currModel = await dbContext.Contacts.FindAsync(ContactId);

            if (currModel == null)
            {
                return BadRequest();
            }

            var entity = new ContactsFormViewModel()
            {
                FirstName = currModel.FirstName,
                LastName = currModel.LastName,
                Email = currModel.Email,
                PhoneNumber = currModel.PhoneNumber,
                Address = currModel.Address,
                Website = currModel.Website
            };

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int ContactId, ContactsFormViewModel editedModel)
        {
            var currModel = await dbContext.Contacts.FindAsync(ContactId);

            if (currModel == null)
            {
                return BadRequest();
            }

            currModel.FirstName = editedModel.FirstName;
            currModel.LastName = editedModel.LastName;  
            currModel.Email = editedModel.Email;
            currModel.PhoneNumber = editedModel.PhoneNumber;
            currModel.Address = editedModel.Address;
            currModel.Website = editedModel.Website;

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Team()
        {
            var currUserId = GetUsernameId();

            var entity = new AllContactsAbstraction()
            {
                Contacts = await dbContext.ApplicationUserContacts
                .AsNoTracking()
                .Where(au => au.ApplicationUserId == currUserId)
                .Select(e => new ContactsInfoViewModel(
                    e.Contact.Id,
                    e.Contact.FirstName,
                    e.Contact.LastName,
                    e.Contact.Email,
                    e.Contact.PhoneNumber,
                    e.Contact.Address,
                    e.Contact.Website
                    ))
                .ToListAsync()
            };  

            return View(entity);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToTeam(int ContactId)
        {
            var currContact = await dbContext.Contacts.FindAsync(ContactId);

            if(currContact == null)
            {
                return BadRequest();
            }

            var currUserId = GetUsernameId();

            var entity = new ApplicationUserContact()
            {
                ApplicationUserId = currUserId,
                ContactId = currContact.Id
            };

            if (dbContext.ApplicationUserContacts.Contains(entity))
            {
               return RedirectToAction(nameof(All));
            }

            await dbContext.ApplicationUserContacts.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromTeam(int ContactId)
        {
            var currContact = dbContext.Contacts.Find(ContactId);
            var currUsernameId = GetUsernameId();

            if (currContact == null)
            {
                return BadRequest();
            }

            if (currUsernameId == "")
            {
                return BadRequest();
            }

            var entity = dbContext.ApplicationUserContacts.FirstOrDefault(u => u.ContactId == currContact.Id && u.ApplicationUserId == currUsernameId);

            if (entity == null)
            {
                return BadRequest();
            }

            dbContext.ApplicationUserContacts.Remove(entity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Team));
        }

        public string GetUsernameId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

    }
}

