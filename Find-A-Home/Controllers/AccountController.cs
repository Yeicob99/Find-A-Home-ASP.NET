using System.Threading.Tasks;
using Find_A_Home.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Find_A_Home.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var existingUser = await userManager.FindByNameAsync(vm.Username);
            if (existingUser is not null)
            {
                ModelState.AddModelError(nameof(vm.Username),
                    "Ese nombre de usuario ya está en uso.");
                return View(vm);
            }

            var existingMail = await userManager.FindByEmailAsync(vm.Email);
            if (existingMail is not null)
            {
                ModelState.AddModelError(nameof(vm.Email),
                    "Ese correo electrónico ya está en uso.");
                return View(vm);
            }

            var user = new IdentityUser
            {
                UserName = vm.Username,
                Email = vm.Email
            };

            var result = await userManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    nameof(vm.Password),
                    error.Description
                );
            }
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }   
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}