using System.Diagnostics;
using Find_A_Home.Data;
using Find_A_Home.Models;
using Find_A_Home.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Find_A_Home.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var featuredProperties = await context.Properties
                .OrderByDescending(p => p.Id)
                .Take(6)
                .ToListAsync();

            var provinces = await context.Provinces
                .OrderBy(p => p.Id)
                .ToListAsync();

            var viewModel = new HomeViewModel
            {
                FeaturedProperties = featuredProperties,
                Provinces = provinces
            };

            return View(viewModel);

        }

        [HttpGet]
        public async Task<IActionResult> GetZonesByProvince(int provinceId)
        {
            var zones = await context.Zones 
                .Where(z => z.ProvinceId == provinceId)
                .OrderBy(z=> z.Name)
                .Select(z=> new {
                    z.Id,
                    z.Name
                })
                .ToListAsync();

            return Json(zones);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
