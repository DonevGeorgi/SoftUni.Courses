using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.ViewModels.CategoryViewModels;
using SeminarHub.Models.ViewModels.SeminarViewModels;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        protected readonly SeminarHubDbContext dbContext;

        public SeminarController(SeminarHubDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var seminars = await dbContext
                .Seminars
                .AsNoTracking()
                .Select(s => new SeminarInfoViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Category,
                    s.DateAndTime,
                    s.Organizer
                    ))
                .ToListAsync();

            return View(seminars);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var entity = new SeminarFormViewModel()
            {
                Categories = await GetCategories()
            };

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel modelToAdd)
        {
            if (!ModelState.IsValid)
            {
                modelToAdd.Categories = await GetCategories();

                return View(modelToAdd);
            }

            var categories = await GetCategories();

            if (!categories.Any(c => c.Id == modelToAdd.CategoryId))
            {
                ModelState.AddModelError(nameof(modelToAdd.CategoryId), "Category does not exist!");
            }

            DateTime dateAndTime;

            bool isDateAndTimeValid = DateTime.TryParseExact(modelToAdd.DateAndTime, DataConstants.DataFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime);

            if (!isDateAndTimeValid)
            {
                ModelState
                   .AddModelError(nameof(modelToAdd.DateAndTime), $"Invalid date! Format must be: {DataConstants.DataFormat}");
            }

            var newSeminar = new Seminar()
            {
                Topic = modelToAdd.Topic,
                Lecturer = modelToAdd.Lecturer,
                Details = modelToAdd.Details,
                OrganizerId = GetUserId(),
                DateAndTime = dateAndTime,
                Duration = modelToAdd.Duration,
                CategoryId = modelToAdd.CategoryId,
            };

            await dbContext.Seminars.AddAsync(newSeminar);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminarToEdit = await dbContext.Seminars.FindAsync(id);

            if (seminarToEdit == null)
            {
                return BadRequest();
            }

            var currUser = GetUserId();

            if (currUser != seminarToEdit.OrganizerId)
            {
                return Unauthorized();
            }

            var currSeminar = new SeminarFormViewModel()
            {
                Topic = seminarToEdit.Topic,
                Lecturer = seminarToEdit.Lecturer,
                Details = seminarToEdit.Details,
                DateAndTime = seminarToEdit.DateAndTime.ToString(DataConstants.DataFormat),
                Duration = seminarToEdit.Duration,
                CategoryId = seminarToEdit.CategoryId
            };

            currSeminar.Categories = await GetCategories();

            return View(currSeminar);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,SeminarFormViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                newModel.Categories = await GetCategories();

                return View(newModel);
            }

            var modelToBeEdited = await dbContext.Seminars.FindAsync(id);

            if (modelToBeEdited == null)
            {
                return BadRequest();
            }

            var currUser = GetUserId();

            if (currUser == null)
            {
                return Unauthorized();
            }

            DateTime dateAndTime;

            bool isDateAndTimeValid = DateTime.TryParseExact(newModel.DateAndTime, DataConstants.DataFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime);

            if (!isDateAndTimeValid)
            {
                ModelState
                   .AddModelError(nameof(newModel.DateAndTime), $"Invalid date! Format must be: {DataConstants.DataFormat}");
            }

            modelToBeEdited.Topic = newModel.Topic;
            modelToBeEdited.Lecturer = newModel.Lecturer;
            modelToBeEdited.Details = newModel.Details;
            modelToBeEdited.DateAndTime = dateAndTime;
            modelToBeEdited.Duration = newModel.Duration;
            modelToBeEdited.CategoryId = newModel.CategoryId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var currUser = GetUserId();

            var currCollection = await dbContext
                .SeminarsParticipants
                .AsNoTracking()
                .Where(sp => sp.ParticipantId == currUser)
                .Select(sp => new SeminarInfoViewModel(
                    sp.Seminar.Id,
                    sp.Seminar.Topic,
                    sp.Seminar.Lecturer,
                    sp.Seminar.Category,
                    sp.Seminar.DateAndTime,
                    sp.Seminar.Organizer
                    ))
                .ToListAsync();

            return View(currCollection);
        }
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var seminarToJoin = await dbContext.Seminars.FindAsync(id);

            if (seminarToJoin == null)
            {
                return BadRequest();
            }

            var currUser = GetUserId();

            if (currUser == null)
            {
                return Unauthorized();
            }

            var newSeminarParticipant = new SeminarParticipant()
            {
                SeminarId = seminarToJoin.Id,
                ParticipantId = currUser
            };

            if (await dbContext.SeminarsParticipants.ContainsAsync(newSeminarParticipant))
            {
                return RedirectToAction(nameof(All));
            }

            await dbContext.SeminarsParticipants.AddAsync(newSeminarParticipant);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var currSeminarToLeave = await dbContext.Seminars.FindAsync(id);

            if (currSeminarToLeave == null)
            {
                return BadRequest();
            }

            var currUser = GetUserId();

            var seminar = await dbContext
                .SeminarsParticipants
                .FirstOrDefaultAsync(sp => sp.SeminarId == currSeminarToLeave.Id &&
                sp.ParticipantId == currUser);

            if(seminar == null)
            {
                return BadRequest();
            }

            dbContext.SeminarsParticipants .Remove(seminar);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var seminarDetails = await dbContext
                .Seminars
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SeminarDetailsViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Details,
                    s.Category,
                    s.DateAndTime,
                    s.Duration,
                    s.Organizer
                    ))
                .FirstOrDefaultAsync();

            return View(seminarDetails);  
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminarToDelete = await dbContext
                .Seminars
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SeminarDeleteViewModel
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime
                })
                .FirstOrDefaultAsync();

            return View(seminarToDelete);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currSeminarToDelete = await dbContext.Seminars.FindAsync(id);

            if (currSeminarToDelete == null)
            {
                return BadRequest();
            }

            var currUser = GetUserId();

            var seminarForDeleting = await dbContext
                .Seminars
                .Where(s => s.OrganizerId == currUser &&
                s.Id == currSeminarToDelete.Id)
                .FirstOrDefaultAsync();

            dbContext.Seminars.Remove(currSeminarToDelete);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
        protected async Task<List<CategoryInfoViewModel>> GetCategories()
        {
            var categories = await dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new CategoryInfoViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }
    }
}
