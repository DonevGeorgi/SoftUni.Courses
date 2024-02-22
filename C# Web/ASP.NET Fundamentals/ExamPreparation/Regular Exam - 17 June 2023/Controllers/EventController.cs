using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Homies.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Security.Claims;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        protected readonly HomiesDbContext dbContext;

        public EventController(HomiesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var entity = await dbContext
                .Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel(
                    e.Id,
                    e.Name,
                    e.Type.Name,
                    e.Organiser.UserName,
                    e.Start
                    ))
                .ToListAsync();

            return View(entity);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var entity = new EventFormViewModel()
            {
                Types = await GetTypes()
            };

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            DateTime startDate;

            bool isStartDateValid = DateTime.TryParseExact(model.Start, DataConstants.DateValidationString,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);

            if (!isStartDateValid)
            {
                ModelState
                   .AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateValidationString}");
            }

            DateTime endDate;


            bool isEndDateValid = DateTime.TryParseExact(model.End, DataConstants.DateValidationString,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (!isEndDateValid)
            {
                ModelState
                   .AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateValidationString}");
            }

            if (!ModelState.IsValid)
            {
                var redirect = new EventFormViewModel()
                {
                    Types = await GetTypes()
                };

                return View(redirect);
            }

            var entity = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                Start = startDate,
                End = endDate,
                OrganiserId = GetUsernameId(),
                TypeId = model.TypeId
            };

            await dbContext.Events.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var modelToEdit = await dbContext.Events.FindAsync(id);

            if (modelToEdit == null)
            {
                return BadRequest();
            }

            var entity = new EventFormViewModel()
            {
                Name = modelToEdit.Name,
                Description = modelToEdit.Description,
                Start = modelToEdit.Start.ToString(DataConstants.DateValidationString),
                End = modelToEdit.End.ToString(DataConstants.DateValidationString),
                TypeId = modelToEdit.TypeId
            };

            entity.Types = await GetTypes();

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormViewModel model)
        {
            var modelToEdit = await dbContext.Events.FindAsync(id);

            if (modelToEdit == null)
            {
                return BadRequest();
            }

            var currUsername = GetUsernameId();
            
            if (currUsername != modelToEdit.OrganiserId)
            {
                return Unauthorized();
            }

            DateTime startDate;
            string inputStartDate = DateTime.ParseExact(
                model.Start, DataConstants.inputValidationDateString,
                CultureInfo.InvariantCulture).ToString(DataConstants.DateValidationString);

            if (!DateTime.TryParseExact(inputStartDate, DataConstants.DateValidationString,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                ModelState
                   .AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateValidationString}");
            }

            DateTime endDate;
            string inputEndDate = DateTime.ParseExact(
                model.End, DataConstants.inputValidationDateString,
                CultureInfo.InvariantCulture).ToString(DataConstants.DateValidationString);

            if (!DateTime.TryParseExact(inputEndDate, DataConstants.DateValidationString,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                ModelState
                   .AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateValidationString}");
            }

            modelToEdit.Name = model.Name;
            modelToEdit.Description = model.Description;
            modelToEdit.Start = startDate;
            modelToEdit.End = endDate;
            modelToEdit.TypeId = model.TypeId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var entity = await dbContext
                .Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new EventDetailViewModel
                {
                    Id = e.Id,
                    CreatedOn = e.CreatedOn.ToString(DataConstants.DateValidationString),
                    Description = e.Description,
                    End = e.End.ToString(DataConstants.DateValidationString),
                    Name = e.Name,
                    Organiser = e.Organiser.UserName,
                    Start = e.Start.ToString(DataConstants.DateValidationString),
                })
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return BadRequest();
            }

            return View(entity);
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var currUsername = GetUsernameId();

            if (currUsername == null)
            {
                return BadRequest();
            }

            var entity = await dbContext
                .EventsParticipants
                .AsNoTracking()
                .Where(ep => ep.HelperId == currUsername)
                .Select(ep => new EventInfoViewModel(
                    ep.Event.Id,
                    ep.Event.Name,
                    ep.Event.Type.Name,
                    ep.Event.OrganiserId,
                    ep.Event.Start
                    ))
                .ToListAsync();

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var currUsername = GetUsernameId();
            var currId = id;

            if (currUsername == null)
            {
                return BadRequest();
            }

            var eventToJoin = new EventParticipants()
            {
                HelperId = currUsername,
                EventId = currId
            };

            if (await dbContext.EventsParticipants.ContainsAsync(eventToJoin))
            {
                return RedirectToAction(nameof(All));
            }

            await dbContext.EventsParticipants.AddAsync(eventToJoin);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var currUsername = GetUsernameId();
            var currId = id;

            if (currUsername == null)
            {
                return BadRequest();
            }

            var eventToLeave = dbContext
                .EventsParticipants
                .FirstOrDefault(ep => ep.HelperId == currUsername && ep.EventId == currId);

            if (eventToLeave == null)
            {
                return BadRequest();
            }

            dbContext.EventsParticipants.Remove(eventToLeave);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        protected string GetUsernameId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
        protected async Task<IEnumerable<TypeFormViewModel>> GetTypes()
        {
            var entity = await dbContext
                .Types
                .AsNoTracking()
                .Select(e => new TypeFormViewModel()
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToListAsync();

            return entity;
        }
    }
}
