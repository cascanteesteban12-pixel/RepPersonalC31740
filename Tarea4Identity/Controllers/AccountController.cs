using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tarea4.Models;
using Tarea4.ViewModels;

namespace Tarea4.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                NombreCompleto = model.Nombre
            };

            var result = await _userManager.CreateAsync(
                user,
                model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction(
                    "Index",
                    "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    "",
                    error.Description);
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result =
                await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    false,
                    false);

            if (result.Succeeded)
            {
                
            {
            await _userManager.AddToRoleAsync(
                user,
                "User");

            await _signInManager.SignInAsync(
                user,
                false);

            return RedirectToAction(
                "Index",
                "Home");
            }
                
            }

            ModelState.AddModelError(
                "",
                "Correo o contraseña incorrectos");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(
                "Login");
        }
    }
}