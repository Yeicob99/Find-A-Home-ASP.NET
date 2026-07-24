using Find_A_Home.Data;
using Find_A_Home.Models;
using Find_A_Home.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Find_A_Home.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public PropertiesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public async Task<IActionResult> Index(PropertyFilterViewModel filters)
        {
            var query = context.Properties.AsQueryable();

            if (filters.ZoneId.HasValue)
            {
                query = query.Where(p => p.ZoneId == filters.ZoneId.Value);
            }

            if (!string.IsNullOrWhiteSpace(filters.PropertyType))
            {
                query = query.Where(p => p.PropertyType == filters.PropertyType);
            }

            if (filters.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filters.MinPrice.Value);
            }

            if (filters.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filters.MaxPrice.Value);
            }

            var properties = await query.ToListAsync();
            return View(properties);

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Property property)
        {
            if (!ModelState.IsValid)
            {
                return View(property);
            }

            if (property.ImageFile is not null && property.ImageFile.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

                var extension = Path.GetExtension(property.ImageFile.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageFile", "Invalid file type. Only JPG, JPEG, and PNG are allowed.");
                    return View(property);
                }
                var uploadsFolder = Path.Combine(environment.WebRootPath, "images", "properties");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = $"{Guid.NewGuid()}{extension}";

                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    await property.ImageFile.CopyToAsync(fileStream);
                }
                property.ImageUrl = $"/images/properties/{fileName}";
            }
            context.Properties.Add(property);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return (NotFound());
            }

            var property = await context.Properties.FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var property = await context.Properties.FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var property = await context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            context.Properties.Remove(property);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var property = await context.Properties.FindAsync(id);

            if (property is null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Property property)
        {
            if (id != property.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(property);
            }
            var existingProperty = await context.Properties.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            if (existingProperty is null)
            {
                return NotFound();
            }
                
            property.ImageUrl = existingProperty.ImageUrl;

            if (property.ImageFile is not null && property.ImageFile.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

                var extension = Path.GetExtension(property.ImageFile.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageFile", "Invalid file type. Only JPG, JPEG, and PNG are allowed.");
                    return View(property);
                }
                var uploadsFolder = Path.Combine(environment.WebRootPath, "images", "properties");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = $"{Guid.NewGuid()}{extension}";

                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    await property.ImageFile.CopyToAsync(fileStream);
                }
                property.ImageUrl = $"/images/properties/{fileName}";
            }


            context.Properties.Update(property);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = property.Id });
        }
    }
}
