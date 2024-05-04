using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTry.Models;

namespace WebApplicationTry.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> BlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.IsBlocked = true; 
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UnblockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.IsBlocked = false; 
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UserAction(string[] selectedUsers, string action)
        {
            foreach (var userId in selectedUsers)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    switch (action)
                    {
                        case "Block":
                            user.IsBlocked = true;
                            break;
                        case "Unblock":
                            user.IsBlocked = false;
                            break;
                        case "Delete":
                            await _userManager.DeleteAsync(user);
                            continue;
                    }
                    await _userManager.UpdateAsync(user);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
