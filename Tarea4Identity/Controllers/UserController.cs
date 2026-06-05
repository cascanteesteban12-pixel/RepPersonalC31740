using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tarea4.Models;

namespace Tarea4.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();

            return View(users);
        }

        public async Task<IActionResult> CambiarEstado(string id)
        {
            var user =
                await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            user.Activo = !user.Activo;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user =
                await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}