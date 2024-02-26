using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models.AdViewModels;
using SoftUniBazar.Models.CategoryViewModel;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        protected readonly BazarDbContext dbContext;

        public AdController(BazarDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
               var entity =  await dbContext.Ads
                .AsNoTracking()
                .Select(e => new AdInfoViewModel(
                    e.Id,
                    e.Name,
                    e.Description,
                    e.Price,
                    e.Owner,
                    e.ImageUrl,
                    e.CreatedOn,
                    e.Category
                    ))
                .ToListAsync(); 

            return View(entity);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AdFormViewModel()
            {
                Categories = GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel model)
        {
            if (!GetCategories().Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
             {
                var rmodel = new AdFormViewModel()
                { 
                    Categories = GetCategories()
                }; 

                return View(rmodel);
            }

            var entity = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                CreatedOn = DateTime.Now,
                OwnerId = GetUserName()
            };

            await dbContext.Ads.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var model = await dbContext.Ads.FindAsync(Id);

            if (model == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserName();

            if (currentUserId != model.OwnerId)
            {
                return Unauthorized();
            }

            var entity = new AdFormViewModel()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                Categories = GetCategories()
            };

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id, AdFormViewModel model)
        {
            var currEditedModel = await dbContext.Ads.FindAsync(Id);
            if (currEditedModel == null)
            {
                return BadRequest();
            }

            var ownerModel = GetUserName();
            if (ownerModel != currEditedModel.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetCategories().Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            currEditedModel.Name = model.Name;
            currEditedModel.Description = model.Description;
            currEditedModel.Price = model.Price;
            currEditedModel.ImageUrl = model.ImageUrl;
            currEditedModel.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }
        public async Task<IActionResult> Cart()
        {
            var currUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userAds = await dbContext.AdBuyers
                .Where(ab => ab.BuyerId == currUser)
                 .Select(ab => new AdInfoViewModel(
                    ab.Ad.Id,
                    ab.Ad.Name,
                    ab.Ad.Description,
                    ab.Ad.Price,
                    ab.Ad.Owner,
                    ab.Ad.ImageUrl,
                    ab.Ad.CreatedOn,
                    ab.Ad.Category
                    ))
                .ToListAsync();

            return View(userAds);
        }
        public async Task<IActionResult> AddToCart(int Id)
        {
            var adToBeAdd = await dbContext.Ads.FindAsync(Id);

            if (adToBeAdd == null)
            {
                BadRequest();
            }

            var currUser = GetUserName();

            var entity = new AdBuyer()
            {
                AdId = adToBeAdd.Id,
                BuyerId = currUser
            };

            if (await dbContext.AdBuyers.ContainsAsync(entity))
            {
                return RedirectToAction(nameof(Cart));
            }

            await dbContext.AdBuyers.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }
        public async Task<IActionResult> RemoveFromCart(int Id)
        {
            var currAdId = Id;
            var currentUser = GetUserName();

            var adToRemove = dbContext.Ads.FindAsync(currAdId);

            if (adToRemove == null)
            {
                return BadRequest();
            }

            var entity = await dbContext.AdBuyers.FirstOrDefaultAsync(ab => ab.BuyerId == currentUser && ab.AdId == currAdId);

            dbContext.AdBuyers.Remove(entity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        private IEnumerable<CategoryFormModel> GetCategories()
          => dbContext
              .Categories
              .Select(t => new CategoryFormModel()
              {
                  Id = t.Id,
                  Name = t.Name
              });

        private string GetUserName()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
